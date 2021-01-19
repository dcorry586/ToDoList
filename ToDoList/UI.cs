/*
 * Program.cs
 * 
 * Version information
 * 
 * Author: Dylan Corry
 * Date: 19/01/2021 
 * Description: clas for user interface.
 * 
 * Copyright notice
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ToDoList
{
    class UI
    {
        // instantiate DatabaseImplementation class
        DatabaseImplementation DB = new DatabaseImplementation();


        // global variables
        private bool programTerminate = false; // variable to base while loop off
        private string userInstruction;
       public bool CheckIfConnectedToDB;

        static string TaskTitle, TaskDescription;

       internal string userTaskTitle;
        internal string userTaskDescription;
        

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

        internal void Greeting()
        {
            Console.WriteLine("Welcome To Task Manager Ultimate!");
        }

         internal void PrintUserInstructions()
        {
            Console.WriteLine("\nUser Options : \n");
            Console.WriteLine("Each command has a key inside the parenthesis - ( ).\n Type in this key to specify what you want the program to do.");
            Console.WriteLine("\nAdd Task (add) \n");
            Console.WriteLine("View Tasks (list) \n");
            Console.WriteLine("Edit Task (edit) \n");
            Console.WriteLine("Delete Task (delete) \n");
            Console.WriteLine("Exit (exit) \n");

        }

         internal void AwaitUserInstrucitons()
        {
            Console.WriteLine("AwaitUserInstructions has been called \n");
            Console.WriteLine("-> ");
            // get input from user
            getUserInstruction = Console.ReadLine();
        }


         internal void RespondToUserInstructions(string userInstruction_)
        {
            userInstruction_ = getUserInstruction;

            Console.WriteLine("RespondToUserInstructions() has been called \n");
            // if userInstruction == "exit" { programTerminate = true; }
            switch (userInstruction_)
            {
                case "add":
                    DB.AddTask();
                    break;
                case "view":
                    DB.ViewTasks();
                    break;
                case "edit":
                    DB.EditTask();
                    break;
                case "delete":
                    DB.DeleteTask();
                    break;
                case "exit":
                    Console.WriteLine("Program exiting...");
                    programTerminate = true;
                    break;
                default:
                    Console.WriteLine("Error : userInstruction incomprehensible. \n");
                    break;
            }
        }

    }
}
