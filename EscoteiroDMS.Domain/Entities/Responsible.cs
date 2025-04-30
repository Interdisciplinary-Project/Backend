using EscoteiroLMS.Domain.Validation;
using EscoteiroLMS.Domain.ValueObjects;
//using FluentAssertions;
//using Xunit;

namespace EscoteiroLMS.Domain.Entities
{
    public sealed class Responsible
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? EmergencyPhone { get; set; }
        public Address Address { get; set; } = default!;
        //public List<Scout> Scout { get; set; } = default!;

        private Responsible() { }

        public Responsible(string name, string cpf, DateOnly birthDate, string phone, string emergencyPhone)
        {
            ValidateDomain(name, cpf, birthDate, phone, emergencyPhone);
        }

        public Responsible(int id, string name, string cpf, DateOnly birthDate, string phone, string emergencyPhone)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(name, cpf, birthDate, phone, emergencyPhone);
        }

        private void ValidateDomain(string name, string cpf, DateOnly birthDate, string phone, string emergencyPhone)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Nome inválido, pois é necessário possuir um nome.");
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
            DomainExceptionValidation.When(name.Length > 50, "Nome inválido, pois está muito longo. No máximo 50 caracteres.");
            DomainExceptionValidation.When(cpf.Length >= 15, "O CPF informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(cpf.Length < 14, "O CPF informado não foi inserido corretamente.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone), "Telefone inválido, pois é necessário possuir um telefone.");
            DomainExceptionValidation.When(phone.Length < 14, "O telefone informado não foi inserido corretamente.");
            DomainExceptionValidation.When(phone.Length >= 15, "O telefone informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(emergencyPhone), "Telefone de emergência inválido, pois é necessário possuir um telefone de emergência.");
            DomainExceptionValidation.When(emergencyPhone.Length < 14, "O telefone de emergência informado não foi inserido corretamente.");
            DomainExceptionValidation.When(emergencyPhone.Length >= 15, "O telefone de emergência informado ultrapassou o limite de caracteres permitido.");

            Name = name;
            Cpf = cpf;
            Phone = phone;
            EmergencyPhone = emergencyPhone;
        }
    }
}
