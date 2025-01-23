using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerClassLibrary
{
    public class Student : Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="email">The email address of the student.</param>
        /// <param name="firstname">The first name of the student.</param>
        /// <param name="lastname">The last name of the student.</param>
        /// <param name="middlename">The middle name of the student.</param>
        /// <param name="mentor">The teacher who is the mentor of the student.</param>
        /// <param name="studentclass">The class in which the student is enrolled.</param>
        /// <param name="studentnumber">The unique number assigned to the student.</param>
        /// 
        // Constructor
        public Student(string email, string firstname, string lastname, string middlename, Teacher mentor, string studentclass, int studentnumber)
            : base(email, firstname, lastname, middlename)
        {
            this.mentor = mentor;
            this.studentclass = studentclass;
            this.studentnumber = studentnumber;
        }

        // Fields
        private Teacher mentor;
        private string studentclass;
        private int studentnumber;

        // Properties
        /// <summary>
        /// Gets or sets the teacher who is the mentor of the student.
        /// </summary>
        public Teacher Mentor
        {
            get { return mentor; }
            set { mentor = value; }
        }


        /// <summary>
        /// Gets or sets the class in which the student is enrolled.
        /// </summary>
        public string Studentclass
        {
            get { return studentclass; }
            set { studentclass = value; }
        }


        /// <summary>
        /// Gets or sets the unique number assigned to the student.
        /// </summary>
        public int Studentnumber
        {
            get { return studentnumber; }
            set { studentnumber = value; }
        }

    }
}
