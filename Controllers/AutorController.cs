using Microsoft.AspNetCore.Mvc;
using WebApi8.Models;
using WebApi8.Services.Autor;

using WebApi8.DTOs;


namespace WebApi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorinterface _autorInterface;

        public AutorController(IAutorinterface autorinterface)
        {
            _autorInterface = autorinterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorDTO>>>> ListarAutores()
        {
            var resultado = await _autorInterface.ListarAutores();

            var dto = resultado.Dados?.Select(a => new AutorDTO
            {
                Id = a.Id,
                Nome = a.Nome,
                Sobrenome = a.Sobrenome
            }).ToList();

            return Ok(new ResponseModel<List<AutorDTO>>
            {
                Dados = dto,
                Status = resultado.Status,
                Mensagem = resultado.Mensagem
            });
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorDTO>>> BuscarAutorPorId(int idAutor)
        {
            var resultado = await _autorInterface.BuscarAutorPorId(idAutor);

            AutorDTO? dto = null;
            if (resultado.Dados != null)
            {
                dto = new AutorDTO
                {
                    Id = resultado.Dados.Id,
                    Nome = resultado.Dados.Nome,
                    Sobrenome = resultado.Dados.Sobrenome
                };
            }

            return Ok(new ResponseModel<AutorDTO>
            {
                Dados = dto,
                Status = resultado.Status,
                Mensagem = resultado.Mensagem
            });
        }

        [HttpGet("BuscarAutorPorLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorDTO>>> BuscarAutorPorLivro(int idLivro)
        {
            var resultado = await _autorInterface.BuscarAutorPorLivro(idLivro);

            AutorDTO? dto = null;
            if (resultado.Dados != null)
            {
                dto = new AutorDTO
                {
                    Id = resultado.Dados.Id,
                    Nome = resultado.Dados.Nome,
                    Sobrenome = resultado.Dados.Sobrenome
                };
            }

            return Ok(new ResponseModel<AutorDTO>
            {
                Dados = dto,
                Status = resultado.Status,
                Mensagem = resultado.Mensagem
            });
        }

        [HttpPost("CriarAutor")]

        public async Task<ActionResult<ResponseModel<List<AutorDTO>>>> CriarAutor(AutorDTO autorDTO)
        {
            var autores = await _autorInterface.CriarAutor(autorDTO);

            return Ok (autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorDTO>>>> EditarAutor(AutorDTO autorDTO)
        {
            var autores = await _autorInterface.EditarAutor(autorDTO);

            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorDTO>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);

            return Ok(autores);
        }
    }
}
