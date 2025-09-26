FROM mysql:5.7.22
EXPOSE 3306
COPY ./WebApp/db/migrations/ /home/database/
COPY ./WebApp/db/dataset/ /home/database/
COPY ./WebApp/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh