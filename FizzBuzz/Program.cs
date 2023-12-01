// See https://aka.ms/new-console-template for more information
using System.Reflection;

var fizzBuzzService = new FizzBuzz.Divisions.FizzBuzz();


foreach (int i in Enumerable.Range(1, 100))
{
    MethodInfo method = fizzBuzzService.GetType().GetMethod("GetDivision")!;
    string output = (string)method.Invoke(fizzBuzzService, new object[] { i })!;
    Console.WriteLine(output);
}