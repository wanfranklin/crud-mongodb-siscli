# CRUD MongoDB (Console Application)

Este é um projeto simples que demonstra operações CRUD (Create, Read, Update, Delete) em um banco de dados MongoDB usando C# e .NET. A aplicação de console interage com o banco de dados MongoDB para realizar operações básicas em uma coleção de clientes.

## Funcionalidades

- Adiciona um novo cliente ao banco de dados MongoDB.
- Lista todos os clientes armazenados no banco de dados MongoDB.

## Configuração

Certifique-se de ter o .NET 7 SDK e o MongoDB instalados na sua máquina.

### Instalação do MongoDB

Siga as instruções de instalação fornecidas no [site oficial do MongoDB](https://www.mongodb.com/try/download/community).

### Execução do projeto

- Clone o repositório para a sua máquina local.
- Abra o projeto no Visual Studio Code ou em qualquer outro editor de código de sua preferência.
- Certifique-se de configurar corretamente a string de conexão e o nome do banco de dados no arquivo `appsettings.json`.

- Execute o projeto.

## Estrutura do Projeto

O projeto está estruturado da seguinte forma:

- `Domain`: Contém os modelos de domínio e as interfaces.
- `Infrastructure`: Responsável por implementar a lógica de acesso a dados.
- `Application`: Responsável pela lógica de negócios e pela intermediação entre a camada de apresentação e a camada de infraestrutura.
- `Presentation`: Contém a camada de apresentação e interação com o usuário.

## Dependências

Certifique-se de ter as seguintes dependências instaladas:

- MongoDB.Driver

## Licença

Este projeto está licenciado sob a [Licença MIT](https://opensource.org/licenses/MIT).

## Autor

Wanfranklin Alves

