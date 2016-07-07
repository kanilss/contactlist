using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHandler
{
    public class SQL
    {
        static string conStr = "Data Source=contactlist.database.windows.net;Initial Catalog=contactlist;Integrated Security=False;User ID=karin;Password=********;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static public void AddNewContact(string firstname, string lastname)
        {

            SqlConnection myConnection = new SqlConnection(conStr);
            SqlCommand myCommand = new SqlCommand();

            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;
            myCommand.CommandText = "spCreateContact";

            SqlParameter paramFirstName = new SqlParameter("@firstName", SqlDbType.VarChar, 255);
            paramFirstName.Value = firstname;
            myCommand.Parameters.Add(paramFirstName);

            SqlParameter paramLastName = new SqlParameter("@lastName", SqlDbType.VarChar, 255);
            paramLastName.Value = lastname;
            myCommand.Parameters.Add(paramLastName);

            SqlParameter paramID = new SqlParameter("@new_id", SqlDbType.Int);
            paramID.Direction = ParameterDirection.Output;
            myCommand.Parameters.Add(paramID);
            try
            {
                myConnection.Open();

                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }
        }

        static public Contact GetContact(string cid)
        {
            Contact tmpContact = null;

            SqlConnection myConnection = new SqlConnection(conStr);
            SqlCommand myCommand = new SqlCommand();

            string strCmd = $"select * from Contact where ID = '{cid}'";

            myCommand.CommandText = strCmd;
            myCommand.Connection = myConnection;

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    string id = myReader["ID"].ToString();
                    string firstname = myReader["firstname"].ToString();
                    string lastname = myReader["lastname"].ToString();
                    tmpContact = new Contact(firstname, lastname, id);
                }
            }
            catch (Exception ex)
            {
                // Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }

            return tmpContact;

        }

        static public void UpdateContact(string cid, string firstname, string lastname)
        {

            SqlConnection myConnection = new SqlConnection(conStr);
            string strCmd = $"update Contact set Firstname='{firstname}', Lastname='{lastname}' where ID = '{cid}'";
            SqlCommand myCommand = new SqlCommand(strCmd, myConnection);
            
            try
            {
                myConnection.Open();

                myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                // Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }
        }

        static public List<Contact> LoadContacts()
        {
            List<Contact> contactList = new List<Contact>();
            contactList.Clear();

            SqlConnection myConnection = new SqlConnection(conStr);
            SqlCommand myCommand = new SqlCommand();

            string strCmd = "select * from Contact order by ID";

            myCommand.CommandText = strCmd;
            myCommand.Connection = myConnection;

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    contactList.Add(new Contact(myReader["FirstName"].ToString(), myReader["LastName"].ToString(), myReader["ID"].ToString()));
                }
            }
            catch (Exception ex)
            {
                //Response.Write($"<script>alert('{ex.Message}');</script>");
            }
            finally
            {
                myConnection.Close();
            }

            return contactList;
        }

        static public void RemoveContact(string cid)
        {
            {
                SqlConnection myConnection = new SqlConnection(conStr);

                try
                {
                    SqlCommand myCommand = new SqlCommand();

                    string strCmd = $"delete Contact where ID = '{cid}'";

                    myCommand.CommandText = strCmd;
                    myCommand.Connection = myConnection;
                    myConnection.Open();
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    //Response.Write($"<script>alert('{ex.Message}');</script>");
                }
                finally
                {
                    myConnection.Close();
                }

            }
        }
    }
}
