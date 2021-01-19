using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ToDoList
{
    class DatabaseImplementation
    {
        // global variables
        private bool programTerminate = false; // variable to base while loop off
        private string userInstruction;
        public bool CheckIfConnectedToDB;

        static string TaskTitle, TaskDescription;

        internal string userTaskTitle;
        internal string userTaskDescription;

        // remove values from the following once final push has come!!!!
        static string datasource = @"";//your server
        static string database = ""; //your database name
        static string username = ""; //username of server to connect
        static string password = ""; //password
                                           //

        // global connection string 
        static string connString = @"Data Source=" + datasource + ";Initial Catalog="
                       + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

        // create instance of database connection
        SqlConnection conn = new SqlConnection(connString);

        StringBuilder strBuilder = new StringBuilder();



        // property for userInstruction
        public string getUserInstruction
        {
            get { return userInstruction; }
            set { userInstruction = value; }
        }

        public bool getProgramTerminate
        {
            get { return programTerminate; }
            set { programTerminate = value; }
        }

        // can i do a prop for private Greeting() ?

        internal void ConnectToDB()
        {
            conn.Open();
            CheckIfConnectedToDB = true;
        }

        // add task
        public void AddTask() 
        {
            Console.WriteLine("AddTask() has been called \n");

            // enter Task Title
            Console.WriteLine("Enter Task Title: ");
            // get input
            userTaskTitle = Console.ReadLine();
            // enter Task Description
            Console.WriteLine("Enter Task Description: ");
            // get input 
            userTaskDescription = Console.ReadLine();

            // INSERT INTO Task (TaskTitle, TaskDescription) VALUES (userTaskTitle, userTaskDescription);

            //add Query to update to Student_Details table

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                // }

                StringBuilder strBuilder = new StringBuilder();

                // add query to read database table Task
                strBuilder.Append($"INSERT INTO Task (TaskTitle, TaskDescription) VALUES ('{userTaskTitle}', '{userTaskDescription}'); ");



                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) // pass SQL query created above and connection
                {
                    //int rowsAffected = command.ExecuteNonQuery();
                    //Console.WriteLine(rowsAffected + " row(s) updated"); // For logging purposes only!! - Remeber


                    command.ExecuteNonQuery();

                    Console.WriteLine("Added new task successfully!");

                    // close connection
                    CloseConnecitonToDB();
                    Console.WriteLine("Connection closed");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();


        } // end of AddTask()

        // view all tasks
        public void ViewTasks() 
        { // start of ViewTasks()


            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                // }

                StringBuilder strBuilder = new StringBuilder();

                strBuilder.Clear();

                // add query to read database table Task
                strBuilder.Append("SELECT * FROM Task;");


                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) // pass SQL query created above and connection
                {
                    //int rowsAffected = command.ExecuteNonQuery();
                    //Console.WriteLine(rowsAffected + " row(s) updated"); // For logging purposes only!! - Remeber
                    Console.WriteLine("Read database successful!");

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TaskTitle = reader.GetString(0);
                            TaskDescription = reader.GetString(1);

                            Console.WriteLine("Task Title : {0}, Task Description : {1}", TaskTitle, TaskDescription);
                        }
                    }

                    reader.Close();

                    Console.WriteLine("Reader closed.");

                    // close connection
                    conn.Close();
                    Console.WriteLine("Connection closed");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();


        } // end of ViewTasks()

        // edit tasks
        public void EditTask() // update specifieed task string in console and update previously stored version of this task string in DB
        {
            Console.WriteLine("EditTask() has been called \n");

            Console.WriteLine("Enter name of Task Title you want to edit: ");
            // get TaskTitle
            userTaskTitle = Console.ReadLine();
            Console.WriteLine("Enter new Task Description: ");
            // get TaskDescription
            userTaskDescription = Console.ReadLine();

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                // }

                StringBuilder strBuilder = new StringBuilder();

                // add query to read database table Task
                strBuilder.Append($" UPDATE Task SET TaskDescription = '{userTaskDescription}' WHERE TaskTitle = '{userTaskTitle}'; ");

                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) // pass SQL query created above and connection
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Task updated!");

                    CloseConnecitonToDB();

                    Console.WriteLine("Connection closed");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();


        }
        public void DeleteTask() // remove specified task string from DB
        {
            Console.WriteLine("DeleteTask() has been called \n");


            Console.WriteLine("Enter name of Task Title you want to delete: ");
            // get TaskTitle
            userTaskTitle = Console.ReadLine();

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();

                Console.WriteLine("Connection successful!");
                // }

                StringBuilder strBuilder = new StringBuilder();

                // add query to read database table Task
                strBuilder.Append($" DELETE  FROM Task WHERE TaskTitle = '{userTaskTitle}'; ");

                string sqlQuery = strBuilder.ToString();
                using (SqlCommand command = new SqlCommand(sqlQuery, conn)) // pass SQL query created above and connection
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Task Deleted!");

                    CloseConnecitonToDB();

                    Console.WriteLine("Connection closed");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            Console.Read();

        } // end of DeleteTask()

        // closes connection to Microsoft SQL Server and databse
        internal void CloseConnecitonToDB()
        {
            conn.Close();
            Console.WriteLine("Connection closed");
            CheckIfConnectedToDB = true;
        }
        

    } // end of class 
} // end of namespace
