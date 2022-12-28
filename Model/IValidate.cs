namespace Banque_Misr.Model {
  internal interface IValidate {
    bool AccountNumber(string accNo);
    bool Password(string pass);
  }
}
