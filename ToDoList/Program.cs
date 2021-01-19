using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
        
        // while programTerminate != true ; run...

        static void Main(string[] args)
        {
            UI ui = new UI();

            ui.Greeting(); // print greeting message 
            ui.PrintUserInstructions(); // print user instructions
           // Greeting() , UserInstructions() ; both printed at start before while loop.
            
        // while loop start
            while (ui.getProgramTerminate != true) // getProgramTerminate
            {
                // connect to database
                ui.AwaitUserInstrucitons();
                
                ui.RespondToUserInstructions(ui.getUserInstruction); // getUserInstruction
                // close connection to database
            } // while loop end

        }

    }
}
