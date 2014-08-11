namespace RubiksCubeSimulator.Views
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnReset = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblErrorStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkLockColors = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cubeUp = new RubiksCubeSimulator.Views.CubeFaceDisplay();
            this.cubeBack = new RubiksCubeSimulator.Views.CubeFaceDisplay();
            this.cubeFront = new RubiksCubeSimulator.Views.CubeFaceDisplay();
            this.cubeDown = new RubiksCubeSimulator.Views.CubeFaceDisplay();
            this.cubeRight = new RubiksCubeSimulator.Views.CubeFaceDisplay();
            this.cubeLeft = new RubiksCubeSimulator.Views.CubeFaceDisplay();
            this.colorStrip = new RubiksCubeSimulator.Views.ColorStrip();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(524, 11);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.AcceptsReturn = true;
            this.txtCommand.Location = new System.Drawing.Point(69, 11);
            this.txtCommand.Margin = new System.Windows.Forms.Padding(2);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(173, 20);
            this.txtCommand.TabIndex = 17;
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 14);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Command";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblErrorStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 521);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip.Size = new System.Drawing.Size(610, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblErrorStatus
            // 
            this.lblErrorStatus.Name = "lblErrorStatus";
            this.lblErrorStatus.Size = new System.Drawing.Size(600, 17);
            this.lblErrorStatus.Spring = true;
            this.lblErrorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkLockColors
            // 
            this.chkLockColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLockColors.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkLockColors.BackgroundImage = global::RubiksCubeSimulator.Properties.Resources.Lock;
            this.chkLockColors.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkLockColors.Location = new System.Drawing.Point(543, 482);
            this.chkLockColors.Margin = new System.Windows.Forms.Padding(2);
            this.chkLockColors.Name = "chkLockColors";
            this.chkLockColors.Size = new System.Drawing.Size(56, 31);
            this.chkLockColors.TabIndex = 20;
            this.chkLockColors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLockColors.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip.SetToolTip(this.chkLockColors, "When checked, colors can not be configured\r\nand rotation can be done with the lef" +
        "t and right mouse");
            this.chkLockColors.UseVisualStyleBackColor = true;
            this.chkLockColors.CheckedChanged += new System.EventHandler(this.chkLockColors_CheckedChanged);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 37);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(586, 437);
            this.tableLayoutPanel.TabIndex = 22;
            // 
            // cubeUp
            // 
            this.cubeUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeUp.Face = RubiksCubeSimulator.Rubiks.CubeSide.Up;
            this.cubeUp.Location = new System.Drawing.Point(148, 2);
            this.cubeUp.Margin = new System.Windows.Forms.Padding(2);
            this.cubeUp.Name = "cubeUp";
            this.cubeUp.NewColor = System.Drawing.Color.Empty;
            this.cubeUp.Size = new System.Drawing.Size(142, 141);
            this.cubeUp.TabIndex = 9;
            this.cubeUp.Text = "colorGridDisplay1";
            this.cubeUp.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Views.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeBack
            // 
            this.cubeBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeBack.Face = RubiksCubeSimulator.Rubiks.CubeSide.Back;
            this.cubeBack.Location = new System.Drawing.Point(440, 147);
            this.cubeBack.Margin = new System.Windows.Forms.Padding(2);
            this.cubeBack.Name = "cubeBack";
            this.cubeBack.NewColor = System.Drawing.Color.Empty;
            this.cubeBack.Size = new System.Drawing.Size(144, 141);
            this.cubeBack.TabIndex = 3;
            this.cubeBack.Text = "colorGridDisplay1";
            this.cubeBack.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Views.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeFront
            // 
            this.cubeFront.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeFront.Face = RubiksCubeSimulator.Rubiks.CubeSide.Front;
            this.cubeFront.Location = new System.Drawing.Point(148, 147);
            this.cubeFront.Margin = new System.Windows.Forms.Padding(2);
            this.cubeFront.Name = "cubeFront";
            this.cubeFront.NewColor = System.Drawing.Color.Empty;
            this.cubeFront.Size = new System.Drawing.Size(142, 141);
            this.cubeFront.TabIndex = 0;
            this.cubeFront.Text = "colorGridDisplay1";
            this.cubeFront.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Views.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeDown
            // 
            this.cubeDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeDown.Face = RubiksCubeSimulator.Rubiks.CubeSide.Down;
            this.cubeDown.Location = new System.Drawing.Point(148, 292);
            this.cubeDown.Margin = new System.Windows.Forms.Padding(2);
            this.cubeDown.Name = "cubeDown";
            this.cubeDown.NewColor = System.Drawing.Color.Empty;
            this.cubeDown.Size = new System.Drawing.Size(142, 143);
            this.cubeDown.TabIndex = 11;
            this.cubeDown.Text = "colorGridDisplay1";
            this.cubeDown.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Views.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeRight
            // 
            this.cubeRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeRight.Face = RubiksCubeSimulator.Rubiks.CubeSide.Right;
            this.cubeRight.Location = new System.Drawing.Point(294, 147);
            this.cubeRight.Margin = new System.Windows.Forms.Padding(2);
            this.cubeRight.Name = "cubeRight";
            this.cubeRight.NewColor = System.Drawing.Color.Empty;
            this.cubeRight.Size = new System.Drawing.Size(142, 141);
            this.cubeRight.TabIndex = 5;
            this.cubeRight.Text = "colorGridDisplay1";
            this.cubeRight.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Views.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // cubeLeft
            // 
            this.cubeLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cubeLeft.Face = RubiksCubeSimulator.Rubiks.CubeSide.Left;
            this.cubeLeft.Location = new System.Drawing.Point(2, 147);
            this.cubeLeft.Margin = new System.Windows.Forms.Padding(2);
            this.cubeLeft.Name = "cubeLeft";
            this.cubeLeft.NewColor = System.Drawing.Color.Empty;
            this.cubeLeft.Size = new System.Drawing.Size(142, 141);
            this.cubeLeft.TabIndex = 7;
            this.cubeLeft.Text = "colorGridDisplay1";
            this.cubeLeft.CellMouseClicked += new System.EventHandler<RubiksCubeSimulator.Views.CellMouseClickedEventArgs>(this.cubeDisplay_CellMouseClicked);
            // 
            // colorStrip
            // 
            this.colorStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorStrip.Colors = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))))};
            this.colorStrip.Location = new System.Drawing.Point(11, 482);
            this.colorStrip.Margin = new System.Windows.Forms.Padding(2);
            this.colorStrip.Name = "colorStrip";
            this.colorStrip.Size = new System.Drawing.Size(528, 31);
            this.colorStrip.TabIndex = 15;
            this.colorStrip.Text = "colorStrip1";
            this.colorStrip.SelectedIndexChanged += new System.EventHandler(this.colorStrip_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 543);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.chkLockColors);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.colorStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Rubiks Cube Solver";
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
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblErrorStatus;
        private System.Windows.Forms.CheckBox chkLockColors;
        private System.Windows.Forms.ToolTip toolTip;
        private CubeFaceDisplay cubeUp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;



    }
}

