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

1. Clone the repository to prefered folder using command `git clone https://github.com/Seeyouinthespring/MEMAnalyzer_Backend`
1. Install database on you SQL Express Server (there are two ways of doing it, use 2.i. or 2.ii. steps)
    1. From dump
        1. Open your MicrsoftSqlMangementStudio
        1. Connect to your SQL Express Server
        1. RightClick on "Data bases" and choose Import Data tier Application
        1. Go to Import Settings Page
        1. Click Browse... to specify the path in the space provided. The path name must include a file name and the .bacpac extension.
        1. There is a bacpac file in the root folder that you have cloned, choose it
        1. Click next, make sure that the name of database is "memanalyzer", if it not then edit it
        1. Click next and then ready, after several time database will be created on your local server
    1. By migration
        1. Open your MicrsoftSqlMangementStudio
        1. Create empty database with name "memanalyzer" (RightClick on "Data bases" -> chose "Create database" -> enter the name -> Click Ok)
        1. Open file `...\MEMAnalyzer_Backend\MEMAnalyzer_Backend\MEMAnalyzer_Backend.sln` with your VisualStudio
        1. Go to file `appsettingsDevelopment.json` and change the value of the field "DefaultConnection" fill it with your SQL Server Settings, gust leve without changes the property Initial Catalog = memanalyzer
        1. Go to Package Manager Console, write there command: `EntityFrameworkCore\Update-Database`
        1. After executing this command database must be created
1. If you havent change your connection string yet, do it (whatch step 2.ii.c and so on)
1. Deploy application in VisualStudio by pushing button MEMAnalyzer_Backend
1. After application deploying you need to create administrator using swagger or postman. 
    1. Go to url `https//:localhost:5001/index.html` in your browser
    1. Chose API `POST /api/Users/RegisterAdmin`, push Try it out
    1. Fill all the fields with data you want for your administrator (dateformat: dd.MM.yyyy)
    1. Push execute
        
         