namespace Banque_Misr {
  partial class FrmViewBalance {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.cboTransactionType = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.Color.Gainsboro;
      this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      this.textBox1.Location = new System.Drawing.Point(178, 75);
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.Size = new System.Drawing.Size(139, 22);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = "$";
      this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      this.label1.Location = new System.Drawing.Point(46, 26);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(126, 17);
      this.label1.TabIndex = 3;
      this.label1.Text = "Choose an Account";
      // 
      // cboTransactionType
      // 
      this.cboTransactionType.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.cboTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cboTransactionType.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cboTransactionType.ForeColor = System.Drawing.Color.Black;
      this.cboTransactionType.FormattingEnabled = true;
      this.cboTransactionType.Items.AddRange(new object[] {
            "Savings Account",
            "Current Account"});
      this.cboTransactionType.Location = new System.Drawing.Point(178, 23);
      this.cboTransactionType.Name = "cboTransactionType";
      this.cboTransactionType.Size = new System.Drawing.Size(121, 25);
      this.cboTransactionType.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      this.label2.Location = new System.Drawing.Point(12, 75);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(151, 17);
      this.label2.TabIndex = 4;
      this.label2.Text = "Your Current Balance is";
      // 
      // FrmViewBalance
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(379, 134);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cboTransactionType);
      this.Controls.Add(this.textBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "FrmViewBalance";
      this.Text = "frmViewBalance";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cboTransactionType;
    private System.Windows.Forms.Label label2;
  }
}