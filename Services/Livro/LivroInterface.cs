using WebApplication8.Dto.Autor;
using WebApplication8.Dto.Livro;
using WebApplication8.Models;

namespace WebApplication8.Services.Livro
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivro();
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int IdLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int IdAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro( LivroCriacaoDto livroCriacaoDto);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEditarDto livroEdicaoDto);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int IdLivro);
    }
}
