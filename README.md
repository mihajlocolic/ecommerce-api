# E-Commerce App API

A RESTful API backend for an e-commerce platform built with ASP.NET Core, Entity Framework Core, and Azure SQL Database.

🔗 **Live Demo:** [Frontend](https://mihajlocolic.github.io/ecommerce-frontend/index.html) | [API](ecommerce-api20251105080905-b7c5d8gbazahhhdw.canadacentral-01.azurewebsites.net/api/product)

## Features

- Product and Category management (CRUD operations)
- Product search functionality
- Category-based filtering
- RESTful API design
- Azure SQL Database integration
- Deployed on Azure App Service

## Tech Stack

- **Backend:** ASP.NET Core 9.0
- **ORM:** Entity Framework Core
- **Database:** Azure SQL Database
- **Hosting:** Azure App Service
- **Frontend:** [Separate repository](https://github.com/yourusername/ecommerce-ui)

## API Endpoints

- `GET /api/product` - Get all products
- `GET /api/product?categoryId={id}` - Filter by category
- `GET /api/product?productName={name}` - Search products
- `POST /api/product` - Create products
- `GET /api/category` - Get all categories
- `POST /api/category` - Create categories

## Local Setup

1. Install [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
2. Clone the repository
```bash
   git clone https://github.com/yourusername/ecommerce-api
   cd ecommerce-api
```
3. Update the connection string in `appsettings.json` (or use environment variable)
4. Run the application
```bash
   dotnet run
```

## Project Purpose

This project was created as a learning exercise to demonstrate full-stack development skills, focusing on backend API development, database integration, and cloud deployment.

## License

MIT
