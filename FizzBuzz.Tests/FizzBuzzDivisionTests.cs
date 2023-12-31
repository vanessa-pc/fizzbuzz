using System.Reflection;
using FizzBuzz.Divisions;
using FluentAssertions;

namespace FizzBuzz.Tests;

public class FizzBuzzDivisionTests
{
    private Type? FizzBuzzImplementationType =>
        Assembly
            .GetExecutingAssembly()
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .SelectMany(x => x.GetTypes())
            .SingleOrDefault(x => x.GetInterfaces().Any(i => typeof(IFizzBuzz) == i));

    [Fact]
    public void WhenAssemblyScannedThenFindsImplementation() => FizzBuzzImplementationType
        .Should().NotBeNull();

    private IFizzBuzz Service => (IFizzBuzz)Activator.CreateInstance(FizzBuzzImplementationType!)!;

    [Fact]
    public void WhenImplementationActivatedThenResolvesService() => Service
        .Should().NotBeNull();

    [Theory]
    [InlineData(1), InlineData(2), InlineData(4), InlineData(7)]
    public void WhenNotDivisibleByThreeOrFiveThenReturnsNumber(int number) => Service
        .GetDivision(number).Should().Be(number.ToString());
    
    [Theory]
    [InlineData(3), InlineData(6), InlineData(9), InlineData(12)]
    public void WhenDivisibleByThreeThenReturnsFizz(int number) => Service
        .GetDivision(number).Should().Be("Fizz");
    
    [Theory]
    [InlineData(5), InlineData(10), InlineData(20), InlineData(25)]
    public void WhenDivisibleByFiveThenReturnsBuzz(int number) => Service
        .GetDivision(number).Should().Be("Buzz");
    
    [Theory]
    [InlineData(15), InlineData(30), InlineData(45), InlineData(60)]
    public void WhenDivisibleByThreeAndFiveThenReturnsFizzBuzz(int number) => Service
        .GetDivision(number).Should().Be("FizzBuzz");
}