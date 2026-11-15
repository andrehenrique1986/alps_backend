using ALPS.Domain.Enums;
using ALPS.Domain.Validations;
using System.Text.RegularExpressions;

namespace ALPS.Domain.Entities
{
    public class NumeroFiscal
    {
        public string Numero { get; private set; }
        public TipoNumeroFiscal Tipo { get; private set; }

        // Construtor protegido exigido pelo Entity Framework Core (ORM)
        protected NumeroFiscal() { }

        public NumeroFiscal(string numero)
        {
            ValidarEPreencher(numero);
        }

        public void ValidarEPreencher(string numero)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(numero), "O número fiscal não pode ser vazio.");

            string numeroLimpo = Regex.Replace(numero, "[^0-9]", "");

            DomainExceptionValidation.When(
                !IsValid(numeroLimpo),
                "O número fiscal informado é inválido (CPF ou CNPJ incorreto)."
            );

            // Preenche o estado da entidade após validação bem-sucedida
            Numero = numeroLimpo;
            Tipo = numeroLimpo.Length == 11 ? TipoNumeroFiscal.CPF : TipoNumeroFiscal.CNPJ;
        }

        public static bool IsValid(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return false;

            string numeros = Regex.Replace(numero, "[^0-9]", "");

            if (numeros.Length == 11)
                return IsCPFValid(numeros);

            if (numeros.Length == 14)
                return IsCNPJValid(numeros);

            return false; // Garante que todos os caminhos de execução retornem um valor
        }

        public static bool IsCPFValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            string numeros = Regex.Replace(cpf, "[^0-9]", "");

            if (numeros.Length != 11)
                return false;

            // Rejeita CPFs com todos os dígitos iguais (ex: 111.111.111-11)
            if (new string(numeros[0], 11) == numeros)
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCPF = numeros.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCPF[i].ToString()) * mult1[i];

            int restoDivisaoCPF = soma % 11;
            restoDivisaoCPF = restoDivisaoCPF < 2 ? 0 : 11 - restoDivisaoCPF;

            string digito = restoDivisaoCPF.ToString();
            tempCPF += digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCPF[i].ToString()) * mult2[i];

            restoDivisaoCPF = soma % 11;
            restoDivisaoCPF = restoDivisaoCPF < 2 ? 0 : 11 - restoDivisaoCPF;
            digito += restoDivisaoCPF.ToString();

            return numeros.EndsWith(digito);
        }

        public static bool IsCNPJValid(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            string numeros = Regex.Replace(cnpj, "[^0-9]", "");

            if (numeros.Length != 14)
                return false;

            // Rejeita CNPJs com todos os dígitos iguais
            if (new string(numeros[0], 14) == numeros)
                return false;

            int[] mult1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCNPJ = numeros.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCNPJ[i].ToString()) * mult1[i];

            int resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;

            string digito = resto.ToString();
            tempCNPJ += digito;

            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCNPJ[i].ToString()) * mult2[i];

            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito += resto.ToString();

            return numeros.EndsWith(digito);
        }
    }
}