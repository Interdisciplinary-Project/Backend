using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Validation;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escoteiro.Domain.Test
{
    public class ScoutUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Scout With Valid State")]
        public void Scout_WithValidParameters_ResultObjectsValidState()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "123.456.789-10", dateOfBirth, "(16)99628-7391", "(16)99628-7391", 1);
            action.Should().NotThrow();
        }

        #endregion


        #region Testes negativos

        [Fact(DisplayName = "Scout With Invalid Id")]
        public void Scout_WithInvalidParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Scout(-1, "Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id inválido.");
        }
        [Fact(DisplayName = "Scout With Empty Name")]
        public void Scout_WithEmptyNameParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, é necessário possuir um nome.");
        }
        [Fact(DisplayName = "Scout With Short Name")]
        public void Scout_WithShortNamedParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Da", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
        }
        [Fact(DisplayName = "Scout with Long Name")]
        public void Scout_WithLongNameParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Maximiliano Domingos da Silva Pereira de Andrade Bononi Pega Na Minha", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito longo. No máximo 50 caracteres.");
        }


        [Fact(DisplayName = "Scout With Long Cpf")]
        public void Scout_WithLongCpfParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-999", dateOfBirth, "(16)99628-7391", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O CPF informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Scout With Invalid Cpf")]
        public void Scout_WithInvalidCpfParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-9", dateOfBirth, "(16)99628-7391", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O CPF informado não foi inserido corretamente.");
        }


        [Fact(DisplayName = "Scout With Empty Phone")]
        public void Scout_WithEmptyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Telefone inválido, pois é necessário possuir um telefone.");
        }
        [Fact(DisplayName = "Scout With Invalid Phone")]
        public void Scout_WithInvalidPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-739", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado não foi inserido corretamente.");
        }
        [Fact(DisplayName = "Scout With Long Phone")]
        public void Scout_WithLongPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-73910", "(16)99628-7391", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }


        [Fact(DisplayName = "Scout With Empty Emergency Phone")]
        public void Scout_WithEmptyEmergencyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-73910", "", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Scout With Invalid Emergency Phone")]
        public void Scout_WithInvalidEmergencyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-739", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Scout With Long Emergency Phone")]
        public void Scout_WithLongEmergencyPhoneParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-73910", 1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("O telefone informado ultrapassou o limite de caracteres permitido.");
        }
        [Fact(DisplayName = "Scout With Invalid Responsible Id")]
        public void Scout_WithInvalidResponsibleIdParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Scout("Daniel Danoni", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391", -1);
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id de responsável inválido");
        }
        #endregion
    }
}
