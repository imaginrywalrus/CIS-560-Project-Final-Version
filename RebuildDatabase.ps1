Param(
   [string] $Server = "mssql.cs.ksu.edu",
   [string] $Database = "kprice147"
)

# This script requires the SQL Server module for PowerShell.
# The below commands may be required.

# To check whether the module is installed.
# Get-Module -ListAvailable -Name SqlServer;

# Install the SQL Server Module
# Install-Module -Name SqlServer -Scope CurrentUser

$CurrentDrive = (Get-Location).Drive.Name + ":"

Write-Host ""
Write-Host "Rebuilding database $Database on $Server..."

<#
   If on your local machine, you can drop and re-create the database.
#>
#& ".\Scripts\DropDatabase.ps1" -Database $Database
#& ".\Scripts\CreateDatabase.ps1" -Database $Database

<#
   If on the department's server, you don't have permissions to drop or create databases.
   In this case, maintain a script to drop all tables.
#>
Write-Host "Dropping tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\DropTables.sql"

Write-Host "Creating schema..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Schemas\Movies.sql"

Write-Host "Creating tables..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.Movie.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.Actors.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.Cinema.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.Reviewer.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.Review.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.Directors.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.MovieCinema.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.MovieDirectors.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Tables\Movies.MovieActor.sql"

Write-Host "Stored procedures..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.MovieActor.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.ActorTotalSalary.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.DirectorMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.GenreMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.MovieReviews.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.ScoreReviews.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.StateCinemas.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\QuestionQueries\Movies.TotalSales.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\ReportQueries\Movies.ActorGenreMovies.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\ReportQueries\Movies.ActorInCommon.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\ReportQueries\Movies.GoodReview.sql"
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Procedures\ReportQueries\Movies.ShowingInfo.sql"

Write-Host "Inserting data..."
Invoke-SqlCmd -ServerInstance $Server -Database $Database -InputFile "MoviesData\Sql\Data\FinalProjectData.sql"

Write-Host "Rebuild completed."
Write-Host ""

Set-Location $CurrentDrive
