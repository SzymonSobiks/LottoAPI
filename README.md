# LottoAPI
Example application generating lottery draws

## How to install
### Prerequisites
You need to have this software on your machine:
- Microsoft SQL Server 2019 + Management Studio
- Visual Studio 2022
- Node.js 12

Clone this repository to your desired directory using git.

### Node.js
Open Node.js console and type the following:
```
npm install -g @angular/cli
```
### SQL Server
Server must be named ".", otherwise launchsettings.json has to be modified

Create DrawHistory database by creating a new SqlQuery and typing:
```
create database LotteryDB;
```
Then use CTRL+A and click 'Execute'

## Running the app
Navigate to LottoAPI\ui\LottoUI and launch command line there.

Type the following in the console:
```
ng serve --open
```
Angular project should be launching.

Open LottoAPI using visual studio and run the program.

Both the angular app and .NET API have to be running for the app to work correctly.
