@echo off
if not defined BRANCH (
    set BRANCH=master
)
if not defined APPVEYOR_REPO_BRANCH (
    exit 0
)  
if not %APPVEYOR_REPO_BRANCH% == %BRANCH% (
    exit 0
)
rd /s /q Help Pages
%SystemRoot%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe doc\Bandwidth.Net.Html.shfbproj
git clone https://github.com/Bandwidth/csharp-bandwidth.git Pages
cd Pages
git config user.name "AppVeyor CI"
git config user.email "%APPVEYOR_REPO_COMMIT_AUTHOR_EMAIL%"
git checkout gh-pages || git checkout -b gh-pages
git rm -rf .
xcopy ..\Help\* . /s /q
git add .
set COMMIT_MESSAGE=Updated API docs: %APPVEYOR_REPO_COMMIT%
if  defined APPVEYOR_PULL_REQUEST_TITLE (
    set COMMIT_MESSAGE=%COMMIT_MESSAGE%: %APPVEYOR_PULL_REQUEST_TITLE%
)
git commit -m "%COMMIT_MESSAGE%"
(
    echo machine github.com
    echo login %APPVEYOR_ACCOUNT_NAME%
    echo password %GITHUB_TOKEN%
) > %HOMEDRIVE%%HOMEPATH%\.netrc
copy %HOMEDRIVE%%HOMEPATH%\.netrc %HOMEDRIVE%%HOMEPATH%\_netrc
git push origin gh-pages
cd ..
