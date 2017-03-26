namespace RubiksCubeSimulator.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonUndoChanges = new System.Windows.Forms.Button();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labellErrorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkBoxLockColors = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonCleanSlate = new System.Windows.Forms.Button();
            this.cubeUp = new RubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeBack = new RubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeFront = new RubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeDown = new RubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeRight = new RubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.cubeLeft = new RubiksCubeSimulator.Forms.CubeFaceDisplay();
            this.colorStrip = new RubiksCubeSimulator.Forms.ColorStrip();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            label7 = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(15, 17);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(71, 17);
            label7.TabIndex = 18;
            label7.Text = "Command";
            // 
            // buttonUndoChanges
            // 
            this.buttonUndoChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUndoChanges.Location = new System.Drawing.Point(454, 11);
            this.buttonUndoChanges.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUndoChanges.Name = "buttonUndoChanges";
            this.buttonUndoChanges.Size = new System.Drawing.Size(166, 28);
            this.buttonUndoChanges.TabIndex = 16;
            this.buttonUndoChanges.Text = "Undo All Changes";
            this.toolTip.SetToolTip(this.buttonUndoChanges, "Undo all changes made since the application has started.");
            this.buttonUndoChanges.UseVisualStyleBackColor = true;
            this.buttonUndoChanges.Click += new System.EventHandler(this.buttonUndoChanges_Click);
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.AcceptsReturn = true;
            this.textBoxCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommand.Location = new System.Drawing.Point(92, 14);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(216, 22);
            this.textBoxCommand.TabIndex = 17;
            this.toolTip.SetToolTip(this.textBoxCommand, "Space-separated algorithms.");
            this.textBoxCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCommand_KeyDown);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.labellErrorStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 550);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip.Size = new System.Drawing.Size(634, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // labellErrorStatus
            // 
            this.labellErrorStatus.Name = "labellErrorStatus";
            this.labellErrorStatus.Size = new System.Drawing.Size(621, 17);
            this.labellErrorStatus.Spring = true;
            this.labellErrorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // checkBoxLockColors
            // 
            this.checkBoxLockColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLockColors.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxLockColors.BackgroundImage = global::RubiksCubeSimulator.Properties.Resources.Lock;
            this.checkBoxLockColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkBoxLockColors.Location = new System.Drawing.Point(545, 497);
            this.checkBoxLockColors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxLockColors.Name = "checkBoxLockColors";
            this.checkBoxLockColors.Size = new System.Drawing.Size(75, 38);
            this.checkBoxLockColors.TabIndex = 20;
            this.checkBoxLockColors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxLockColors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.checkBoxLockColors, "When checked, colors can not be configured\r\nand rotation can be done with the lef" +
        "t and right mouse.");
            this.checkBoxLockColors.UseVisualStyleBackColor = true;
            this.checkBoxLockColors.CheckedChanged += new System.EventHandler(this.checkBoxLockColors_CheckedChanged);
            // 
            // buttonCleanSlate
            // 
            this.buttonCleanSlate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCleanSlate.Location = new System.Drawing.Point(314, 12);
            this.buttonCleanSlate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCleanSlate.Name = "buttonCleanSlate";
            this.buttonCleanSlate.Size = new System.Drawing.Size(134, 28);
            this.buttonCleanSlate.TabIndex = 23;
            this.buttonCleanSlate.Text = "Clean Slate";
            this.toolTip.SetToolTip(this.buttonCleanSlate, "Start from a solved, or unmixed cube.");
            this.buttonCleanSlate.UseVisualStyleBackColor = true;
            this.buttonCleanSlate.Click += new System.EventHandler(this.buttonCleanSlate_Click);
            // 
            // cubeUp
            // 
            this.cubeUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeUp.Face = RubiksCubeSimulator.Rubiks.CubeSide.Up;
            this.cubeUp.Location = new System.Drawing.Point(155, 3);
            this.cubeUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeUp.Name = "cubeUp";
            this.cubeUp.NewColor = System.Drawing.Color.Empty;
            this.cubeUp.Size = new System.Drawing.Size(144, 143);
            this.cubeUp.TabIndex = 9;
            this.cubeUp.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeUp, "Top Face");
            this.cubeUp.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Forms.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeBack
            // 
            this.cubeBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeBack.Face = RubiksCubeSimulator.Rubiks.CubeSide.Back;
            this.cubeBack.Location = new System.Drawing.Point(457, 151);
            this.cubeBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeBack.Name = "cubeBack";
            this.cubeBack.NewColor = System.Drawing.Color.Empty;
            this.cubeBack.Size = new System.Drawing.Size(144, 143);
            this.cubeBack.TabIndex = 3;
            this.cubeBack.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeBack, "Back Face");
            this.cubeBack.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Forms.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeFront
            // 
            this.cubeFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeFront.Face = RubiksCubeSimulator.Rubiks.CubeSide.Front;
            this.cubeFront.Location = new System.Drawing.Point(155, 151);
            this.cubeFront.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeFront.Name = "cubeFront";
            this.cubeFront.NewColor = System.Drawing.Color.Empty;
            this.cubeFront.Size = new System.Drawing.Size(144, 143);
            this.cubeFront.TabIndex = 0;
            this.cubeFront.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeFront, "Front Face");
            this.cubeFront.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Forms.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeDown
            // 
            this.cubeDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeDown.Face = RubiksCubeSimulator.Rubiks.CubeSide.Down;
            this.cubeDown.Location = new System.Drawing.Point(155, 299);
            this.cubeDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeDown.Name = "cubeDown";
            this.cubeDown.NewColor = System.Drawing.Color.Empty;
            this.cubeDown.Size = new System.Drawing.Size(144, 143);
            this.cubeDown.TabIndex = 11;
            this.cubeDown.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeDown, "Bottom Face");
            this.cubeDown.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Forms.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeRight
            // 
            this.cubeRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeRight.Face = RubiksCubeSimulator.Rubiks.CubeSide.Right;
            this.cubeRight.Location = new System.Drawing.Point(306, 151);
            this.cubeRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeRight.Name = "cubeRight";
            this.cubeRight.NewColor = System.Drawing.Color.Empty;
            this.cubeRight.Size = new System.Drawing.Size(144, 143);
            this.cubeRight.TabIndex = 5;
            this.cubeRight.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeRight, "Right Face");
            this.cubeRight.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Forms.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeLeft
            // 
            this.cubeLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeLeft.Face = RubiksCubeSimulator.Rubiks.CubeSide.Left;
            this.cubeLeft.Location = new System.Drawing.Point(4, 151);
            this.cubeLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cubeLeft.Name = "cubeLeft";
            this.cubeLeft.NewColor = System.Drawing.Color.Empty;
            this.cubeLeft.Size = new System.Drawing.Size(144, 143);
            this.cubeLeft.TabIndex = 7;
            this.cubeLeft.Text = "colorGridDisplay1";
            this.toolTip.SetToolTip(this.cubeLeft, "Left Face");
            this.cubeLeft.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Forms.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // colorStrip
            // 
            this.colorStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorStrip.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))))};
            this.colorStrip.Location = new System.Drawing.Point(15, 497);
            this.colorStrip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorStrip.Name = "colorStrip";
            this.colorStrip.Size = new System.Drawing.Size(525, 38);
            this.colorStrip.TabIndex = 15;
            this.colorStrip.Text = "colorStrip1";
            this.toolTip.SetToolTip(this.colorStrip, "Pick a color to set the cubes with.");
            this.colorStrip.SelectedIndexChanged += new System.EventHandler(this.colorStrip_SelectedIndexChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.cubeUp, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.cubeBack, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.cubeFront, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.cubeDown, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.cubeRight, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.cubeLeft, 0, 1);
            this.tableLayoutPanel.Location = new System.Drawing.Point(16, 46);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(605, 445);
            this.tableLayoutPanel.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 572);
            this.Controls.Add(this.buttonCleanSlate);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.checkBoxLockColors);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(label7);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.buttonUndoChanges);
            this.Controls.Add(this.colorStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Rubiks Cube Simulator";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CubeFaceDisplay cubeFront;
        private CubeFaceDisplay cubeBack;
        private CubeFaceDisplay cubeLeft;
        private CubeFaceDisplay cubeRight;
        private CubeFaceDisplay cubeDown;
        private ColorStrip colorStrip;
        private System.Windows.Forms.Button buttonUndoChanges;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel labellErrorStatus;
        private System.Windows.Forms.CheckBox checkBoxLockColors;
        private System.Windows.Forms.ToolTip toolTip;
        private CubeFaceDisplay cubeUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Button buttonCleanSlate;
    }
}

