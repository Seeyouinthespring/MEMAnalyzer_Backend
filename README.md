# MEMAnalyzer - a questionnaire that determines your charachter lines by your sense of humor

### Recommendations before installation

It is a backend part of an application, so it need to be depolyed on web server
But firstly you have to deploy it locally

### Local Installation
Before starting installation make sure that this sources are installed on your computer
* VisualStudio 2019
* .Net Framework 3 or higher
* SQL Express Server 2016 or higher
* MicrsoftSqlMangementStudio

1.Clone the repository to prefered folder

```sh
git clone https://github.com/Seeyouinthespring/MEMAnalyzer_Backend
```
2.Install database on you SQL Express Server (there are two ways of doing it, use 2.1. or 2.2. steps)
  2.1. From dump
    2.1.1. Open your MicrsoftSqlMangementStudio
    2.1.2. Connect to your SQL Express Server
    2.1.3. RightClick on "Data bases" and choose Import Data tier Application
    2.1.4. Go to Import Settings Page
    2.1.5. Click Browse... to specify the path in the space provided. The path name must include a file name and the .bacpac extension.
    2.1.6. There is a bacpac file in the root folder that you have cloned, choose it
    2.1.7. Click next, make sure that the name of database is "memanalyzer", if it not then edit it
    2.1.8. Click next and then ready, after several time database will be created on your local server
  2.2. By migration
    2.2.1. Open your MicrsoftSqlMangementStudio
    2.2.2. Create empty database with name "memanalyzer" (RightClick on "Data bases" -> chose "Create database" -> enter the name -> Click Ok)
    2.2.3. Open file `...\MEMAnalyzer_Backend\MEMAnalyzer_Backend\MEMAnalyzer_Backend.sln` with your VisualStudio
    2.2.4. Go to file `appsettingsDevelopment.json` and change the value of the field "DefaultConnection" fill it with your SQL Server Settings, gust leve without changes the property Initial Catalog = memanalyzer
    2.2.5. Go to Package Manager Console, write there command: `EntityFrameworkCore\Update-Database`
    2.2.6. After executing this command database must be created
3. If you havent change your connection string yet, do it (whatch step 2.2.3 and so on)
4. Deploy application in VisualStudio by pushing button MEMAnalyzer_Backend
        
         