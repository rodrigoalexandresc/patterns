using System;

namespace Patterns.Domain.Adapter
{
    public class CalculadoraDeIPVA
    {
        private decimal valorVeiculo;
        public CalculadoraDeIPVA(decimal valorVeiculo)
        {
            this.valorVeiculo = valorVeiculo;
        }

        public decimal CalcularValor(string tipoTributacao)
        {
            var ipva = new IPVA(tipoTributacao, valorVeiculo);
            return ipva.CalcularValor();
        }
    }

    public class Imposto
    {
        public Imposto(string tipoTributacao, decimal baseCalculo)
        {
            TipoTributacao = tipoTributacao;
            BaseCalculo = baseCalculo;
        }

        protected string TipoTributacao;
        protected decimal BaseCalculo;
        protected decimal Aliquota;

        public virtual decimal CalcularValor()
        {
            return Math.Round(BaseCalculo * Aliquota, 2);
        }
    }

    public class IPVA : Imposto
    {
        public IPVA(string tipoTributacao, decimal baseCalculo) : base(tipoTributacao, baseCalculo)
        {
        }

        public override decimal CalcularValor()
        {
            var tabela = new TabelaIPVA();
            return Math.Round(tabela.ObterAliquota(TipoTributacao) * BaseCalculo, 2);
        }
    }

    public class TabelaIPVA
    {
        public decimal ObterAliquota(string tipoTributacao)
        {
            switch (tipoTributacao)
            {
                case "NORMAL":
                    return 0.04m;                
                case "FROTISTA":
                    return 0.02m;
                case "PCD":
                case "GOVERNO":
                    return 0m;
                default:
                    return 0.04m;
            }
        }
    }
}
