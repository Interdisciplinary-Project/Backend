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
    public class BranchUnitTest
    {
        #region Testes Positivos
        [Fact(DisplayName = "Branch With Valid State")]
        public void Branch_WithValidParameters_ResultObjectsValidState()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("Daniel Danoni", "O Ramo Escoteiro é voltado para jovens de 11 a 14 anos e tem como foco o desenvolvimento do caráter");
            action.Should().NotThrow();
        }
        #endregion


        #region Testes Negativos
        [Fact(DisplayName = "Branch With Invalid Id")]
        public void Branch_WithInvalidParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");
            Action action = () => new BranchDto(-1, "Daniel Danoni", "O Ramo Escoteiro é voltado para jovens de 11 a 14 anos e tem como foco o desenvolvimento do caráter");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Id inválido.");
        }
        [Fact(DisplayName = "Branch With Empty Name")]
        public void Branch_WithEmptyNameParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("", "O Ramo Escoteiro é voltado para jovens de 11 a 14 anos e tem como foco o desenvolvimento do caráter");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois é necessário possuir um nome.");
        }
        [Fact(DisplayName = "Branch With Short Name")]
        public void Branch_WithShortNamedParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("Lo", "O Ramo Escoteiro é voltado para jovens de 11 a 14 anos e tem como foco o desenvolvimento do caráter");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
        }
        [Fact(DisplayName = "Branch with Long Name")]
        public void Branch_WithLongNameParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("LobinhoLobinhoLobinhoLobinhoLobinhoLobinhoLobinhoLobinho", "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Nome inválido, pois está muito longo. No máximo 50 caracteres.");
        }

        [Fact(DisplayName = "Branch With Empty Description")]
        public void Branch_WithEmptyDescriptionParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("Lobinho", "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição inválida, pois é necessário possuir uma descrição");
        }
        [Fact(DisplayName = "Branch With Short Description")]
        public void Branch_WithShortDescriptionParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("Lobinho", "O Ramo Escoteiro");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição inválida, pois está muito curta. No mínimo 20 caracteres.");
        }
        [Fact(DisplayName = "Branch with Long Description")]
        public void Branch_WithLongDescriptionParameters_ResultException()
        {
            string dateString = "01062005";
            DateOnly dateOfBirth = DateOnly.ParseExact(dateString, "ddMMyyyy");

            Action action = () => new BranchDto("Lobinho",
                "Os Ramos Escoteiros é voltado para jovens de 11 a 14 anos e tem como foco o desenvolvimento do caráter, da cidadania e das habilidades de " +
                "liderança por meio de atividades ao ar livre, jogos, acampamentos e projetos em equipe. Os escoteiros aprendem a trabalhar em patrulhas, a tomar decisões e a respeitar valores como lealdade, " +
                "responsabilidade e amizade, seguindo sempre a Promessa e a Lei Escoteira." +
                "O Ramo Escoteiro é voltado para jovens de 11 a 14 anos e tem como foco o desenvolvimento do caráter");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Descrição inválida, pois está muito longo. No máximo 500 caracteres.");
        }
        #endregion
    }
}
