namespace FizzBuzz.Divisions;

public class FizzBuzz : IFizzBuzz
{
    public string GetDivision(int number)
    {
        return number switch
        {
            _ when number % 5 == 0 => "Buzz",
            _ when number % 3 == 0 => "Fizz",
            _ => number.ToString()
        };
    }
}