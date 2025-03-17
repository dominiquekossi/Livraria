using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;
using WebApplication8.Dto.Autor;
using WebApplication8.Models;

namespace WebApplication8.Services.Autor
{
    public class AutorServices : IAutorInterface
    {

        private AppDbContext _context;

        public AutorServices(AppDbContext context)
        {
            _context = context;
        }
    
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int IdAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autor => autor.Id == IdAutor);
                if (autor == null) {
                    resposta.Mensagem = "Nehum Resgistro Localizado";
                    return resposta;
                        }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor Localizado!";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdDoLivro(int IdLivro)
        {
        ResponseModel<AutorModel>resposta = new ResponseModel<AutorModel>();
            try
            {
             var livro = await _context.Livro.Include(a=>a.Autor).FirstOrDefaultAsync(LivroBanco => LivroBanco.Id == IdLivro);
                if (livro == null) {
                    resposta.Mensagem = "Nehum Resgistro Localizado";
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Todos os autores foram coletados";
                return resposta;


            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
           var resposta = new ResponseModel<List<AutorModel>>();
            try
            {

                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    SobreNome = autorCriacaoDto.SobreNome,
                };
                _context.Add(autor);
                await _context.SaveChangesAsync();
                resposta.Dados= await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {

            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Nehum autor localizado";
                    return resposta;
                }
                autor.Nome = autorEdicaoDto.Nome;
                autor.SobreNome = autorEdicaoDto.SobreNome;

                _context.Update(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int IdAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();
             
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == IdAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Nehum autor localizado";
                    return resposta;
                }
                _context.Remove(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                return resposta;
            }
            catch (Exception ex) {
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
                resposta.Mensagem = "Todos os autores foram coletados";
                return resposta;
            }
            catch (Exception ex) {
                resposta.Mensagem = ex.Message;
                resposta.Status= false;
                return resposta;
            }
        }
    }
}
