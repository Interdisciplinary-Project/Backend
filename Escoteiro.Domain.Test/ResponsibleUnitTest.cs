using FluentAssertions;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Validation;
using Xunit;

namespace Escoteiro.Domain.Test
{
    public class ResponsibleUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Responsible With Valid State")]
        public void Responsible_WithValidParameters_ResultObjectsValidState()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "123.456.789-10", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().NotThrow();
        }

        #endregion


        #region Testes negativos

        [Fact(DisplayName = "Responsible With Invalid Id")]
        public void Responsible_WithInvalidParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Responsible(-1, "Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id inválido.");
        }
        [Fact(DisplayName = "Responsible With Empty Name")]
        public void Responsible_WithEmptyNameParameters_ResultException()
        { 
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois é necessário possuir um nome.");
        }
        [Fact(DisplayName = "Responsible With Short Name")]
        public void Responsible_WithShortNamedParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Da", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
        }
        [Fact(DisplayName = "Responsible with Long Name")]
        public void Responsible_WithLongNameParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Maximiliano Domingos da Silva Pereira de Andrade Bononi Pega Na Minha", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito longo. No máximo 50 caracteres.");
        }


        [Fact(DisplayName = "Responsible With Long Cpf")]
        public void Responsible_WithLongCpfParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-999", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O CPF informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Responsible With Invalid Cpf")]
        public void Responsible_WithInvalidCpfParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-9", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O CPF informado não foi inserido corretamente.");
        }


        [Fact(DisplayName = "Responsible With Empty Phone")]
        public void Responsible_WithEmptyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-99", dateOfBirth, "", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone inválido, pois é necessário possuir um telefone.");
        }
        [Fact(DisplayName = "Responsible With Invalid Phone")]
        public void Responsible_WithInvalidPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-739", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado não foi inserido corretamente.");
        }
        [Fact(DisplayName = "Responsible With Long Phone")]
        public void Responsible_WithLongPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-73910", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }


        [Fact(DisplayName = "Responsible With Empty Emergency Phone")]
        public void Responsible_WithEmptyEmergencyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-73910", "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Responsible With Invalid Emergency Phone")]
        public void Responsible_WithInvalidEmergencyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-73910", "(16)99628-739");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Responsible With Long Emergency Phone")]
        public void Responsible_WithLongEmergencyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-73910", "(16)99628-73910");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }
        #endregion
    }
}