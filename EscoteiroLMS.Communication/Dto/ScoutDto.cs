using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Communication.Dto
{
    public class ScoutDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [MinLength(14)]
        [MaxLength(14)]
        public string Cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "A Data de Nascimento é obrigatório.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [MinLength(14)]
        [MaxLength(14)]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "O número de telefone de emergência é obrigatório.")]
        [MinLength(14)]
        [MaxLength(14)]
        public string? EmergencyPhone { get; set; }

        public int ResponsibleId { get; set; }
        public AddressDto Address { get; set; } = default!;
    }
}
