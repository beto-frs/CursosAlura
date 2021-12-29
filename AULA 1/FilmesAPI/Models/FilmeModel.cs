using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class FilmeModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(50, ErrorMessage = "Não pode passar de 30 caracteres")]
        public string Genero { get; set; }

        [Range(1,300, ErrorMessage = "O campo Duraçao deve ser de 1 até 300")]
        public int Duracao { get; set; }
    }
}
