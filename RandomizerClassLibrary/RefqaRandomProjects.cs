using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizerClassLibrary
{
    /// <summary>
    /// A static class for generating various random objects by Refqa.
    /// </summary>
    public static class RefqaRandomProjects
    {
        private static Random random = new Random();

        /// <summary>
        /// Generates random dice rolls.
        /// </summary>
        /// <param name="numberOfDice">The number of rolls you want.</param>
        /// <returns>A list of random integers with the given amount. </returns>
        public static int[] GenerateRandomDiceRolls(int numberOfDice)
        {
            if (numberOfDice < 1 || numberOfDice > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfDice), "Number of dice must be between 1 and 6 inclusive.");
            }
            int[] rolls = new int[numberOfDice];

            for (int i = 0; i < numberOfDice; i++)
            {
                rolls[i] = random.Next(1, 7);
            }

            return rolls;
        }

        /// <summary>
        /// Generate random text with specified parameters.
        /// </summary>
        /// <param name="numberOfParagraphs">Number of paragraphs to generate (max 10).</param>
        /// <param name="isDutch">True for Dutch text, false for Lorem Ipsum.</param>
        /// <param name="asHtml">True to format as HTML, false for plain text.</param>
        /// <returns>The generated text.</returns>
        public static string GenerateRandomText(int numberOfParagraphs, bool isDutch, bool asHtml)
        {
            numberOfParagraphs = (byte)Math.Min(numberOfParagraphs, 10);

            string filePath = isDutch ? "Resources/loremipsumNL.txt" : "Resources/loremipsum.txt";
            string loremIpsumText = File.ReadAllText(filePath);

            // Split the text into paragraphs
            string[] paragraphs = loremIpsumText.Split(new[] { Environment.NewLine, "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            // Randomly select the specified number of paragraphs
            var selectedParagraphs = paragraphs.OrderBy(_ => random.Next()).Take(numberOfParagraphs);

            // Join paragraphs into a single text
            string resultText = string.Join(Environment.NewLine, selectedParagraphs);

            // Optionally format as HTML
            if (asHtml)
            {
                resultText = $"<p>{resultText.Replace(Environment.NewLine, "</p><p>")}</p>";
            }

            return resultText;
        }

        /// <summary>
        /// Generate random names based on the specified criteria.
        /// </summary>
        /// <param name="includeBoys">Include boys' names if true.</param>
        /// <param name="includeGirls">Include girls' names if true.</param>
        /// <param name="numberOfNames">The number of names to generate.</param>
        /// <returns>An array of randomly generated names.</returns>
        public static string[] GenerateRandomNames(bool includeBoys, bool includeGirls, int numberOfNames)
        {
            // Validate the number of names
            numberOfNames = Math.Max(numberOfNames, 0);

            List<string> names = new List<string>();

            if (includeBoys)
            {
                string[] boysNames = LoadNamesFromFile("Resources/jongensvoornamen.txt");
                names.AddRange(boysNames);
            }

            if (includeGirls)
            {
                string[] girlsNames = LoadNamesFromFile("Resources/meisjesvoornamen.txt");
                names.AddRange(girlsNames);
            }

            // Shuffle and take the specified number of names
            var shuffledNames = names.OrderBy(_ => random.Next()).Take(numberOfNames);
            return shuffledNames.ToArray();
        }

        private static string[] LoadNamesFromFile(string filePath)
        {
            string[] names = File.ReadAllLines(filePath);
            return names;
        }

        /// <summary>Gets the random person json.</summary>
        /// <param name="selection">The selection.</param>
        /// <returns>
        ///   <para>randnom student or teacher</para>
        /// </returns>
        public static string GetRandomPersonJson(string selection)
        {
            Random random = new Random();
            School school = new School();

            if (selection.ToLower() == "student")
            {
                int randomIndex = random.Next(school.Students.Count);
                return JsonConvert.SerializeObject(school.Students[randomIndex]);
            }
            else if (selection.ToLower() == "teacher")
            {
                int randomIndex = random.Next(school.Teachers.Count);
                return JsonConvert.SerializeObject(school.Teachers[randomIndex]);
            }
            else
            {
                // Assume "person" if selection is neither "student" nor "teacher"
                List<Person> allPeople = new List<Person>();
                allPeople.AddRange(school.Students);
                allPeople.AddRange(school.Teachers);

                int randomIndex = random.Next(allPeople.Count);
                return JsonConvert.SerializeObject(allPeople[randomIndex]);
            }
        }
    }

}
