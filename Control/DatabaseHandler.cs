﻿using System.Data.SqlClient;
using System.Windows.Forms;

namespace Banque_Misr.Control {
  internal class DatabaseHandler {
    private const string DB_URL = @"Data Source=.;Initial Catalog=Banque_Misr;Integrated Security=True";
    private const string DB_NAME = "Banque_Misr";

    public DatabaseHandler() {
      string query = $@"SELECT database_id FROM sys.databases WHERE Name 
      = '{DB_NAME}'";
      using (SqlConnection conn = new SqlConnection(DB_URL))
      using (SqlCommand command = new SqlCommand(query, conn))
        if ((int)command.ExecuteScalar() == 1)
          return;
    }

    public static T execQuery<T>(string query) where T : class, new() {
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

    private static void convertToObject<T>(SqlDataReader dataReader, T obj) {
      foreach (var item in obj.GetType().GetProperties()) {
        obj.GetType().GetProperty(item.Name).SetValue(obj, dataReader[item.Name], null);
      }
    }


  }
}
