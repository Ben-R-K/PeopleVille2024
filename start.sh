#!/bin/bash

echo "Building the project..."
echo "$OSTYPE"

echo "Running on macOS"
MAIN_PROJECT = "PeopleVille.csproj"
PROJECTS=$(find . -name "*.csproj" ! -name "$MAIN_PROJECT")
for PROJECT in $PROJECTS; do
    PROJECT_DIR=$(dirname "$PROJECT")
    PROJECT_NAME=$(basename "$PROJECT" .csproj)

    if [ -f "$PROJECT_DIR/dll_location.txt" ]; then
      echo "Building $PROJECT"
      dotnet build $PROJECT -c Release
      if [ $? -ne 0 ]; then
          echo "Build failed for $PROJECT"
          exit 1
      fi

      PROJECT_DLL_LOCATION=$(cat "$PROJECT_DIR/dll_location.txt")
      FULL_PROJECT_DIR=$(realpath "$PROJECT_DIR")
      echo "Copying $FULL_PROJECT_DIR/bin/Release/net8.0/$PROJECT_NAME.* to $PROJECT_DLL_LOCATION"
      cp "$FULL_PROJECT_DIR/bin/Release/net8.0/$PROJECT_NAME.dll" "$PROJECT_DLL_LOCATION"
    fi
done
dotnet build --project "$(realpath)/PeopleVille/PeopleVille.csproj" -c Release
dotnet run --project "$(realpath)/PeopleVille/PeopleVille.csproj" -c Release
