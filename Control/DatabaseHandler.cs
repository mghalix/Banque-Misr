using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banque_Misr.Control {
  internal class DatabaseHandler {
    private const string DB_MASTER_URL = @"Data Source=.;Initial Catalog=master;Integrated Security=True";
    private const string DB_URL = @"Data Source=.;Initial Catalog=Banque_Misr;Integrated Security=True";
    private const string DB_NAME = "Banque_Misr";
    private static DatabaseHandler s_databaseHandler;
    private DatabaseHandler() {
      createDB();
      setUpTableBranch();
      setUpTableClient();
      setUpTableEmployee();
      setUpTableTransaction();
    }

    public static DatabaseHandler GetInstance() {
      if (s_databaseHandler == null)
        s_databaseHandler = new DatabaseHandler();
      return s_databaseHandler;
    }

    private void createDB() {
      if (CheckDatabaseExists(DB_MASTER_URL, DB_NAME))
        return;


      try {
        string createDatabase = $@"CREATE DATABASE {DB_NAME}";
        using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=master;Integrated Security=True"))
        using (SqlCommand cmd = new SqlCommand(createDatabase, conn)) {
          conn.Open();
          cmd.ExecuteNonQuery();
        }
      }
      catch (SqlException ex) {
        MessageBox.Show(ex.Message);
      }
    }
    private void setUpTableTransaction() {
      if (checkTableExists("bank_transaction")) {
        return;
      }
      string createTableTransaction = $@"Create table bank_transaction (
      transaction_id                INT PRIMARY KEY,
      account_number                VARCHAR(25) NOT NULL,
      transaction_date              DATETIME NOT NULL DEFAULT GETDATE(), 
      transaction_type              VARCHAR(25) NOT NULL,
      transaction_amount            MONEY DEFAULT '0',
      balance_as_of                 MONEY DEFAULT'0' ,
      branch_code VARCHAR(20)       FOREIGN KEY REFERENCES branch(branch_code),
      client_number                 VARCHAR(20)  FOREIGN KEY REFERENCES client(acc_no)
      )";

      ExecAction(createTableTransaction);
    }
    private bool checkTableExists(string tableName) {
      using (SqlConnection conn = new SqlConnection(DB_URL)) {
        using (SqlCommand cmd = new SqlCommand("SELECT CASE WHEN EXISTS((SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '" + tableName + "')) THEN 1 ELSE 0 END", conn)) {
          conn.Open();
          return (int)cmd.ExecuteScalar() == 1;
        }
      }
    }

    private void setUpTableEmployee() {
      if (checkTableExists("employee")) {
        return;
      }
      const string createTableEmp = @"CREATE TABLE employee (
      branch_code   VARCHAR (20)  FOREIGN KEY REFERENCES branch(branch_code),
      id		        VARCHAR (20) PRIMARY key,
      name	        VARCHAR (20) NOT NULL,
      salary        DECIMAL (10, 2),
      pass          VARCHAR (20),
      manager_id    VARCHAR (20)  FOREIGN KEY REFERENCES employee(id
)
      )";
      ExecAction(createTableEmp);
    }

    private void setUpTableClient() {
      if (checkTableExists("client")) {
        return;
      }
      const string createTableClient = @"CREATE TABLE client (
      branch_code VARCHAR (20)  FOREIGN KEY REFERENCES branch(branch_code),
      acc_no      VARCHAR (20) PRIMARY key,
      acc_type    VARCHAR (20) NOT NULL,
      name        VARCHAR (20) NOT NULL,
      phone       VARCHAR (20),
      pass	      VARCHAR (20) NOT NULL
      )";
      ExecAction(createTableClient);
    }

    private void setUpTableBranch() {
      if (checkTableExists("branch")) {
        return;
      }
      const string createTableBranch = @"CREATE TABLE branch (
      branch_code   VARCHAR(20) PRIMARY KEY,
      branch_name   VARCHAR(20)
      )";
      ExecAction(createTableBranch);
    }

    public T ExecQuery<T>(string query) where T : class, new() {
      T obj = new T();
      try {
        using (SqlConnection conn = new SqlConnection(DB_URL))
        using (SqlCommand command = new SqlCommand(query, conn)) {
          conn.Open();
          SqlDataReader dataReader = command.ExecuteReader();

          if (dataReader.Read()) {
            convertToObject(dataReader, obj);
          }
        }
      }
      catch (SqlException ex) {
        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return obj;
    }

    public bool ExecAction(string action) {
      try {
        using (SqlConnection conn = new SqlConnection(DB_URL))
        using (SqlCommand cmd = new SqlCommand(action, conn)) {
          conn.Open();
          cmd.ExecuteNonQuery();
          return true;
        }
      }
      catch (SqlException ex) {
        MessageBox.Show(ex.Message);
        return false;
      }
    }

    private static void convertToObject<T>(SqlDataReader dataReader, T obj) {
      foreach (var item in obj.GetType().GetProperties()) {
        obj.GetType().GetProperty(item.Name).SetValue(obj, dataReader[item.Name], null);
      }
    }

    public static bool CheckDatabaseExists(string DatabaseURL, string databaseName) {
      using (var connection = new SqlConnection(DatabaseURL)) {
        using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection)) {
          connection.Open();
          return (command.ExecuteScalar() != DBNull.Value);
        }
      }
    }

    public bool CheckUserExist(string accNo) {
      string query = $@"SELECT * FROM client WHERE acc_no={accNo}";
      using (SqlConnection conn = new SqlConnection(DB_URL)) {
        using (SqlCommand cmd = new SqlCommand(query, conn)) {
          conn.Open();
          if ((int)cmd.ExecuteScalar() > 0)
            return true;
        }
      }
      return false;
    }

  }
}
