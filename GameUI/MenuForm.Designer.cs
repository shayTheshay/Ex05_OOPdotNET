namespace GameUI
{
    partial class MenuForm
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
            this.changeSizeButton = new System.Windows.Forms.Button();
            this.computerButton = new System.Windows.Forms.Button();
            this.PvPButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // changeSizeButton
            // 
            this.changeSizeButton.Location = new System.Drawing.Point(64, 34);
            this.changeSizeButton.Name = "changeSizeButton";
            this.changeSizeButton.Size = new System.Drawing.Size(324, 74);
            this.changeSizeButton.TabIndex = 0;
            this.changeSizeButton.UseVisualStyleBackColor = true;
            this.changeSizeButton.Click += new System.EventHandler(this.changeSizeButton_Click);
            updateBoardSizeText();
            // 
            // ComputerButton
            // 
            this.computerButton.Location = new System.Drawing.Point(64, 143);
            this.computerButton.Name = "ComputerButton";
            this.computerButton.Size = new System.Drawing.Size(112, 34);
            this.computerButton.TabIndex = 1;
            this.computerButton.Text = "Computer";
            this.computerButton.UseVisualStyleBackColor = true;
            this.computerButton.Click += new System.EventHandler(this.ComputerButton_Click);
            // 
            // PvPButton
            // 
            this.PvPButton.Location = new System.Drawing.Point(276, 143);
            this.PvPButton.Name = "PvPButton";
            this.PvPButton.Size = new System.Drawing.Size(112, 34);
            this.PvPButton.TabIndex = 2;
            this.PvPButton.Text = "PvP";
            this.PvPButton.UseVisualStyleBackColor = true;
            this.PvPButton.Click += new System.EventHandler(this.PvPButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 227);
            this.Controls.Add(this.PvPButton);
            this.Controls.Add(this.computerButton);
            this.Controls.Add(this.changeSizeButton);
            this.Name = "MenuForm";
            this.Text = "Othello - main menu";
            this.ResumeLayout(false);

        }

        #endregion

        private Button changeSizeButton;
        private Button computerButton;
        private Button PvPButton;
    }
}