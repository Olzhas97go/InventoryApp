# Inventory Management System

This project is a simple ASP.NET Core web application that allows users to manage an inventory of products. The system includes functionality for viewing a list of available products, adding new products, updating existing ones, and deleting products. The product information is persisted in a MySQL database using Entity Framework Core (EF Core).

## Features

- **View Products**: See a list of all products in the inventory with details such as name, description, price, and quantity.
- **Add Products**: Add new products to the inventory by specifying their name, description, price, and quantity.
- **Edit Products**: Update the details of existing products in the inventory.
- **Delete Products**: Remove products from the inventory.

## Technologies Used

- **ASP.NET Core**: For building the web application and handling HTTP requests.
- **Entity Framework Core (EF Core)**: For interacting with the MySQL database to persist product information.
- **MySQL**: For storing product information.
- **XUnit**: For unit testing the controller methods.

## Project Structure

- **Controllers**: Contains the `InventoryController`, which manages the CRUD operations for the products.
- **Models**: Contains the `Product` class, which represents the product entity with properties such as `Id`, `Name`, `Description`, `Price`, and `Quantity`.
- **Data**: Contains the `InventoryContext` class that represents the EF Core DbContext for interacting with the MySQL database.

## Database Setup

The project uses a MySQL database to store product information. Ensure that you have a MySQL server running and properly configured for the application to connect.

### Steps:

1. **Install MySQL**:
   Download and install [MySQL](https://www.mysql.com/downloads/).

2. **Update `appsettings.json`**:
   Update the connection string in the `appsettings.json` file to point to your MySQL server:
   
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=InventoryDB;User=root;Password=your_password;"
   }
Migrate the Database: Use the Entity Framework Core migration tools to create and apply the database schema:

bash
Copy code
dotnet ef migrations add InitialCreate
dotnet ef database update
Getting Started
Prerequisites
.NET 6 SDK
MySQL
Visual Studio or Rider
Running the Application
Clone the repository:

bash
Copy code
git clone https://github.com/Olzhas97go/InventoryApp.git
cd InventoryApp
Update the database connection string in appsettings.json to point to your MySQL instance.

Restore dependencies and run the application:

bash
Copy code
dotnet restore
dotnet run
Open your browser and navigate to http://localhost:5000/Inventory to see the inventory list.

Testing
This project uses XUnit to test the functionality of the InventoryController.

Running Tests
To run the tests, use the following command:

bash
Copy code
dotnet test
The test project includes the following unit tests:

Index_ReturnsAViewResult_WithAListOfProducts: Verifies that the Index method returns a list of products.
Details_ReturnsViewWithProduct_WhenIdIsValid: Ensures the Details method returns the correct product for a valid ID.
Create_ValidProduct_RedirectsToIndex: Checks if a valid product creation redirects to the index page.
Edit_ValidProduct_RedirectsToIndex: Verifies that editing a product with valid information works correctly.
Delete_Confirmed_RedirectsToIndex: Ensures that deleting a product works and redirects to the index page.
License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
Author: Sagidolla Olzhas
Email: your.email@example.com
GitHub: Olzhas97go
