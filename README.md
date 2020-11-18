# Ittaca ERP
## An Enterprise Resource Planning for a (fictional) e-commerce company: Ittaca.

**NOTE: this project will be uploaded to Azure App Service in the coming few days. The URL will be displayed here.** 

### Setup
1. Download the code from this repository.
2. If you do not have Angular CLI, you need to install it by running `npm install -g @angular/cli` at a terminal window.
3. From a terminal window, navigate to the project folder containing the Angular code (*ERPProject/**ClientApp***) and type `npm update`.
4. Once finished installing packages, open the `ERPProject.sln` file. [Visual Studio](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50#install-with-visual-studio) is recommended.
5. For this step, you need [Entity Framework Core tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools) for [.NET Core CLI](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50). From a terminal window, navigate to the project folder (*ERPProject*) and type `dotnet ef migrations add InitialCreate -o Data/Migrations`.
6. Once the migration process is completed, run `dotnet ef database update` from the same terminal window.
7. Press `Ctrl+F5` or go to `Debug > Start Without Debugging`. A new tab will start loading in the web browser, which may take up to 1-2 minutes. If a 'TimeoutException' error occurs, try closing the tab, stopping IIS Express and repeating this step from the beginning. If the error persists, try opening a terminal window, navigating to *ClientApp* and running `npm start`. Close the terminal window and start this step again.
8. Navigate to the Login page by clicking the Log In button from the home page or the nav bar. As username, you can use either `Admin` or `Employee`, with the password `Pass123$`.
