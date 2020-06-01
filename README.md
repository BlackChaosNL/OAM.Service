# Open Asset Manager Service

## Table of Contents
 - [1. Project Definition](#1-project-definition)
 - [2. Requirements](#2-requirements)
 - [3. Software Used](#3-software-used)
 - [4. Licenses](#4-licenses)

### 1. Project Definition

What is the Open Asset Manager? The Open Asset Manager holds Asset Lists created by it's user(s). 
The user can define what type of assets they register in their lists, this can be for instance: Computer with seperate parts bought, their warranty paperwork etc. 
This has to be defined in the context of an asset location. (Where is the product and other assets are located.)

This is the repository for the backend service of the Open Asset Manager, the full repository with the entire system can be found under the [OAM](https://github.com/BlackChaosNL/OAM) repository.

### 2. Requirements

- [X] There needs to be authentication present;
- [X] There needs to be authorization present;
- [X] The authentication and authorization should be done with OAuth2 (OpenID Connect);
- [X] The System needs to migrate the database on first use;
- [X] The System needs to hold a multitude of Asset Locations defined by the User;
- [X] The System needs to hold a multitude of Asset Types defined by the User;
- [X] The System needs to hold a multitude of Assets defined by the User;
- [X] The User needs to be able to authenticate;
- [ ] The Administrator needs to be able to CRUD users;
- [ ] The User needs to be able to define (multiple) Asset Location(s);
- [ ] The User needs to be able to define (multiple) Asset Types;
- [ ] The User needs to be able to define (multiple) Assets;
- [ ] The User needs to be able to export multiple Asset Chains (Assets including Sub-Assets);
- [ ] The User needs to be able to import multiple Asset Chains (Assets including Sub-Assets);
- [ ] A Docker module needs to be added for usage in a containerized environment;
- [ ] A set of unit tests need to be written to verify regression when updating;
- [ ] A permissive license needs to be granted for FOSS usage. (Including all sub-software: To be verified)

### 3. Software Used 

| Software        | Version | Reason                                                                                                                                           |
| --------------- | ------- | ------------------------------------------------------------------------------------------------------------------------------------------------ |
| .NET Core       | 3.1     | I opted for C# as programming language due to ASP.NET & EF Core.                                                                                 |
| ASP.NET Core    | 3.1     | See above reason.                                                                                                                                |
| EF Core         | 3.1     | For an ORM I wanted to use EF Core, because it has a fluent way of defining DB Calls                                                             |
| IdentityServer4 | Latest  | For defining OAuth2 for authentication & authorization I opted for using IS4, due to the thorough integration with .NET Core, ASP.NET & EF Core. |
| PostgresQL      | Latest  | For saving all objects, I've opted to use the open source PostgresQL. Widely available and FOSS.                                                 |

### 4. Licenses

The following licenses are applied to the following pieces of software:
- .NET Core - [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0);
- ASP.NET Core - [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0);
- EF Core - [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0);
- IdentityServer4 - [Apache License 2.0](https://www.apache.org/licenses/LICENSE-2.0);
- PostgresQL - [PostgresQL license](https://www.postgresql.org/about/licence/);