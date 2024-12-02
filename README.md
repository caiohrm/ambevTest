# To execute

## Change the appsettings.json with the required config

- DefaultConnection
- RabbitMq
- RabbitMqUser
- RabbitMqPassword

**if necessary you can create the infrastucture with docker containers with the following commands**

## RabbitMQ broker
- docker run -d --hostname my-rabbit --name some-rabbit2 -p 8080:15672  -p 5672:5672 -p25676:25676 rabbitmq:3-management

## PostgresSql
- docker run --name some-postgres -e POSTGRES_PASSWORD=mysecretpassword -d -p 5432:5432 postgres

To start testing it first create a new user, each user has different roles with privileges 

- Customer: Can create,update and Select (POST,PUT)    
- Manager: Can create,update,delete and Select (POST,PUT,GET,DELETE)
- Admin: Can create,update,delete and Select (POST,PUT,GET,DELETE)


