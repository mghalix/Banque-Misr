using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banque_Misr {
  public partial class frmRegister : Form {
    //Members
    private bool darkOn = true;
    public FileStream fs;
    public StreamWriter sw;
    public StreamReader sr;
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
    public frmRegister() {
      InitializeComponent();
      this.FormBorderStyle = FormBorderStyle.None;
      Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

    }

    private void darkToggle_Click(object sender, EventArgs e) {
      if (!darkOn) //On white page
      {
        fs.Seek(0, SeekOrigin.Begin);
        sw.WriteLine("0");
        sw.Flush();
        darkOn = true;
        this.BackColor = Color.White;
        this.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        //34, 41, 87
        label1.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        button1.BackColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        button2.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        button2.BackColor = Color.Transparent;
        label6.ForeColor = Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(41)))), ((int)(((byte)(87)))));
        //text
        txtName.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
        txtUsername.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
        txtPassword.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
        txtComPassword.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
        txtAge.BackColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));

        txtName.ForeColor = Color.Black;
        txtUsername.ForeColor = Color.Black;
        txtPassword.ForeColor = Color.Black;
        txtComPassword.ForeColor = Color.Black;
        txtAge.ForeColor = Color.Black;
        //--------------------------------//
        darkToggle.BackColor = Color.Transparent;
        darkToggle.Image = global::Banque_Misr.Properties.Resources.Nightmode;
        darkToggle.FlatAppearance.BorderColor = Color.White;
      }
      else //on dark page
      {
        fs.Seek(0, SeekOrigin.Begin);
        sw.WriteLine("1");
        sw.Flush();
        darkOn = false;
        this.ForeColor = Color.GhostWhite;
        this.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
        //Colors
        label1.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
        button1.BackColor = Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(77)))), ((int)(((byte)(163)))));
        button2.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
        button2.BackColor = Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
        label6.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
        //texts
        txtName.BackColor = Color.DarkGray;
        txtUsername.BackColor = Color.DarkGray;
        txtPassword.BackColor = Color.DarkGray;
        txtComPassword.BackColor = Color.DarkGray;
        txtAge.BackColor = Color.DarkGray;

        txtName.ForeColor = Color.Black;
        txtUsername.ForeColor = Color.Black;
        txtPassword.ForeColor = Color.Black;
        txtComPassword.ForeColor = Color.Black;
        txtAge.ForeColor = Color.Black;
        //labels
        label2.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label3.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label4.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label5.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label6.ForeColor = Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
        label7.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        label8.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));

        checkbxShowPass.ForeColor = Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
        checkbxShowPass.BackColor = Color.Transparent;

        darkToggle.Image = global::Banque_Misr.Properties.Resources.Lightmode_v1;
        darkToggle.BackColor = System.Drawing.Color.Transparent;
        darkToggle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
        //darkToggle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
        darkToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        darkToggle.ForeColor = System.Drawing.Color.White;
        darkToggle.Name = "button1";
        darkToggle.Size = new System.Drawing.Size(36, 31);
        darkToggle.TabIndex = 0;
        darkToggle.UseVisualStyleBackColor = false;
        darkToggle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
      }
    }

    private void label6_Click(object sender, EventArgs e) {
      sw.Close();
      fs.Close();
      frmLogin frm = new frmLogin();
      this.Hide();
      frm.Show();
    }

    private void button1_Click(object sender, EventArgs e) {
      fs.Seek(3, SeekOrigin.End);
      string line;
      while ((line = sr.ReadLine()) != null) {
        string[] field = line.Split('|');
        if (txtUsername.Text.ToLower() == field[2]) {
          MessageBox.Show("Username already exists, please choose another one", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          txtUsername.Clear();
          return;
        }
      }
      if (txtUsername.Text == "" || txtPassword.Text == "" || txtComPassword.Text == "" || txtAge.Text == "" || txtName.Text == "")
        MessageBox.Show("Registration Failed. Please fill in all fields", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      else if (txtPassword.Text == txtComPassword.Text) {
        fs.Seek(0, SeekOrigin.End);
        sw.WriteLine($"{txtName.Text}|{txtAge.Text}|{txtUsername.Text.ToLower()}|{txtPassword.Text}");
        sw.Close();
        fs.Close();
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
      txtAge.Clear();
      txtUsername.Clear();
      txtPassword.Clear();
      txtComPassword.Clear();
    }

    private void checkbxShowPass_CheckedChanged(object sender, EventArgs e) {
      ShowPassword();
    }
    public void ShowPassword() {
      txtPassword.MaxLength = 14;
      txtComPassword.MaxLength = 14;

      if (!checkbxShowPass.Checked) {
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
      fs = new FileStream("ClientInfo.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
      sw = new StreamWriter(fs);
      sr = new StreamReader(fs);
      fs.Seek(0, SeekOrigin.Begin);
      if (sr.ReadLine() == "1") {
        darkOn = true;
        darkToggle_Click(sender, e);
      }
      else {
        darkOn = false;
        darkToggle_Click(sender, e);
      }
      sr.DiscardBufferedData();
    }

    private void btnClose_Click(object sender, EventArgs e) {
      Application.Exit();
    }

    private void btnMinimize_Click(object sender, EventArgs e) {
      this.WindowState = FormWindowState.Minimized;
    }

    private void btnMaximize_Click(object sender, EventArgs e) {
      //if (this.WindowState == FormWindowState.Normal)
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