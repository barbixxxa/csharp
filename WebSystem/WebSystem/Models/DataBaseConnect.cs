using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace WebSystem.Models
{
    public class DataBaseConnect
    {
        private MySqlConnection connection; //open a connection to the DB
        private string server; //location of the server
        private string database; //name of the DB
        private string uid; //username 
        private string password; //password


        //Constructor
        public DataBaseConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "WebSystem";
            uid = "root";
            password = "";

            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to DB
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {

                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact ADM");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, plesa retry");
                        break;
                }
                return false;
            }

        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;

            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        //Insert statement
        public void Insert(User usuario)
        {
            //create query
            string query = "INSERT INTO user " + "(username, password, name, email) VALUES('" + usuario.UserLogin + "', '" + usuario.UserPassword + "', '" + usuario.UserName + "', '" + usuario.UserEmail + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(User usuario)
        {
            string query = "UPDATE user SET username='" + usuario.UserLogin + "', password='" + usuario.UserPassword + "', name='" + usuario.UserName + "', email='" + usuario.UserEmail + "' WHERE id=" + usuario.UserId;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(int id)
        {
            string query = "DELETE FROM user WHERE id=" + id;
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Search user
        public User Search(int id)
        {
            User userFound = new User();

            string query = "SELECT * FROM user WHERE id =" + id;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //create a data reader and execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    userFound.UserId = int.Parse(dataReader["id"].ToString());
                    userFound.UserLogin = dataReader["username"].ToString();
                    userFound.UserPassword = dataReader["password"].ToString();
                    userFound.UserName = dataReader["name"].ToString();
                    userFound.UserEmail = dataReader["email"].ToString();
                }
                //close Data Reader
                dataReader.Close();

                //close connection
                this.CloseConnection();

                return userFound;


            }
            else
            {
                return userFound;
            }
        }

        //Select statement
        public List<User> Select()
        {
            List<User> UsersList = new List<User>();
            User usuario;

            string query = "SELECT * FROM user";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //create a data reader and execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    usuario = new User();
                    usuario.UserId = int.Parse(dataReader["id"].ToString());
                    usuario.UserLogin = dataReader["username"].ToString();
                    usuario.UserPassword = dataReader["password"].ToString();
                    usuario.UserName = dataReader["name"].ToString();
                    usuario.UserEmail = dataReader["email"].ToString();

                    UsersList.Add(usuario);
                }

                //close Data Reader
                dataReader.Close();

                //close connection
                this.CloseConnection();

                return UsersList;
            }
            else
            {
                return UsersList;
            }



        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM user";
            int count = -1;
            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return count;
            }
            else
            {
                return count;
            }
        }


    }
}