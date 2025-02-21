```
# Buildar imagem do DB
docker image build -f docker/mysql.dockerfile -t mysql-db .

# Executar container do DB em modo daemon
docker run -d -p 3306:3306 --name mysql-db mysql-db

# Entrar no container pelo bash
docker exec -it mysql-db bash

# Acessar instância do Mysql (após o comando, inserir a senha 'pokepass')
mysql -uroot -p
```