using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscoteiroLMS.Communication.Dto
{
    public class AddressDto
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int? Number { get; set; }
        public States State { get; set; }
        public string Complement { get; set; } = string.Empty;
    }

    public enum States
    {
        AC = 0,  // Acre
        AL = 1,  // Alagoas
        AP = 2,  // Amapá
        AM = 3,  // Amazonas
        BA = 4,  // Bahia
        CE = 5,  // Ceará
        DF = 6,  // Distrito Federal
        ES = 7,  // Espírito Santo
        GO = 8,  // Goiás
        MA = 9,  // Maranhão
        MT = 10, // Mato Grosso
        MS = 11, // Mato Grosso do Sul
        MG = 12, // Minas Gerais
        PA = 13, // Pará
        PB = 14, // Paraíba
        PR = 15, // Paraná
        PE = 16, // Pernambuco
        PI = 17, // Piauí
        RJ = 18, // Rio de Janeiro
        RN = 19, // Rio Grande do Norte
        RS = 20, // Rio Grande do Sul
        RO = 21, // Rondônia
        RR = 22, // Roraima
        SC = 23, // Santa Catarina
        SP = 24, // São Paulo
        SE = 25, // Sergipe
        TO = 26  // Tocantins
    }
    }
}
