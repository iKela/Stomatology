//using System;
//using System.Data.SqlClient;
//using System.Windows.Forms;

//namespace Stomatology.Other
//{
//    public class Connector
//    {
//        /* Змінні для роботи з SQL */
//        private string connectionString;
//        protected SqlCommand command;
//        protected SqlConnection connection;
//        protected SqlDataReader reader;
//        public bool isOK = true;

//        /* Дані про акаунт */
//        protected string user_id = "";


//        /* Дані що мігрують між формами */
//        protected string MedCard_id = "";
//        //protected string custom_id = "";
//        protected string User_id = "";
//       // protected string clinic_id = "";

//        /* Getters */

//        public string getUserID()
//        {
//            return user_id;
//        }

//        public string getMedCardID()
//        {
//            return MedCard_id;
//        }

//        //public string getCustomID()
//        //{
//        //    return custom_id;
//        //}

//        //public string getDoctorID()
//        //{
//        //    return User_id;
//        //}


//        /* Setters */
//        //public void setClinicID(string clinic_id)
//        //{
//        //    this.clinic_id = clinic_id;
//        //}
//        public void setUserID(string user_id)
//        {
//            this.user_id = user_id;
//        }

//        public void setCard_id(string cID)
//        {
//            MedCard_id = cID;
//        }

//        //public void setCustomID(string cID)
//        //{
//        //    custom_id = cID;
//        //}

//        //public void setDoctorID(string dID)
//        //{
//        //    doctor_id = dID;
//        //}

//        public void setCommand(string target)
//        {
//            command.CommandText = target;
//        }


//        /* Constructor*/
//        public Connector()
//        {
//            try
//            {
//                connectionString = @" Data Source = insopdentistry.cywgv3xkqj2b.eu - west - 3.rds.amazonaws.com; Initial Catalog = Dentistry; Persist Security Info = True; User ID = iKela; Password = 6621Nazar";
//                connection = new SqlConnection(connectionString);

//                command = connection.CreateCommand();
//            }
//            catch (Exception ex)
//            {
//                connection.Close();
//                MessageBox.Show(ex.ToString());
//            }
//        }



//        public string getFullName(SqlDataReader source)
//        {
//            string tmp = source["surname"].ToString() + " " + source["name"].ToString() + " " + source["last_name"].ToString();
//            return tmp;
//        }
//        public string getCFullName(SqlDataReader source)
//        {
//            string tmp = source["card_surname"].ToString() + " " + source["card_name"].ToString() + " " + source["card_lname"].ToString();
//            return tmp;
//        }

//        public void showMessage(string text)
//        {
//            MessageBoxButtons btnOK = new MessageBoxButtons();
//            MessageBoxIcon icon = new MessageBoxIcon();
//            btnOK = MessageBoxButtons.OK;
//            icon = MessageBoxIcon.Warning;
//            MessageBox.Show(text, "Warning", btnOK, icon);
//        }

//        public void execute()
//        {
//            try
//            {
//                isOK = true;
//                connection.Open();
//                command.ExecuteNonQuery();
//                connection.Close();
//            }
//            catch (Exception ex)
//            {
//                isOK = false;
//                connection.Close();
//                showMessage(ex.ToString());
//            }
//        }

//        public double calculateTotalSum(int cID)
//        {
//            double cost = 0;
//            try
//            {
//                connection.Open();
//                command.CommandText = "select sum(wc.cost*wc.amount) as 'cost' from Work_Custom wc where custom_id='" + cID + "'";
//                reader = command.ExecuteReader();
//                if (reader.Read())
//                {
//                    string value = getReaderValue("cost");
//                    if (value != "")
//                        cost = Convert.ToDouble(value);
//                }
//                connection.Close();
//                return cost;
//            }
//            catch (Exception ex)
//            {
//                showMessage(ex.ToString());
//                connection.Close();
//                return cost;
//            }
//        }

//        public void loadSearchAutocomplete(ComboBox customer, ComboBox doctor, ComboBox phone)
//        {
//            setCommand("SELECT * FROM Card");
//            try
//            {
//                connection.Open();
//                reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    string fullName = getFullName(reader);
//                    string phoneNumber = getReaderValue("phone");
//                    customer.AutoCompleteCustomSource.Add(fullName);
//                    customer.Items.Add(fullName);

//                    phone.AutoCompleteCustomSource.Add(phoneNumber);
//                    phone.Items.Add(phoneNumber);
//                }
//                connection.Close();


//                setCommand("SELECT * FROM Users where type='2'");
//                connection.Open();
//                reader = command.ExecuteReader();
//                while (reader.Read())
//                {
//                    string fullName = getFullName(reader);
//                    doctor.AutoCompleteCustomSource.Add(fullName);
//                    doctor.Items.Add(fullName);
//                }
//                connection.Close();

//            }
//            catch (Exception ex)
//            {
//                connection.Close();
//                showMessage(ex.ToString());
//            }
//        }

//        public string getReaderValue(string columnName)
//        {
//            return reader[columnName].ToString();
//        }

//        public void FormAcivity(Form father, Form daughter)
//        {
//            daughter.Owner = father;
//            father.Hide();
//        }

//        public string generateStatus(int value)
//        {
//            string result = "";
//            switch (value)
//            {
//                case 1:
//                    result = "Відкрито";
//                    break;
//                case 2:
//                    result = "Виконано (не оплачено)";
//                    break;
//                case 3:
//                    result = "Виконано (оплачено)";
//                    break;
//            }

//            return result;
//        }

//    }
//}
