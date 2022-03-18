using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmeAPI.Data;
using FilmeAPI.Data.Dtos;
using FilmeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/filme")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        [Route("/filme")]
        public IActionResult RecuperaFilme()
        {
            return Ok(_context.Filmes);
        }

        [HttpGet]
        [Route("/filme/{id:int}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);//=> transformamos o obj em outro obj
                return Ok(filmeDto);
            }
            return NotFound();

        }

        [HttpPut]
        [Route("/filme/{id:int}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme != null)
            {
                _mapper.Map(filmeDto, filme);//=> distribuimos as propriedades
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("/filme/{id:int}")]
        public IActionResult DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
            if (filme != null)
            {
                _context.Remove(filme);
                _context.SaveChanges();

                return NoContent();
            }
            return NotFound();
        }

    }
}