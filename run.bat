@ECHO OFF
dotnet build --configuration Release --no-restore

md test_output

dotnet test --no-restore --verbosity normal > test_output/unit_test_output.txt

:: Run Python Script
python run.py

FOR /F %%i IN (test_output/result.txt) DO (if "%%i" == "Failed" (exit))

dotnet run --project Devoid
