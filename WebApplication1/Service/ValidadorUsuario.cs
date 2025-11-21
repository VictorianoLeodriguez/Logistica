using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication1.Service
{
    public class ValidadorUsuario
    {
        public static bool ValidarNome(string nome)
        {
            // Verifica se não está vazio e se tem até 50 caracteres
            return !string.IsNullOrEmpty(nome) && nome.Length <= 50;
        }

        public static bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = Regex.Replace(cpf, "[^0-9]", "");

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (ex.: 11111111111 → inválido)
            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            // Calcula o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);

            int resto = soma % 11;
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);

            resto = soma % 11;
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            // Confere se os dígitos calculados batem com os informados
            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        public static bool ValidarSenha(string senha)
        {
            // Verifica se a senha tem até 8 caracteres, contém número e caractere especial
            bool tamanhoOk = !string.IsNullOrEmpty(senha) && senha.Length <= 8;
            bool temNumero = System.Text.RegularExpressions.Regex.IsMatch(senha, @"\d");
            bool temEspecial = System.Text.RegularExpressions.Regex.IsMatch(senha, @"[!@#$%^&*(),.?""{}|<>]");

            return tamanhoOk && temNumero && temEspecial;
        }

    }
}