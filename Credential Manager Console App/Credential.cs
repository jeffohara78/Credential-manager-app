using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credential_Manager_Console_App
{

    // This class represents 1 saved login credential, which includes the website, username/email, and password.
    public class Credential
    {
        // Use get; set; properties to allow easy access and modification of the credential fields.
        public string Website { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        // Constructor for whenever a new Credential object is created
        public Credential(string website, string username, string password)
        {
            Website = website;
            Username = username;
            Password = password;
        }
    }
}
