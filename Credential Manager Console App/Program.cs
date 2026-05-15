using System;

namespace Credential_Manager_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create 1 CredentialManager instance to manage all credentials/work
            CredentialManager manager = new CredentialManager();

            bool running = true;

            // Main program loop to display menu and handle user input
            while (running)
            {
                Console.WriteLine("\nCredential Manager");
                Console.WriteLine("1. Add Credential");
                Console.WriteLine("2. View All Credentials");
                Console.WriteLine("3. Search Credential");
                Console.WriteLine("4. Delete Credential");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    manager.AddCredential();
                }
                else if (choice == "2")
                {
                    manager.ViewAllCredentials();

                }
                else if (choice == "3")
                {
                    manager.SearchCredential();
                }
                else if (choice == "4")
                {
                    manager.DeleteCredential();
                }
                else if (choice == "5")
                {
                    running = false;
                    Console.WriteLine("Exiting Credential Manager. Goodbye.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a number between 1 and 5.");
                }

            }
        }
    }
}