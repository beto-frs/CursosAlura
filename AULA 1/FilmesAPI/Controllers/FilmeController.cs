using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTOs;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
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
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            /*FilmeModel filme = new FilmeModel
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao
            };*/
            FilmeModel filme = _mapper.Map<FilmeModel>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId),
                new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<FilmeModel> RecuperarFilmes() //--> IEnumerable<> == List<>
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            //--> Funcional --> return filmes.FirstOrDefault(filme => filme.Id == id);

            FilmeModel filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme != null)
            {
                /*ReadFilmeDTO filmeDto = new ReadFilmeDTO
                {
                    Titulo = filme.Titulo,
                    Genero = filme.Genero,
                    Duracao = filme.Duracao,
                    Diretor = filme.Diretor,
                    Id = filme.Id,
                    HoraConsulta = DateTime.Now
                };*/
                ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

                return Ok(filmeDto);
            }
            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDto)
        {
            FilmeModel filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            /*filme.Titulo = filmeDto.Titulo;
           filme.Genero = filmeDto.Genero;
           filme.Duracao = filmeDto.Duracao;
           filme.Diretor = filmeDto.Diretor;*/
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();


        }

        [HttpDelete("{id}")]
        public IActionResult ApagarFime(int id)
        {
            FilmeModel filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
            {
                return NotFound();
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
