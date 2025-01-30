# Documentação do Projeto

Pré-requisitos
## Instalar .NET 8.0
Certifique-se de que o .NET 8 está instalado em sua máquina.

### Este projeto utiliza vários containers Docker para rodar as dependências necessárias. Abaixo estão os passos para configurar e executar a aplicação.

## Containers Necessários

### 1. SQL Server
```bash
docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password@123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```
  * Porta: 1433
  * Senha do SA: Password@123


### 2. RabbitMQ
```bash
docker run -d --hostname rabbitmq --name rabbitmq -e RABBITMQ_DEFAULT_USER=admin -e RABBITMQ_DEFAULT_PASS=admin -p 5672:5672 -p 15672:15672 rabbitmq:management
```
  * Interface de Gestão: http://localhost:15672
  * Usuário: admin
  * Senha: admin


### 3. Jaeger - Tracing
```bash
docker run --name jaeger -p 13133:13133 -p 16686:16686 -p 4317:4317 -d --restart=unless-stopped jaegertracing/opentelemetry-all-in-one
```
  * Interface de Gestão: http://localhost:16686


### 4. Seq - Logs
```bash
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
```
  * Interface de Gestão: http://localhost:5341


## Configuração da Aplicação

Após todos os containers estiverem em execução, siga os passos abaixo para configurar e iniciar a aplicação:

  1. Abra o projeto no Visual Studio.
  2. Nas configurações da Solution, marque a opção "Vários projetos de Inicialização".
  3. Altere a ação para "Iniciar" nos seguintes projetos:
      * Authentication.API
      * Vendas.API
      * WorkServiceFaturamento
  4. Inicie a aplicação pressionando F5.

## Passos para Realizar Vendas

### 1. Gerar Token de Autorização

Acesse a API de autenticação para gerar um token:
  * URL: https://localhost:7108/swagger/index.html
  * Método: POST /api/Authentication/login
  * Request:
    ```Json
    {
      "userName": "admin",
      "password": "123"
    }
    ```
Copie o token gerado.


### 2. Configurar Autorização na Vendas.API
Acesse a API de vendas configure o token de autorização:
  * URL: https://localhost:7226/swagger/index.html
  * No Swagger, clique no botão "Authorize" e cole o token gerado.


### 3. Realizar Vendas
Siga os passos abaixo para realizar uma venda:

  1. Cadastrar Cliente:
      * Método: POST /api/Cliente
      * Cadastre um novo cliente.

  2. Cadastrar Produto:
      * Método: POST /api/Produto
      * Cadastre um novo produto.

  3. Iniciar uma Venda:
      * Método: POST /api/Venda
      * Crie uma nova venda.

  4. Adicionar Item à Venda:
      * Método: POST /api/VendaItem
      * Adicione itens à venda criada.

  5. Faturar Venda:
      * Método: PUT /api/Venda/{id}/faturar
      * Finalize a venda alterando seu status para "Faturada".

  > [!NOTE]
  > Utilize as interfaces de gestão (RabbitMQ, Jaeger, Seq) para monitorar o funcionamento da aplicação.

  > [!IMPORTANT]
  > Certifique-se de que todos os containers estejam em execução antes de iniciar a aplicação.
 
