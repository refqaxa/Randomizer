using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RandomizerClassLibrary
{
    /// <summary>
    /// Represents a school with students, teachers, and persons.
    /// </summary>
    public class School
    {
        /// <summary>
        /// Gets or sets the list of students in the school.
        /// </summary>
        public List<Student> Students = new List<Student>();

        /// <summary>
        /// Gets or sets the list of teachers in the school.
        /// </summary>
        public List<Teacher> Teachers = new List<Teacher>();

        /// <summary>
        /// Gets or sets the list of persons in the school.
        /// </summary>
        public List<Person> Persons = new List<Person>();

        /// <summary>
        /// Initializes a new instance of the <see cref="School"/> class.
        /// </summary>
        public School()
        {
            // Initialize the lists with sample data.
            for (int i = 0; i < 100; i++)
            {
                this.Students.Add(new Student($"student{i}@example.com", $"John{i}", $"Doe{i}", "",
                    new Teacher($"teacher{i}@example.com", $"John{i}", $"Doe{i}", "", DateTime.Now, i * 1000.0m),
                    $"ClassA", i));
                this.Teachers.Add(new Teacher($"teacher{i}@example.com", $"John{i}", $"Doe{i}", "", DateTime.Now, i * 1000.0m));
                this.Persons.Add(new Person($"person{i}@example.com", $"John{i}", $"Doe{i}", ""));
            }
        }
    }


}
