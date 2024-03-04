namespace Login_Menu
{
    internal class Program
    {
        // constants
        const string USERNAME = "admin";
        const string PASSWORD = "Password123";

        static void Main(string[] args)
        {
            // validate user login
            bool valid = Login();
            while (!valid)
            {
                // ask for login information again
                Console.Clear();
                Console.WriteLine("-- ! Incorrect Username or Password ! --");
                valid = Login();
            }


            Console.Clear();
            // provide menu options within a loop
            valid = true;
            while (true) // allows user to try all options. x is used to escape.
            {
                // if input was invalid provide a prompt
                valid = (!HandleOptionInput(valid)) ? false : true;

                // clear previous output
                Console.Clear();
            }
        }

        static bool Login()
        {
            // asks for username and password
            Console.Write("Username: ");
            string? inputUsername = Console.ReadLine();

            Console.Write("Password: ");
            string? inputPassword = Console.ReadLine();

            // validates input
            if ((inputUsername.ToLower() == USERNAME.ToLower()) && inputPassword == PASSWORD)
            {
                return true;
            }
            return false;
        }

        static void DisplayMenu()
        {
            Console.WriteLine(""" 
                -- Main Menu --
                1. Create new member
                2. Edit member
                3. View member
                4. Delete member
                x. Exit

                """);
        }

        static bool HandleOptionInput(bool prevInputValid)
        {
            // display menu
            DisplayMenu();

            // ask for input
            if (prevInputValid) // provides a prompt if previous input was invalid
                Console.Write("Please enter an option: ");
            else 
                Console.Write("""
                    -- ! Invalid Input ! --
                    Please enter an option: 
                    """);

            string? input = Console.ReadLine();


            int option = 0;
            // validate its a number
            try
            {
                option = int.Parse(input);
            } 
            catch 
            {
                // check if its an x
                if (input == "x")
                {
                    // exit application
                    Environment.Exit(0);
                } else
                {
                    // ask again
                    return false;
                }
            }

            Console.Clear(); // clear menu before displaying option
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
                    // ask again
                    return false;
                    //break;
            }

            // correct output
            Console.ReadLine(); // provides a pause to read output
            return true;
        }
    }
}
