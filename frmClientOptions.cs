using Banque_Misr.Model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Banque_Misr {
  public partial class FrmClientOptions : Form, IColorScheme {
    private Form selectedForm = null;
    private readonly FileStream fs;
    private readonly StreamReader sr;
    private readonly StreamWriter sw;

    public FrmClientOptions() {
      InitializeComponent();
      fs = new FileStream("Clientinfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
      sr = new StreamReader(fs);
      sw = new StreamWriter(fs);

      fs.Seek(0, SeekOrigin.Begin);

      if (Preferences.sMode == Mode.Light)
        SetLight();
      else
        SetDark();
    }
    void close() {
      fs.Seek(0, SeekOrigin.Begin);
      sw.WriteLine((int)Preferences.sMode);
      sw.Flush();
      sw.Close();
      sr.Close();
      fs.Close();
    }

    private void initPanelOpt(Form frm) {
      pnlViewForm.Controls.Clear();
      pnlViewForm.BackColor = Color.Transparent;

      controlsColor();

      pnlViewForm.Dock = DockStyle.Bottom;
      frm.TopLevel = false;
      pnlViewForm.Controls.Add(frm);
      frm.Show();
    }

    private void cboTransactionType_SelectedIndexChanged(object sender, System.EventArgs e) {
      switch (cboTransactionType.SelectedIndex) {
        case 0: // transfer
          selectedForm = new FrmTransfer();
          initPanelOpt(selectedForm);
          break;
        case 1: // view balance
          selectedForm = new FrmViewBalance();
          //string axn = "INSERT INTO branch VALUES('TestName2', 'TestCode2')";
          //DatabaseHandler.execAction(axn);
          initPanelOpt(selectedForm);
          break;
        case 2: // deposit
          FrmDeposit deposit = new FrmDeposit();
          selectedForm = new FrmDeposit();
          initPanelOpt(selectedForm);
          break;
        case 3: // withdraw
          selectedForm = new FrmWithdraw();
          initPanelOpt(selectedForm);
          break;
      }
    }
    public void SetLight() {
      Preferences.sMode = Mode.Light;
      darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
      this.BackColor = Color.White;
      this.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));

      darkToggle.FlatAppearance.BorderColor = Color.White;
      darkToggle.Image = global::Banque_Misr.Properties.Resources.Nightmode;
      //----------------------/
      label1.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
    }
    public void SetDark() {
      darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
      Preferences.sMode = Mode.Dark;
      this.ForeColor = Color.GhostWhite;
      this.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
      darkToggle.BackColor = System.Drawing.Color.Transparent;
      darkToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      darkToggle.FlatAppearance.BorderColor = Color.FromArgb(13, 17, 163);
      darkToggle.Image = global::Banque_Misr.Properties.Resources.Lightmode_v1;
      darkToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      darkToggle.ForeColor = System.Drawing.Color.White;
      darkToggle.Name = "button1";
      darkToggle.Size = new System.Drawing.Size(36, 31);
      darkToggle.TabIndex = 0;
      darkToggle.UseVisualStyleBackColor = false;
      darkToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
      //-------------------------------//

      //63, 77, 163
      //label1.ForeColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
      label1.ForeColor = Color.White;
    }

    private void darkToggle_Click(object sender, System.EventArgs e) {
      darkToggle.Image = null;
      if (Preferences.sMode == Mode.Light)
        SetDark();
      else
        SetLight();

      if (selectedForm != null) {
        initPanelOpt(selectedForm);
      }
    }

    void controlsColor() {
      if (Preferences.sMode == Mode.Light) {
        selectedForm.BackColor = Color.White;
        selectedForm.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
      }
      else {
        selectedForm.ForeColor = Color.GhostWhite;
        selectedForm.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
      }

      foreach (var c in selectedForm.Controls) {
        if (c is Button) {
          if (Preferences.sMode == Mode.Light)
            ((Button)c).BackColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
          else
            ((Button)c).BackColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
          continue;
        }

        if (c is Label) {
          if (Preferences.sMode == Mode.Light)
            ((Label)c).ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
          else
            ((Label)c).ForeColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
          continue;
        }
      }
    }
    private void darkToggle_MouseEnter(object sender, EventArgs e) {
      if (Preferences.sMode == Mode.Dark) {
        darkToggle.Image = (System.Drawing.Image)(Banque_Misr.Properties.Resources.Lightmode_v1Hover);
        darkToggle.FlatAppearance.BorderColor = Color.FromArgb(13, 17, 24);
        return;
      }
      darkToggle.Image = (System.Drawing.Image)(Banque_Misr.Properties.Resources.Nightmode_onHover);
      darkToggle.FlatAppearance.BorderColor = Color.White;
    }

    private void darkToggle_MouseLeave(object sender, EventArgs e) {
      if (Preferences.sMode == Mode.Dark) {
        darkToggle.Image = (Banque_Misr.Properties.Resources.Lightmode_v1);
        darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
        darkToggle.FlatAppearance.MouseOverBackColor = Color.Transparent;
        return;
      }
      darkToggle.Image = (Banque_Misr.Properties.Resources.Nightmode);
      darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
      darkToggle.FlatAppearance.MouseOverBackColor = Color.Transparent;
    }

    private void btnClose_MouseEnter(object sender, EventArgs e) {
      btnClose.Image = Banque_Misr.Properties.Resources.titlebutton_close_hover;
      btnClose.FlatAppearance.MouseDownBackColor = Color.Transparent;
      btnClose.FlatAppearance.MouseOverBackColor = Color.Transparent;
    }

    private void btnClose_MouseLeave(object sender, EventArgs e) {
      btnClose.Image = Banque_Misr.Properties.Resources.titlebutton_close;
    }

    private void btnMinimize_MouseEnter(object sender, EventArgs e) {
      btnMinimize.Image = Banque_Misr.Properties.Resources.titlebutton_minimize_hover;
      btnMinimize.FlatAppearance.MouseDownBackColor = Color.Transparent;
      btnMinimize.FlatAppearance.MouseOverBackColor = Color.Transparent;
    }

    private void btnMinimize_MouseLeave(object sender, EventArgs e) {
      btnMinimize.Image = Banque_Misr.Properties.Resources.titlebutton_minimize;
    }
    private void btnClose_Click(object sender, EventArgs e) {
      close();
      Application.Exit();
    }

    private void btnMinimize_Click(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }
  }
}


