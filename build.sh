#!/bin/bash

echo "Building the project..."
echo "$OSTYPE"

if [[ "$OSTYPE" == "darwin"* ]]; then
  echo "Running on macOS"
#   cp -R "DIR" "DESTINATION"
elif [[ "$OSTYPE" == "msys"* || "$OSTYPE" == "cygwin"* || "$OSTYPE" == "win32" ]]; then
  echo "Running on Windows"
#   xcopy "DIR" "DESTINATION" /E /I /H /Y
else
  echo "Unsupported OS"
fi
