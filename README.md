# LottoAPI
Angular UI + .NET API Application generating simulated lottery draws.

## How to install
### Prerequisites
You need to have this software on your machine:
- Microsoft SQL Server
- Visual Studio
- Node.js

Clone this repository to your desired directory.
### SQL Server
Server must be named ".", otherwise launchsettings.json has to be modified.

### Node.js
*If you already have a global Angular instance you can skip this step.*


Open Node.js console and type the following:
```
npm install -g @angular/cli
```

## Running the app
Navigate to LottoAPI\ui\LottoUI and launch command line there.

Type the following in the console:
```
ng serve --open
```
Angular project should be launching.

Open LottoAPI using Visual Studio and run the program.

Both the angular app and .NET API have to be running for the app to work correctly.
