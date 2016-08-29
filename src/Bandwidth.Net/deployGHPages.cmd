@echo off
if "%APPVEYOR_REPO_BRANCH%" == "v3-preview" goto cont
goto exit
:cont
rd /s /q Help Pages
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Bandwidth.Net.Html.shfbproj
git clone https://github.com/bandwidthcom/csharp-bandwidth.git Pages
cd Pages
git checkout gh-pages || git checkout -b gh-pages
git rm -rf .
xcopy ..\Help\* . /s /q
git add .
set COMMIT_MESSAGE = "Updated API docs"
if  "%APPVEYOR_PULL_REQUEST_TITLE%" == "" goto next
COMMIT_MESSAGE="%COMMIT_MESSAGE%: %APPVEYOR_PULL_REQUEST_TITLE%"
:next
git commit -m "%COMMIT_MESSAGE%"
git push origin gh-pages
cd ..
:exit
