@echo off
if not defined APPVEYOR_REPO_TAG_NAME (
    exit 0
)
rd /s /q bin
dotnet pack -c Release --include-symbols
dotnet nuget push bin\Release\*.nupkg -s nuget.org -k %NUGET_API_KEY% || exit 0
