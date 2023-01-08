using Microsoft.AspNetCore.Mvc;
using MyTask.Repository;

namespace MyTask.Controllers
{
    /// <summary>
    /// Controller for checking prime numbers
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PrimeNumberController : ControllerBase
    {
        private readonly INumberRepository _repository;
        public PrimeNumberController(INumberRepository numberRepository)
        {
            _repository = numberRepository;
        }

        [HttpPost("IsThisAPrimeNumber")]
        public async Task<ActionResult> IsThisAPrimeNumber(int number)
        {
            var res = await _repository.GetAlreadyCalculatedNumberAsync(number);

            if (res is null)
            {
                var isPrime = Alg.IsPrime(number);
                _repository.SaveCalculatedNumber(number, isPrime);

                if (isPrime)
                    return Ok();
                return BadRequest("Number is non-prime");
            }

            else
            {
                if (res.IsPrime)
                    return Ok();
                return BadRequest("Number is non-prime");
            }
        }
    }
}