using WebApplication8.Dto.Autor;
using WebApplication8.Models;

namespace WebApplication8.Services.Autor
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId( int IdAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdDoLivro(int IdLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int IdAutor);





    }
}
