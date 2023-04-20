@ECHO OFF
dotnet build --configuration Release --no-restore

dotnet test --no-restore --verbosity normal > unit_test_output.txt

:: Run Python Script
python run.py

FOR /F %%i IN (result.txt) DO (if "%%i" == "Failed" (exit))

dotnet run --project Devoid
