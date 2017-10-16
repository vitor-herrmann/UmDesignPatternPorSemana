using Evitando.Duplicacao.de.Codigo.OO;
using Evitando.Duplicacao.de.Codigo.tissLoteGuiasV3_02_02;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 3: Temos 3 entidades que representam uma autorizacao,
    // precisamos converte-las para a resposta de um servico, o codigo
    // atual triplica essa implementacao, como podemos melhorar?

    // Entidades

    public class SamGuia : Entidade<SamGuia>
    {
    }

    public class SamAutoriz : Entidade<SamAutoriz>
    {
    }

    public class WebAutoriz : Entidade<SamAutoriz>
    {
    }

    public class DTO
    {
        public string NumeroGuia { get; set; }
        public string ProfissionalExecutante { get; set; }
        public string Beneficiario { get; set; }
    }

    public interface IConsultar
    {
        DTO ObterGuia(T guia);
    }

    public class Consulta<T>
    {
        private IConsultar consultar;

        public Consulta()
        {
            this.consultar = new Consultar();
        }

        public ctm_consultaGuia ConsultarGuia(long handle)
        {
            return new ctm_consultaGuia(consultar.ObterGuia());
        }
    }

    public class Consultar<T> where T : IConsultar
    {
        public T ObterGuia(T guia)
        {
            return new ctm_consultaGuia
            {
                numeroGuiaOperadora = guia.NumeroGuia,
                dadosBeneficiario = new ct_beneficiarioDados
                {
                    nomeBeneficiario = guia.Beneficiario
                },
                profissionalExecutante = new ct_contratadoProfissionalDados
                {
                    nomeProfissional = guia.ProfissionalExecutante
                }
            };
        }
    }

    // Serviços

    //public class ConsultaGuias
    //{
    //    public ctm_consultaGuia ConsultarGuia(long handle)
    //    {
    //        var guia = SamGuia.Get(handle);

    //        return new ctm_consultaGuia
    //        {
    //            numeroGuiaOperadora = guia.NumeroGuia,
    //            dadosBeneficiario = new ct_beneficiarioDados
    //            {
    //                nomeBeneficiario = guia.Beneficiario
    //            },
    //            profissionalExecutante = new ct_contratadoProfissionalDados
    //            {
    //                nomeProfissional = guia.ProfissionalExecutante
    //            }
    //        };
    //    }
    //}

    //public class ConsultaAutorizacao
    //{
    //    public ctm_consultaGuia ConsultarAutorizacao(long handle)
    //    {
    //        var guia = SamAutoriz.Get(handle);

    //        return new ctm_consultaGuia
    //        {
    //            numeroGuiaOperadora = guia.NumeroGuia,
    //            dadosBeneficiario = new ct_beneficiarioDados
    //            {
    //                nomeBeneficiario = guia.Beneficiario
    //            },
    //            profissionalExecutante = new ct_contratadoProfissionalDados
    //            {
    //                nomeProfissional = guia.ProfissionalExecutante
    //            }
    //        };
    //    }
    //}

    //public class ConsultaAutorizacaoWeb
    //{
    //    public ctm_consultaGuia ConsultarAutorizacaoWeb(long handle)
    //    {
    //        var guia = WebAutoriz.Get(handle);

    //        return new ctm_consultaGuia
    //        {
    //            numeroGuiaOperadora = guia.NumeroGuia,
    //            dadosBeneficiario = new ct_beneficiarioDados
    //            {
    //                nomeBeneficiario = guia.Beneficiario
    //            },
    //            profissionalExecutante = new ct_contratadoProfissionalDados
    //            {
    //                nomeProfissional = guia.ProfissionalExecutante
    //            }
    //        };
    //    }
    //}
}
