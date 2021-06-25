# dotnet webapi

- base on youtube video [.NET 5 REST API Tutorial - Build From Scratch With C#](https://www.youtube.com/watch?v=ZXdFisA_hOY&t=874s)

## commands

- `dotnet new webapi -n catalog` -> making project
- `dotnet dev-certs https --trust` -> prevent https error
- run debugger from left menu or `f5` see project in `localhost:5001/swagger`
- for prevent open new windows for every debug, remove `serverReadyAction` in `.vscode\launch.json`
- <kbd>ctrl</kbd><kbd>.</kbd> for list of import source
- for build easily add to default task add group to build task for build -> <kbd>ctrl</kbd><kbd>shift</kbd><kbd>b</kbd>
- `dotnet add package MongoDB.Driver` -> add mongo db package to connect to database
- rename variable or method in all project with <kbd>right-click</kbd><kbd> rename symbpl</kbd> or <kbd>f2</kbd>
- `docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo` -> make database without user/pass
- `docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo` -> make database with user/pass
- `dotnet user-secrets init` -> add user secret id to project in `catalog.csproj`
- `dotnet user-secrets set MongoDbSettings:Password Pass#word1` -> add secret to project
- `mongodb for vscode` extension show database data

2:21:00
