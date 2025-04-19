using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Communication.Dto
{
    public class BranchDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatório.")]
        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
    }
}
