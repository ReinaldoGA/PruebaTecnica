# .NET 8  BooksAPI


## 📌 Descripción
Este proyecto es una prueba tecnica de una api de libros.

## 🚀 Tecnologías Utilizadas
- **.NET 8**
- **C#**
- **Entity Framework Core**
- **Swagger (Swashbuckle)**
- **Angular**

## 📂 Estructura del Proyecto

/BookAPI
│── /BookAPI
│   │── /BookAPI (Proyecto principal)
│   │── /Books.Core (Capa de aplicación y servicio)
│── /Front/booksfrontend
│   │── /src (Proyecto Front End Angular)

## 📌 EndPoints Principales 
| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/Books | Obtiene la lista de Libros |
| POST | /api/Books | Crea un nuevo Libro |
| GET | /api/Books/{id} | Obtiene un Libro por ID |
| PUT | /api/Books/{id} | Actualiza un Libro |
| DELETE | /api/Books/{id} | Elimina un Libro |
