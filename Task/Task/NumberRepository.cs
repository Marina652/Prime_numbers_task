using Microsoft.EntityFrameworkCore;

namespace MyTask;

public class NumberRepository : INumberRepository
{
    public async Task<NumberModel> GetNumberAsync(int number)
    {
        using var context = new ApiContext();

        var res = await context.Numbers.FirstOrDefaultAsync(x => x.Number == number);

        return res;
    }

    public async void WriteNumber(int number, bool isPrime)
    {
        var model = new NumberModel
        {
            Number = number,
            IsPrime = isPrime,
        };

        using var context = new ApiContext();

        await context.Numbers.AddAsync(model);

        await context.SaveChangesAsync();
    }

    public async Task<List<NumberModel>> GetNumbers()
    {
        using var context = new ApiContext();

        return await context.Numbers.Include(x => x.Number).ToListAsync();
    }
}
