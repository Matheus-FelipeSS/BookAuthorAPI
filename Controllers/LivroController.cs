using Microsoft.AspNetCore.Mvc;
using WebApi8.DTOs;
using WebApi8.Models;
using WebApi8.Services.Livro;

namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarAutorPorId(int idLivro)
        {
            var livro = await _livroInterface.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorAutor(int idAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroDTO livroDTO)
        {
            var autores = await _livroInterface.CriarLivro(livroDTO);
            return Ok(autores);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroDTO livroDTO)
        {
            var livros = await _livroInterface.EditarLivro(livroDTO);
            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroInterface.ExcluirLivro(idLivro);
            return Ok(livros);
        }
    }
}

