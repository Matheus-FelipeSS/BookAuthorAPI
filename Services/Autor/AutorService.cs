using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.DTOs;
using WebApi8.Models;

namespace WebApi8.Services.Autor
{
    public class AutorService : IAutorinterface
    {

        private readonly AppDbContext _context;
        public AutorService(AppDbContext Context)
        {
            _context = Context;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {

                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {

                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado!";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorDTO autorDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>> ();

            try
            {

                var autor = new AutorModel()
                {

                    Nome = autorDTO.Nome,
                    Sobrenome = autorDTO.Sobrenome,

                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso!";

                return resposta;

            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorDTO autorDTO)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {

                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorDTO.Id);
                    if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }

                    autor.Nome = autorDTO.Nome;
                    autor.Sobrenome = autorDTO.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }


        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
            try
            {

                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram encontrados!";

                return resposta;
            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
