using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RubiksCubeSimulator.Rubiks;
using System.Collections.Generic;
using System.Linq;

namespace RubiksCubeSimulator.Views
{
    public partial class MainForm : Form
    {
        private RubiksCube _rubiksCube;

        /// <summary>
        /// Gets all of the cube displays on the form
        /// </summary>
        private IEnumerable<CubeFaceDisplay> CubeDisplays
        {
            get { return tableLayoutPanel.Controls.OfType<CubeFaceDisplay>(); }
        }

        public MainForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
            chkLockColors.DataBindings.Add("Checked", Settings.Instance, "ColorsLocked");
            colorStrip.Colors = Settings.Instance.Palette;
            SetRubiksCube();
            SetHoverEffect();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Color borderColor = Color.FromKnownColor(KnownColor.ActiveBorder);
            e.Graphics.DrawRectangle(new Pen(borderColor), 
                tableLayoutPanel.Left - 1, 
                tableLayoutPanel.Top - 1,
                tableLayoutPanel.Width +2, 
                tableLayoutPanel.Height + 2);
        }

        private void SetRubiksCube()
        {
            Settings.Instance.Clear();
            _rubiksCube = new RubiksCube(Settings.Instance.CubeColors);
            // _rubiksCube = RubiksCube.Create(CubeColorScheme.DevsScheme);
            //_rubiksCube = CreateScrambledCube();
            Debug.WriteLine(_rubiksCube.Solved);
            _rubiksCube.MoveMade += RubiksCubeMoveMade;

            foreach (var display in CubeDisplays)
                display.RubiksCube = _rubiksCube;

            UpdateDisplayedCube();
        }

        private void SetHoverEffect()
        {
            foreach (var display in CubeDisplays)
            {
                if (chkLockColors.Checked)
                    display.ClickMode = ClickMode.Rotation;
                else if (colorStrip.HasSelection)
                    display.ClickMode = ClickMode.ColorSet;
                else
                    display.ClickMode = ClickMode.None;
            }
        }

        private static RubiksCube CreateScrambledCube()
        {
            var colors = new[]
            {
            new[,] // Front face
            {
               {Color.White, Color.White, Color.White},
               {Color.White, Color.White, Color.White},
               {Color.White, Color.White, Color.White}
            },
             new[,] // Back face
            {
               {Color.Yellow, Color.Green, Color.Yellow},
               {Color.Red, Color.Yellow, Color.Blue},
               {Color.Red, Color.Yellow, Color.Red}
            },
            new[,] // Right face
            {
               {Color.Green, Color.Blue, Color.Orange},
               {Color.Green, Color.Blue, Color.Yellow},
               {Color.Green, Color.Green, Color.Green}
            },
            new[,] // Left face
            {
               {Color.Orange, Color.Orange, Color.Blue},
               {Color.Red, Color.Green, Color.Orange},
               {Color.Blue, Color.Green, Color.Blue}
            },

            new[,] // Up face
            {
               {Color.Blue, Color.Yellow, Color.Green},
               {Color.Blue, Color.Orange, Color.Yellow},
               {Color.Red, Color.Blue, Color.Red}
            },
            new[,] // Down face
            {
               {Color.Orange, Color.Red, Color.Orange},
               {Color.Red, Color.Red, Color.Orange},
               {Color.Yellow, Color.Orange, Color.Yellow}
            }
            };

            return new RubiksCube(colors);
        }

        private void UpdateDisplayedCube()
        {
            foreach (var display in CubeDisplays)
                display.RubiksCube = _rubiksCube;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Instance.Palette = colorStrip.Colors;
            Settings.Instance.CubeColors = _rubiksCube.AllColors;
            Settings.Instance.Save();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            const string MSG = "Are you sure you want to reset?";

            if (MessageBox.Show(MSG, Application.ProductName, MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                return;
            }

            lblErrorStatus.Text = string.Empty;
            _rubiksCube.Restore();
            tableLayoutPanel.Invalidate();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            txtCommand.BackColor = Color.FromKnownColor(KnownColor.Window);
            if (e.KeyCode != Keys.Enter) return;
            string lower = txtCommand.Text;
            if (lower == "clean slate") _rubiksCube.CleanSlate();
            string[] splitted = txtCommand.Text.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var moveList = new List<CubeMove>();

            foreach (string str in splitted)
            {
                try
                {
                    moveList.Add(new CubeMove(str));
                }
                catch (ArgumentException)
                {
                    txtCommand.BackColor = Color.LightPink;
                    return; // Invalid input
                }
            }

            foreach (var move in moveList)
            {
                lblStatus.Text = "Last Move: " + move;
                _rubiksCube.MakeMove(move);
            }

            e.SuppressKeyPress = true;
            txtCommand.Clear();
            tableLayoutPanel.Invalidate();
        }

        private void chkLockColors_CheckedChanged(object sender, EventArgs e)
        {
            SetHoverEffect();
            colorStrip.Enabled = !chkLockColors.Checked;
        }

        private void colorStrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetHoverEffect();

            foreach (var display in CubeDisplays)
                display.NewColor = colorStrip.SelectedColor;
        }

        private void cubeDisplay_CellMouseClicked(object sender, CellMouseClickedEventArgs e)
        {
            var defects = _rubiksCube.GetColorDefects();

            // There are too many instances of certain colors
            if (defects.Type.HasFlag(ColorDefectType.TooMany))
            {
                var SB = new StringBuilder();
                SB.Append("There is too much of: ");

                foreach (Color color in defects.Colors)
                    SB.Append(color.Name + ", ");

                SB.Remove(SB.Length - 2, 2);
                lblErrorStatus.Text = SB.ToString();
            }
            // There are too many distinct colors
            else if (defects.Type.HasFlag(ColorDefectType.TooManyDistinct))
            {
                lblErrorStatus.Text = "There are too many distinct colors";
            }
        }

        private void RubiksCubeMoveMade(object sender, CubeMove move)
        {
            if (_rubiksCube.Solved)
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
