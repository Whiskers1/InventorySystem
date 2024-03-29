﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using InventorySystem;

namespace InventorySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new ViewModel.LoginViewModel();
            //Content = new ViewModel.TabViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoginViewModel loginViewModelObject = new ViewModel.LoginViewModel();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.TabViewModel TabViewModelObject = new ViewModel.TabViewModel();

        }

        /// <summary>
        /// 
        /// </summary>
        public class DBConnect
        {
            private MySqlConnection connection;
            private string server;
            private string database;
            private string uid;
            private string password;

            //Constructor
            public DBConnect()
            {
                Initialize();
            }

            //Initialize values
            private void Initialize()
            {
                server = "127.0.0.1";
                database = "inventory_system";
                uid = "root";
                password = "admin";

                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

                connection = new MySqlConnection(connectionString);
            }

            //open connection to database
            private bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
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
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }

            //GetAdmin statement
            public List<string>[] GetAdmin()
            {
                string query = "SELECT * FROM admin_users";

                //Create a list to store the result
                List<string>[] list = new List<string>[3];
                list[0] = new List<string>();
                list[1] = new List<string>();
                list[2] = new List<string>();

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        list[0].Add(dataReader["id"] + "");
                        list[1].Add(dataReader["name"] + "");
                        list[2].Add(dataReader["pass"] + "");
                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    this.CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }

            /*
            //Insert statement
            public void Insert(string query)
            {
                //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }

            //Update statement
            public void Update(string query)
            {
                //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }

            //Delete statement
            public void Delete(string query)
            {
                //string query = "DELETE FROM tableinfo WHERE name='John Smith'";

                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
           
            //Select statement
            public List<string>[] Select()
            {
            }
            
            //Count statement
            public int Count(string query)
            {
                //string query = "SELECT Count(*) FROM tableinfo";
                int Count = -1;

                //Open Connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //ExecuteScalar will return one value
                    Count = int.Parse(cmd.ExecuteScalar() + "");

                    //close Connection
                    this.CloseConnection();

                    return Count;
                }
                else
                {
                    return Count;
                }
            }
            */

            //Backup
            public void Backup()
            {
                try
                {
                    DateTime Time = DateTime.Now;
                    int year = Time.Year;
                    int month = Time.Month;
                    int day = Time.Day;
                    int hour = Time.Hour;
                    int minute = Time.Minute;
                    int second = Time.Second;
                    int millisecond = Time.Millisecond;

                    //Save file to C:\ with the current date as a filename
                    string path;
                    path = "C:\\MySqlBackup" + year + "-" + month + "-" + day + "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                    StreamWriter file = new StreamWriter(path);


                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "mysqldump";
                    psi.RedirectStandardInput = false;
                    psi.RedirectStandardOutput = true;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                        uid, password, server, database);
                    psi.UseShellExecute = false;

                    Process process = Process.Start(psi);

                    string output;
                    output = process.StandardOutput.ReadToEnd();
                    file.WriteLine(output);
                    process.WaitForExit();
                    file.Close();
                    process.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error , unable to backup!");
                }
            }

            //Restore
            public void Restore()
            {
                try
                {
                    //Read file from C:\
                    string path;
                    path = "C:\\MySqlBackup.sql";
                    StreamReader file = new StreamReader(path);
                    string input = file.ReadToEnd();
                    file.Close();

                    ProcessStartInfo psi = new ProcessStartInfo();
                    psi.FileName = "mysql";
                    psi.RedirectStandardInput = true;
                    psi.RedirectStandardOutput = false;
                    psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                        uid, password, server, database);
                    psi.UseShellExecute = false;


                    Process process = Process.Start(psi);
                    process.StandardInput.WriteLine(input);
                    process.StandardInput.Close();
                    process.WaitForExit();
                    process.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Error , unable to Restore!");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Log
        {
            public int Id { get; set; }

            public int ItemId { get; set; }

            public int UserId { get; set; }

            public int AdminId { get; set; }

            public DateTime DateTime { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Item
        {
            public int Id { get; set; }

            public int ItemId { get; set; }

            public string Name { get; set; }

            public int Amount { get; set; }

            public string Details
            {
                get
                {
                    return String.Format("Details for item nr: {0} - name: {1}.", this.Id, this.Name);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class User
        {
            public int Id { get; set; }

            public string UniLog { get; set; }

            public string Name { get; set; }

            public string Email { get; set; }

            public int PhoneNr { get; set; }

            public string Code { get; set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public class Admin
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        
    }
}
