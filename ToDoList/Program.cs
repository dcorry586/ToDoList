using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
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

        }
        static void AddTask() // insert string into SQL Server DB
        {

        }
        static void ViewTasks() // Read all task strings from DB and print out to console
        {

        }
        static void EditTask() // update specifieed task string in console and update previously stored version of this task string in DB
        {

        }
        static void DeleteTask() // remove specified task string from DB
        {

        }

        static void AwaitUserInstrucitons() 
        {

        }

        static void RespondToUserInstructions()
        {
            
        }

        static void Main(string[] args)
        {
            Greeting(); // print greeting message 
            UserInstructions(); // print user instructions
            AwaitUserInstrucitons();// Await user insutructions // so key wait() ... parse input maybe?? or...
            RespondToUserInstructions();

        }

        

    }
}
