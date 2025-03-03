using System;
using Moq;
using PhonePadChallenge.Services;
using Xunit;

namespace TestPhonePadChallenge;

public class PhonePadConverterTests
{
    private readonly Mock<IPhonePadConverter> _converterMock = new();

    [Fact]
    public void Convert_ValidInput_ReturnsExpectedText()
    {
        // Arrange
        const string expectedText = "Hello";
        _converterMock.Setup(c => c.Convert("4356667890")).Returns(expectedText);

        // Act
        string result = _converterMock.Object.Convert("4356667890");

        // Assert
        Assert.Equal(expectedText, result);
    }

    [Fact]
    public void Convert_InvalidInput_ThrowsArgumentException()
    {
        // Arrange
        const string invalidInput = "Not a valid number";

        // Act & Assert
        _converterMock.Setup(c => c.Convert(invalidInput)).Throws<ArgumentException>();

        // Call the method to check if exception is thrown
        Action act = () => _converterMock.Object.Convert(invalidInput);

        // Verify that the action throws an ArgumentException
        var ex = Record.Exception(act);
        Assert.IsType<ArgumentException>(ex);
    }

    [Fact]
    public void Reverse_ValidInput_ReturnsExpectedKeyPressSequence()
    {
        // Arrange
        const string expectedPresses = "4356667890#";
        _converterMock.Setup(c => c.Reverse("Hello")).Returns(expectedPresses);

        // Act
        string result = _converterMock.Object.Reverse("Hello");

        // Assert
        Assert.Equal(expectedPresses, result);
    }

    [Fact]
    public void Reverse_InvalidInput_ThrowsArgumentException()
    {
        // Arrange
        const string invalidInput = "Not a valid sequence";

        // Act & Assert
        _converterMock.Setup(c => c.Reverse(invalidInput)).Throws<ArgumentException>();

        // Call the method to check if exception is thrown
        Action act = () => _converterMock.Object.Reverse(invalidInput);

        // Verify that the action throws an ArgumentException
        var ex = Record.Exception(act);
        Assert.IsType<ArgumentException>(ex);
    }
}