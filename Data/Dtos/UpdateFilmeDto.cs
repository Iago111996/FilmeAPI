using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "O gênero não pode estrapolar 30 caracteres")]
        public string Genero { get; set; }

        [Range(0, 300, ErrorMessage = "Coloque um número entre 0 e 300")]
        public int Duracao { get; set; }
    }
}