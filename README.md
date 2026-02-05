# Imparta Task List

## What Am I?

I am a proof of concept task management application, written in C# and React (NextJS with Typescript).

See also the [API README](./api/README.md) and the [UI README](./ui/README.md).

Between the APIs and the UI, all requirements of the project have been met.

## Running Me

I have had no issues in running these projects, but gremlins love a good demo. If there are any unknown dependencies or other issues, please reach out to me so I can help where required.

### Prerequesites

- [.NET SDK 10.0](https://dotnet.microsoft.com/en-us/download)
- [Node](https://nodejs.org/en) v24
  - Recommend to install with [nvm](https://github.com/nvm-sh/nvm)
    - [nvm-windows](https://github.com/coreybutler/nvm-windows)
- [yarn](https://classic.yarnpkg.com/en/docs/install) or npm

### APIs

```bash
cd api/JoF.Imparta.TaskList.Api
dotnet run
```

- Project will run at <http:\\localhost:5050>.
- Swagger, the interactive API documentation, is served from the root, <http:\\localhost:5050>.
  - Example GUIDs,
    - `321902d1-1115-42ae-b874-cb9f2d2c1064`
    - `9e5f128c-8db9-455e-be65-68453be120dd`

### UI

```bash
cd ./ui
yarn install
yarn dev
```

- Project will run at <http:\\localhost:3030>.

## Project Structure

The project consists of two applications, one for the front end (UI) and one for the back end (APIs).

## API Endpoints

<!-- prettier-ignore -->
Method | Endpoint | Comment | Body Inputs
--- | --- | --- | ---
GET | `/Task?userId={{userId}}` | Get all tasks for the user.
POST | `/Task` | Create a new task | title / description / userId.
PUT | `/Task/{{taskId}}` | Update a task.  Changes depend on the optional inputs. | status? / title? / description?
DELETE | `/Task/{{taskId}}?userId={{userId}}` | Delete a user's task.
GET | `/Profile/{{userId}}` | Get the user's profile avatar.
POST | `/Profile/{{userId}}` | Create a profile (avatar image) for the user. | contentType / imageBase64

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
- Async methods were added with a view to using at least a Sqlite InMemory database, but time constraints reduced it to a HashSet, then to a List...
- ...And so many more, but I started, so it's here for further ideas.

## Disclaimer

### APIs

The backend APIs are heavily based on an existing project that I wrote a number of years ago (.NET 3.5). The approach and concepts took a number of weeks to design and hone-in. This is a very much slimmed down approach, due to time constraints. It was proven to be a good approach to enable others to extend functionality without introducing risk to existing code.

### .env File

`.env.local` is deliberately committed to Git. **There is nothing interesting in it**, just a configurable link to the localhost APIs :)
