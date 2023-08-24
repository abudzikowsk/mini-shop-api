# Mini Shop API - .NET Core Project

## Description

The Mini Shop API is a .NET Core project that serves as the backend for a mini e-commerce application. It provides endpoints for creating, deleting, updating, and retrieving products, orders, and users. The project is built using .NET 7, Entity Framework, and Microsoft SQL Server.

## Features

- **Product Management:** Allows users to perform CRUD operations on products. They can create new products, update existing ones, and delete products from the inventory.

- **Order Management:** Users can create orders, specifying the products they want to purchase. Orders can be retrieved and managed through dedicated endpoints.

- **User Management:** Provides endpoints for user management, including user registration, authentication, and authorization. Users can sign up, log in, and access features based on their roles.

## Technology Stack

- **.NET 7:** The project is developed using .NET 7, leveraging the latest features and improvements of the framework.

- **Entity Framework:** Entity Framework is used as the Object-Relational Mapping (ORM) tool to interact with the Microsoft SQL Server database.

- **MS SQL Server:** The project utilizes Microsoft SQL Server to store and manage data. It provides a reliable and scalable database solution.

## Endpoints

1. **Products:**
   - `GET /api/products`: Retrieve a list of all products.
   - `GET /api/products/{id}`: Retrieve details of a specific product.
   - `POST /api/products`: Create a new product.
   - `PUT /api/products/{id}`: Update details of a product.
   - `DELETE /api/products/{id}`: Delete a product.

2. **Orders:**
   - `GET /api/orders`: Retrieve a list of all orders.
   - `GET /api/orders/{id}`: Retrieve details of a specific order.
   - `POST /api/orders`: Create a new order.
   - `PUT /api/orders/{id}`: Update details of an order.
   - `DELETE /api/orders/{id}`: Delete an order.

3. **Users:**
   - `POST /api/users/register`: Register a new user.
   - `POST /api/users/login`: Log in an existing user.
   - `GET /api/users/{id}`: Retrieve user profile.
   - `PUT /api/users/{id}`: Update user profile.

## Setup and Installation

1. Clone the repository: `git clone https://github.com/a.budzikowsk/mini-shop-api.git`
2. Navigate to the project directory: `cd mini-shop-api`
3. Install dependencies: `dotnet restore`
4. Configure the database connection string in `appsettings.json`.
5. Apply database migrations: `dotnet ef database update`
6. Run the application: `dotnet run`
