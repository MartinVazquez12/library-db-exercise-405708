# utn-prog3-ef-library

Proyecto: Gestión de Biblioteca

Requisitos del Proyecto

Entidades:

Libro: ISBN, Título, Autor, Fecha de Publicación, Género.

Autor: Id, Nombre, Fecha de Nacimiento.

Género: Id, Nombre.

Realizar un CRUD de libros:

Crear, leer, actualizar y eliminar libros.

Relaciones:

Un libro puede tener un autor.

Un libro puede pertenecer a un género.

Pasos del Ejercicio

1. Crear un proyecto de api en Visual Studio.
2. Crear los modelos de las entidades.
3. Crear el contexto de la base de datos.
5. Usar code first para crear la base de datos.
6. Utilizar el patrón repositorio cada entidad.
7. Crear los controladores para cada entidad.
8. Crear los documentos HTML necesarios para poder conectarse con la API
    - Listado: contendrá el listado de los libros y la posibilidad de eliminarlos con un mensaje de confirmacion.
    - Creacion: un nuevo html que mostrará todos los datos para crear un nuevo libro. Al cargarlo exitosamente debe redireccionar al listado.
    - Actualizacion: un nuevo html similar a la pagina de creación solo que no deberá permitir modificar el ID. Debe cargar los datos del libro a modificar.

Instalar los paquetes necesarios:

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet add package Microsoft.EntityFrameworkCore.Design

