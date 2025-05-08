using Microsoft.EntityFrameworkCore;
using WebApi8.Data;
using WebApi8.DTOs;
using WebApi8.Models;

namespace WebApi8.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(l => l.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros foram encontrados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            var resposta = new ResponseModel<LivroModel>();
            try
            {
                var livro = await _context.Livros.Include(l => l.Autor).FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro localizado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorAutor(int idAutor)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livros = await _context.Livros.Include(l => l.Autor).Where(l => l.Autor.Id == idAutor).ToListAsync();

                if (livros == null || !livros.Any())
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livros;
                resposta.Mensagem = "Livros localizados!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDTO livroDTO)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroDTO.AutorId);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado!";
                    return resposta;
                }

                var livro = new LivroModel
                {
                    Titulo = livroDTO.Titulo,
                    AutorId = autor.Id
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroDTO livroDTO)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == livroDTO.Id);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroDTO.AutorId);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado!";
                    return resposta;
                }

                livro.Titulo = livroDTO.Titulo;
                livro.AutorId = autor.Id;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(l => l.Autor).ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(l => l.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro localizado!";
                    return resposta;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.Include(l => l.Autor).ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso!";
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
