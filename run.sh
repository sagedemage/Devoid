#!/bin/bash

# Create directory if it does not exist
if [ ! -d "test_output" ]
then
    mkdir test_output
fi


# Build program
dotnet build --configuration Release --no-restore

# Run unit tests
dotnet test --no-restore --verbosity normal > test_output/unit_test_output.txt

# Run Python Script
python3 run.py

# Exit the script if the unit test failed
file=$(cat test_output/result.txt)

for line in $file
do
    #echo -e "$line"
    if [ "$line" == "Failed" ]
    then
        exit
    fi
done

# Run the Program
dotnet run --project Devoid
