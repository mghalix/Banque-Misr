namespace Banque_Misr.Model {
  internal class Preferences {
    public static Mode Mode { get; set; }
    public static Client Client { get; set; }
    Preferences() {
      string branchCode, accountNo, accountType, name, phone, password;

      //client = new Client(branchCode, accountNo, accountType, name, phone, password);
    }
  }
}