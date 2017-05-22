Required for project:
- .NetCoreApp1.1
- MSSQL 2008/2012
- Internet Connection (3rd party api use for countries)

Instructios:
- Create new DB named "Celebrities_db".
- Run on MSSQL the CreateCelebritiesTable.sql located on the project directory.
- Replace ConnectionString in AppSetting.Json located on CelebritiesAPI Root with the appropriate connectionString.
- Restore Nuget packages for CelebritiesAPI
- Click with right mouse button on CelebritiesClient and click on option - "View in Browser" (Chrome is preffered)
- Buid & Run Project trough IIS Express button located on VisualStudio Toolbar
- Refresh Chrome with client application

Thank you and Enjoy

Dror