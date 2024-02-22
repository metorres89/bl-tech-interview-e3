# Book REST API

This is a sample web api made in .NET Core 8. The goal of this project is to showcase how to assemble and implement a REST Api to perform CRUD operations over an entity. The web api also includes JWT token authentication.

The project is based on a made up user story which serves as a leading domain for the program.

## User story

    As a library administrator, I want to have a RESTful API to manage a catalog of books efficiently. The API should support CRUD operations and adhere to the principles of REST architecture. Additionally, it should be developed using .NET Core 8, include Swagger for documentation, and avoid the use of EF Core, Dapper, and other Object-Relational Mapping (ORM) tools.

    Create Book:

        As a user, I should be able to add a new book to the catalog.
        The API should expose an HTTP POST endpoint to create a new book.
        The request payload should include necessary details such as title, author, ISBN, and any other relevant information.
        The response should include the newly created book with its unique identifier.
    
    Read Book:

        As a user, I should be able to retrieve information about a specific book.
        The API should expose an HTTP GET endpoint to retrieve a book based on its unique identifier.
        The response should include details such as title, author, ISBN, and other relevant information.
    
    Update Book:

        As a user, I should be able to update the details of an existing book in the catalog.
        The API should expose an HTTP PUT endpoint to update the information of a specific book.
        The request payload should include the unique identifier of the book and the updated information.
        The response should include the updated book details.
    
    Delete Book:

        As a user, I should be able to remove a book from the catalog.
        The API should expose an HTTP DELETE endpoint to delete a specific book based on its unique identifier.
        The response should confirm the successful deletion of the book.
    
    List All Books:

        As a user, I should be able to retrieve a list of all books in the catalog.
        The API should expose an HTTP GET endpoint to retrieve the entire catalog.
        The response should include a collection of books with their details.

### Requirements

There are some additional restrictions related to technical aspects:

1. I cannot use Entity Framework, Dapper or Mediator to perform operations against a Db.
2. The code should adhere to Clean Architecture principles.
3. The development should be lead by Test-Driven Development methodologies (TDD).
4. The application should be divided in some basic modules:
   1. API: to expose endpoints to perform CRUD operations for an entity.
   2. Data Layer: to enclose the logic related to data access.
   3. Buisiness logic layer: to enclose the business rules related to the domain.
   4. Unit tests: to enclose unit tests for every layer of the application.

### Design

#### Business layer

![Business package](out/uml.business.design/uml.business.design.png)

#### Data access layer
![Data package](out/uml.data.design/uml.data.design.png)

#### WebApi layer
![WebApi package](out/uml.webapi.design/uml.webapi.design.png)

### Project structure
TODO

### Development process
TODO

### How to run
