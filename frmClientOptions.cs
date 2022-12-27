using System.Windows.Forms;
namespace Banque_Misr {
  public partial class frmClientOptions : Form {
    public frmClientOptions() {
      InitializeComponent();
    }
    private void initPanelOpt(Form frm) {
      pnlViewForm.Controls.Clear();
      pnlViewForm.Dock = DockStyle.Bottom;

      frm.TopLevel = false;
      pnlViewForm.Controls.Add(frm);
      frm.Show();
    }

    private void cboTransactionType_SelectedIndexChanged(object sender, System.EventArgs e) {
      switch (cboTransactionType.SelectedIndex) {
        case 0: // transfer
          frmTransfer transfer = new frmTransfer();
          initPanelOpt(transfer);
          break;
        case 1: // view balance
          frmViewBalance balance = new frmViewBalance();
          //string axn = "INSERT INTO branch VALUES('TestName2', 'TestCode2')";
          //DatabaseHandler.execAction(axn);
          initPanelOpt(balance);
          balance.Show();
          break;
        case 2: // deposit
          frmDeposit deposit = new frmDeposit();
          initPanelOpt(deposit);
          break;
        case 3: // withdraw
          frmWithdraw withdraw = new frmWithdraw();
          initPanelOpt(withdraw);
          break;
      }
    }
  }
}
