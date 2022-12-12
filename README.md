# Week 5 C#

This repository contains all the code written during Week 5 of the Sparta C#
course.

# Table of contents

-   [LINQ](#linq)
    -   [LINQ Query Syntax](#linq-query-syntax)
    -   [LINQ Method Syntax](#linq-method-syntax)
-   [Entity Framework](#entity-framework)
    -   [DbContext](#dbcontext)
    -   [Partial Classes](#partial-classes)
-   [Markup Languages](#markup-languages)
-   -   [XML](#xml)
    -   [JSON](#json)
    -   [YAML](#yaml)
    -   [Serialisation](#serialisation)
    -   [Deserialisation](#deserialisation)

## LINQ

<hr />

LINQ is used to query data from a data source. They are used to retrieve data
from a database, XML document or any other data source. LINQ stands for Language
Integrated Query and is integrated into the C# language. There are two ways to
write LINQ queries, the query syntax and the method syntax.

### LINQ Query Syntax

<hr />

One way to write LINQ queries is to use the query syntax. This is the syntax
used in the example below.

```csharp
var query = from <range variable> in <collection>
            where <filter>
            select <result>;
```

It has similarities to SQL queries.

### LINQ Method Syntax

<hr />

The other way to write LINQ queries is to use the method syntax. This is the
syntax used in the example below.

```csharp
var query = <collection>
                .Where(<filter>)
                .Select(<result>);
```

Lambda expressions or delegates can be utilised within many of the LINQ methods
to help filter the data.

## Entity Framework

<hr />

Entity Framework is an object-relational mapper (ORM) that can be used within C#
to map objects to a relational database. It can model the database using a Code
First approach, a Database First approach or a Model First approach. It also
helps to manage the database by allowing us to create, read, update and delete
data from the database. In addition, it can also handle migrations, which are
changes to the database schema.

Some of the advantages of using Entity Framework over writing SQL queries
directly are:

-   It can easier to write queries using LINQ if the person writing the queries
    is not familiar with SQL.
-   It can be easier to maintain the database schema as Entity Framework can
    handle migrations.
-   Entity Framework provides a layer of abstraction between the database and
    the application, which can make it easier to change the database provider.
-   It can be easier to write unit tests as the database can be mocked.
-   It helps keep all the database logic in one place, which can make it easier
    to maintain.

### DbContext

<hr />

DbContext is the main class that is used to interact with the database. Within a
DbContext class, we hold a DbSet for each entity that we want to map to a table
in the database. The DbSet is used to query and save instances of the entity.
There are also configuration options that can be set within the DbContext class,
such as the connection string and the database provider.

### Partial Classes

<hr />

Partial classes are classes that can be split into multiple files. This can be
used for organisation purposes, to hide implementation details or to extend
functionality. For Entity Framework in particular, it allows us to add
additional functionality to a part of the model without the risk of losing our
changes if the model is changed or regenerated.

## Markup Languages

<hr />

Markup languages are used to store and transport data. They should be human
readable and easily parsed by computers. Some examples of markup languages are
HTML, XML, JSON and YAML.

### XML

<hr />

XML stands for Extensible Markup Language. It is a markup language that is
similar to HTML, but where the tags can be defined by the user. It is used to
store and transport data.

An example of a basic XML document is shown below.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<bookstore>
    <book>
        <title lang="en">Harry Potter</title>
        <price>29.99</price>
    </book>
    <book>
        <title lang="en">Learning XML</title>
        <price>39.95</price>
    </book>
```

### JSON

<hr />

JSON stands for JavaScript Object Notation. As the name suggests, it is based on
JavaScript objects, however it is language independent.

An example of a basic JSON document is shown below.

```json
{
    "bookstore": {
        "book": [
            {
                "title": "Harry Potter",
                "price": 29.99
            },
            {
                "title": "Learning XML",
                "price": 39.95
            }
        ]
    }
}
```

### YAML

<hr />

YAML originally stood for Yet Another Markup Language, but the author now
considers it to be an acronym for YAML Ain't Markup Language as they decided
that it was not really a markup language. It is somewhat similar to Python in
that it uses colons and indentation to define blocks of data.

An example of a basic YAML document is shown below.

```yaml
bookstore:
    book:
        - title: Harry Potter
          price: 29.99
        - title: Learning XML
          price: 39.95
```

### Serialisation

<hr />

Serialisation is the process of converting an object into a stream of bytes to
store the object or transmit it to memory, a database or a file. Some examples
of serialisation are JSON, XML and YAML.

### Deserialisation

<hr />

Deserialisation is the reverse process of serialisation. It is the process of
converting a stream of bytes into an object. For example, we can convert a JSON
file/string into a C# object.
