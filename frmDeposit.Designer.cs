namespace Banque_Misr
{
    partial class frmDeposit
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
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.button2 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // txtPassword
      // 
      this.txtPassword.BackColor = System.Drawing.Color.Gainsboro;
      this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPassword.ForeColor = System.Drawing.Color.Black;
      this.txtPassword.Location = new System.Drawing.Point(95, 30);
      this.txtPassword.Multiline = true;
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(216, 21);
      this.txtPassword.TabIndex = 11;
      this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.818182F, System.Drawing.FontStyle.Bold);
      this.label2.Location = new System.Drawing.Point(12, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(62, 19);
      this.label2.TabIndex = 10;
      this.label2.Text = "Amount";
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
      this.button2.FlatAppearance.BorderSize = 0;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button2.Font = new System.Drawing.Font("Nirmala UI", 9.818182F, System.Drawing.FontStyle.Bold);
      this.button2.ForeColor = System.Drawing.Color.White;
      this.button2.Location = new System.Drawing.Point(12, 85);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(130, 30);
      this.button2.TabIndex = 9;
      this.button2.TabStop = false;
      this.button2.Text = "Deposit";
      this.button2.UseVisualStyleBackColor = false;
      // 
      // frmDeposit
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
      this.ClientSize = new System.Drawing.Size(365, 127);
      this.Controls.Add(this.txtPassword);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.button2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "frmDeposit";
      this.Text = "frmDeposit";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
    }
}