using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo.Data
{
    public class Caminhao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Placa é um campo obrigatório")]
        [DisplayName("Placa")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Modelo é um campo obrigatório")]
        [DisplayName("Modelo")]
        public string Modelo { get; set; }

        [DisplayName("Ano do modelo")]
        [Required(ErrorMessage = "Ano do modelo é um campo obrigatório")]
        public string AnoModelo { get; set; }

        [DisplayName("Ano da fabricação")]
        [Required(ErrorMessage = "Ano de fabricação é um campo obrigatório")]
        public string AnoFabricacao { get; set; }
    }
}
