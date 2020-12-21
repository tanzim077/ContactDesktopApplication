using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDesktopApplication.ContactClasses
{
    class ContactClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnectionstring = ConfigurationManager.ConnectionStrings["constrings"].ConnectionString;

        public DataTable Select()
        {
            //Database Connection
            SqlConnection con = new SqlConnection(myconnectionstring);
            DataTable dt = new DataTable();
            try
            {
                //SQL Query
                string sql = "SELECT * FROM tbl_contact";
                SqlCommand cmd = new SqlCommand(sql, con);
                //
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);

            } 
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return dt;
        }

        //Insert Data is DB
        public bool Insert(ContactClass C)
        {
            bool issuccess = false;
            SqlConnection con = new SqlConnection(myconnectionstring);
           
            try
            {
                //SQL Query
                string sql = "INSERT INTO tbl_contact(Name, Email, City, ContactNo, Address, Gender) VALUES (@Name, @Email, @City, @ContactNo, @Address, @Gender )";
                SqlCommand cmd = new SqlCommand(sql, con);
                //
                cmd.Parameters.AddWithValue("@Name", C.Name);
                cmd.Parameters.AddWithValue("@Email", C.Email);
                cmd.Parameters.AddWithValue("@City", C.City);
                cmd.Parameters.AddWithValue("@ContactNo", C.ContactNo);
                cmd.Parameters.AddWithValue("@Address", C.Address);
                cmd.Parameters.AddWithValue("@Gender", C.Gender);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows>0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                con.Close();
            }
            return issuccess;
        }

        //Update
        public bool Update(ContactClass c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnectionstring);

            try
            {
                //SQL Query
                string sql = "UPDATE tbl_contact SET Name=@Name, Email=@Email, City=@City , ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //
                cmd.Parameters.AddWithValue("@ID", c.ID);
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@City", c.City);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

               
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Delete
        public bool Delete(ContactClass C)
        {
            bool issuccess = false;
            SqlConnection con = new SqlConnection(myconnectionstring);

            try
            {
                //SQL Query
                string sql = "DELETE FROM tbl_contact  WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql, con);
                //
                cmd.Parameters.AddWithValue("@ID", C.ID);

                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            finally
            {
                con.Close();
            }
            
            return issuccess;
        }
    }

}
