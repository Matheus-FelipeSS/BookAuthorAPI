using WebApi8.DTOs;
using WebApi8.Models;

namespace WebApi8.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDTO LivroDTO);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroDTO LivroDTO);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
