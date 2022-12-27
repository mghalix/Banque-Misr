namespace Banque_Misr.Model {
  internal class Client {
    public string BranchCode { get; set; }
    public string AccountNo { get; set; }
    public AccountType AccountType { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }

    public Client() { }

    public Client(string branchCode, string accountNo, AccountType accountType, string name, string phone, string password) {
      BranchCode = branchCode;
      AccountNo = accountNo;
      AccountType = accountType;
      Name = name;
      Phone = phone;
      Password = password;
    }
  }
}
