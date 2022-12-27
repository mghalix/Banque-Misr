namespace Banque_Misr.Model {
  internal class Client {
    public string BranchCode { get; set; }
    public string SSN { get; set; }
    public string AccountNo { get; set; }
    public string AccountType { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }

    public Client() { }

    public Client(string branchCode, string ssn, string accountNo, string accountType, string name, string phone, string password) {
      BranchCode = branchCode;
      SSN = ssn;
      AccountNo = accountNo;
      AccountType = accountType;
      Name = name;
      Phone = phone;
      Password = password;
    }
  }
}
