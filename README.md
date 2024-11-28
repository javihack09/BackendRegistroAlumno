#Registro de Estudiantes 📚

Este proyecto es una API RESTful diseñada para administrar un sistema de registro y consulta de estudiantes. 
Está construida con ASP.NET Core y permite realizar operaciones como listar estudiantes, 
consultar información por clases o materias, y registrar nuevos alumnos.

Funcionalidades
Obtener la lista completa de estudiantes

Endpoint: GET /api/Estudiante/lista
Consultar estudiantes por clase específica

Endpoint: GET /api/Estudiante/clase?clase={nombreClase}
Obtener la lista de materias disponibles

Endpoint: GET /api/Estudiante/materias
Consultar detalles de un estudiante por ID

Endpoint: GET /api/Estudiante/{id}
Registrar un nuevo estudiante

Endpoint: POST /api/Estudiante
Requiere un objeto JSON con la información del estudiante.

Tecnologías utilizadas
ASP.NET Core para la creación del backend.
Entity Framework (suponiendo que se utiliza para interactuar con la base de datos).
Inyección de dependencias para gestionar la lógica de acceso a datos (EstudianteData).
Cómo iniciar el proyecto
Cómo iniciar el proyecto
Clona el repositorio:

bash
Copiar código
git clone https://github.com/usuario/registro-estudiantes.git
Configura la conexión a la base de datos en el archivo appsettings.json.

Ejecuta el proyecto:

Configuración de la Base de Datos
Antes de ejecutar la aplicación, es necesario configurar la base de datos en SQL Server creando las tablas y procedimientos almacenados necesarios.

Configuración de la Cadena de Conexión
Este proyecto utiliza una cadena de conexión (StringSQL) para conectarse a la base de datos. Es necesario configurarla antes de ejecutar el proyecto. La cadena de conexión se encuentra en el archivo appsettings.json.

Pasos para modificar la cadena de conexión:
Abre el archivo appsettings.json en la raíz del proyecto.

👀 Busca la sección "ConnectionStrings" y localiza "StringSQL".

Reemplaza el valor actual con la cadena de conexión de tu base de datos.

bash
Copiar código
dotnet run
Accede a la API en http://localhost:5000/api/Estudiante.

Requisitos del sistema
.NET Core SDK 6.0 o superior.
Una base de datos configurada compatible con el proyecto.
Cómo contribuir
1.Realiza un fork del repositorio.
2.Crea una rama para tu funcionalidad (git checkout -b nueva-funcionalidad).
3.Envía un pull request describiendo tus cambios.
