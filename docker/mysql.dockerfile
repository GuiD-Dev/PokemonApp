FROM mysql:8.3

ENV MYSQL_ROOT_PASSWORD=pokepass \
    MYSQL_DATABASE=pokedb \
    MYSQL_USER=pokeuser \
    MYSQL_PASSWORD=pokepass