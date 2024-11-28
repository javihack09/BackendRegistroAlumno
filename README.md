# Registro Alumno 📚

Este proyecto es una API RESTful diseñada para administrar un sistema de registro y consulta de estudiantes. 
Está construida con ASP.NET Core y permite realizar operaciones como listar estudiantes, 
consultar información por clases o materias, y registrar nuevos alumnos.


### Funcionalidades



Endpoint: GET /api/Estudiante/lista
- Descripción: Obtener la lista completa de estudiantes

Endpoint: GET /api/Estudiante/clase?clase={nombreClase}
- Descripción: Consultar estudiantes por clase específica

Endpoint: GET /api/Estudiante/materias
- Descripción: Obtener la lista de materias disponibles

Endpoint: GET /api/Estudiante/{id}
- Descripción: Consultar detalles de un estudiante por ID

Endpoint: POST /api/Estudiante
- Descripción: Registrar un nuevo estudiante


### Tecnologías utilizadas
ASP.NET Core 8.0 para la creación del backend.
Entity Framework
Inyección de dependencias para gestionar la lógica de acceso a datos (EstudianteData).


### Ejecuta el proyecto:

Copiar código
git clone https://github.com/usuario/registro-estudiantes.git

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
Accede a la API en http://localhost:5041/api/Estudiante.

### Requisitos del sistema
.NET Core SDK 6.0 o superior.
Una base de datos configurada compatible con el proyecto.

Cómo contribuir
1.Realiza un fork del repositorio.
2.Crea una rama para tu funcionalidad (git checkout -b nueva-funcionalidad).
3.Envía un pull request describiendo tus cambios.
