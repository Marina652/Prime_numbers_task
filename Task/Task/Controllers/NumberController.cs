using Microsoft.AspNetCore.Mvc;
using MyTask;

namespace MyTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeController : ControllerBase
    {
        private readonly INumberRepository _repository;
        public PrimeController(INumberRepository numberRepository)
        {
            _repository = numberRepository;
        }

        [HttpPost("IsThisAPrimeNumber")]
        public async Task<ActionResult> IsThisAPrimeNumber(int number)
        {
            var res = await _repository.GetNumberAsync(number);

            if (res is null)
            {
                var isPrime = Alg.IsPrime(number);
                _repository.WriteNumber(number, isPrime);

                if (isPrime)
                    return Ok();
                return BadRequest();
            }

            else
            {
                if (res.IsPrime)
                    return Ok();
                return BadRequest();
            }
        }
    }
}