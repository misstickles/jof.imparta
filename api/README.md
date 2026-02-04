# API

- A set of C# .NET APIs to provide UI requirements for a simple task list.
- There is input validation on all API fields, to ensure accuracy and security.
- A standard common response is returned from all requests.
- Available endpoints are available via Swagger (via OpenApi json), located in the root <http://localhost:5050>.
- There is also a [postman collection](../Imparta.postman_collection.json)
  - To use, ensure you have an environment with:
    - `baseUrl` : `http://localhost:5050/v1`
    - `userId` : `97b81a67-1775-4253-be07-c73605334517`
      - (or any Guid (powershell: `New-Guid`))
  - To modify a task, obtain a taskId via the "Get All Tasks" request.
  - To update a profile image, you need to convert the image to base64.
    - This worked well, <https://www.base64-image.de/>.
- A sample task and default profile image is provided to new users
- There are a (limited) number of unit tests to ensure the code is functioning.

## Running

```bash
cd ./api/JoF.Imparta.TaskList.Api
dotnet run
```

...or via Visual Studio

## Select Tools

<!-- prettier-ignore -->
Technology | Version
--- | ---
C# .NET | 10.0
ASP\.NET Core | 10.0.2

<!-- prettier-ignore -->
Tool | Version | Comment
--- | --- | ---
Asp.Versioning.Mvc | 8.1.1 | to enable API versions
Asp.Versioning.Mvc.ApiExplorer | 8.1.1 | To allow OpenAPI to discover the APIs
FluentValidation | 12.1.1 | To provide validation of inputs
FluentValidation.DependencyInjectionExtensions | 12.1.1
Microsoft.AspNetCore.OpenApi | 10.0.2 | To generate an OpenApi json doc
SharpGrip.FluentValidation.AutoValidation.Mvc | 1.5.0 | Enables automatic validation of inputs
Swashbuckle.AspNetCore.SwaggerUI | 10.1.1 | UI for OpenApi json doc

## Commands

- Created with Visual Studio > New ASP.NET Core Web API
- `dotnet new editorconfig` for code quality

## Resources

[.gitignore](https://github.com/github/gitignore/blob/main/VisualStudio.gitignore)
