# This is my VehicleUtility Project
### Table of Contents
1. [Concept](#Concept)
2. [Data-Diagram](#Data-Diagram)
3. [UI first draft](#UI-first-draft)
4. [User Stories](#User-Stories)
5. [Use Cases](#Use-Cases)
6. [Requirements Table](#Requirements-Table)
7. [Test Table](#Test-Table)
8. [Prototype](#Prototype)

<a name="Concept"/>

## Concept

Vehicle Utility app that records and schedule service for vehicles. This tool would store vehicle information, require a user to input the mileage, and the amount of fuel filled at every gas station stop, and any prior maintenance that has been completed on the vehicle.

<a name="Data-Diagram"/>

## Draft Data-Diagram


![Data-Diagram](https://github.com/ThompsonSamuel/VehicleUtilityTool/blob/master/ERD%20-%20SThompson.PNG?raw=true)

<a name="UI-first-draft"/>

## UI first draft

Home Page
![Home Page](https://github.com/ThompsonSamuel/VehicleUtilityTool/blob/master/VehicleUtility%20UI/Home.PNG?raw=true)
Calender Page
![Calender Page](https://github.com/ThompsonSamuel/VehicleUtilityTool/blob/master/VehicleUtility%20UI/Calender.PNG?raw=true)
Schedule Page
![Schedule Page](https://github.com/ThompsonSamuel/VehicleUtilityTool/blob/master/VehicleUtility%20UI/Schedule.PNG?raw=true)

<a name="User-Stories"/>

## User Stories

_As a_  driver who owns mutiple vehicle
_I want_ ability to store/input information for multiple vehicles
_So that_ I do not need mutiple accounts.

_As a_ driver without knowledge of vehicle maintenance
_I want_ notifications when service is due
_So that_ I do not forget to look at the schedule for service times.

_As a_ motorcyclist who cant carry a laptop while riding
_I want_ the application to function easily on a phone
_So that_ I can use it at gas station or shops.

_As a_ shop with service and parts warrenty
_I want_ the customers to store a copy of their reciepts 
_So that_ customers can utilize the warrenty service.

<a name="Use-Cases"/>

## Use Cases

![Use Case Diagram](https://github.com/ThompsonSamuel/VehicleUtilityTool/blob/master/Use%20Cases%20Diagram.PNG?raw=true)

<a name="Requirements-Table"/>

## Requirements Table

Req. ID | Requirement Description | Test Method | Test ID Number
------------ | ------------ | ------------- | -------------
 1.0 | When user presses log in, button shall display loading symbol | Inspection | TC01
 2.0 | Application shall verify log in information | Test | TC02
 3.0 | Application shall display vehicles stored in users account | Inspection | TC01
 | | | 
 1.1 | When user looks at service schedule, application shall display date/mileage until recommended | Inspection | TC01
 2.1 | Application shall calculate date/mileage remaining from current date/mileage| Demonstration | TC03
 | | | 
 1.3 | User may input mileage | Test | TC04
 2.3 | Application shall update current mileage for selected vehicle | Test | TC04
 3.3 | Application shall display mileage until next service | Inspection | TC05
 | | | 
 1.4 | Application shall save images of reciepts | Inspection| TC05
 | | |
 1.5 | When user presses enter to log, application shall refresh page |  Demonstration | TC06
 2.5 | Application shall load updated service history log |  Demonstration | TC06
 3.5 | Application shall update date/mileage until service required | Test | TC04

<a name="Test-Table"/>

## Test Table

Test ID | Req. ID | Test Procedure | Current Status | TimeStamp | build/version
------------ | ------------ | ------------- | ------------- | ------------- | --------------
TC01 | 1.0<br/>3.0<br/>1.1 |  Program displays log in and home page of account | Passed | 10-31-20 | 1
TC02 | 2.0 | Application verifies log in information | Passed | 10-31-20 | 1
TC03 | 2.1 | Application calculates date/mileage remaining from current date/mileage | Passed | 10-31-20 | 1
TC04 | 1.3<br/>2.3<br/>3.5 | Application accepts mileage input, updates current mileage, ~~and updates mileage until service~~ _now unnecessary_ | Passed | 10-31-20 | 1
TC05 | 1.4<br/>3.3 | Application displays mileage remaining and save reciepts | Passed | 10-31-20 | 1
TC06 | 1.5<br/>2.5 | Application loads service history when _enter ~~to log~~_ is pressed | Passed | 10-31-20 | 1

<a name="Prototype"/>

## Prototype
![PrototypeH](https://github.com/ThompsonSamuel/VehicleUtilityTool/blob/master/Prototype/PrototypeH.PNG?raw=true)

## Database
![Database](https://github.com/ThompsonSamuel/VehicleUT/blob/master/ScreenShots/NewDB.PNG?raw=true)
