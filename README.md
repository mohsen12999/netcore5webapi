# dotnet webapi

- base on youtube video [.NET 5 REST API Tutorial - Build From Scratch With C#](https://www.youtube.com/watch?v=ZXdFisA_hOY&t=874s)

## commands

- `dotnet new webapi -n catalog` -> making project
- `dotnet dev-certs https --trust` -> prevent https error
- run debugger from left menu or `f5` see project in `localhost:5001/swagger`
- for prevent open new windows for every debug, remove `serverReadyAction` in `.vscode\launch.json`
- for build easily add to default task add group to build task for build -> <kbd>ctrl</kbd><kbd>shift</kbd><kbd>b</kbd>
