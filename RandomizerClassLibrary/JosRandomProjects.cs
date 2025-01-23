using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerClassLibrary
{
    /// <summary>
    /// A static class for generating various random objects by Jos.
    /// </summary>
    public static class JosRandomProjects
    {
        /// <summary>
        /// Generates a random password with a length that is specified by the user.
        /// </summary>
        /// <param name="length">The length of the password.</param>
        /// <returns>A random password with a length that is specified by the user.</returns>
        public static string RandomPassword(int length)
        {
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                password.Append(letters[random.Next(letters.Length)]);
            }
            return password.ToString();
        }
        /// <summary>
        /// Generates a random password with a length that is specified by the user and with the option to use upper case, lower case, numbers, and special characters.
        /// </summary>
        /// <param name="length">Length of the password.</param>
        /// <param name="useUpperCase">If set to <c>true</c>, allow uppercase letters.</param>
        /// <param name="useLowerCase">If set to <c>true</c>, allow lowercase letters.</param>
        /// <param name="useNumbers">If set to <c>true</c>, allow numbers.</param>
        /// <param name="useSpecialCharacters">If set to <c>true</c>, allow special characters.</param>
        /// <returns>A random password with the specified settings for generation.</returns>
        public static string RandomPassword(int length, bool useUpperCase, bool useLowerCase, bool useNumbers, bool useSpecialCharacters)
        {
            string letters = "";
            if (useUpperCase)
            {
                letters += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            }
            if (useLowerCase || (!useUpperCase && !useLowerCase && !useNumbers && !useSpecialCharacters))
            {
                letters += "abcdefghijklmnopqrstuvwxyz";
            }
            if (useNumbers)
            {
                letters += "1234567890";
            }
            if (useSpecialCharacters)
            {
                letters += "!@#$%^&*()_+";
            }
            StringBuilder password = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                password.Append(letters[random.Next(letters.Length)]);
            }
            return password.ToString();
        }
        //Vier bytes als parameters: met deze parameters kan de gebruiker aangeven hoeveelhoofdletters, kleine letters, cijfer en bijzondere tekens hij in het wachtwoord wil. Ookhier wordt voor de speciale tekens een lijst van 10 tekens gebruikt.
        /// <summary>
        /// Generates a random password with a specified number of uppercase letters, lowercase letters, numbers, and special characters.
        /// </summary>
        /// <param name="uppercaseAmount">The number of uppercase letters in the password.</param>
        /// <param name="lowerCaseAmount">The number of lowercase letters in the password.</param>
        /// <param name="numbersAmount">The number of numbers in the password.</param>
        /// <param name="specialCharsAmount">The number of special characters in the password.</param>
        /// <returns>A random password with the specified length of each type.</returns>
        public static string RandomPassword(byte uppercaseAmount, byte lowerCaseAmount, byte numbersAmount, byte specialCharsAmount)
        {
            string password = "";
            string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string LowerCase = "abcdefghijklmnopqrstuvwxyz";
            string Numbers = "1234567890";
            string SpecialCharacters = "!@#$%^&*()_+";
            List<char> charList = new List<char>();

            Random random = new Random();

            for (int i = 0; i < uppercaseAmount; i++)
            {
                charList.Add(UpperCase[random.Next(UpperCase.Length)]);
            }
            for (int i = 0; i < lowerCaseAmount; i++)
            {
                charList.Add(LowerCase[random.Next(LowerCase.Length)]);
            }
            for (int i = 0; i < numbersAmount; i++)
            {
                charList.Add(Numbers[random.Next(Numbers.Length)]);
            }
            for (int i = 0; i < specialCharsAmount; i++)
            {
                charList.Add(SpecialCharacters[random.Next(SpecialCharacters.Length)]);
            }

            // Fisher-Yates shuffle
            int n = charList.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = charList[k];
                charList[k] = charList[n];
                charList[n] = value;
            }

            password = new string(charList.ToArray());

            return password;
        }
        /// <summary>
        /// Represents a time with hours, minutes, and seconds.
        /// </summary>
        public class Time
        {
            public int Hour { get; }
            public int Minute { get; }
            public int Second { get; }

            // Constructor with one parameter (seconds)
            public Time(int seconds)
            {
                Hour = seconds / 3600;
                Minute = (seconds % 3600) / 60;
                Second = seconds % 60;
            }

            // Constructor with two parameters (minutes and seconds)
            public Time(int minutes, int seconds) : this(minutes * 60 + seconds)
            {
            }

            // Constructor with three parameters (hours, minutes, and seconds)
            public Time(int hours, int minutes, int seconds) : this(hours * 3600 + minutes * 60 + seconds)
            {
            }
        }
        /// <summary>
        /// Generates a random time.
        /// </summary>
        /// <returns> a random time</returns>
        public static Time RandomTime()
        {
            Random random = new Random();
            int hours = random.Next(0, 24);
            int minutes = random.Next(0, 60);
            int seconds = random.Next(0, 60);
            return new Time(hours, minutes, seconds);
        }


        /// <summary>
        /// Generates a random location (latitude and longitude) within the world.
        /// </summary>
        /// <returns>A random location (latitude and longitude) within the world.</returns>
        public static string RandomLocation()
        {
            Random random = new Random();
            double latitude = random.NextDouble() * 180 - 90;
            double longitude = random.NextDouble() * 360 - 180;
            return $"Latitude: {latitude}, Longitude: {longitude}";
        }
    }
}
