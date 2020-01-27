# Syntax

## Add Initial
1. cd OpenKHS.Data
1. dotnet ef migrations add Init -s ../OpenKHS.CLI

## Create / Update Database
dotnet ef database update -s ../OpenKHS.CLI

## Remove Database
dotnet ef database drop -s ../OpenKHS.CLI

## Rollback Migration
dotnet ef migrations remove -s ../OpenKHS.CLI