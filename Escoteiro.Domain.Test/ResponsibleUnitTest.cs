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
        [Fact(DisplayName = "Responsible with empty name")]
        public void Responsible_WithEmptyNameParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Maximiliano Domingos da Silva Pereira de Andrade Bononi Pega Na Minha", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito longo. No máximo 50 caracteres.");
        }

        [Fact(DisplayName = "Responsible With Invalid id")]
        public void Responsible_WithInvalidParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Responsible(-1, "Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id inválido.");
        }

        [Fact(DisplayName = "Responsible With Short Name")]
        public void Responsible_WithShortNamedParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Responsible("Da", "488.999.999-99", dateOfBirth, "(16)99628-7391", "(16)99628-7391");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
        }
        #endregion
    }
}