# PokemonApp

Este projeto tem o objetivo de praticar os seguintes conhecimentos:

### **Clean Architecture**
- Divisão da arquitetura nas camadas:
  - Data (acesso ao banco de dados, repositórios, contextos, etc...)
  - API (contém os adaptadores da aplicação, como os controllers)
  - Application (contém os serviços de aplicação que orquestram a lógica de negócio)
  - Domain (contém as entidades que correspondem ao domínio da aplicação)

### **Entity Framework Core**
- Aplicação de migrations

### **Testes Unitários**
- Usando a dependência xUnit

### **Docker**
- Para executar o banco Mysql da aplicação em um container


## Como executar e acessar o DB

```bash
# Buildar imagem do DB
docker image build -f docker/mysql.dockerfile -t mysql-db .

# Executar container do DB em modo daemon
docker container run -d -p 3306:3306 --name mysql-db mysql-db

# Entrar no container pelo bash
docker container exec -it mysql-db bash

# Acessar instância do Mysql (após o comando, inserir a senha 'pokepass')
mysql -uroot -p
```