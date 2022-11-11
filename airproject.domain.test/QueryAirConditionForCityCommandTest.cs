using airproject.domain.Application.Ports.Inbound;
using FluentAssertions;

namespace airproject.domain.test
{
    public class QueryAirConditionForCityCommandTest
    {
        [Fact]
        public void Empty_City_Should_Thrown_Exception()
        {
            //Arrange
            var city = string.Empty;
            var sort = "desc";
            var validator = new QueryAirConditionForCityCommandValidator();

            //Act
            var result = Assert.Throws<FluentValidation.ValidationException>(() => new QueryAirConditionForCityCommand(validator, city, sort));
            
            //Assert
            result.Message.Should().Be("Validation failed: \r\n -- City: 'City' must not be empty.");            
        }
    }
}