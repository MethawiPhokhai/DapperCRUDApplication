DapperCRUDApplication

How to run this project
1. Install Docker (https://www.docker.com/products/docker-desktop)
2. Run docker command to create SQL Server instant 

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd" `
   -p 1433:1433 --name mssql -h mssql `
   -d mcr.microsoft.com/mssql/server:2019-latest
   
3. Update Database Migration
4. Enjoy!! 
