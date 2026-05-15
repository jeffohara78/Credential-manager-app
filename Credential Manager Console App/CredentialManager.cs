/*
 * Jeff O'Hara 
 * 5-12-26
 * This program is a simple console application that allows users to manage their credentials (website, username, and password) in memory. 
 * It provides functionality to add new credentials, view all saved credentials, search for credentials by website name, and delete credentials. 
 * The application uses a Credential class to represent individual credentials and a CredentialManager class to handle the operations on the list of credentials.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credential_Manager_Console_App
{

    // This class manages the list of saved credentials and handles adding, viewing, searching, and deleting credentials.
    public class CredentialManager
    {
        // This list stores all Credential objects created by the user.
        private List<Credential> credentials = new List<Credential>();

        // Adds a new credential to the list by prompting the user for website, username, and password.
        public void AddCredential()
        {
            Console.Write("Enter website name:");
            string website = Console.ReadLine();

            Console.Write("Enter username or email: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            // Create a new Credential object using the user's input and add it to the credentials list.
            Credential newCredential = new Credential(website, username, password);

            // Add the new credential to the list of credentials.
            credentials.Add(newCredential);

            Console.Write("Credential added successfully!");
        }

        // Displays every credentials in the credentials list, showing the website, username, and password for each one.
        public void ViewAllCredentials()
        {
            if (credentials.Count == 0)
            {
                Console.Write("No credentials have been saved yet.");
                return;
            }

            Console.WriteLine("***  Saved Credentials  ***");

            // Loop through the credentials list and display the details of each credential.
            for (int i = 0; i < credentials.Count; i++)
            {
                Console.WriteLine($"\nCredential #{i + 1}");
                Console.WriteLine($"Website: {credentials[i].Website}");
                Console.WriteLine($"Username: {credentials[i].Username}");
                Console.WriteLine($"Password: {credentials[i].Password}");
            }
        }

        // Searches for credentials by website name. It prompts the user for a search term and displays any credentials that match the search term.
        public void SearchCredential()
        {
            Console.Write("Enter website name to search for: ");
            string searchWebsite = Console.ReadLine();

            bool found = false;

            Console.WriteLine("\n*** Search Results ***");

            // Loop through the list and display any credentials where the website name contains the search term (case-insensitive).
            foreach (Credential credential in credentials)
            {
                // ToLower() is used to make the search case-insensitive, allowing for matches regardless of capitalization.
                // This means Amazon, amazon, and AMAZON would all match if the search term is "amazon".
                if (credential.Website.ToLower().Contains(searchWebsite.ToLower()))
                {
                    Console.WriteLine($"\nWebsite: {credential.Website}");
                    Console.WriteLine($"Username: {credential.Username}");
                    Console.WriteLine($"Password: {credential.Password}");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching credentials found.");
            }
        }

        // Deletes a credential from the list. It first displays all credentials with a number next to each one, then prompts the user to enter the number of the credential they want to delete.
        public void DeleteCredential()
        {
            ViewAllCredentials();

            if (credentials.Count == 0)
            {
                Console.WriteLine("There are no credentials to delete.");
                return;
            }

            Console.Write("\n*** Current Credentials ***");

            // Display credentials with clear numbering so the user can easily select which one to delete. The numbering starts at 1 for user-friendliness, but the index in the list is zero-based, so we will subtract 1 from the user's input when accessing the list.
            for (int i = 0; i < credentials.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {credentials[i].Website} ({credentials[i].Username})");
            }

            Console.Write("\nEnter the number of the credential you want to delete: ");

            // Read the user's input and attempt to parse it as an integer. If the input is not a valid number, display an error message and return from the method.
            string input = Console.ReadLine();

            bool isValidNumber = int.TryParse(input, out int credentialNumber);

            if (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return;
            }

            // Conver the user's input (which is 1-based) to a zero-based index for accessing the credentials list. For example, if the user enters "1", we want to access index 0 in the list.
            int index = credentialNumber - 1;

            // Verify the number is within the valid range of existing credentials. If it is, remove the credential at that index from the list and confirm deletion to the user. If the number is out of range, display an error message.
            if (index >= 0 && index < credentials.Count)
            {
                // Store the website of the credential being deleted so we can display it in the confirmation message after deletion.
                string deletedWebsite = credentials[index].Website;

                // Remove the credential at the specified index from the credentials list.
                credentials.RemoveAt(index);

                Console.WriteLine($"Credential for '{deletedWebsite}' has been deleted successfully.");
            }
            else
            {
                Console.WriteLine("That credential number does not exist");
            }
        }
    }
}
