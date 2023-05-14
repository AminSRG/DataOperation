# DataOperation

# Project Description
This project is an implementation of a CRUD (Create, Read, Update, Delete) operation for DataExample with different fields using RSA 2048 key encryption. The project is structured using the MediatR pattern to communicate between the API endpoint and the application layer. The intention is to enable the implementation of the CQRS pattern in the future.

The project uses Entity Framework Core as the ORM and the Unit of Work pattern for managing database transactions. Additionally, the project includes the NLog logging system. A class library has been created in the frameworks solution folder and referenced in the project to handle RSA encryption and other useful features. This class library can be published as a package on NuGet and used by referencing it in other projects.

# Technologies Used
C#
RSA 2048 key encryption
MediatR pattern
Entity Framework Core (EFCore)
Unit of Work pattern
NLog logging system
Project Structure
DataExample.API - This project is responsible for handling the API endpoint and routing the requests to the appropriate handlers.
DataExample.Application - This project contains all the business logic and handlers required to carry out the CRUD operation.
DataExample.Domain - This project contains all the domain models and entities.
DataExample.Infrastructure - This project is responsible for handling the database operations and communication with the external services.
DataExample.Frameworks - This project contains the RSA encryption and logging system.
DataExample.Tests - This project contains all the unit tests.

# How to Use
Clone this repository to your local machine.
Open the solution file in Visual Studio.
Build the solution.
Run the API project.
Encrypt the sample data using the RSAController/encryptor API. The sample data is as follows:
json
Copy code
{
  "CustomerNumber": "123456",
  "Name": "John Smith",
  "Price": 99.99,
  "IsActive": true,
  "CreatedDate": "2023-05-14T12:30:00Z"
}
Use the encrypted data in the request body of the API endpoint for carrying out CRUD operations.

# Future Enhancements
Implementation of the CQRS pattern.
Integration with an external key management service for better security.
Deployment to cloud platforms like Azure or AWS.

# Credits
This project was created by Amin Sohrabi.
