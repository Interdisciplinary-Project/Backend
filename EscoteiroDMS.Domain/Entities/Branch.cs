using EscoteiroLMS.Domain.Validation;
using System.Numerics;

namespace EscoteiroLMS.Domain.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Branch(string name, string description)
        {
            ValidateDomain(name, description);

        }

        public Branch(int id, string name, string description)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(name, description);

        }

        private void ValidateDomain(string name, string description)
        {
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
            DomainExceptionValidation.When(name.Length > 50, "Nome inválido, pois está muito longo. No máximo 50 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, pois é necessário possuir um nome.");
            DomainExceptionValidation.When(description.Length > 500, "Descrição inválida, pois está muito longo. No máximo 500 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida, pois está muito longo. No máximo 500 caracteres.");
            DomainExceptionValidation.When(description.Length < 20, "Descrição inválida, pois está muito curta. No mínimo 20 caracteres.");

            Name = name;
            Description = description;
        }
    }
}
