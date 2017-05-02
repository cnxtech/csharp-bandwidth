@echo off
if not defined APPVEYOR_REPO_TAG_NAME (
    exit 0
)
rd /s /q bin
set VERSION=%APPVEYOR_REPO_TAG_NAME%
dotnet pack -c Release --include-symbols
dotnet nuget push bin\Release\*.nupkg -s nuget.org -k %NUGET_API_KEY% -c NuGet.Config || exit 0
