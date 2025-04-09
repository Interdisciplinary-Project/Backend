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

            Action action = () => new Responsible(1, "Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().NotThrow();
        }

        [Fact(DisplayName = "Responsible with empty name")]
        public void Responsible_WithEmptyNameParameters_ResultObjectsValidState()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().NotThrow();
        }
        #endregion


        #region Testes negativos
        [Fact(DisplayName = "Responsible With Invalid id")]
        public void Responsible_WithInvalidParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Responsible(-1, "Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid user id");
        }

        [Fact(DisplayName = "Responsible With Short Name")]
        public void Responsible_WithShortNamedParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Responsible("Da", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. minimum 3 characters!");
        }
        [Fact(DisplayName = "Create Category With Null Name Parameter")]
        public void CreateCategory_WithNullNameParameter_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new Responsible("", "48899999999", dateOfBirth, "16996287391", "16996287391");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }
        #endregion
    }
}