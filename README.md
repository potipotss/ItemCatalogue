# Item Catalogue SPA

This is a Single Page Application (SPA) built with Angular for the frontend and .NET Core for the backend. The application displays an item catalogue and provides a RESTful API to manage items.

## Prerequisites

- Node.js and npm
- Angular CLI
- .NET Core SDK

## Backend Setup (.NET Core)

1. **Clone the repository:**
   git clone <repository-url>
   cd ItemCatalogueAPI
2. Restore NuGet packages
   dotnet restore
3. Run the application:
   dotnet run

## FrontEnd Setup (Angular)

1. Navigate to the frontend directory:
   cd item-catalogue
2. Install npm packages:
   npm install
3. Run the application:
   ng serve

## Usage
1. Open http://localhost:4200 in your web browser.
2. The homepage will display a list of all items in the catalogue.
3. Click on an item to view its details.
