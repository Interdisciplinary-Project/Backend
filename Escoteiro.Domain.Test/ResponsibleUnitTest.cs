using FluentAssertions;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.Validation;
using Xunit;

namespace Escoteiro.Domain.Test
{
    public class ResponsibleUnitTest
    {
        [Fact(DisplayName = "Responsible With Valid State")]
        public void Responsible_WithValidParameters_ResultObjectsValidState()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new Responsible("Daniel Danoni", "48899999999", dateOfBirth, "16996287391", "16996287391");

            action.Should().NotThrow();
        }
    }
}