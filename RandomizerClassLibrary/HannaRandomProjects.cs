namespace RandomizerClassLibrary
{
    /// <summary>
    /// A static class for generating various random objects by Hanna.
    /// </summary>
    public static class HannaRandomProjects
    {
        private static readonly Random random = new Random();


        /// <summary>
        /// Generates a random date within the range from January 1, 1900, to the current date.
        /// </summary>
        /// <returns>A random date within the specified range.</returns>
        public static DateTime RandomDateNoPara()
        {
            DateTime startDate = new DateTime(1900, 1, 1);
            DateTime endDate = DateTime.Now.Date;
            return RandomDateTwoPara(startDate, endDate);
        }




        /// <summary>
        /// Generates a random date within the range from the specified start date to the current date.
        /// </summary>
        /// <param name="startDate">The start date for the random date generation.</param>
        /// <returns>A random date within the specified range.</returns>
        public static DateTime RandomDateOnePara(DateTime startDate)
        {
            DateTime endDate = DateTime.Now.Date;
            return RandomDateTwoPara(startDate, endDate);
        }




        /// <summary>
        /// Generates a random date within the specified range.
        /// </summary>
        /// <param name="startDate">The start date for the random date generation.</param>
        /// <param name="endDate">The end date for the random date generation.</param>
        /// <returns>A random date within the specified range.</returns>
        public static DateTime RandomDateTwoPara(DateTime startDate, DateTime endDate)
        {
            TimeSpan timeSpan = endDate - startDate;
            int randomDays = random.Next(0, timeSpan.Days);
            return startDate.AddDays(randomDays).Date;
        }




        /// <summary>
        /// Generates a random integer, either positive or negative.
        /// </summary>
        /// <param name="allowNegative">If set to <c>true</c>, allows the generation of negative integers.</param>
        /// <returns>A random integer.</returns>
        public static int GenerateRandomInteger(bool allowNegative)
        {
            Random random = new Random();

            if (allowNegative)
            {
                return random.Next();
            }
            else
            {
                return random.Next(int.MaxValue);
            }
        }


        /// <summary>
        /// Generates a random PIN code with the specified length.
        /// </summary>
        /// <param name="length">The length of the PIN code.</param>
        /// <returns>A random PIN code.</returns>
        public static string GenerateRandomPin(int length)
        {
            if (length <= 0)
            {
                return "PIN length must be greater than 0.";
            }

            Random random = new Random();
            char[] pinCode = new char[length];

            pinCode[0] = (char)(random.Next(1, 10) + '0');

            for (int i = 1; i < length; i++)
            {
                pinCode[i] = (char)(random.Next(10) + '0');
            }

            return new string(pinCode);
        }



        /// <summary>
        /// Generates a random season.
        /// </summary>
        /// <returns>A random season.</returns>
        public static Season GenerateRandomSeason()
        {
            Array seasons = Enum.GetValues(typeof(Season));
            Random random = new Random();
            return (Season)seasons.GetValue(random.Next(seasons.Length));
        }
    }

    public enum Season
    {
        /// <summary>
        /// Winter Season.
        /// </summary>
        Winter,

        /// <summary>
        /// Spring Season.
        /// </summary>
        Spring,

        /// <summary>
        /// summer Season.
        /// </summary>
        Summer,

        /// <summary>
        /// Autumn Season.
        /// </summary>
        Autumn
    }

}

