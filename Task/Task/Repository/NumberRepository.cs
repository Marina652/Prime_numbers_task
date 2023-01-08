using Microsoft.EntityFrameworkCore;
using MyTask.Models;
using System.Data;

namespace MyTask.Repository;

public class NumberRepository : INumberRepository
{
    private readonly ApiContext _dbContext;
    public NumberRepository(ApiContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<NumberModel> GetAlreadyCalculatedNumberAsync(int number)
    {
        var res = await _dbContext.Numbers.FirstOrDefaultAsync(x => x.Number == number);

        return res;
    }

    public async void SaveCalculatedNumber(int number, bool isPrime)
    {
        var model = new NumberModel
        {
            Number = number,
            IsPrime = isPrime,
        };

        await _dbContext.Numbers.AddAsync(model);

        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<NumberModel>> GetCalculatedNumbers()
    {
        return await _dbContext.Numbers.Include(x => x.Number).ToListAsync();
    }
}
