# UsersApp

UsersApp é uma API desenvolvida com **ASP.NET Core** para gerenciamento de usuários, utilizando diversas tecnologias modernas para garantir escalabilidade, segurança e boas práticas.

## Tecnologias Utilizadas

- **[ASP.NET Core API](https://learn.microsoft.com/aspnet/core/)** - Framework para criação de APIs robustas e escaláveis.
- **[Entity Framework Core](https://learn.microsoft.com/ef/core/)** - ORM para manipulação do banco de dados relacional.
- **[AutoMapper](https://automapper.org/)** - Biblioteca para mapeamento automático de objetos.
- **[MediatR](https://github.com/jbogard/MediatR)** - Implementação do padrão CQRS para separação de responsabilidades.
- **[xUnit](https://xunit.net/)** - Framework de testes unitários.
- **[JWT (JSON Web Token)](https://jwt.io/)** - Autenticação segura via tokens.
- **[MongoDB](https://www.mongodb.com/)** - Banco de dados NoSQL utilizado para armazenamento de logs e histórico.
- **[SQL Server](https://www.microsoft.com/sql-server)** - Banco de dados relacional principal.

## Configuração e Execução

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/sql-server) instalado ou via Docker
- [MongoDB](https://www.mongodb.com/try/download/community) instalado ou via Docker
- [Docker e Docker Compose](https://docs.docker.com/compose/install/)

### Passos para rodar o projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/seuusuario/UsersApp.git
   cd UsersApp
   ```

2. Configure a conexão com os bancos de dados no **appsettings.json**.

3. Execute as migrações do Entity Framework:
   ```sh
   dotnet ef database update
   ```

4. Inicie a aplicação:
   ```sh
   dotnet run
   ```

### Executando com Docker Compose
Se preferir rodar a aplicação junto com os serviços do banco de dados via Docker Compose, execute:
```sh
docker-compose up -d
```
Isso iniciará os containers necessários, incluindo SQL Server e MongoDB.

## Testes
Para rodar os testes unitários, utilize:
```sh
dotnet test
```

## Autenticação
A API utiliza **JWT** para autenticação. Para acessar endpoints protegidos:
1. Faça login com um usuário válido.
2. Use o token JWT retornado no cabeçalho `Authorization` nas requisições subsequentes.

---

📌 **Contribuições são bem-vindas!** Sinta-se à vontade para abrir issues ou pull requests. 🚀
