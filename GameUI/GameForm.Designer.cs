namespace GameUI
{
    partial class GameForm
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
        private void InitializeComponent(int i_Size)
        {
            int buttonIndex = 0;

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new Size((r_CellSize * (i_Size)) + (2 * r_Margins),
                                       (r_CellSize * (i_Size)) + (2 * r_Margins));
            this.Text = "Game Board";
            this.m_AIDelayTimer = new System.Windows.Forms.Timer(this.components);
            this.m_AIDelayTimer.Interval = 400;
            this.m_AIDelayTimer.Tick += new System.EventHandler(this.makeAiMove);
            this.SuspendLayout();
            for (int i = 0; i < i_Size; i++)
            {
                for (int j = 0; j < i_Size; j++)
                {
                    OthelloButton nextButtonToAdd = new OthelloButton(i, j);
                    nextButtonToAdd.Location = new System.Drawing.Point((r_CellSize * nextButtonToAdd.X) + r_Margins, (r_CellSize * nextButtonToAdd.Y) + r_Margins);
                    nextButtonToAdd.Name = String.Format("othelloButton{0}", buttonIndex);
                    nextButtonToAdd.Size = new System.Drawing.Size(r_CellSize, r_CellSize);
                    nextButtonToAdd.TabIndex = buttonIndex;
                    nextButtonToAdd.Click += new System.EventHandler(this.othelloButton_Click);
                    nextButtonToAdd.BorderStyle = BorderStyle.Fixed3D;
                    nextButtonToAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    buttonIndex++;
                    this.Controls.Add(nextButtonToAdd);
                    r_ButtonList.Add(nextButtonToAdd);
                }
            }
          
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer m_AIDelayTimer;
    }
}