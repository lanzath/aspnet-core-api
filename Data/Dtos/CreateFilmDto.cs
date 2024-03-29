using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnetCoreAPI.Data.Dtos
{
    public class CreateFilmDto
    {
        // DTO (Data Transfer Object)
        // é utilizada para definir o que será enviado pela requisição
        // e o que será gerenciado internamente pelo DB (ex: ID).

        [Required(ErrorMessage = "Title field is Required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director field is Required.")]
        public string Director { get; set; }

        [StringLength(20, ErrorMessage = "Character limit for Genre exceeded.")]
        public string Genre { get; set; }

        [Range(1, 600, ErrorMessage = "Range must be between 1 and 600.")]
        public int Length { get; set; }
    }
}