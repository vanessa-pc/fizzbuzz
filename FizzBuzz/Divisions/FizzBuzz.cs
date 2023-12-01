namespace FizzBuzz.Divisions;

public class FizzBuzz : IFizzBuzz
{
    public string GetDivision(int number)
    {
        return number switch
        {
            _ => number.ToString()
        };
    }
}