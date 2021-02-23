#!/bin/sh

dotnet publish

RLS=$(find . -wholename "./bin/Debug/*.nupkg" -print0 | xargs -r -0 ls -1 -t | head -1)

echo "$RLS"

dotnet nuget push "$RLS" --api-key="$SMS77IO_NUGET_API_KEY"