using EscoteiroLMS.Domain.Validation;
using EscoteiroLMS.Domain.ValueObjects;
using System.Net;

namespace EscoteiroLMS.Domain.Entities
{
    public sealed class Scout
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? EmergencyPhone { get; set; }
        public Address Address { get; set; } = default!;
        public Responsible Responsible { get; set; } = default!;
        public int ResponsibleId { get; set; }

        public Scout(string name, string cpf, DateOnly birthdate, string phone, string emergencyphone, int responsibleid)
        {
            ValidateDomain(name, cpf, birthdate, phone, emergencyphone, responsibleid);
        }

        public Scout(int id, string name, string cpf, DateOnly birthDate, string phone, string emergencyPhone, int responsibleid)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(name, cpf, birthDate, phone, emergencyPhone, responsibleid);
        }

        private void ValidateDomain(string name, string cpf, DateOnly birthDate, string phone, string emergencyPhone, int responsibleid)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Nome inválido, é necessário possuir um nome.");
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, pois está muito curto. No mínimo 3 caracteres.");
            DomainExceptionValidation.When(name.Length > 50, "Nome inválido, pois está muito longo. No máximo 50 caracteres.");
            DomainExceptionValidation.When(cpf.Length > 14, "O CPF informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(cpf.Length < 14, "O CPF informado não foi inserido corretamente.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(phone), "Telefone inválido, pois é necessário possuir um telefone.");
            DomainExceptionValidation.When(phone.Length < 14, "O telefone informado não foi inserido corretamente.");
            DomainExceptionValidation.When(phone.Length > 14, "O telefone informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(emergencyPhone), "Telefone de emergência inválido, pois é necessário possuir um telefone de emergência.");
            DomainExceptionValidation.When(emergencyPhone.Length < 14, "O telefone de emergência informado não foi inserido corretamente.");
            DomainExceptionValidation.When(emergencyPhone.Length > 14, "O telefone de emergência informado ultrapassou o limite de caracteres permitido.");
            DomainExceptionValidation.When(responsibleid < 0, "Id de responsável inválido");

            Name = name;
            Cpf = cpf;
            Phone = phone;
            EmergencyPhone = emergencyPhone;
            ResponsibleId = responsibleid;
        }
    }
}
