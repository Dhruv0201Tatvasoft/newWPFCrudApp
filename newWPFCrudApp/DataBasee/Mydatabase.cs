using System.Data;
using System.Data.SqlClient;
using System.Windows;
namespace newWPFCrudApp.DataBasee
{
    internal class Mydatabase
    {
        private string myconnectionString;

        public Mydatabase()
        {
            myconnectionString = @"Server=192.168.0.5;Database=dhruvkhoradiya_db;User Id=dhruv4;password=Th3xNXJX;";
        }
        /// <summary>
        /// this method will establish connection to database
        /// </summary>
        /// <returns> SqlConnection object after creating successful connection</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(myconnectionString);
        }

        /// <summary>
        /// this method will first get SqlConnection and then create SqlCommand and then execute it.
        /// </summary>
        /// <param name="sql">this is actual Sql query which we want to perform on database </param>
        public void executeQuery(string sql)
        {
            try
            {
                SqlConnection conn = GetConnection();
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                /// Exeption number 2627 belongs to Duplicate primary key exception. 
              if(ex.Number == 2627) {
                    MessageBox.Show("There is already a Person with same User Id");
                }
                else
                {
                    MessageBox.Show("Some error occured");
                }
            }
        }

        public bool doesExixst(string userId)
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(myconnectionString))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand($"select * from Persons where UserId = '{userId}'", conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }


            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt.Rows.Count > 0;
        }

        /// <summary>
        /// this method will give the actual data table from the databases.  
        /// </summary>
        /// <returns>Table from the database</returns>
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            try
            {
                {
                    using (SqlConnection conn = new SqlConnection(myconnectionString))
                    {
                        conn.Open();
                        using (SqlCommand command = new SqlCommand("SELECT * FROM Persons", conn))
                        {
                            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                            {
                                adapter.Fill(dt);
                            }
                        }
                    }
                }
            }
            
          
            catch (Exception)
            {
                MessageBox.Show("Error in Fetching data from database");
            }
            return dt;
        }

        /// <summary>
        /// this method is used to insert item to the database
        /// </summary>
        /// <param name="Firstname">firstname of person</param>
        /// <param name="Lastname">lastname of person</param>
        /// <param name="Birthdate">birthdate of person</param>
        /// <param name="Gender">gender of person</param>
        /// <param name="title">selected title of person</param>
        /// <param name="Interests">selected interest from the user </param>
        /// <param name="UserId">user id of the user</param>
        public void insertQuery(string Firstname, string Lastname, string Birthdate, string Gender, string title, string Interests,string UserId)
        {
            try
            {
                if ((!String.IsNullOrEmpty(UserId)) && (String.IsNullOrEmpty(Firstname) && String.IsNullOrEmpty(Lastname)))
                {
                    MessageBox.Show("Cant Update User Id");
                    return;
                }
                else if (String.IsNullOrEmpty(Firstname) || String.IsNullOrEmpty(Lastname) || String.IsNullOrEmpty(UserId)) {
                    MessageBox.Show("Empty Firstname,Lastname Or Userid");
                    return;
                }
             
                     string sQuery = String.Format("INSERT INTO Persons (Firstname, Lastname, Birthdate, Gender, Title, Interests,UserId) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}')", Firstname, Lastname, Birthdate, Gender, title, Interests,UserId);
                     this.executeQuery(sQuery);
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error in insertQuery: " + ex.Message, "Error", MessageBoxButton.OK);
            }
            
        } 
       
        /// <summary>
        /// this method will update the item in databse
        /// </summary>
        /// <param name="nFirstname">updated firstname of person </param>
        /// <param name="nLastname">updated lastname of person</param>
        /// <param name="nBirthDate">updated birthdate of person</param>
        /// <param name="nGender">updated Gender of person</param>
        /// <param name="nTitle">updated title of person</param>
        /// <param name="nInterests">updated interest of person</param>
        /// <param name="nUserId">updated userId</param>
        /// <param name="oUserId">old userId of person</param>
        public void updateQuery(string nFirstname, string nLastname, string nBirthDate, string nGender, string nTitle, string nInterests, string nUserId, string oUserId)
        {
            if(nUserId!=oUserId) {
                MessageBox.Show("Cant Update User id");
                return;
            }
            if(String.IsNullOrEmpty(nFirstname) || String.IsNullOrEmpty(nLastname))
            {
                
                MessageBox.Show("Empty Firstname or Lastname");
                return;
            }

            try
            {

            string uQuery = String.Format("UPDATE Persons SET Firstname='{0}',Lastname='{1}',Birthdate='{2}',Gender='{3}',Title='{4}',Interests='{5}',UserId='{6}' where UserId='{7}'", nFirstname, nLastname, nBirthDate, nGender, nTitle, nInterests, nUserId, oUserId);
            this.executeQuery(uQuery);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in updateQuery: " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// this method will delete the entry from the table.
        /// </summary>
        /// <param name="UserId">UserId of user to be deleted.</param>
        public void deleteQuery(string UserId)
        {
            try
            {
                string sql = String.Format("DELETE FROM Persons WHERE UserId='{0}'", UserId);
                this.executeQuery(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is error to delete item " + ex.Message, "Error", MessageBoxButton.OK);
            }
        }
}
  }
