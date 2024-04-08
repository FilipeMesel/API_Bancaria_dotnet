# API Bancária Simples

Esta é uma API bancária simples desenvolvida em C# usando ASP.NET Core. A API permite a criação de usuários, contas associadas a esses usuários, depósitos e saques em contas.

## Funcionalidades Principais

**Listar Usuários:**
Retorna todos os usuários cadastrados na API.

**Método: GET**
URL: /api/bank/users
Criar Usuário: Cria um novo usuário na API.

**Método: POST**
URL: /api/bank/users
Corpo da Requisição (JSON)

```bash
    {
        "name": "John Doe",
        "age": 30,
        "weight": 75.5,
        "phone": "123456789"
    }
```

**Obter Usuário por ID: Retorna as informações de um usuário com base no seu ID.**
Método: GET
URL: /api/bank/users/{userId}

**Criar Conta para um Usuário: Cria uma nova conta associada a um usuário existente.**
Método: POST
URL: /api/bank/users/{userId}/accounts

**Listar Contas de um Usuário: Retorna todas as contas associadas a um usuário específico.**
Método: GET
URL: /api/bank/users/{userId}/accounts

**Obter Conta por ID: Retorna as informações de uma conta com base no seu ID.**
Método: GET
URL: /api/bank/accounts/{accountId}

**Depositar em uma Conta: Realiza um depósito em uma conta existente.**
Método: POST
URL: /api/bank/accounts/{accountId}/deposit
Corpo da Requisição (JSON):
``` bash
100
```

**Sacar de uma Conta: Realiza um saque em uma conta existente.**
Método: POST
URL: /api/bank/accounts/{accountId}/withdraw
Corpo da Requisição (JSON):
``` bash
50
```

## Pré-requisitos
Certifique-se de ter o .NET Core SDK instalado na sua máquina.

## Executando a API

1. Clone o repositório para sua máquina:
```bash
git clone https://github.com/seu-usuario/minha-primeira-api.git
```

2. Navegue até o diretório
```bash
cd minha-primeira-api
```

3. No cmd, digite:
```bash
dotnet run
```

## Tecnologias Utilizadas
* ASP.NET Core
* C#
* RESTful API
* Visual Studio Code
* Insomnia (ou outro cliente HTTP)