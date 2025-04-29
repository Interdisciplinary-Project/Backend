using EscoteiroLMS.Domain.Enums;
using EscoteiroLMS.Domain.Validation;
using System.Xml.Linq;

namespace EscoteiroLMS.Domain.ValueObjects
{
    public class Address
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int? Number { get; set; }
        public States State { get; set; }
        public string Complement { get; set; } = string.Empty;

        private Address() { }

        public Address(string zipcode, string street, string neighborhood, string city, string complement, int number)
        {
            ValidateDomain(zipcode, street, neighborhood, city, complement, number);
        }

        private void ValidateDomain(string zipcode, string street, string neighborhood, string city, string complement, int number)
        {
            DomainExceptionValidation.When(zipcode.Length > 9, "Código Postal informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(zipcode), "Código Postal Inválido.");
            DomainExceptionValidation.When(street.Length < 3, "Nome de Rua inválida, pois está muito curta. No mínimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(street), "Nome de Rua Inválido.");
            DomainExceptionValidation.When(neighborhood.Length < 3, "Nome de Bairro inválido, pois está muito curta. Mínimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(neighborhood), "Bairro inválido.");
            DomainExceptionValidation.When(city.Length < 3, "Cidade informada inválida, pois está muito curta. No mínimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), "Cidade Inválida.");
            DomainExceptionValidation.When(complement.Length < 3, "Complemento informado inválido, pois está muito curto. No mínimo 3 caracteres.");
            DomainExceptionValidation.When(complement.Length > 30, "Complemento informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(number < 0, "Número inválido");

            ZipCode = zipcode;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            Complement = complement;
            Number = number;
        }
    }
}
