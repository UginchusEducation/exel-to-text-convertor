@echo off
rem Batch file to execute .exe files in a folder relative to this .bat file

rem Get the directory of the current .bat file
set SCRIPT_DIR=%~dp0

rem Specify the folder containing the .exe files
set EXE_FOLDER="%SCRIPT_DIR%\publish"

rem Set paths to the .exe files
set EXE="%EXE_FOLDER%\exel-to-text-app.exe"

rem Start each .exe file
echo Starting FirstProgram...
start "" %EXE%