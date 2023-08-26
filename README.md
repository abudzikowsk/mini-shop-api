# Mini Shop API - .NET Core Project

## Description

The Mini Shop API is a .NET Core project that serves as the backend for a mini e-commerce application. It provides endpoints for creating, deleting, updating, and retrieving products, orders, and users. The project is built using .NET 7, Entity Framework, and Microsoft SQL Server.

## Features

## Orders:

- **Retrieve Orders**: Use the `GET /orders` endpoint to retrieve a list of all orders.
- **Create Order**: Utilize the `POST /orders` endpoint to create a new order.
- **Retrieve Specific Order**: Access details of a specific order using `GET /orders/{id}`.
- **Delete Order**: Delete an order with the `DELETE /orders/{id}` endpoint.

## Products:

- **Retrieve Products**: Fetch a list of all products using the `GET /products` endpoint.
- **Create Product**: Create a new product by sending a POST request to `/products`.
- **Retrieve Specific Product**: Get details of a specific product via `GET /products/{id}`.
- **Update Product**: Update product details using the `PUT /products/{id}` endpoint.
- **Delete Product**: Delete a product using the `DELETE /products/{id}` endpoint.

## User:

- **Retrieve Users**: Retrieve a list of all users using the `GET /users` endpoint.
- **Create User**: Create a new user by sending a POST request to `/users`.
- **Retrieve Specific User**: Access details of a specific user with `GET /users/{id}`.
- **Update User**: Update user details through the `PUT /users/{id}` endpoint.
- **Delete User**: Delete a user using the `DELETE /users/{id}` endpoint.

## Technology Stack

- **.NET 7:** The project is developed using .NET 7, leveraging the latest features and improvements of the framework.

- **Entity Framework:** Entity Framework is used as the Object-Relational Mapping (ORM) tool to interact with the Microsoft SQL Server database.

- **MS SQL Server:** The project utilizes Microsoft SQL Server to store and manage data. It provides a reliable and scalable database solution.

## Endpoints

## Orders:

- `GET /orders`: Retrieve a list of all orders.
- `POST /orders`: Create a new order.
- `GET /orders/{id}`: Retrieve details of a specific order.
- `DELETE /orders/{id}`: Delete an order.

## Products:

- `GET /products`: Retrieve a list of all products.
- `POST /products`: Create a new product.
- `GET /products/{id}`: Retrieve details of a specific product.
- `PUT /products/{id}`: Update details of a product.
- `DELETE /products/{id}`: Delete a product.

## User:

- `GET /users`: Retrieve a list of all users.
- `POST /users`: Create a new user.
- `GET /users/{id}`: Retrieve details of a specific user.
- `PUT /users/{id}`: Update details of a user.
- `DELETE /users/{id}`: Delete a user.


## Setup and Installation

1. Clone the repository: `git clone https://github.com/a.budzikowsk/mini-shop-api.git`
2. Navigate to the project directory: `cd mini-shop-api`
3. Install dependencies: `dotnet restore`
4. Configure the database connection string in `appsettings.json`.
5. Apply database migrations: `dotnet ef database update`
6. Run the application: `dotnet run`
