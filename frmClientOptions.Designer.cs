namespace Banque_Misr
{
    partial class FrmClientOptions
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
      this.darkToggle = new System.Windows.Forms.Button();
      this.btnMinimize = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cboTransactionType
      // 
      this.cboTransactionType.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.cboTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cboTransactionType.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cboTransactionType.ForeColor = System.Drawing.Color.Black;
      this.cboTransactionType.FormattingEnabled = true;
      this.cboTransactionType.Items.AddRange(new object[] {
            "Transfer",
            "View Balance",
            "Deposit",
            "Withdraw"});
      this.cboTransactionType.Location = new System.Drawing.Point(166, 23);
      this.cboTransactionType.Name = "cboTransactionType";
      this.cboTransactionType.Size = new System.Drawing.Size(121, 25);
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
      // darkToggle
      // 
      this.darkToggle.BackColor = System.Drawing.Color.Transparent;
      this.darkToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.darkToggle.Cursor = System.Windows.Forms.Cursors.Default;
      this.darkToggle.FlatAppearance.BorderSize = 0;
      this.darkToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.darkToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
      this.darkToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.darkToggle.ForeColor = System.Drawing.Color.Transparent;
      this.darkToggle.Image = global::Banque_Misr.Properties.Resources.Nightmode;
      this.darkToggle.Location = new System.Drawing.Point(350, 6);
      this.darkToggle.Name = "darkToggle";
      this.darkToggle.Size = new System.Drawing.Size(36, 29);
      this.darkToggle.TabIndex = 3;
      this.darkToggle.TabStop = false;
      this.darkToggle.UseVisualStyleBackColor = false;
      this.darkToggle.Click += new System.EventHandler(this.darkToggle_Click);
      this.darkToggle.MouseEnter += new System.EventHandler(this.darkToggle_MouseEnter);
      this.darkToggle.MouseLeave += new System.EventHandler(this.darkToggle_MouseLeave);
      // 
      // btnMinimize
      // 
      this.btnMinimize.BackColor = System.Drawing.Color.Transparent;
      this.btnMinimize.FlatAppearance.BorderSize = 0;
      this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnMinimize.ForeColor = System.Drawing.Color.Transparent;
      this.btnMinimize.Image = global::Banque_Misr.Properties.Resources.titlebutton_minimize;
      this.btnMinimize.Location = new System.Drawing.Point(21, 3);
      this.btnMinimize.Name = "btnMinimize";
      this.btnMinimize.Size = new System.Drawing.Size(24, 21);
      this.btnMinimize.TabIndex = 4;
      this.btnMinimize.TabStop = false;
      this.btnMinimize.UseVisualStyleBackColor = false;
      this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
      this.btnMinimize.MouseEnter += new System.EventHandler(this.btnMinimize_MouseEnter);
      this.btnMinimize.MouseLeave += new System.EventHandler(this.btnMinimize_MouseLeave);
      // 
      // btnClose
      // 
      this.btnClose.BackColor = System.Drawing.Color.Transparent;
      this.btnClose.FlatAppearance.BorderSize = 0;
      this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClose.ForeColor = System.Drawing.Color.Transparent;
      this.btnClose.Image = global::Banque_Misr.Properties.Resources.titlebutton_close;
      this.btnClose.Location = new System.Drawing.Point(1, 3);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(24, 21);
      this.btnClose.TabIndex = 5;
      this.btnClose.TabStop = false;
      this.btnClose.UseVisualStyleBackColor = false;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      this.btnClose.MouseEnter += new System.EventHandler(this.btnClose_MouseEnter);
      this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
      // 
      // frmClientOptions
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(393, 224);
      this.Controls.Add(this.btnMinimize);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.darkToggle);
      this.Controls.Add(this.pnlViewForm);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cboTransactionType);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "frmClientOptions";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "frmClientOptions";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel pnlViewForm;
    private System.Windows.Forms.Button darkToggle;
    private System.Windows.Forms.Button btnMinimize;
    private System.Windows.Forms.Button btnClose;
  }
}