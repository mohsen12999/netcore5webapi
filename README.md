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
- `dotnet user-secrets init` -> add user secret id to project in `Catalog.Api.csproj`
- `dotnet user-secrets set MongoDbSettings:Password Pass#word1` -> add secret to project
- `mongodb for vscode` extension show database data
- health check -> add service and pipeline in `Startup.cs` and check the route
- `dotnet add package AspNetCore.HealthChecks.MongoDb` -> package for mongodb health check
- list of health check package[Enterprise HealthChecks for ASP.NET Core Diagnostics Package](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks)
- `docker` extension for better write dockerfile -> in command pallete <kbd>ctrl</kbd><kbd>shift</kbd><kbd>p</kbd> `Docker: add docker files to workspace`
- make docker image from dockerfile `docker build -t catalog:v1 .`
- make network for connect image file `docker network create net5tutorial`
- connect image to network `docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=net5tutorial mongo`
- `docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=Pass#word1 --network=net5tutorial catalog:v1`
- enable kubernetes in docker descktop -> setting - kubernetes - enable kubernetes
- test kubernetes: `kubectl config current-contex` -> output: docker desktop
- `kubernetes` extension to easier make kubernetes config file -> in yaml file write `kubernetes deploy` to make sample code
- make secretes for kubernetes: `kubectl create secret generic catalog-secrets --from-literal=mongodb-password=Pass#word1`
- `kubernetes` extension: write `kubernetes service` for sample service config
- for apply kubernetes config file: `kubectl apply -f ./kubernetes/catalog.yaml`
- show status of deployment: `kubectl get deployments`
- for show pods status: `kubectl get pods`
- for show pods logs: `kubectl logs <podId>`
- `StateFulSet` for uniq and order pods like database
- for apply mongodb kubernetes config file: `kubectl apply -f ./kubernetes/mongodb.yaml`
- `kubectl get statefulsets`
- watch pods online status: `kubectl get pods -w`
- delete pod: `kubectl delete pod <podId>`
- for scale pods: `kubectl scale deployments/catalog-deployment --replicas=3` -> make 3 pods
- add new version of image: `docker build -t mohsen1299/catalog:v2 .`
- push new version of image: `docker push mohsen1299/catalog:v2 .`
- for show pods logs: `kubectl logs <podId> -f`
- add unit test project: `dotnet new xunit -n Catalog.UnitTests`
- for build file together make `build.proj` and change task to run it
- for adding api project reference in unit test -> `dotnet add reference ..\Catalog.Api\Catalog.Api.csproj`
