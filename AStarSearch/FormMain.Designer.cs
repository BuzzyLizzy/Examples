namespace AStarSearch
{
    partial class FormMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMapSourceFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseMapSourceFile = new System.Windows.Forms.Button();
            this.textBoxPathResultFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonFindPath = new System.Windows.Forms.Button();
            this.checkBoxGenerateDebugOutputFile = new System.Windows.Forms.CheckBox();
            this.groupBoxMovementHeuristicSettings = new System.Windows.Forms.GroupBox();
            this.checkBoxAllowDiagonalMovement = new System.Windows.Forms.CheckBox();
            this.groupBoxHeuristicChoice = new System.Windows.Forms.GroupBox();
            this.radioButtonManhattan = new System.Windows.Forms.RadioButton();
            this.radioButtonChebyshev = new System.Windows.Forms.RadioButton();
            this.labelGoalInfo = new System.Windows.Forms.Label();
            this.groupBoxMovementHeuristicSettings.SuspendLayout();
            this.groupBoxHeuristicChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Map Source File Path";
            // 
            // textBoxMapSourceFile
            // 
            this.textBoxMapSourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMapSourceFile.Location = new System.Drawing.Point(165, 94);
            this.textBoxMapSourceFile.Name = "textBoxMapSourceFile";
            this.textBoxMapSourceFile.Size = new System.Drawing.Size(498, 23);
            this.textBoxMapSourceFile.TabIndex = 1;
            // 
            // buttonBrowseMapSourceFile
            // 
            this.buttonBrowseMapSourceFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBrowseMapSourceFile.Location = new System.Drawing.Point(669, 91);
            this.buttonBrowseMapSourceFile.Name = "buttonBrowseMapSourceFile";
            this.buttonBrowseMapSourceFile.Size = new System.Drawing.Size(101, 28);
            this.buttonBrowseMapSourceFile.TabIndex = 2;
            this.buttonBrowseMapSourceFile.Text = "Browse . . .";
            this.buttonBrowseMapSourceFile.UseVisualStyleBackColor = true;
            this.buttonBrowseMapSourceFile.Click += new System.EventHandler(this.buttonBrowseMapSourceFile_Click);
            // 
            // textBoxPathResultFile
            // 
            this.textBoxPathResultFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPathResultFile.Location = new System.Drawing.Point(165, 223);
            this.textBoxPathResultFile.Name = "textBoxPathResultFile";
            this.textBoxPathResultFile.Size = new System.Drawing.Size(201, 23);
            this.textBoxPathResultFile.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Path Result File Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(408, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Specify the full directory and File Name of the Source Map File.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(16, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(728, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Specify only the name of the Path Result File, it shall be stored in the same dir" +
    "ectory as the above Map Source File.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(16, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(480, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "The found path shall be indicated by the # character in the Path Result File.";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "txt";
            this.openFileDialog.FileName = "map";
            this.openFileDialog.Filter = "\"text files (*.txt)|*.txt|All files (*.*)|*.*\"";
            // 
            // buttonFindPath
            // 
            this.buttonFindPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindPath.Location = new System.Drawing.Point(320, 310);
            this.buttonFindPath.Name = "buttonFindPath";
            this.buttonFindPath.Size = new System.Drawing.Size(111, 28);
            this.buttonFindPath.TabIndex = 9;
            this.buttonFindPath.Text = "Find Path";
            this.buttonFindPath.UseVisualStyleBackColor = true;
            this.buttonFindPath.Click += new System.EventHandler(this.buttonFindPath_Click);
            // 
            // checkBoxGenerateDebugOutputFile
            // 
            this.checkBoxGenerateDebugOutputFile.AutoSize = true;
            this.checkBoxGenerateDebugOutputFile.Location = new System.Drawing.Point(20, 272);
            this.checkBoxGenerateDebugOutputFile.Name = "checkBoxGenerateDebugOutputFile";
            this.checkBoxGenerateDebugOutputFile.Size = new System.Drawing.Size(159, 17);
            this.checkBoxGenerateDebugOutputFile.TabIndex = 10;
            this.checkBoxGenerateDebugOutputFile.Text = "Generate Debug Output File";
            this.checkBoxGenerateDebugOutputFile.UseVisualStyleBackColor = true;
            // 
            // groupBoxMovementHeuristicSettings
            // 
            this.groupBoxMovementHeuristicSettings.Controls.Add(this.groupBoxHeuristicChoice);
            this.groupBoxMovementHeuristicSettings.Controls.Add(this.checkBoxAllowDiagonalMovement);
            this.groupBoxMovementHeuristicSettings.Location = new System.Drawing.Point(20, 310);
            this.groupBoxMovementHeuristicSettings.Name = "groupBoxMovementHeuristicSettings";
            this.groupBoxMovementHeuristicSettings.Size = new System.Drawing.Size(252, 150);
            this.groupBoxMovementHeuristicSettings.TabIndex = 12;
            this.groupBoxMovementHeuristicSettings.TabStop = false;
            this.groupBoxMovementHeuristicSettings.Text = "Heuristic Settings";
            // 
            // checkBoxAllowDiagonalMovement
            // 
            this.checkBoxAllowDiagonalMovement.AutoSize = true;
            this.checkBoxAllowDiagonalMovement.Location = new System.Drawing.Point(18, 40);
            this.checkBoxAllowDiagonalMovement.Name = "checkBoxAllowDiagonalMovement";
            this.checkBoxAllowDiagonalMovement.Size = new System.Drawing.Size(149, 17);
            this.checkBoxAllowDiagonalMovement.TabIndex = 0;
            this.checkBoxAllowDiagonalMovement.Text = "Allow Diagonal Movement";
            this.checkBoxAllowDiagonalMovement.UseVisualStyleBackColor = true;
            this.checkBoxAllowDiagonalMovement.CheckedChanged += new System.EventHandler(this.checkBoxAllowDiagonalMovement_CheckedChanged);
            // 
            // groupBoxHeuristicChoice
            // 
            this.groupBoxHeuristicChoice.Controls.Add(this.radioButtonChebyshev);
            this.groupBoxHeuristicChoice.Controls.Add(this.radioButtonManhattan);
            this.groupBoxHeuristicChoice.Location = new System.Drawing.Point(18, 82);
            this.groupBoxHeuristicChoice.Name = "groupBoxHeuristicChoice";
            this.groupBoxHeuristicChoice.Size = new System.Drawing.Size(211, 53);
            this.groupBoxHeuristicChoice.TabIndex = 1;
            this.groupBoxHeuristicChoice.TabStop = false;
            this.groupBoxHeuristicChoice.Text = "Heuristic";
            // 
            // radioButtonManhattan
            // 
            this.radioButtonManhattan.AutoSize = true;
            this.radioButtonManhattan.Checked = true;
            this.radioButtonManhattan.Location = new System.Drawing.Point(17, 20);
            this.radioButtonManhattan.Name = "radioButtonManhattan";
            this.radioButtonManhattan.Size = new System.Drawing.Size(76, 17);
            this.radioButtonManhattan.TabIndex = 0;
            this.radioButtonManhattan.TabStop = true;
            this.radioButtonManhattan.Text = "Manhattan";
            this.radioButtonManhattan.UseVisualStyleBackColor = true;
            // 
            // radioButtonChebyshev
            // 
            this.radioButtonChebyshev.AutoSize = true;
            this.radioButtonChebyshev.Location = new System.Drawing.Point(110, 20);
            this.radioButtonChebyshev.Name = "radioButtonChebyshev";
            this.radioButtonChebyshev.Size = new System.Drawing.Size(78, 17);
            this.radioButtonChebyshev.TabIndex = 1;
            this.radioButtonChebyshev.Text = "Chebyshev";
            this.radioButtonChebyshev.UseVisualStyleBackColor = true;
            // 
            // labelGoalInfo
            // 
            this.labelGoalInfo.AutoSize = true;
            this.labelGoalInfo.Location = new System.Drawing.Point(318, 375);
            this.labelGoalInfo.Name = "labelGoalInfo";
            this.labelGoalInfo.Size = new System.Drawing.Size(113, 13);
            this.labelGoalInfo.TabIndex = 13;
            this.labelGoalInfo.Text = "Searching for Path . . .";
            this.labelGoalInfo.Visible = false;
            // 
            // FormMain
            // 
            this.AcceptButton = this.buttonFindPath;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 483);
            this.Controls.Add(this.labelGoalInfo);
            this.Controls.Add(this.groupBoxMovementHeuristicSettings);
            this.Controls.Add(this.checkBoxGenerateDebugOutputFile);
            this.Controls.Add(this.buttonFindPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPathResultFile);
            this.Controls.Add(this.buttonBrowseMapSourceFile);
            this.Controls.Add(this.textBoxMapSourceFile);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.Text = "A* Algorithm";
            this.groupBoxMovementHeuristicSettings.ResumeLayout(false);
            this.groupBoxMovementHeuristicSettings.PerformLayout();
            this.groupBoxHeuristicChoice.ResumeLayout(false);
            this.groupBoxHeuristicChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMapSourceFile;
        private System.Windows.Forms.Button buttonBrowseMapSourceFile;
        private System.Windows.Forms.TextBox textBoxPathResultFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonFindPath;
        private System.Windows.Forms.CheckBox checkBoxGenerateDebugOutputFile;
        private System.Windows.Forms.GroupBox groupBoxMovementHeuristicSettings;
        private System.Windows.Forms.GroupBox groupBoxHeuristicChoice;
        private System.Windows.Forms.RadioButton radioButtonChebyshev;
        private System.Windows.Forms.RadioButton radioButtonManhattan;
        private System.Windows.Forms.CheckBox checkBoxAllowDiagonalMovement;
        private System.Windows.Forms.Label labelGoalInfo;
    }
}

