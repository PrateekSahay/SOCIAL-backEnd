#!/bin/bash

set -e
run_cmd="dotnet run --server.urls http://*:81"

until dotnet ef database update; do
>&2 echo "SQL Server is starting up"
sleep 1
done

./wait-for-it.sh -t 0 neo4j:7474 -- echo "neo4j is up"

>&2 echo "SQL Server is up - executing command"
exec $run_cmd
