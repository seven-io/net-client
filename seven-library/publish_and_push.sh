#!/bin/sh
# Publish seven-library to NuGet.
# Usage: sh seven-library/publish_and_push.sh (from any directory)
# Requires SEVEN_NUGET_API_KEY in ../.env

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"
cd "$SCRIPT_DIR"

[ -f ../.env ] && . ../.env

dotnet publish

RLS=$(ls -t bin/Debug/*.nupkg 2>/dev/null | head -1)

echo "$RLS"

dotnet nuget push "$RLS" --source "https://api.nuget.org/v3/index.json" --api-key="$SEVEN_NUGET_API_KEY"