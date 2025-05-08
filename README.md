# BookAuthorAPI - API de Gerenciamento de Livros e Autores

Esta é uma API REST desenvolvida em .NET 8 para gerenciamento de livros e autores, utilizando Entity Framework Core e PostgreSQL como banco de dados.

## 🚀 Tecnologias Utilizadas

- .NET 8.0
- Entity Framework Core 9.0.4
- PostgreSQL
- Swagger/OpenAPI
- Docker

## 📋 Pré-requisitos

- .NET 8.0 SDK
- Docker (opcional)
- PostgreSQL

## 🔧 Configuração

1. Clone o repositório
2. Configure a string de conexão no arquivo `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=webapi8;Username=seu_usuario;Password=sua_senha"
  }
}
```

3. Execute as migrações do banco de dados:
```bash
dotnet ef database update
```

## 🚀 Executando o Projeto

### Usando Docker
```bash
docker build -t webapi8 .
docker run -p 8080:8080 webapi8
```

### Localmente
```bash
dotnet run
```

A API estará disponível em `http://localhost:8080`

## 📚 Documentação da API

A documentação Swagger está disponível na raiz da aplicação (`/`). Ela fornece uma interface interativa para testar todos os endpoints disponíveis.

## 📦 Estrutura do Projeto

- `Controllers/` - Controladores da API
- `Models/` - Modelos de dados
- `DTOs/` - Objetos de transferência de dados
- `Services/` - Serviços de negócio
- `Data/` - Contexto do banco de dados e configurações
- `Migrations/` - Migrações do Entity Framework

## 🔄 Endpoints Principais

A API possui endpoints para gerenciamento de:
- Autores
- Livros

## 🔒 Segurança

- A API utiliza autenticação e autorização
- Configurações sensíveis são gerenciadas através de User Secrets

## 🤝 Contribuindo

1. Faça um Fork do projeto
2. Crie uma Branch para sua Feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a Branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📝 Licença

Este projeto está sob a licença MIT. 
