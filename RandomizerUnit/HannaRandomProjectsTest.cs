using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using RandomizerClassLibrary;

namespace HannaRandomProjectsTest
{
    public class HannaRandomProjectsTest
    {
        [Fact]
        public void RandomDate_NoParameters_ReturnsDateBetween1900AndNow()
        {
            // Arrange
            DateTime startDate = new DateTime(1900, 1, 1);
            DateTime endDate = DateTime.Now;

            // Act
            DateTime result = HannaRandomProjects.RandomDateNoPara();

            // Assert
            Assert.InRange(result, startDate, endDate);
        }

        [Fact]
        public void RandomDate_OneParameter_ReturnsDateBetweenParameterAndNow()
        {
            // Arrange
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = DateTime.Now;

            // Act
            DateTime result = HannaRandomProjects.RandomDateOnePara(startDate);

            // Assert
            Assert.InRange(result, startDate, endDate);
        }

        [Fact]
        public void RandomDate_TwoParameters_ReturnsDateBetweenParameters()
        {
            // Arrange
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime endDate = new DateTime(2020, 1, 1);

            // Act
            DateTime result = HannaRandomProjects.RandomDateTwoPara(startDate, endDate);

            // Assert
            Assert.InRange(result, startDate, endDate);
        }


        [Fact]
        public void GenerateRandomInteger_AllowNegativeTrue_ShouldGenerateInteger()
        {
            // Arrange
            bool allowNegative = true;

            // Act
            int result = HannaRandomProjects.GenerateRandomInteger(allowNegative);

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void GenerateRandomInteger_AllowNegativeFalse_ShouldGeneratePositiveInteger()
        {
            // Arrange
            bool allowNegative = false;

            // Act
            int result = HannaRandomProjects.GenerateRandomInteger(allowNegative);

            // Assert
            Assert.IsType<int>(result);
            Assert.True(result >= 0);
        }


        [Fact]
        public void GenerateRandomPin_ValidLength_ReturnsCorrectLength()
        {
            // Arrange
            int length = 6;

            // Act
            string pin = HannaRandomProjects.GenerateRandomPin(length);

            // Assert
            Assert.Equal(length, pin.Length);
        }

        [Fact]
        public void GenerateRandomSeason_ShouldReturnValidSeason()
        {
            // Act
            Season result = HannaRandomProjects.GenerateRandomSeason();

            // Assert
            Assert.Contains(result, new[] { Season.Winter, Season.Spring, Season.Summer, Season.Autumn });
        }
    }

}