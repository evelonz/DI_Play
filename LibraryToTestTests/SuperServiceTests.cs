using Xunit;
using LibraryToTest;
using Moq;
using FluentAssertions;
using System.Collections.Generic;

namespace LibraryToTestTests
{
    public class SuperServiceTests
    {
        private readonly SuperService _sut;

        public SuperServiceTests()
        {
            var d = new Mock<IDateService>();
            d.Setup(service => service.GetDate()).Returns(new System.DateTime(2019, 08, 01));
            var dateService = d.Object;
            _sut = new SuperService(dateService);
        }

        [Fact]
        public void SuperServiceGetShortDate_GivenNoDate_ShouldReturnDateFromDateService()
        {
            // Arrange

            // Act
            var result = _sut.GetShortDate(null);

            // Assert
            result.Should().Be("Short date is 2019-08-01.", "it is such a hit song!");
        }

        [Theory]
        [InlineData(1, "My number is 1")]
        [InlineData(10, "My number is 10")]
        [InlineData(100, "My number is 100")]
        [InlineData(-13, "My number is -13")]
        [InlineData(13, "My number is 13")]
        public void SuperServiceGetMessage_GivenANumber_ShouldReturnTheCorrectString(int number, string expected)
        {
            // Arrange

            // Act
            var result = _sut.GetMessage(number);

            // Assert
            result.Should().Be(expected, "it is expected");
        }

        [Theory]
        [MemberData(nameof(GetData))]
        public void SuperServiceGetMessage_GivenANumber_ShouldReturnTheCorrectString2(int number, string expected)
        {
            // Arrange

            // Act
            var result = _sut.GetMessage(number);

            // Assert
            result.Should().Be(expected, "it is expected");
        }

        public static IEnumerable<object[]> GetData()
        {
            return new List<object[]>
            {
                new object[] { 1, "My number is 1" },
                new object[] { 10, "My number is 10" },
                new object[] { -13, "My number is -13" },
                new object[] { int.MinValue, $"My number is {int.MinValue}" },
            };
        }
    }
}
