using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers
{
   [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 1;

        [HttpPost]
        [Route("/filme")]
        public IActionResult AdicionaFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        [Route("/filme")]
        public IActionResult RecuperaFilme()
        {
            return Ok(filmes);
        }

        [HttpGet]
        [Route("/filme/{id:int}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            // foreach (Filme filme in filmes){
            //     if(filme.Id == id) {
            //         return filme;
            //     }
            // }

            // return null;

            Filme filme = filmes.FirstOrDefault(x => x.Id == id);
            if (filme != null)
            {
                return Ok(filme);
            }
            return NotFound();

        }
    }
}