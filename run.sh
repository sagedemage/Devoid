#!/bin/sh

# Build the Program
dotnet build --configuration Release --no-restore

# Test the Program
dotnet test --no-restore --verbosity normal

# Run the Program
dotnet run --project Devoid
