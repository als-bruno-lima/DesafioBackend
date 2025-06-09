.NET API Rest Desafio Backend

Desarrollar una API Rest que permita gestionar una biblioteca digital, los usuarios podrán explorar y administrar libros, autores y géneros.
Para la gestión de la base de datos se utilizó SQL Server y el ORM EntityFramework, el deployment se realizó en azure.

El repositorio se encuentra alojado en github, para clonarlo correr en consola:
git clone https://github.com/als-bruno-lima/DesafioBackend.git
con el proyecto ya creado correr las migraciones con el comando: Update-database
Para correr el proyecto usa F5 para compilarlo, esto abrirá una interfaz de swagger en el navegador con los endpoints disponibles.

Para ver el proyecto desde el navegador deployado en azure acceder en: https://desafiobackend20250609103918-g6d9fpdwe7gwh8bc.canadacentral-01.azurewebsites.net/swagger/index.html

Ejemplo de uso
para acceder a los endpoints primero hay que estar logueado.
•	crear usuario
Endpoint: /auth/register
petición por body en formato json ejemplo:
{
"name": "usuarioDePrueba",
"email": "prueba@gmail.com",
"password": "123",
"status": 0
}

•	Loguearse
Endpoint: /auth/login
peticion por body en formato json ejemplo:
{
"email": "prueba@gmail.com",
"password": "123"
}
Una vez logueado exitosamente este endpoint nos proporciona una respuesta con un token en formato json, ejemplo: 
{
  "$id": "1",
  "message": "usuario encontrado",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJicnVub0BnbWFpbC5jb20iLCJqdGkiOiI2Njg1ODg2Yi1iNjEzLTQyNTctYjQ2My0zZGE0YzNhMjg2YjgiLCJpZCI6IjIiLCJlbWFpbCI6ImJydW5vQGdtYWlsLmNvbSIsImV4cCI6MTc0OTQ4NDI1MiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzE2My8iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo3MTYzLyJ9.WZ8O8D9QUnaZZcMKtUJ3rpLeGpzRBuigOOdB9hK5BrE",
  "email": "bruno@gmail.com"
}
Copiar el token y pegarlo en el endpoint de Authorize, se encuentra arriba del todo a la derecha. Una vez ingresado el token ya se tiene acceso a los demás endpoints. 






