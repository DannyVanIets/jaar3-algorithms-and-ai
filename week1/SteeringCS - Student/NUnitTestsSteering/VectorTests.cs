using NUnit.Framework;
using SteeringCS;
using System;

namespace NUnitTestsSteering
{
    public class VectorTests
    {
        [TestCase(5, 4, 4, 6, 9, 10)]
        [TestCase(-2, -3, 5, 7, 3, 4)]
        [TestCase(-150, 150, 50, 50, -100, 200)]
        public void Vector2D_Add_Correct(double x, double y, double addX, double addY, double expectedX, double expectedY)
        {
            // Arrange
            Vector2D vector = new Vector2D(x, y);
            Vector2D vectorAdd = new Vector2D(addX, addY);

            // Act
            vector.Add(vectorAdd);
            double actualX = vector.X;
            double actualY = vector.Y;

            // Assert
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }

        [TestCase(10, 8, 2, 5, 4)]
        [TestCase(-2, 13, 5, -0.4, 2.6)]
        [TestCase(-150, 150, 50, -3, 3)]
        public void Vector2D_Divide_Correct(double x, double y, double divideNumber, double expectedX, double expectedY)
        {
            // Arrange
            Vector2D vector = new Vector2D(x, y);

            // Act
            vector.divide(divideNumber);
            double actualX = vector.X;
            double actualY = vector.Y;

            // Assert
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }

        [TestCase(10, 8, 12.806)]
        [TestCase(-2, 13, 13.153)]
        [TestCase(-150, 150, 212.132)]
        public void Vector2D_Length_Correct(double x, double y, double expectedLength)
        {
            // Arrange
            Vector2D vector = new Vector2D(x, y);

            // Act
            // Round the length to 3 decimals, otherwise it becomes way too long.
            double actualLength = Math.Round(vector.Length(), 3);

            // Assert
            Assert.AreEqual(expectedLength, actualLength);
        }

        [TestCase(10, 8, 0.781, 0.625)]
        [TestCase(-2, 13, -0.152, 0.988)]
        [TestCase(-150, 150, -0.707, 0.707)]
        public void Vector2D_Normalize_Correct(double x, double y, double expectedX, double expectedY)
        {
            // Arrange
            Vector2D vector = new Vector2D(x, y);

            // Act
            Vector2D vectorNormalized = vector.Normalize();
            // Round the actual to 3 decimals, otherwise it becomes way too long.
            double actualX = Math.Round(vectorNormalized.X, 3);
            double actualY = Math.Round(vectorNormalized.Y, 3);

            // Assert
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }
    }
}