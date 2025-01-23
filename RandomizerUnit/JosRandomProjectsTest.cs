using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomizerClassLibrary;


namespace JosRandomProjectsTest
{
    public class JosRandomProjectsTest
    {
        //test for randompassword

        [Fact]
        public void RandomPasswordTest()
        {
            //Arrange   
            //Act
            string password = JosRandomProjects.RandomPassword(1000);
            //Assert
            string lowerCharacters = "abcdefghijklmnopqrstuvwxyz";
            string upperCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string numbers = "1234567890";
            string specialCharacters = "!@#$%^&*()_+";

            Assert.True(password.Intersect(lowerCharacters).Any());
            Assert.True(password.Intersect(upperCharacters).Any());
            Assert.True(password.Intersect(numbers).Any());

            string password2 = JosRandomProjects.RandomPassword(1000, false, false, false, true);

            Assert.True(password2.Intersect(specialCharacters).Any());
            //check uppercase
            string password3 = JosRandomProjects.RandomPassword(1000, true, false, false, false);
            Assert.True(password3.Intersect(upperCharacters).Any());
            //check lowercase
            string password4 = JosRandomProjects.RandomPassword(1000, false, true, false, false);
            Assert.True(password4.Intersect(lowerCharacters).Any());
            //check numbers
            string password5 = JosRandomProjects.RandomPassword(1000, false, false, true, false);
            Assert.True(password5.Intersect(numbers).Any());
            //check special characters
            string password6 = JosRandomProjects.RandomPassword(1000, false, false, false, true);
            Assert.True(password6.Intersect(specialCharacters).Any());
            string password7 = JosRandomProjects.RandomPassword(2,2,2,2);
            Assert.Equal(8, password7.Length);
            //check if password contains 2 uppercase, 2 lowercase, 2 numbers and 2 special characters
            Assert.Equal(2, password7.Count(char.IsUpper));

            // Check if password contains 2 lowercase letters
            Assert.Equal(2, password7.Count(char.IsLower));

            // Check if password contains 2 numbers
            Assert.Equal(2, password7.Count(char.IsDigit));

            // Check if password contains 2 special characters
            Assert.Equal(2, password7.Count(c => specialCharacters.Contains(c)));






        }
        //test for randomlocation
        [Fact]
        public void RandomLocationTest()
        {
            // Arrange & Act
            string location = JosRandomProjects.RandomLocation();

            // Assert
            Assert.NotNull(location);
            Assert.NotEmpty(location);

            // Check if the location string has the correct format
            Assert.StartsWith("Latitude: ", location);
            Assert.Contains(", Longitude: ", location);

            // You may also want to extract and validate the latitude and longitude values
            string[] parts = location.Split(", ");

            // Check if latitude and longitude are valid numeric values
            Assert.True(double.TryParse(parts[0].Substring("Latitude: ".Length), out _));
            Assert.True(double.TryParse(parts[1].Substring("Longitude: ".Length), out _));
        }
        //test for randomtime   
        [Fact]
        public void RandomTimeTest()
        {
            // Arrange & Act
            JosRandomProjects.Time time = JosRandomProjects.RandomTime();

            // Assert

            //check if time.hour is between 0 and 23
            Assert.InRange(time.Hour, 0, 23);
            //check if time.minute is between 0 and 59
            Assert.InRange(time.Minute, 0, 59);
            //check if time.second is between 0 and 59
            Assert.InRange(time.Second, 0, 59);
        }

    }
}
