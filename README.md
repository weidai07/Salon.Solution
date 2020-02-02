# Hair Salon Project
##### By Wei Dai
###### Created 17 January, 2020

## Description

This project allows a hair salon owner to track their stylists and clients lists.

## Links:

Github - https://github.com/weidai07/Salon.Solution

## Setup/Installation Requirements:

1. Open https://github.com/weidai07/Salon.Solution
2. Clone repository to local machine 
3. Build and Run project

  - $ dotnet restore - when you are ready to restore the dependencies of the project
  - $ dotnet build - when you are ready to build the project
  - $ dotnet run - to run the project 
  - $ dotnet test - for testing the project
  

### Specification

  This programs allows hair salon owners to keep track of how many stylists work for them as well as how many clients each hair stylists have under them. Every client is assigned to a stylists therefore no clients will be left out. All the owner of the salon has to do is just click add stylists to add the names of their employees as well as all of the clients each of their employees attends to. 

## SQL Table

CREATE TABLE `Clients` (
  `ClientId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255),
  PRIMARY KEY (`ClientId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `StylistClient` (
  `StylistClientId` int(11) NOT NULL AUTO_INCREMENT,
  `ClientId` int(11) NOT NULL,
  `StylistId` int(11) NOT NULL,
  PRIMARY KEY (`StylistClientId`),
  KEY `IX_StylistClient_ClientId` (`ClientId`),
  KEY `IX_StylistClient_StylistId` (`StylistId`),
  CONSTRAINT `FK_StylistClient_Clients_ClientId` FOREIGN KEY (`ClientId`) REFERENCES `clients` (`ClientId`) ON DELETE CASCADE,
  CONSTRAINT `FK_StylistClient_Stylists_StylistId` FOREIGN KEY (`StylistId`) REFERENCES `stylists` (`StylistId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `Stylists` (
  `StylistId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255),
  PRIMARY KEY (`StylistId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


## Known Bugs

* _None at this time_

## Technologies Used:

* C#
* .NET
* Microsoft(MS) Test

### License:

Copyright (c) 2020 Wei Dai

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.