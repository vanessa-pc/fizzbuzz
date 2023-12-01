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
}