using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Model;

namespace DataAccessLayer
{
    public class StudentDAL : IDatabase<StudentModel>
    {
        private OleDbConnection connection;
        public StudentDAL()
        {
            connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; " +
                    "Data Source=Student.mdb;Persist Security Info=True");
        }
        public bool CreateItem(StudentModel item)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                OleDbCommand command = new OleDbCommand(
                    "INSERT INTO Student (FullName, BirthDate) VALUES (@fullname, @birthdate)",
                    connection);
                command.Parameters.Add("@fullname", OleDbType.BSTR).Value = item.FullName;
                command.Parameters.Add("@birthdate", OleDbType.Date).Value = item.BirthDate;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public bool DeleteItem(StudentModel item)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                OleDbCommand command = new OleDbCommand(
                    "DELETE FROM Student WHERE Identity = @identity", connection);
                command.Parameters.Add("@identity", OleDbType.Numeric).Value = item.Identity;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        public DataTable ReadItems()
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                OleDbCommand command = new OleDbCommand(
                    "SELECT * FROM Student ORDER BY Identity ASC", connection);
                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(command);
                oleDbDataAdapter.Fill(dataTable);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }

        public bool UpdateItem(StudentModel item)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                OleDbCommand command = new OleDbCommand(
                    "UPDATE Student SET FullName = @fullname, BirthDate = @birthdate " +
                    "WHERE Identity = @identity", connection);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
