using MyTask.Models;

namespace MyTask.Repository;

public interface INumberRepository
{
    public Task<NumberModel> GetAlreadyCalculatedNumberAsync(int number);
    public Task<List<NumberModel>> GetCalculatedNumbers();
    public void SaveCalculatedNumber(int number, bool isPrime);
}
