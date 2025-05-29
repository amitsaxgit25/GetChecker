namespace GetChecker.Tests.Controllers
{
    using Xunit;
    using GetChecker.Controllers;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System.Linq;
        public class WeatherForecastControllerTests
        {
            [Fact]
            public void Get_ReturnsFiveWeatherForecasts_WithValidSummaries()
            {
                // Arrange
                var loggerMock = new Mock<ILogger<WeatherForecastController>>();
                var controller = new WeatherForecastController(loggerMock.Object);

                // Act
                var result = controller.Get();

                // Assert
                Assert.NotNull(result);
                var forecasts = result.ToArray();
                Assert.Equal(5, forecasts.Length);
                foreach (var forecast in forecasts)
                {
                    Assert.NotNull(forecast.Summary);
                    Assert.InRange(forecast.TemperatureC, -20, 55);
                }
            }
        }
}
