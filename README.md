# Pangea_DiffAPI
Pangea_DiffAPI




#### Diff API
* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, FluentValidation and AutoMapper packages**
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup




#### Docker Compose establishment with diff microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables







# Diff API

This is a REST API to perform diff operations.

## The Assignment

Provide 2 http endpoints that accepts JSON base64 encoded binary data on both endpoints 
```
<host>/v1/diff/<ID>/left and <host>/v1/diff/<ID>/right
```
The provided data needs to be diff-ed and the results shall be available on a third endpoint 
```
<host>/v1/diff/<ID>
```
The results shall provide the following info in JSON format 
 
* If value of the "input" property of diffed JSONs is equal, just return that information saying “inputs were equal”. No need to return
compared values.
 
* If value of the "input" property of diffed JSONs is not of equal size, just return that information “inputs are of different size”. No need
to return compared values.

* If value of the "input" property of diffed JSONs has the same size, perform a simple diff - return offsets (in both values of the "input"
property) and lengths (in both values of the "input" property) of the differences.

	
  
### Manual tests

It was used the tool Postman to perform manual tests and validate the endpoints.  

Example 1 - data is not equal, but data size is equal:

```

=== Add left data === 
POST request: http://localhost:5193/v1/diff/123/left
JSON data in the request body:
{
	"text" : "dmluaWNpdXM="
}

=== Add right data === 
POST request: http://localhost:5193/v1/diff/123/right
JSON data in the request body:
{
	"text" : "aXNhYmVsbGU="
}

=== Get the diff ===
GET request: http://localhost:5193/v1/diff/123
JSON data in the response:
{
    "message": "Inputs were compared",
    "differences": [
        {
            "Offset": 0,
            "Length": 5
        },
        {
            "Offset": 1,
            "Length": 3
        },
        {
            "Offset": 2,
            "Length": 4
        },
        {
            "Offset": 3,
            "Length": 3
        },
        {
            "Offset": 4,
            "Length": 2
        },
        {
            "Offset": 5,
            "Length": 2
        },
        {
            "Offset": 6,
            "Length": 3
        },
        {
            "Offset": 7,
            "Length": 3
        }
    ]
}

```

Example 2 - Inputs were equal:
```
=== Add left data === 
POST request: http://localhost:5193/v1/diff/123/left
JSON data in the request body:
{
	"text" : "dmluaWNpdXM="
}

=== Add right data === 
POST request: http://localhost:5193/v1/diff/123/right
JSON data in the request body:
{
	"text" : "dmluaWNpdXM="
}

=== Get the diff ===
GET request: http://localhost:5193/v1/diff/123
JSON data in the response:
{
    "message": "Inputs were equal",
    "differences": []
}
```

Example 3 - Inputs are of different size : 
```
=== Add left data === 
POST request: http://localhost:5193/v1/diff/123/left
JSON data in the request body:
{
	"text" : "dmluaWNpdXM="
}

=== Add right data === 
POST request: http://localhost:5193/v1/diff/123/right
JSON data in the request body:
{
	"text" : "YW5hbmRh"
}

=== Get the diff ===
GET request: http://localhost:5193/v1/diff/123
JSON data in the response:
{
    "message": "string",
    "differences": []
}


