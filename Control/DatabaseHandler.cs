using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banque_Misr.Control {
  internal static class DatabaseHandler {
    private const string DB_URL = "Data Source=.;Initial Catalog=Banque_Misr;Integrated Security=True";
    public static DataTable execQuery(string query) {
      DataTable results = new DataTable();
      try {
        using (SqlConnection conn = new SqlConnection(DB_URL))
        using (SqlCommand cmd = new SqlCommand(query, conn))
        using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd)) {
          dataAdapter.Fill(results);
        }
      }
      catch (SqlException ex) {
        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      return results;
    }

    public static void execAction(string action) {
      try {
        using (SqlConnection conn = new SqlConnection(DB_URL))
        using (SqlCommand cmd = new SqlCommand(action, conn)) {
          conn.Open();
          cmd.ExecuteNonQuery();
        }
      }
      catch (SqlException ex) {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
