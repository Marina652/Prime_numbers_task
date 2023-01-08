using FluentAssertions;
using MyTask;

namespace TestProject
{
    public class Tests
    {
        [Test]
        [TestCase(3)]
        [TestCase(5)]
        [TestCase(7)]
        public void AlgTest_WhenNumberIsPrime_ReturnTrue(int number)
        {
            var actual = Alg.IsPrime(number);

            actual.Should().BeTrue();
        }

        [Test]
        [TestCase(4)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-4)]
        public void AlgTest_WhenNumberIsNotPrime_ReturnFalse(int number)
        {
            var actual = Alg.IsPrime(number);

            actual.Should().BeFalse();
        }
    }
}