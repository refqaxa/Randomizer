using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerClassLibrary
{
    /// <summary>
    /// Represents a person with basic information.
    /// </summary>
    public class Person
    {
        // Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="email">The email address of the person.</param>
        /// <param name="firstname">The first name of the person.</param>
        /// <param name="lastname">The last name of the person.</param>
        /// <param name="middlename">The middle name of the person.</param>
        public Person(string email, string firstname, string lastname, string middlename)
        {
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
            this.middlename = middlename;
            this.id = ++lastId;
        }

        private static int lastId = 0;

        // Fields
        private string email;
        private string firstname;
        private int id;
        private string lastname;
        private string middlename;

        // Properties
        /// <summary>
        /// Gets or sets the email address of the person.
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Gets or sets the first name of the person.
        /// </summary>
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        /// <summary>
        /// Gets the unique identifier of the person.
        /// </summary>
        public int Id
        {

            get { return id; }
        }

        /// <summary>
        /// Gets or sets the last name of the person.
        /// </summary>
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        /// <summary>
        /// Gets or sets the middle name of the person.
        /// </summary>
        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }

    }
}
