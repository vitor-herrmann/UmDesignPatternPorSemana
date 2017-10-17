using Evitando.Duplicacao.de.Codigo.OO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 4: Precisamos verificar se o cpf ou cnpj informado é
    // o mesmo que esta salvo no banco para 3 entidades diferentes

    public interface Dados
    {
        string GetCnpjCpf();
    }

    public class SamBeneficiario : Entidade<SamBeneficiario>, Dados
    {
        public string Cpf { get; set; }

        public string GetCnpjCpf()
        {
            return this.Cpf;
        }
    }

    public class SamPrestador : Entidade<SamPrestador>, Dados
    {
        public string Cnpj { get; set; }

        public string GetCnpjCpf()
        {
            return this.Cnpj;
        }
    }

    public class SamContratante : Entidade<SamContratante>, Dados
    {
        public string CnpjOuCpf { get; set; }

        public string GetCnpjCpf()
        {
            return this.CnpjOuCpf;
        }
    }

    public class ValidacaoDto
    {
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
    }

    public class ValidacaoDocumento
    {
        public ValidacaoDocumento()
        {
            //pegar aqui o generic, mas como? :/
        }

        public ValidacaoDto ValidacaoMaster(string documento, string campo)
        {
            var criteria = new Criteria(getCriterio(documento, campo));
            var cpfCadastrado = generic.GetFirstOrDefault(criteria).GetCnpjCpf();
            if (string.IsNullOrEmpty(cpfCadastrado))
                return new ValidacaoDto { Resultado = false, Mensagem = string.Format("Não foi encontrado {0} em seu cadastro", campo.Replace("_", "/").ToLowerInvariant()) };

            if (cpfCadastrado != documento)
                return new ValidacaoDto { Resultado = false, Mensagem = string.Format("O {0} informado é diferente", campo.Replace("_", "/").ToLowerInvariant()) };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sem erro!" };
        }

        private string getCriterio(string documento, string campo)
        {
            return string.Format("where {0} = :{1}", campo, documento);
        }
    }


    public class ValidacaoCadastro
    {
        public ValidacaoDto VerificarCPF(string cpfInformado)
        {
            var documento = ObterTipoDocumento<SamBeneficiario>();
            return documento.ValidacaoMaster(cpfInformado, "CPF");
        }

        public ValidacaoDto VerificarCNPJ(string cnpjInformado)
        {
            var documento = ObterTipoDocumento<SamPrestador>();
            return documento.ValidacaoMaster(cnpjInformado, "CNPJ");
        }

        public ValidacaoDto ValidarCpfCnpjPrestador(string informado)
        {
            var documento = ObterTipoDocumento<SamContratante>();
            return documento.ValidacaoMaster(informado, "CPF_CNPJ");
        }
    }
}
