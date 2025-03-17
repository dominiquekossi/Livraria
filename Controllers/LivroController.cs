using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Dto.Livro;
using WebApplication8.Models;
using WebApplication8.Services.Autor;
using WebApplication8.Services.Livro;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }
        [HttpGet("ListarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivro()
        {
            var autores = await _livroInterface.ListarLivro();
            return Ok(autores);
        }
        [HttpGet("BuscarLivroPorId")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int IdLivro)
        {
         var livro = await _livroInterface.BuscarLivroPorId(IdLivro);
            return Ok(livro);
        }
        [HttpGet("BuscarLivroPorIdAutor")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int IdAutor)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(IdAutor);
            return Ok(livro);
        }
        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livro = await _livroInterface.CriarLivro(livroCriacaoDto);
            return Ok(livro);
        }
        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEditarDto livroEdicaoDto)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicaoDto);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int IdLivro)
        {
            var livro = await _livroInterface.ExcluirLivro(IdLivro);
            return Ok(livro);
        }
    }
}
