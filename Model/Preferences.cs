﻿namespace Banque_Misr.Model {
  internal class Preferences {
    Mode mode;
    Client client;
    Preferences() {
      mode = Mode.Light;
      //string branchCode, ssn, accountNo, accountType, name, phone, password;

      //client = new Client(branchCode, ssn, accountNo, accountType, name, phone, password);
    }
  }
}