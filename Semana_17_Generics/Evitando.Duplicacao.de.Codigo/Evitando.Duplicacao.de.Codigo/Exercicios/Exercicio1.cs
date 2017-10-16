using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 1: Precisamos preencher as informações de contato do prestador, 
    // beneficiário e contratante em um dto, atualmente nosso código esta duplicado
    // para cada uma das entidades, como podemos melhorar isso?

    public class Prestador : ContatoDto
    {
        
    }

    public class Beneficiario : ContatoDto
    {
        
    }

    public class Contratante : ContatoDto
    {
        
    }

    public class ContatoDto
    {
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }

    public class InformacoesContato
    {
        public ContatoDto ObterContato(Beneficiario beneficiario)
        {
            return new ContatoDto
            {
                Email = beneficiario.Email,
                Endereco = beneficiario.Endereco,
                Telefone = beneficiario.Telefone
            };
        }

        public ContatoDto ObterContato(Prestador prestador)
        {
            return new ContatoDto
            {
                Email = prestador.Email,
                Endereco = prestador.Endereco,
                Telefone = prestador.Telefone
            };
        }

        public ContatoDto ObterContato(Contratante contratante)
        {
            return new ContatoDto
            {
                Email = contratante.Email,
                Endereco = contratante.Endereco,
                Telefone = contratante.Telefone
            };
        }
    }
}
