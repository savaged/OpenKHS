# Syntax

## Add Initial

1. cd OpenKHS.Data
1. dotnet ef migrations add Init -s ../OpenKHS.WPF

## Create / Update Database

1. cd OpenKHS.Data
1. dotnet ef database update -s ../OpenKHS.WPF

## Remove Database

1. cd OpenKHS.Data
1. dotnet ef database drop -s ../OpenKHS.WPF

## Rollback Migration

1. cd OpenKHS.Data
1. dotnet ef migrations remove -s ../OpenKHS.WPF
