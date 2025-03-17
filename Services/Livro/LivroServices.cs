using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Dto.Autor;
using WebApplication8.Dto.Livro;
using WebApplication8.Models;

namespace WebApplication8.Services.Livro
{

    public class LivroServices : ILivroInterface
    {
        private readonly AppDbContext _context;
        public LivroServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int IdLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();
            try
            {
             var livro = await _context.Livro.Include(a=>a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nehum livro encontrado";
                    return resposta;
                }
                resposta.Dados = livro;
                return resposta;
            }
            catch(Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int IdAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new();
            try
            {
                var autor = await _context.Livro.Include(a => a.Autor).Where(livroBanco => livroBanco.Autor.Id == IdAutor).ToListAsync();
                if (autor == null)
                {
                    resposta.Mensagem = "nehum livro encontrado";
                    return resposta;
                }
                resposta.Dados = autor;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var resposta = new ResponseModel<List<LivroModel>>();
            try
            {
                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroCriacaoDto.Autor.Id);
                if(autor is null)
                {
                    resposta.Mensagem = "nehum registro de autor nao existe";
                    return resposta;
                }
                var livro = new LivroModel()
                {
                    Autor = autor,
                    Titulo = livroCriacaoDto.Titulo
                };
                _context.Add(livro);
                 await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livro.Include(a => a.Autor).ToListAsync();
                resposta.Mensagem = "Livro criado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEditarDto livroEdicaoDto)
        {
            var resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livro.Include(a => a.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEdicaoDto.Id);
                var autor = await _context.Autores.FirstOrDefaultAsync(a => a.Id == livroEdicaoDto.Id);
                if (livro == null) {
                    resposta.Mensagem = "nehum livro encontrado";
                    return resposta;
                }
                if (autor == null)
                {
                    resposta.Mensagem = "nehum registro de autor localizado";
                }
                livro.Titulo = livroEdicaoDto.Titulo;
                livro.Autor = autor;
                _context.Update(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livro.ToListAsync();
                resposta.Mensagem = "livro editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int IdLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new();

            try
            {
                var livro = await _context.Livro.FirstOrDefaultAsync(livroBanco => livroBanco.Id == IdLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nehum autor localizado";
                    return resposta;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livro.ToListAsync();
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivro()
        {
            ResponseModel<List<LivroModel>> resposta = new();
            try
            {
                var livros = await _context.Livro.Include(a=>a.Autor).ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os autores foram coletados";
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
