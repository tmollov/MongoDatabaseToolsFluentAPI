# MongoDB Database Tools - Fluent API

This repository contains **Fluent API** that runs given **MongoDB Database Tool** with [**CliWrap**](https://github.com/Tyrrrz/CliWrap).

## Project Description

**ExampleApp** project is project created for testing the Fluent Api.  
It uses [System.CommandLine.DragonFruit](https://github.com/dotnet/command-line-api/blob/main/docs/Your-first-app-with-System-CommandLine-DragonFruit.md) to collect arguments and gives them to Main method in Program.cs file.

**ExampleApp.Data** is project created to connect to database with ready-to-use code.

**FluentApi** project is entry point of Fluent API.

## Main Features

Fluent API consists **MongoUtilities** class which gives you access to different utilities.  
Currently only **3** of them are working:

**MongoDump, MongoRestore** and **BsonDump**.

## Usage

Every utility have utility specific method described in their interfaces.  
You **must use** them **before** using global ones that returns **IMongoUtility**.

Every utility becomes **MongoUtility** which at the other hand have **Run** method which starts given utility in a new process.

## Code examples

Mongodump utility example:

```csharp
await MongoUtilities
        .MongoDump
        .WithOplog()
        .ToGzip()
        .NumberOfParallelCollections(3)
        .Verbose(4)
        .Run();
```

Mongorestore utility example:

```csharp
await MongoUtilities
        .MongoRestore
        .WithoutIndexes()
        .WithoutCollectionOptions()
        .DropEachBeforeImport()
        .BypassDocumentValidation()
        .StopOnError()
        .Verbose(5)
        .Run();
```

BsonDump utility example:

```csharp
await MongoUtilities
        .BsonDump
        .OfType(FluentApi.Common.Enums.BsonType.JSON)
        .ValidateBSON()
        .PrettierJSON()
        .ToOutputFile("test.json")
        .Run();
```

Currently it is configured for Linux systems.  
If you want to run in Non-Linux enviroment you can modify **MongoTools method** in **ProcessConstants class** to return path to given utility in your machine.

## How to Run ExampleApp project

Use `dotnet run -- {option}` in terminal.

Options:

`--backup-and-get,`  
`--backup-and-put,`  
`--oplog-and-get,`  
`--oplog-and-put,`  
`--oplog-replay`  
`--advanced`

## Example Output of "--advanced" option

```
Dropping database: test
Dropped database test
connecting to mongodb://127.0.0.1:27017
collection test: done               [====================================================================] 100%
collection test: generating         [=====>--------------------------------------------------------------]  10%
+------------+---------+-----------------+----------------+----------------------------------------------]  10%
| COLLECTION |  COUNT  | AVG OBJECT SIZE |    INDEXES     |
+------------+---------+-----------------+----------------+
| test       | 1000000 |            2074 | _id_  23288 kB |
+------------+---------+-----------------+----------------+

run finished in 39.25s
Starting mongodump...
Importing 1000 elements...
2021-10-18T20:48:42.735+0300    writing admin.system.version to dump/admin/system.version.bson
2021-10-18T20:48:42.736+0300    done dumping admin.system.version (2 documents)
2021-10-18T20:48:42.740+0300    writing test.test to dump/test/test.bson
2021-10-18T20:48:45.724+0300    [###.....................]  test.test  149462/1000000  (14.9%)
2021-10-18T20:48:48.723+0300    [######..................]  test.test  257099/1000000  (25.7%)
2021-10-18T20:48:51.723+0300    [##########..............]  test.test  439287/1000000  (43.9%)
2021-10-18T20:48:54.724+0300    [###############.........]  test.test  626063/1000000  (62.6%)
2021-10-18T20:48:57.724+0300    [###################.....]  test.test  828296/1000000  (82.8%)
2021-10-18T20:48:59.291+0300    [########################]  test.test  1000319/1000000  (100.0%)
2021-10-18T20:48:59.291+0300    done dumping test.test (1000319 documents)
2021-10-18T20:48:59.291+0300    writing captured oplog to
2021-10-18T20:48:59.343+0300            dumped 322 oplog entries
Done importing elements...
Getting Document IDs
IDs acquired.
Document count: 1001000
Dropping database: test
Dropped database test
Starting mongorestore...
2021-10-18T20:49:37.283+0300    using default 'dump' directory
2021-10-18T20:49:37.283+0300    preparing collections to restore from
2021-10-18T20:49:37.284+0300    reading metadata for test.test from dump/test/test.metadata.json
2021-10-18T20:49:37.310+0300    restoring test.test from dump/test/test.bson
2021-10-18T20:49:40.284+0300    [#.......................]  test.test  127MB/1.93GB  (6.4%)
2021-10-18T20:49:43.283+0300    [##......................]  test.test  172MB/1.93GB  (8.7%)
...
2021-10-18T20:51:17.406+0300    [########################]  test.test  1.93GB/1.93GB  (100.0%)
2021-10-18T20:51:17.406+0300    finished restoring test.test (1000319 documents, 0 failures)
2021-10-18T20:51:17.406+0300    replaying oplog
2021-10-18T20:51:17.828+0300    applied 322 oplog entries
2021-10-18T20:51:17.828+0300    no indexes to restore for collection test.test
2021-10-18T20:51:17.828+0300    1000319 document(s) restored successfully. 0 document(s) failed to restore.
Getting Document IDs
IDs acquired.
Document count after RESTORE: 1000321
```
