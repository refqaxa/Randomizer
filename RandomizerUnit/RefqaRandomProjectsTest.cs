using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomizerClassLibrary;


namespace RefqaRandomProjectsTest
{
    public class RefqaRandomProjectsTest
    {
        [Fact]
        public void GenerateRandomDiceRolls_ReturnsArrayWithCorrectLength()
        {
            // Arrange
            int numberOfDice = 3;

            // Act
            int[] rolls = RefqaRandomProjects.GenerateRandomDiceRolls(numberOfDice);

            // Assert
            Assert.Equal(numberOfDice, rolls.Length);
        }

        [Fact]
        public void GenerateRandomDiceRolls_ReturnsValidDiceValues()
        {
            for(int i = 0; i > 100000; i++)
            {
                // Arrange
                int numberOfDice = 5;

                // Act
                int[] rolls = RefqaRandomProjects.GenerateRandomDiceRolls(numberOfDice);

                // Assert
                Assert.All(rolls, roll => Assert.InRange(roll, 1, 6));
            }
        }

        [Fact]
        public void GenerateRandomText_ValidParameters_ReturnsText()
        {
            // Arrange
            byte numberOfParagraphs = 3;
            bool isDutch = true;
            bool asHtml = false;

            // Act
            string result = RefqaRandomProjects.GenerateRandomText(numberOfParagraphs, isDutch, asHtml);

            // Assert
            Assert.NotNull(result);
            Assert.False(string.IsNullOrWhiteSpace(result));
        }

        [Fact]
        public void GenerateRandomNames_ShouldReturnCorrectNumberOfNames()
        {
            // Arrange
            bool includeBoysNames = true;
            bool includeGirlsNames = true;
            int numberOfNames = 5;

            // Act
            string[] generatedNames = RefqaRandomProjects.GenerateRandomNames(includeBoysNames, includeGirlsNames, numberOfNames);

            // Assert
            Assert.Equal(numberOfNames, generatedNames.Length);
        }

        // Three test to see all the three possible errors
        [Fact]
        public void GetRandomPersonJson_ReturnsValidJsonForStudent()
        {
            // Arrange
            string selection = "student";

            // Act
            string result = RefqaRandomProjects.GetRandomPersonJson(selection);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            // Ensure that the result is a valid JSON representation of a Student
            Assert.Contains("\"Email\":", result);
            Assert.Contains("\"Firstname\":", result);
            Assert.Contains("\"Lastname\":", result);
            Assert.Contains("\"Studentclass\":", result);
            Assert.Contains("\"Studentnumber\":", result);
        }

        [Fact]
        public void GetRandomPersonJson_ReturnsValidJsonForTeacher()
        {
            // Arrange
            string selection = "teacher";

            // Act
            string result = RefqaRandomProjects.GetRandomPersonJson(selection);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            // Ensure that the result is a valid JSON representation of a Teacher
            Assert.Contains("\"Email\":", result);
            Assert.Contains("\"Firstname\":", result);
            Assert.Contains("\"Lastname\":", result);
            Assert.Contains("\"Hiredate\":", result);
            Assert.Contains("\"Salary\":", result);
        }

        [Fact]
        public void GetRandomPersonJson_ReturnsValidJsonForPerson()
        {
            // Arrange
            string selection = "person";

            // Act
            string result = RefqaRandomProjects.GetRandomPersonJson(selection);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            // Ensure that the result is a valid JSON representation of a Person
            Assert.Contains("\"Email\":", result);
            Assert.Contains("\"Firstname\":", result);
            Assert.Contains("\"Lastname\":", result);
        }

        [Fact]
        public void GetRandomPersonJson_ReturnsValidJsonForInvalidSelection()
        {
            // Arrange
            string selection = "invalid";

            // Act
            string result = RefqaRandomProjects.GetRandomPersonJson(selection);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);

            // Ensure that the result is a valid JSON representation of a Person
            Assert.Contains("\"Email\":", result);
            Assert.Contains("\"Firstname\":", result);
            Assert.Contains("\"Lastname\":", result);
        }
    }
}

