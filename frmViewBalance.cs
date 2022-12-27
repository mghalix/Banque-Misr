using Banque_Misr.Control;
using Banque_Misr.Model;
using System.Windows.Forms;

namespace Banque_Misr {
  public partial class frmViewBalance : Form {
    public frmViewBalance() {
      InitializeComponent();
      string query = "SELECT b_code AS branchCode, b_name AS branchName FROM branch WHERE b_name='TestCode2'";
      var branch = DatabaseHandler.execQuery<Branch>(query);
      textBox1.Text = branch.branchName;
      textBox2.Text = branch.branchCode;
    }
  }
}
