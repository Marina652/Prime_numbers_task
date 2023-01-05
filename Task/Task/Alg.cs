namespace MyTask;

public class Alg
{
    public static bool IsPrime(int number)
    {
        var result = true;

        if (number > 1)
        {
            for (var i = 2u; i < number; i++)
            {
                if (number % i == 0)
                {
                    result = false;
                    break;
                }
            }
        }
        else
        {
            result = false;
        }

        return result;
    }
}
