# UI

- This is a React UI for the APIs (usually) located at <http://localhost:5050>.
- It provides a very simple "login" for multiple users.
- The UI allows for users to:
  - add new tasks
  - view the task status (by colour and icon)
  - edit a task
  - change a task's status (to one of 'pending', 'in progress', 'completed')
  - view a counter of task statuses
  - change their profile image
- The UI can handle different users (currently hard-coded into the home page (`app/page.tsx`))
  - tasks and profile apply to individual users
  - a user can only delete their own tasks - that functionality is in progress for changing status and editing
- High level errors will be displayed where necessary.
  - Granular handling of errors and loading are a WIP.

## Running

```bash
cd ./ui
yarn install
yarn dev
```

- Project will run at <http:\\localhost:3030>.

## Technology

- This is a [Next.js](https://nextjs.org) project bootstrapped with [`create-next-app`](https://nextjs.org/docs/app/api-reference/cli/create-next-app).
  - `npx create-next-app@latest tasklist --use-yarn`

### Select Tools

<!-- prettier-ignore -->
Tool | Version | Comment
--- | --- | ---
react | 19.2.3 | JavaScript library
typescript | 5.7 | Strongly typed programming language
next.js | 16.1.6 | React framework
mui material | 7.3.7 | Component library

## Resources

- Favourite icon, https://www.flaticon.com/free-icon/tasks_906334
