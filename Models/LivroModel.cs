
namespace WebApplication8.Models
{

    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; }

        //public static implicit operator List<object>(LivroModel v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
