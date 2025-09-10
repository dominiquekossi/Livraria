A **RESTful API** built with **ASP.NET Core 8** to manage **books** and **authors**.  
The project implements full **CRUD operations** (Create, Read, Update, Delete) and follows clean architecture practices using **DTOs**, **Services**, and **Controllers**.

---

## 🚀 Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)  
- **Entity Framework Core**  
- **ASP.NET Core Web API**  
- **C#**  
- **PostgreSQL 
- **Swagger** (API documentation)  

---

## 📂 Project Structure

/Controllers
├── LivroController.cs # Book endpoints
├── AutorController.cs # Author endpoints
/Dto
├── Livro/ # DTOs for books
├── Autor/ # DTOs for authors
/Models
├── LivroModel.cs # Book entity
├── AutorModel.cs # Author entity
/Services
├── Livro/ILivroInterface.cs
├── Autor/IAutorInterface.cs

markdown
Copiar código

---

## 📌 Features

- **Books Management**  
  - List all books  
  - Get book by ID  
  - Get books by Author ID  
  - Create a new book  
  - Update book details  
  - Delete a book  

- **Authors Management**  
  - List all authors  
  - Get author by ID  
  - Get author by Book ID  
  - Create a new author  
  - Update author details  
  - Delete an author  

---

## 🔗 API Endpoints

### Books (`/api/Livro`)
- `GET /ListarLivro` → List all books  
- `GET /BuscarLivroPorId?IdLivro={id}` → Get book by ID  
- `GET /BuscarLivroPorIdAutor?IdAutor={id}` → Get books by author ID  
- `POST /CriarLivro` → Create new book  
- `PUT /EditarLivro` → Edit book  
- `DELETE /ExcluirLivro?IdLivro={id}` → Delete book  

### Authors (`/api/Autor`)
- `GET /ListarAutores` → List all authors  
- `GET /BuscarAutorPorId/{IdAutor}` → Get author by ID  
- `GET /BuscarAutorPorIdLivro/{IdLivro}` → Get author by book ID  
- `POST /CriarAutor` → Create new author  
- `PUT /EditarAutor` → Edit author  
- `DELETE /ExcluirAutor?IdAutor={id}` → Delete author  

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)  
- PostgreSQL (or SQL Server/MySQL)  

### Run the project
```bash
# Clone repository
git clone https://github.com/your-username/bookstore-api.git

# Navigate into project folder
cd bookstore-api

# Restore dependencies
dotnet restore

# Run the project
dotnet run
The API will be available at:

Swagger UI: https://localhost:5001/swagger

Base URL: https://localhost:5001/api

📌 Future Improvements
Authentication & Authorization with JWT

Unit & Integration tests

Docker support

CI/CD pipeline
