using WebApi8.DTOs;
using WebApi8.Models;

namespace WebApi8.Services.Autor
{
    public interface IAutorinterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro);
        Task <ResponseModel<List<AutorModel>>> CriarAutor(AutorDTO autorDTO);

        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorDTO autorDTO);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);
    }
}
