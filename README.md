# Imparta Task List

## What Am I?

I am a proof of concept task management application, written in C# and NextJS (React / Typescript).

## Running

```bash
cd api/JoF.Imparta.TaskList.Api
dotnet run
```

- If the port is already in use, change the port in `Properties\launchSettings.json` and re-run.
- Also change the port in the `.env` file in the UI.
- Swagger, the interactive API documentation, is served from the root, <http:\\localhost:5050>.
  - Example GUID, `321902d1-1115-42ae-b874-cb9f2d2c1064`

## Project Structure

The project consists of two applications, one for the front end (UI) and one for the back end (APIs).

```text

.
|-- api
|-- ui

```

## Further Steps

(A non-exhaustive list)

- Content of `.../...Api/Domain` folder should be a separate project
- Extend login capabilities
  - Name / password encryption
  - SSO, Login Providers (Google, Facebook, Other)
- Introduce real-time updates
  - Webhooks, pub/sub
- Add labels (tags) and priorities
- Improve logging, or add observability
- Add middleware to provide consistent and customisable response
- Add configurable options...

## Disclaimer

### APIs

The backend APIs are heavily based on an existing project that I wrote a number of years ago (.NET 3.5). The approach and concepts (for a much bigger application) took a number of weeks to design and hone-in. This is also a much slimmed down approach.

It was proven to be a good approach to enable others to extend functionality without introducing risk to existing code.
