# 🏪 Sistema de Gerenciamento de Produtos - API REST .NET
![badge](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)
![badge](https://img.shields.io/badge/C%2523-11.0-239120?logo=c-sharp)
![badge](https://img.shields.io/badge/ASP.NET_Core-8.0-512BD4?logo=dotnet)
![badge](https://img.shields.io/badge/Swagger-85EA2D?logo=swagger)
![badge](https://img.shields.io/badge/License-MIT-green)

## Uma API RESTful completa desenvolvida em .NET 8 para gerenciamento de produtos e usuários, seguindo os princípios da arquitetura cliente-servidor com documentação Swagger integrada.

## ✨ Funcionalidades
-  API RESTful completa com endpoints HTTP
-  CRUD completo de produtos e usuários
-  Documentação automática com Swagger/OpenAPI
-  Dados fictícios para demonstração e testes
-  Configuração CORS para consumo por clientes web
-  Validação de dados e tratamento de erros
-  Cliente console integrado para testes
-  Arquitetura limpa com separação de concerns

## 🏗️ Arquitetura:
```bash
┌─────────────────┐    HTTP Requests    ┌─────────────────┐
│                 │ ──────────────────► │                 │
│   CLIENTE       │                     │     SERVIDOR    │
│   Console App   │                     │   API .NET 8    │
│                 │ ◄────────────────── │                 │
└─────────────────┘    JSON Responses   └─────────────────┘
```
## 🚀 Como Executar
## Pré-requisitos:
- .NET 8 SDK
- Visual Studio 2022 ou VS Code

## 📥 Clone e Configuração
```bash
#Clone o repositório
git clone https://github.com/seu-usuario/api-gerenciamento-produtos.git
cd api-gerenciamento-produtos

# Restaure as dependências
dotnet restore

# Execute a API
cd ApiFicticia
dotnet run
```
## 🌐 Acessos
* API: http://localhost:5000
* Swagger UI: http://localhost:5000/swagger
* Health Check: http://localhost:5000/api/produtos

## 📡 Endpoints da API
### 🎯 Produtos
### Método	// Endpoint	// Descrição
- GET	/api/produtos	Lista todos os produtos
- GET	/api/produtos/{id}	Busca produto por ID
- POST	/api/produtos	Cria novo produto
- GET	/api/produtos/categoria/{categoria}	Filtra por categoria
  
### 👥 Usuários
### Método	// Endpoint	// Descrição
- GET	/api/usuarios	Lista todos os usuários
- GET	/api/usuarios/{id}	Busca usuário por ID
- GET	/api/usuarios/ativos	Lista usuários ativos
  
## 🛠️ Tecnologias Utilizadas
* .NET 8 - Framework principal
* ASP.NET Core - Web API framework
* Swagger/OpenAPI - Documentação da API
* HttpClient - Consumo de APIs (cliente)
* C# 11 - Linguagem de programação
* JSON - Formato de serialização

## 🎯 Exemplos de Uso
### 📨 Requisições HTTP
Listar todos os produtos:
```bash
GET http://localhost:5000/api/produtos
```
Buscar produto específico:
```bash
GET http://localhost:5000/api/produtos/1
``` 
Criar novo produto:
```bash
POST http://localhost:5000/api/produtos

Content-Type: application/json

{
  "nome": "Notebook Dell",
  "preco": 3299.99,
  "estoque": 15,
  "categoria": "Eletrônicos"
}
```
Listar usuários ativos:
```bash
GET http://localhost:5000/api/usuarios/ativos
``` 
## 🖥️ Cliente Console
### O projeto inclui um cliente console para testar a API:

```bash
cd ClienteConsole
dotnet run
```

## 📦 Estrutura do Projeto
```bash
ApiGerenciamentoProdutos/
├── 📁 ApiFicticia/
│   ├── 📁 Controllers/
│   │   ├── ProdutosController.cs
│   │   └── UsuariosController.cs
│   ├── 📁 Models/
│   │   ├── Produto.cs
│   │   └── Usuario.cs
│   ├── 📁 Services/
│   │   └── DadosService.cs
│   ├── Program.cs
│   └── ApiFicticia.csproj
│
├── 📁 ClienteConsole/
│   ├── Program.cs
│   └── ClienteConsole.csproj
│
└── 📄 ApiGerenciamentoProdutos.sln
```
📊 Modelos de Dados

## 🏷️ Produto
```bash
csharp
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
    public string Categoria { get; set; }
    public DateTime DataCriacao { get; set; }
}
´´´

## 👤 Usuário
```bash
csharp
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }
    public bool Ativo { get; set; }
}
```
## 🧪 Testando a API Via Swagger
- Acesse http://localhost:5000/swagger

## 🤝 Contribuição
- Contribuições são bem-vindas! Siga os passos:
- Fork o projeto
- Crie uma branch para sua feature (git checkout -b feature/AmazingFeature)
- Commit suas mudanças (git commit -m 'Add some AmazingFeature')
- Push para a branch (git push origin feature/AmazingFeature)
- Abra um Pull Request

### 📄 Licença:
## Este projeto está sob a licença MIT. Veja o arquivo LICENSE para detalhes.

## 🙋‍♂️ Suporte
Se você tiver alguma dúvida ou sugestão, sinta-se à vontade para abrir uma issue

## Enviar um e-mail para: [enzoblousa@gmail.com](to.Mail(enzoblousa@gmail.com))

## ⭐️ Se este projeto te ajudou, deixe uma estrela no GitHub!
