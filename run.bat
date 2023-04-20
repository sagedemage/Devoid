@ECHO OFF
:: Build program
dotnet build --configuration Release --no-restore

:: Create directory if it does not exist
if not exist test_output\ (
    md test_output
)

:: Run unit tests
dotnet test --no-restore --verbosity normal > test_output/unit_test_output.txt

:: Run Python Script
python run.py

:: Exit the script if the unit test failed
FOR /F %%i IN (test_output/result.txt) DO (if "%%i" == "Failed" (exit))

:: Run the Porgram
dotnet run --project Devoid
