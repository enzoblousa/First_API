using ApiFicticia.Models;

namespace ApiFicticia.Services
{
    public class DadosService
    {
        private readonly List<Produto> _produtos;
        private readonly List<Usuario> _usuarios;

        public DadosService()
        {
            _produtos = GerarProdutosFicticios();
            _usuarios = GerarUsuariosFicticios();
        }

        public List<Produto> ObterTodosProdutos() => _produtos;
        public List<Usuario> ObterTodosUsuarios() => _usuarios;

        public Produto? ObterProdutoPorId(int id) => 
            _produtos.FirstOrDefault(p => p.Id == id);

        public Usuario? ObterUsuarioPorId(int id) => 
            _usuarios.FirstOrDefault(u => u.Id == id);

        public Produto AdicionarProduto(Produto produto)
        {
            produto.Id = _produtos.Max(p => p.Id) + 1;
            produto.DataCriacao = DateTime.Now;
            _produtos.Add(produto);
            return produto;
        }

        private List<Produto> GerarProdutosFicticios() => new()
        {
            new Produto { Id = 1, Nome = "Notebook Gamer", Preco = 4500.99m, Estoque = 15, Categoria = "Eletrônicos", DataCriacao = DateTime.Now.AddDays(-30) },
            new Produto { Id = 2, Nome = "Smartphone", Preco = 1899.90m, Estoque = 25, Categoria = "Eletrônicos", DataCriacao = DateTime.Now.AddDays(-15) },
            new Produto { Id = 3, Nome = "Mouse Sem Fio", Preco = 89.90m, Estoque = 50, Categoria = "Periféricos", DataCriacao = DateTime.Now.AddDays(-10) },
            new Produto { Id = 4, Nome = "Teclado Mecânico", Preco = 299.90m, Estoque = 20, Categoria = "Periféricos", DataCriacao = DateTime.Now.AddDays(-5) },
            new Produto { Id = 5, Nome = "Monitor 24\"", Preco = 899.90m, Estoque = 12, Categoria = "Monitores", DataCriacao = DateTime.Now.AddDays(-3) }
        };

        private List<Usuario> GerarUsuariosFicticios() => new()
        {
            new Usuario { Id = 1, Nome = "João Silva", Email = "joao@email.com", Idade = 28, Ativo = true },
            new Usuario { Id = 2, Nome = "Maria Santos", Email = "maria@email.com", Idade = 32, Ativo = true },
            new Usuario { Id = 3, Nome = "Pedro Costa", Email = "pedro@email.com", Idade = 25, Ativo = false },
            new Usuario { Id = 4, Nome = "Ana Oliveira", Email = "ana@email.com", Idade = 29, Ativo = true },
            new Usuario { Id = 5, Nome = "Carlos Souza", Email = "carlos@email.com", Idade = 35, Ativo = true }
        };
    }
}