using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerClassLibrary
{
    /// <summary>
    /// Represents a teacher, inheriting from the <see cref="Person"/> class.
    /// </summary>
    public class Teacher : Person
    {
        // Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Teacher"/> class.
        /// </summary>
        /// <param name="email">The email address of the teacher.</param>
        /// <param name="firstname">The first name of the teacher.</param>
        /// <param name="lastname">The last name of the teacher.</param>
        /// <param name="middlename">The middle name of the teacher.</param>
        /// <param name="hiredate">The date when the teacher was hired.</param>
        /// <param name="salary">The salary of the teacher.</param>
        public Teacher(string email, string firstname, string lastname, string middlename, DateTime hiredate, decimal salary)
            : base(email, firstname, lastname, middlename)
        {
            this.hiredate = hiredate;
            this.salary = salary;
        }

        // Fields
        private DateTime hiredate;
        private decimal salary;

        // Properties
        /// <summary>
        /// Gets or sets the date when the teacher was hired.
        /// </summary>
        public DateTime Hiredate
        {
            get { return hiredate; }
            set { hiredate = value; }
        }

        /// <summary>
        /// Gets or sets the salary of the teacher.
        /// </summary>
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
    }

}
