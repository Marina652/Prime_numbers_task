namespace MyTask;

public interface INumberRepository
{
    public Task<NumberModel> GetNumberAsync(int number);
    public Task<List<NumberModel>> GetNumbers();
    public void WriteNumber(int number, bool isPrime);
}
