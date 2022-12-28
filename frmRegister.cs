using Banque_Misr.Control;
using Banque_Misr.Model;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Banque_Misr {
  public partial class FrmRegister : Form, IShowPassword, IColorScheme {
    //Members
    private readonly FileStream fs;
    private readonly StreamWriter sw;
    private readonly StreamReader sr;
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn(
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // width of ellipse
        int nHeightEllipse // height of ellipse
    );

    public FrmRegister() {
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None;
      Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

      fs = new FileStream("ClientInfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
      sw = new StreamWriter(fs);
      sr = new StreamReader(fs);

      fs.Seek(0, SeekOrigin.Begin);
    }

    void close() {
      fs.Seek(0, SeekOrigin.Begin);
      sw.WriteLine((int)Preferences.Mode);
      sw.Flush();
      sw.Close();
      sr.Close();
      fs.Close();
    }

    private void darkToggle_Click(object sender, EventArgs e) {
      if (Preferences.Mode == Mode.Light) {//On white page 
        SetDark();
        return;
      }
      //on dark page
      SetLight();
    }

    public void SetDark() {
      Preferences.Mode = Mode.Dark;
      this.ForeColor = Color.GhostWhite;
      this.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
      //------------------------------------//
      foreach (object c in this.Controls) {
        if (c is Button) {
          ((Button)c).BackColor = Color.Transparent;
          continue;
        }

        if (c is TextBox) {
          ((TextBox)c).BackColor = Color.DarkGray;
          ((TextBox)c).ForeColor = Color.Black;
        }

        if (c is Label) {
          ((Label)c).ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        }

        if (c is ComboBox) {
          ((ComboBox)c).BackColor = Color.Gainsboro;
          ((ComboBox)c).ForeColor = Color.Black;
        }
      }
      //------------------------------------//
      lblBackToLogin.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));

      darkToggle.Image = global::Banque_Misr.Properties.Resources.Lightmode_v1;
      darkToggle.BackColor = System.Drawing.Color.Transparent;
      darkToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
      darkToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      darkToggle.ForeColor = System.Drawing.Color.White;
      darkToggle.Name = "button1";
      darkToggle.Size = new System.Drawing.Size(36, 31);
      darkToggle.TabIndex = 0;
      darkToggle.UseVisualStyleBackColor = false;
      darkToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));

      chkShowPass.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
      chkShowPass.BackColor = Color.Transparent;

      //Colors
      lblGetStarted.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
      btnRegister.BackColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
      btnClear.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
      btnClear.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
      lblBackToLogin.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
    }

    public void SetLight() {
      Preferences.Mode = Mode.Light;
      this.BackColor = Color.White;
      this.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
      //--------------------------------//
      foreach (object c in this.Controls) {
        if (c is Button) {
          ((Button)c).BackColor = Color.Transparent;
        }

        if (c is TextBox) {
          ((TextBox)c).BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
          ((TextBox)c).ForeColor = Color.Black;
        }

        if (c is ComboBox) {
          ((ComboBox)c).BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
          ((ComboBox)c).ForeColor = Color.Black;
        }

        if (c is Label) {
          ((Label)c).ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        }
      }
      //--------------------------------//
      darkToggle.BackColor = Color.Transparent;
      darkToggle.Image = global::Banque_Misr.Properties.Resources.Nightmode;
      darkToggle.FlatAppearance.BorderColor = Color.White;

      btnRegister.BackColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      btnClear.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
      btnClear.BackColor = Color.Transparent;
      lblHaveAcc.ForeColor = Color.FromArgb(164, 165, 169);
      lblName.ForeColor = lblBranchCode.ForeColor = lblAccNo.ForeColor = lblAccType.ForeColor = lblPhoneNo.ForeColor = lblPass.ForeColor = lblConfPass.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
    }

    private void label6_Click(object sender, EventArgs e) {
      close();
      FrmLogin frm = new FrmLogin();
      this.Hide();
      frm.Show();
    }

    private void button1_Click(object sender, EventArgs e) {
      DatabaseHandler dataHandler = DatabaseHandler.GetInstance();
      Validation validate = new Validation();

      if (!validate.AccountNumber(txtAccNo) || !validate.Password(txtPassword)) {

      }

      if (dataHandler.CheckUserExist(txtAccNo.Text)) {
        MessageBox.Show("Username already exists, please choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        txtAccNo.Clear();
        return;
      }

      fs.Seek(3, SeekOrigin.End);
      string line;
      while ((line = sr.ReadLine()) != null) {
        string[] field = line.Split('|');
        if (txtAccNo.Text.ToLower() == field[2]) {
          MessageBox.Show("Username already exists, please choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtAccNo.Clear();
          return;
        }
      }
      if (txtAccNo.Text == "" || txtPassword.Text == "" || txtComPassword.Text == "" || txtBranchCode.Text == "" || txtName.Text == "")
        MessageBox.Show("Registration Failed. Please fill in all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else if (txtPassword.Text == txtComPassword.Text) {
        fs.Seek(0, SeekOrigin.End);
        sw.WriteLine($"{txtName.Text}|{txtBranchCode.Text}|{txtAccNo.Text.ToLower()}|{txtPassword.Text}");
        label6_Click(sender, e);
        MessageBox.Show("Your Account has been Succesfully Created", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else {
        MessageBox.Show("Passwords does not match.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        txtPassword.Clear();
        txtComPassword.Clear();
        txtPassword.Focus();
      }

    }

    private void button2_Click(object sender, EventArgs e) {
      txtName.Clear();
      txtBranchCode.Clear();
      txtAccNo.Clear();
      txtPassword.Clear();
      txtComPassword.Clear();
    }

    private void checkbxShowPass_CheckedChanged(object sender, EventArgs e) {
      ShowPassword();
    }
    public void ShowPassword() {
      txtPassword.MaxLength = 14;
      txtComPassword.MaxLength = 14;

      if (!chkShowPass.Checked) {
        txtPassword.PasswordChar = '•';
        txtComPassword.PasswordChar = '•';
      }
      else {
        txtPassword.PasswordChar = '\0';
        txtComPassword.PasswordChar = '\0';
      }
    }

    private void frmRegister_Load(object sender, EventArgs e) {
      ShowPassword();

      if (Preferences.Mode == Mode.Dark)
        SetDark();
      else
        SetLight();
    }

    private void btnClose_Click(object sender, EventArgs e) {
      close();
      Application.Exit();
    }

    private void btnMinimize_Click(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }


    private void darkToggle_MouseEnter(object sender, EventArgs e) {
      if (Preferences.Mode == Mode.Dark) {
        darkToggle.Image = (System.Drawing.Image)(Banque_Misr.Properties.Resources.Lightmode_v1Hover);
        darkToggle.FlatAppearance.BorderColor = Color.FromArgb(13, 17, 24);
        return;
      }
      darkToggle.Image = (System.Drawing.Image)(Banque_Misr.Properties.Resources.Nightmode_onHover);
      darkToggle.FlatAppearance.BorderColor = Color.White;
    }

    private void darkToggle_MouseLeave(object sender, EventArgs e) {
      if (Preferences.Mode == Mode.Dark) {
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
  }
}