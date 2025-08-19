using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;

namespace ClienteConsole
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUrl = "http://localhost:5000/api";

        static async Task Main(string[] args)
        {
            Console.WriteLine("=== CLIENTE CONSOLE - API FICTÍCIA ===");
            Console.WriteLine("Conectando à API...\n");

            try
            {
                await MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
                Console.WriteLine("Certifique-se de que a API está rodando na porta 5000");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static async Task MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Listar Produtos");
                Console.WriteLine("2. Buscar Produto por ID");
                Console.WriteLine("3. Listar Usuários");
                Console.WriteLine("4. Buscar Usuário por ID");
                Console.WriteLine("5. Usuários Ativos");
                Console.WriteLine("6. Adicionar Novo Produto");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");

                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        await ListarProdutos();
                        break;
                    case "2":
                        await BuscarProdutoPorId();
                        break;
                    case "3":
                        await ListarUsuarios();
                        break;
                    case "4":
                        await BuscarUsuarioPorId();
                        break;
                    case "5":
                        await ListarUsuariosAtivos();
                        break;
                    case "6":
                        await AdicionarProduto();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static async Task ListarProdutos()
        {
            Console.WriteLine("\n--- LISTA DE PRODUTOS ---");
            var response = await client.GetAsync($"{baseUrl}/produtos");
            response.EnsureSuccessStatusCode();
            
            var produtos = await response.Content.ReadFromJsonAsync<object>();
            Console.WriteLine(JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true }));
        }

        static async Task BuscarProdutoPorId()
        {
            Console.Write("\nDigite o ID do produto: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var response = await client.GetAsync($"{baseUrl}/produtos/{id}");
                
                if (response.IsSuccessStatusCode)
                {
                    var produto = await response.Content.ReadFromJsonAsync<object>();
                    Console.WriteLine(JsonSerializer.Serialize(produto, new JsonSerializerOptions { WriteIndented = true }));
                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("ID inválido!");
            }
        }

        static async Task ListarUsuarios()
        {
            Console.WriteLine("\n--- LISTA DE USUÁRIOS ---");
            var response = await client.GetAsync($"{baseUrl}/usuarios");
            response.EnsureSuccessStatusCode();
            
            var usuarios = await response.Content.ReadFromJsonAsync<object>();
            Console.WriteLine(JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true }));
        }

        static async Task BuscarUsuarioPorId()
        {
            Console.Write("\nDigite o ID do usuário: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var response = await client.GetAsync($"{baseUrl}/usuarios/{id}");
                
                if (response.IsSuccessStatusCode)
                {
                    var usuario = await response.Content.ReadFromJsonAsync<object>();
                    Console.WriteLine(JsonSerializer.Serialize(usuario, new JsonSerializerOptions { WriteIndented = true }));
                }
                else
                {
                    Console.WriteLine("Usuário não encontrado!");
                }
            }
            else
            {
                Console.WriteLine("ID inválido!");
            }
        }

        static async Task ListarUsuariosAtivos()
        {
            Console.WriteLine("\n--- USUÁRIOS ATIVOS ---");
            var response = await client.GetAsync($"{baseUrl}/usuarios/ativos");
            response.EnsureSuccessStatusCode();
            
            var usuarios = await response.Content.ReadFromJsonAsync<object>();
            Console.WriteLine(JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true }));
        }

        static async Task AdicionarProduto()
        {
            Console.WriteLine("\n--- ADICIONAR NOVO PRODUTO ---");
            
            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            
            Console.Write("Preço: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
            {
                Console.WriteLine("Preço inválido!");
                return;
            }
            
            Console.Write("Estoque: ");
            if (!int.TryParse(Console.ReadLine(), out int estoque))
            {
                Console.WriteLine("Estoque inválido!");
                return;
            }
            
            Console.Write("Categoria: ");
            var categoria = Console.ReadLine();

            var novoProduto = new
            {
                Nome = nome,
                Preco = preco,
                Estoque = estoque,
                Categoria = categoria
            };

            var response = await client.PostAsJsonAsync($"{baseUrl}/produtos", novoProduto);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Produto adicionado com sucesso!");
        }
    }
}