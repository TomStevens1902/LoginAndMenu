namespace Login_Menu
{
    internal class Program
    {
        // constants
        const string USERNAME = "admin";
        const string PASSWORD = "Password123";
        static void Main(string[] args)
        {
            Login();
            Menu();
        }

        static void Login()
        {
            bool validLogin = false;
            do
            {
                // asks for username and password
                Console.Write("Username: ");
                string? inputUsername = Console.ReadLine();

                Console.Write("Password: ");
                string? inputPassword = Console.ReadLine();

                // validates input
                if ((inputUsername.ToLower() == USERNAME.ToLower()) && inputPassword == PASSWORD)
                {
                    validLogin = true;
                } else
                {
                    // adds an error message if input was invalid
                    Console.Clear();
                    Console.WriteLine("-- ! Incorrect Username or Password ! --");
                }

            } while (!validLogin);
            /* 
            - Used as the loop will always need to loop once
            - previously i had a call to a login method before and inside the loop and
              so i have improved readability
             */
        }

        static void Menu()
        {
            bool prevInputValid = true;
            bool exitMenu = false;

            do
            {
                // displays the menu
                Console.Clear();
                Console.WriteLine(""" 
                -- Main Menu --
                1. Create new member
                2. Edit member
                3. View member
                4. Delete member
                x. Exit

                """);

                // asks the user to provide an option.
                // provides a prompt if previous input was invalid
                Console.Write(prevInputValid ? "Please enter an option: " : "--! Invalid Input !--\nPlease enter an option: ");

                string? input = Console.ReadLine();
                int option = 0;

                // tries to determine if the input is an interger
                if (int.TryParse(input, out option))
                {
                    Console.Clear(); // clear menu before displaying option
                    // if option is an interger try and display a menu option
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Create new member");
                            break;
                        case 2:
                            Console.WriteLine("Edit member");
                            break;
                        case 3:
                            Console.WriteLine("View member");
                            break;
                        case 4:
                            Console.WriteLine("Delete member");
                            break;
                        default:
                            // if interger was not a valid option then provide invalid prompt
                            prevInputValid = false;
                            continue; // used to jump back to the start of the loop
                    }
                    prevInputValid = true;
                    Console.ReadLine();
                } else if (input == "x") // exit condition
                {
                    exitMenu = true;
                } else // user provided a non int and so should be handled as invalid
                {
                    prevInputValid = false;
                }

            } while (!exitMenu);
            /* 
            - Used as the loop will always need to loop once
            - previously i had this loop as a infinite while(true) relying on Environment.Exit(0); to
              exit the program. Now it relies on a condition and exits the program normally 
             */
        }
    }
}
