/*
  ================================================================================
  File: DropTablesAndStoredProcedures.sql
  ================================================================================
  Summary:
    This script drops all user-defined objects from the current database,
    across every schema. It handles, in order:
      1. Stored Procedures
      2. Foreign-Key Constraints
      3. Primary-Key Constraints
      4. Tables

    Key Features:
      • Uses modern catalog views (sys.procedures, sys.views, sys.objects, etc.).
      • Uses STRING_AGG() for clean string assembly.
      • Wraps identifiers in QUOTENAME() for safety.
      • Emits Windows-style CR+LF separators (CHAR(13)+CHAR(10)).
      • Executes each batch only if there are objects to drop.
      • Prints progress messages.

    Usage Notes:
      • Requires SQL Server 2017+ (STRING_AGG support).
      • Run in a dev or disposable database—drops are irreversible.
  ================================================================================
*/

SET NOCOUNT ON;
GO

DECLARE @SQL NVARCHAR(MAX);

-- 1. Drop all Stored Procedures
SELECT @SQL = STRING_AGG(
    'DROP PROCEDURE ' 
      + QUOTENAME(s.name) + '.' + QUOTENAME(p.name) + ';',
    CHAR(13) + CHAR(10)
  ) WITHIN GROUP (ORDER BY s.name, p.name)
FROM sys.procedures AS p
JOIN sys.schemas    AS s ON p.schema_id = s.schema_id;

IF @SQL IS NOT NULL
BEGIN
  PRINT 'Dropping Stored Procedures...';
  EXEC(@SQL);
END

-- 2. Drop all Foreign-Key Constraints
SELECT @SQL = STRING_AGG(
    'ALTER TABLE '
      + QUOTENAME(OBJECT_SCHEMA_NAME(fk.parent_object_id)) + '.'
      + QUOTENAME(OBJECT_NAME(fk.parent_object_id))
      + ' DROP CONSTRAINT ' + QUOTENAME(fk.name) + ';',
    CHAR(13) + CHAR(10)
  ) WITHIN GROUP (
    ORDER BY OBJECT_SCHEMA_NAME(fk.parent_object_id),
             fk.name
  )
FROM sys.foreign_keys AS fk;

IF @SQL IS NOT NULL
BEGIN
  PRINT 'Dropping Foreign-Key Constraints...';
  EXEC(@SQL);
END

-- 3. Drop all Primary-Key Constraints
SELECT @SQL = STRING_AGG(
    'ALTER TABLE '
      + QUOTENAME(OBJECT_SCHEMA_NAME(kc.parent_object_id)) + '.'
      + QUOTENAME(OBJECT_NAME(kc.parent_object_id))
      + ' DROP CONSTRAINT ' + QUOTENAME(kc.name) + ';',
    CHAR(13) + CHAR(10)
  ) WITHIN GROUP (
    ORDER BY OBJECT_SCHEMA_NAME(kc.parent_object_id),
             kc.name
  )
FROM sys.key_constraints AS kc
WHERE kc.[type] = 'PK';

IF @SQL IS NOT NULL
BEGIN
  PRINT 'Dropping Primary-Key Constraints...';
  EXEC(@SQL);
END

-- 4. Drop all Tables
SELECT @SQL = STRING_AGG(
    'DROP TABLE '
      + QUOTENAME(s.name) + '.' + QUOTENAME(t.name) + ';',
    CHAR(13) + CHAR(10)
  ) WITHIN GROUP (ORDER BY s.name, t.name)
FROM sys.tables    AS t
JOIN sys.schemas   AS s ON t.schema_id = s.schema_id;

IF @SQL IS NOT NULL
BEGIN
  PRINT 'Dropping Tables...';
  EXEC(@SQL);
END

PRINT 'Cleanup complete. The database is now free of user objects.';
