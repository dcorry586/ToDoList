using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
        
        static bool programTerminate = false; // variable to base while loop off
        static string userInstruction;

        static void Greeting()
        {
            Console.WriteLine("Welcome To Task Manager Ultimate!");
        }

        static void UserInstructions()
        {
            Console.WriteLine("User Options : \n");
            Console.WriteLine("Each command has a key inside the parenthesis - ( ).\n Type in this key to specify what you want the program to do.");
            Console.WriteLine("Add Task (add) \n");
            Console.WriteLine("View Tasks (list) \n");
            Console.WriteLine("Edit Task (edit) \n");
            Console.WriteLine("Delete Task (delete) \n");
            Console.WriteLine("Exit (exit) \n");

        }
        static void AddTask() // insert string into SQL Server DB
        {
            Console.WriteLine("AddTask() has been called \n");
        }
        static void ViewTasks() // Read all task strings from DB and print out to console
        {
            Console.WriteLine("ViewTask() has been called \n");
        }
        static void EditTask() // update specifieed task string in console and update previously stored version of this task string in DB
        {
            Console.WriteLine("EditTask() has been called \n");
        }
        static void DeleteTask() // remove specified task string from DB
        {
            Console.WriteLine("DeleteTask() has been called \n");
        }

        static void AwaitUserInstrucitons() 
        {
            Console.WriteLine("AwaitUserInstructions has been called \n");
            Console.WriteLine(">\t");
            // get input from user
            userInstruction = Console.ReadLine();
        }

        
        static void RespondToUserInstructions(string userInstruction_)
        {
            userInstruction_ = userInstruction;

            Console.WriteLine("RespondToUserInstructions() has been called \n");
            // if userInstruction == "exit" { programTerminate = true; }
            switch (userInstruction_)
            {
                case "add":
                    Console.WriteLine("Add has been entered \n");
                    break;
                case "view":
                    Console.WriteLine("view has been entered \n");
                    break;
                case "edit":
                    Console.WriteLine("edit has been entered \n");
                    break;
                case "delete":
                    Console.WriteLine("delete has been entered \n");
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


        // while programTerminate != true ; run...

        static void Main(string[] args)
        {
            Greeting(); // print greeting message 
            UserInstructions(); // print user instructions
           // Greeting() , UserInstructions() ; both printed at start before while loop.
            
        // while loop start
      

            while (programTerminate != true)
            {
                AwaitUserInstrucitons();
                
                RespondToUserInstructions(userInstruction);
            }
          //  AwaitUserInstrucitons();// Await user insutructions // so key wait() ... parse input maybe?? or...
            //RespondToUserInstructions();
            // while loop end
        }

    }
}
