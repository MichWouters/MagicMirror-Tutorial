using Acme.Generic.Helpers;
using Xunit;

namespace Acme.Generic.Tests
{
    public class DistanceTests
    {
        [Fact]
        public void Miles_To_Kilometres()
        {
            // Arrange
            double[] inputs = { 1, 25, 37.33 };
            double[] expectedValues = { 1.61, 40.23, 60.08 };

            for (int i = 0; i < inputs.Length; i++)
            {
                // Act
                double result = DistanceHelper.MilesToKilometers(inputs[i]);

                // Assert
                Assert.Equal(result, expectedValues[i]);
            }
        }

        [Fact]
        public void Kilometres_To_Miles()
        {
            // Arrange
            double[] inputs = { 1, 25, 37.33 };
            double[] expectedValues = { 0.62, 15.53, 23.2 };

            for (int i = 0; i < inputs.Length; i++)
            {
                // Act
                double result = DistanceHelper.KilometersToMiles(inputs[i]);

                // Assert
                Assert.Equal(result, expectedValues[i]);
            }
        }
    }
}