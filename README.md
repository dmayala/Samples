# Samples 
A .NET Core/Angular application that displays a list of samples and allows new samples to be added. 

## Requirements
  - [Visual Studio 2017](https://www.visualstudio.com/downloads/)
  - [node.js 7.x](http://nodejs.org/)
  - [Angular CLI](https://www.npmjs.com/package/@angular/cli)

## Running Locally
Install the software in the above requirements then open Samples.sln in Visual Studio 2017.

Open the Package Manager Console (Tools - NuGet Package Manager - Package Manager Console) and run the following commands:
```sh
  Update-Database
  cd Samples
  npm install
``` 

Once the install has finished, start the application with Visual Studio 2017. The application will run on http://localhost:49999. 
