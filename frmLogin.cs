using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Banque_Misr {
  public partial class frmLogin : Form, IShowPassword {
    //Members
    FileStream fs;
    StreamReader sr;
    StreamWriter sw;
    private bool darkOn = true;
    [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,     // x-coordinate of upper-left corner
        int nTopRect,      // y-coordinate of upper-left corner
        int nRightRect,    // x-coordinate of lower-right corner
        int nBottomRect,   // y-coordinate of lower-right corner
        int nWidthEllipse, // width of ellipse
        int nHeightEllipse // height of ellipse
    );
    public frmLogin() {
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None;
      Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
      txtUsername.TabIndex = 0;
      txtPassword.TabIndex = 1;
    }
    public void darkToggle_Click(object sender, EventArgs e) {
      darkToggle.Image = null;
      if (!darkOn) //on white mode
      {
        darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
        fs.Seek(0, SeekOrigin.Begin);
        sw.WriteLine("0");
        sw.Flush();
        darkOn = true;
        this.BackColor = Color.White;
        this.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));

        darkToggle.FlatAppearance.BorderColor = Color.White;
        darkToggle.Image = global::Banque_Misr.Properties.Resources.Nightmode;
        //----------------------/
        label1.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        button1.BackColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        label6.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        //texts
        txtPassword.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
        txtUsername.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));

        txtUsername.ForeColor = Color.Black;
        txtPassword.ForeColor = Color.Black;
      }
      else //on dark mode
      {
        darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
        fs.Seek(0, SeekOrigin.Begin);
        sw.WriteLine("1");
        sw.Flush();
        darkOn = false;
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
        label1.ForeColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
        button1.BackColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
        button2.BackColor = Color.Transparent;
        button2.ForeColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
        label6.ForeColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
        //texts
        txtPassword.BackColor = Color.DarkGray;
        txtUsername.BackColor = Color.DarkGray;

        txtUsername.ForeColor = Color.Black;
        txtPassword.ForeColor = Color.Black;

        label2.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label3.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        checkbxShowPass.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label5.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));

      }
    }

    private void button1_Click(object sender, EventArgs e) {
      Login();
    }

    private void checkbxShowPass_CheckedChanged(object sender, EventArgs e) {
      ShowPassword();
    }

    private void frmLogin_Load(object sender, EventArgs e) {
      ShowPassword();
      fs = new FileStream("Clientinfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
      sr = new StreamReader(fs);
      sw = new StreamWriter(fs);
      fs.Seek(0, SeekOrigin.Begin);
      if (sr.ReadLine() == "1") {
        darkOn = true;
        txtUsername.Focus();
      }
      else
        darkOn = false;

      darkToggle_Click(sender, e);
      txtUsername.Focus();
      sr.DiscardBufferedData();

    }
    private void button2_Click(object sender, EventArgs e) {
      txtPassword.Clear();
      txtUsername.Clear();
    }

    private void label6_Click(object sender, EventArgs e) {
      sw.Close();
      fs.Close();
      frmRegister frm = new frmRegister();
      this.Hide();
      frm.Show();

    }
    public void ShowPassword() {
      txtPassword.MaxLength = 14;

      if (!checkbxShowPass.Checked) {
        txtPassword.PasswordChar = '•';
      }
      else {
        txtPassword.PasswordChar = '\0';
      }
    }
    public void Login() {
      sr.DiscardBufferedData();
      fs.Seek(3, SeekOrigin.Begin);
      string line;

      if (txtUsername.Text == "" || txtPassword.Text == "") {
        MessageBox.Show("Please enter Complete Username and Password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }


      while ((line = sr.ReadLine()) != null) {
        string[] field = line.Split('|');

        if (txtUsername.Text.ToLower() == field[2].ToLower() && txtPassword.Text == field[3]) {
          sr.Close();
          frmClientOptions main = new frmClientOptions();
          this.Hide();
          main.Show();
          return;
        }
      }

      MessageBox.Show("Wrong Username or Password. Please try again", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      txtPassword.Text = "";
      txtPassword.Focus();
    }
    private void btnClose_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void btnMinimize_Click(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }

    private void btnMaximize_Click(object sender, EventArgs e) {
      //if (WindowState == FormWindowState.Normal)
      //    this.WindowState = FormWindowState.Maximized;
      //else
      //    this.WindowState = FormWindowState.Normal;
    }

    private void darkToggle_MouseEnter(object sender, EventArgs e) {
      if (darkOn) //white
      {
        //darkToggle.FlatAppearance.MouseOverBackColor = Color.LightSlateGray;
        darkToggle.Image = (System.Drawing.Image)(Banque_Misr.Properties.Resources.Nightmode_onHover);
        darkToggle.FlatAppearance.BorderColor = Color.White;
      }
      if (!darkOn)// dark
      {
        //darkToggle.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke;
        darkToggle.Image = (System.Drawing.Image)(Banque_Misr.Properties.Resources.Lightmode_v1Hover);
        darkToggle.FlatAppearance.BorderColor = Color.FromArgb(13, 17, 24);
      }
    }

    private void darkToggle_MouseLeave(object sender, EventArgs e) {
      if (!darkOn) {
        darkToggle.Image = (Banque_Misr.Properties.Resources.Lightmode_v1);
        darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
        darkToggle.FlatAppearance.MouseOverBackColor = Color.Transparent;
      }
      if (darkOn) {
        darkToggle.Image = (Banque_Misr.Properties.Resources.Nightmode);
        darkToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;
        darkToggle.FlatAppearance.MouseOverBackColor = Color.Transparent;
      }

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