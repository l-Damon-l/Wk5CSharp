# Week 5 C#

This repository contains all the code written during Week 4 of the Sparta C#
course.

# Table of contents

## LINQ Queries

LINQ queries are used to query data from a data source. They are used to
retrieve data from a database, XML document or any other data source. LINQ
stands for Language Integrated Query and is integrated into the C# language.

### LINQ Query Syntax

One way to write LINQ queries is to use the query syntax. This is the syntax
used in the example below.

```csharp
var query = from <range variable> in <collection>
            where <filter>
            select <result>;
```

It has similarities to SQL queries.

### LINQ Method Syntax

The other way to write LINQ queries is to use the method syntax. This is the
syntax used in the example below.

```csharp
var query = <collection>
                .Where(<filter>)
                .Select(<result>);
```
