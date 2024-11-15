# Mutant Detection API

Este proyecto es una API desarrollada en ASP.NET Core 8.0, que detecta si un conjunto de secuencias de ADN pertenece a un mutante o no. Utiliza SQL Server para almacenar los registros de ADN, y cuenta con una funcionalidad para calcular estadísticas sobre los datos procesados.
#Arquitectura

Elegi utilizar una minimal API ya que no me parecio necesario para este proyecto hacer una API convencional ya que solo necesitaba dos endpoints.
Despues decidi utilizar una biblioteca de clases MutantLibrary/MutantDetection para poner ahi todo lo relacionado a los servicios que utilizan los endpoints para ver si es mutant o no, y lo relacionado al
modelado y la base de datos.
Despues hay otra biblioteca de clases que tiene los test unitarios.
No utilice una arquitectura limpia debido a que la complejidad del projecto no me parecia necesaria. 

#Aclaraciones

No llegue en tiempo pero me hubiera gustado agregar un Middleware para centralizar los errores o aunque sea agregarle serilog a la API para loggear.
Tampoco llegue a desplegar en la nube la imagen de docker.

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet) o superior.
- [Docker](https://www.docker.com/products/docker-desktop) (opcional, para contenedores).
- [Google Cloud SDK](https://cloud.google.com/sdk) (opcional, para despliegue en Google Cloud).
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (si no usas Docker o Google Cloud).

## Instalación

1. Clonar el repositorio:

   git clone https://github.com/mequerejeta/Querejeta-Meli.git
   cd Querejeta-Meli/MutantAPI

2.Una vez clonado abrir el proyecto con visual studio o vscode
3. Si se quiere usar SQLServer revisar el appsetting que apunte a tu base de datos local
4.Pasos para aplicar migraciones desde Visual Studio:
Accede a la Consola de Administrador de Paquetes:
Ve al menú "Herramientas" en la barra superior.
Selecciona "Administrador de paquetes NuGet" y luego "Consola del Administrador de Paquetes".
Selecciona en Default Project del Package Manager Console: ExternalMutants y en Startup Project MutantAPI

En la consola, ejecuta el siguiente comando para aplicar las migraciones a la base de datos:
Update-Database
Este comando aplicará todas las migraciones pendientes a la base de datos configurada en el DbContext. Si la base de datos no existe, la creará automáticamente.

Si no tienes migraciones, obtendrás un mensaje indicándote que no hay migraciones y deberas poner 

Add-Migration NombreDeLaMigracion
5.Una vez realizado este paso se debera correr el programa se puede usar el comando dotnet run, una vez que se corra se ejecutara el Seeder en el codigo que carga en la database datos iniciales para que 
se pueda probar el endpoint /stats/
