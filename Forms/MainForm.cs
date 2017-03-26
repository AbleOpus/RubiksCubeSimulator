using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RubiksCubeSimulator.Rubiks;

namespace RubiksCubeSimulator.Forms
{
    public partial class MainForm : Form
    {
        private RubiksCube rubiksCube;

        /// <summary>
        /// Gets all of the cube displays on the form.
        /// </summary>
        private IEnumerable<CubeFaceDisplay> CubeDisplays => 
            tableLayoutPanel.Controls.OfType<CubeFaceDisplay>();

        public MainForm()
        {
            InitializeComponent();
            ResizeRedraw = true;

            checkBoxLockColors.DataBindings.Add("Checked", 
                Settings.Instance, nameof(Settings.Instance.ColorsLocked));

            colorStrip.Colors = Settings.Instance.Palette;
            SetRubiksCube();
            SetHoverEffect();
            UpdateErrorStatus();
        }

        private void SetRubiksCube()
        {
            // Restore cube from settings
             rubiksCube = new RubiksCube(Settings.Instance.CubeColors);

            // Create a solved cube with the developers color scheme
            //rubiksCube = RubiksCube.Create(CubeColorScheme.DevsScheme);

            rubiksCube.MoveMade += RubiksCubeMoveMade;
            UpdateDisplayedCube();
        }

        private void UpdateErrorStatus()
        {
            var defects = rubiksCube.GetColorDefects();
            labellErrorStatus.Text = defects.GetShortReport();
        }

        private void SetHoverEffect()
        {
            foreach (var display in CubeDisplays)
            {
                if (checkBoxLockColors.Checked)
                    display.ClickMode = ClickMode.Rotation;
                else if (colorStrip.HasSelection)
                    display.ClickMode = ClickMode.ColorSet;
                else
                    display.ClickMode = ClickMode.None;
            }
        }

        private void UpdateDisplayedCube()
        {
            foreach (var display in CubeDisplays)
                display.RubiksCube = rubiksCube;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Instance.Palette = colorStrip.Colors;
            Settings.Instance.CubeColors = rubiksCube.AllColors;
            Settings.Instance.Save();
            base.OnClosing(e);
        }

        private static DialogResult ShowQuestionPrompt(string message)
        {
            return MessageBox.Show(message, Application.ProductName,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void buttonCleanSlate_Click(object sender, EventArgs e)
        {
            if (ShowQuestionPrompt("Are you sure you want to undo changes?") == DialogResult.Yes)
            {
                labellErrorStatus.Text = string.Empty;
                rubiksCube.CleanSlate();
                tableLayoutPanel.Invalidate(true);
            }
        }

        private void buttonUndoChanges_Click(object sender, EventArgs e)
        {
            if (ShowQuestionPrompt("Are you sure you want to undo changes?") == DialogResult.Yes)
            {
                labellErrorStatus.Text = string.Empty;
                rubiksCube.Restore();
                tableLayoutPanel.Invalidate(true);
            }
        }

        private void textBoxCommand_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxCommand.BackColor = Color.FromKnownColor(KnownColor.Window);
            if (e.KeyCode != Keys.Enter) return;
            string lower = textBoxCommand.Text;
            if (lower == "clean slate") rubiksCube.CleanSlate();
            string[] splitted = textBoxCommand.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var moveList = new List<CubeMove>();

            foreach (string str in splitted)
            {
                try
                {
                    moveList.Add(new CubeMove(str));
                }
                catch (ArgumentException)
                {
                    textBoxCommand.BackColor = Color.LightPink;
                    return; // Invalid input
                }
            }

            foreach (var move in moveList)
            {
                lblStatus.Text = "Last Move: " + move;
                rubiksCube.MakeMove(move);
            }

            e.SuppressKeyPress = true;
            textBoxCommand.Clear();
            tableLayoutPanel.Invalidate();
        }

        private void checkBoxLockColors_CheckedChanged(object sender, EventArgs e)
        {
            SetHoverEffect();
            colorStrip.Enabled = !checkBoxLockColors.Checked;
        }

        private void colorStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHoverEffect();

            foreach (var display in CubeDisplays)
                display.NewColor = colorStrip.SelectedColor;
        }

        private void cubeDisplay_CellMouseClicked(object sender, CellMouseClickedEventArgs e)
        {
            UpdateErrorStatus();
        }

        private void RubiksCubeMoveMade(object sender, CubeMove move)
        {
            if (rubiksCube.Solved)
            {
                lblStatus.Text = "Cube Solved";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                lblStatus.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                lblStatus.Text = "Last Move: " + move;
            }
        }
    }
}
