namespace Banque_Misr
{
    partial class frmClientOptions
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
      this.cboTransactionType = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.pnlViewForm = new System.Windows.Forms.Panel();
      this.SuspendLayout();
      // 
      // cboTransactionType
      // 
      this.cboTransactionType.FormattingEnabled = true;
      this.cboTransactionType.Items.AddRange(new object[] {
            "Transfer",
            "View Balance",
            "Deposit",
            "Withdraw"});
      this.cboTransactionType.Location = new System.Drawing.Point(168, 24);
      this.cboTransactionType.Name = "cboTransactionType";
      this.cboTransactionType.Size = new System.Drawing.Size(121, 21);
      this.cboTransactionType.TabIndex = 0;
      this.cboTransactionType.SelectedIndexChanged += new System.EventHandler(this.cboTransactionType_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      this.label1.Location = new System.Drawing.Point(77, 24);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(85, 17);
      this.label1.TabIndex = 1;
      this.label1.Text = "Transactions";
      // 
      // pnlViewForm
      // 
      this.pnlViewForm.Location = new System.Drawing.Point(12, 51);
      this.pnlViewForm.Name = "pnlViewForm";
      this.pnlViewForm.Size = new System.Drawing.Size(358, 165);
      this.pnlViewForm.TabIndex = 2;
      // 
      // frmClientOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(393, 224);
      this.Controls.Add(this.pnlViewForm);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cboTransactionType);
      this.Name = "frmClientOptions";
      this.Text = "frmClientOptions";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnlViewForm;
  }
}