# DocumentKeeper

## Description
DocumentKeeper is a Razor Pages project integrated with Swagger for seamless uploading and downloading of documents. This application facilitates easy document management, ensuring efficient storage and retrieval of files.

## Features
- **Document Upload:** Easily upload documents via a user-friendly interface.
- **Document Download:** Retrieve and download documents seamlessly.
- **Swagger Integration:** API documentation and testing through Swagger UI.
- **ASP.NET Core:** Built using the ASP.NET Core framework with Razor Pages.

## Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/filip-copija/DocumentKeeper.git
    cd DocumentKeeper
    ```
2. Build the solution:
    ```bash
    dotnet build
    ```
3. Run the application:
    ```bash
    dotnet run
    ```

## Usage
1. Open a web browser and navigate to `http://localhost:5000`.
2. Use the provided interface to upload or download documents.
3. Access Swagger UI for API documentation and testing at `http://localhost:5000/swagger`.

## Project Structure
- **ApplicationCore/**: Core application logic and domain models.
- **DocumentKeeper/**: Main project files and configuration.
- **DocumentTest/**: Unit tests for the application.
- **Infrastructure/**: Data access and infrastructure services.
- **WebApi/**: API endpoints and controllers.
