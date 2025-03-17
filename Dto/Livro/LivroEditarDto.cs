using WebApplication8.Models;

namespace WebApplication8.Dto.Livro
{
    public class LivroEditarDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }
    }
}
