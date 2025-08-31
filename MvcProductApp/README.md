# MvcProductApp

This is a basic ASP.NET Core MVC application built with .NET 9. It demonstrates the use of Models, Views, and Controllers (MVC) to display a list of products, and it incorporates Tag Helpers and basic logging.

## How to Run

1.  **Prerequisites:**
    * [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
    * Visual Studio 2022
2.  **Clone the repository:**
    ```bash
    git clone [https://github.com/jomuch/MvcProductApp.git](https://github.com/jomuch/MvcProductApp.git)
    ```
3.  **Open in Visual Studio:**
    * Navigate to the cloned directory.
    * Open the `MvcProductApp.sln` solution file.
4.  **Run the application:**
    * Press `F5` or click the green "Start" button in Visual Studio to build and run the project.

## Dependencies

-   ASP.NET Core 9.0

## Screenshot

Here is a screenshot of the application's product list page:

<img width="1920" height="1020" alt="Screenshot MvcProductApp" src="https://github.com/user-attachments/assets/ab476d34-4732-4cc7-a306-25333524b71b" />

## Design Notes

### Separation of Concerns

This project uses a service layer to separate business logic from the controller. The `HomeController` is responsible for handling web requests and returning a view, but it is not responsible for the logic that determines what a "featured product" is. This logic is encapsulated entirely within the `ProductService`. This makes the controller cleaner and the business logic reusable and easier to maintain.

### Dependency Injection (DI)

Dependency Injection is used to provide the `ProductService` to the `HomeController`.

* **Constructor Injection**: The `HomeController` receives an `IProductService` through its constructor. This makes the dependency explicit and ensures the controller cannot be created without its required service.
* **Programming to an Interface**: The controller depends on the `IProductService` interface, not the concrete `ProductService` class. This decouples the controller from the implementation, allowing the service to be easily replaced with a different implementation or a mock object for unit testing without changing the controller's code.
* **DI Lifetime**: The service is registered with a **Scoped** lifetime in `Program.cs`. This is the appropriate choice because the `ProductService` depends on `ApplicationDbContext`, which is also scoped. This ensures that both services share the same instance within a single HTTP request, preventing data consistency issues.
