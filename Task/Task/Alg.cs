namespace MyTask;

public class Alg
{
    public static bool IsPrime(int number)
    {
        var result = true;

        if (number <= 1)
            result = false;

        else
        {
            for (var i = 2u; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    return result;
                }
            }
        }

        return result;
    }
}
