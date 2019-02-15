using Patterns.Domain.Adapter;
using Xunit;

namespace Patterns.Domain.Tests.Adapter
{
    public class ImpostoTests
    {
        [Fact]
        public void CalcularIPVANormal()
        {
            var calculadoraIPVA = new CalculadoraDeIPVA(20000);
            Assert.Equal(800, calculadoraIPVA.CalcularValor("NORMAL"));
        }

        [Fact]
        public void CalcularIPVAPCD()
        {
            var calculadoraIPVA = new CalculadoraDeIPVA(20000);
            Assert.Equal(0, calculadoraIPVA.CalcularValor("PCD"));
        }

        [Fact]
        public void CalcularIPVAFrotista()
        {
            var calculadoraIPVA = new CalculadoraDeIPVA(20000);
            Assert.Equal(400, calculadoraIPVA.CalcularValor("FROTISTA"));
        }

        [Fact]
        public void CalcularIPVAGoverno()
        {
            var calculadoraIPVA = new CalculadoraDeIPVA(20000);
            Assert.Equal(0, calculadoraIPVA.CalcularValor("GOVERNO"));
        }
    }
}
