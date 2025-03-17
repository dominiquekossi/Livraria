using System.Text.Json.Serialization;

namespace WebApplication8.Models
{


    public class AutorModel
    {


        public int Id { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        [JsonIgnore]
        public ICollection<LivroModel> Livros { get; set; }
    }
}
