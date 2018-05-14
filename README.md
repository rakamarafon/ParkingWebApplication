# ParkingWebApplication
This is ASP.NET Core Web API App. Solution includes 2 projects: ASP.NET Core with REST API and class library with parking logic.

# REST API:
_Cars_
* List of all cars(GET)
* Info by one car(GET)
* Delete car(DELETE)
* Add car(POST)

_Parking_
* Count of free space(GET)
* Count of occupied places(GET)
* Total incoming(GET)

_Transactions_
* Get Transactions.log(GET)
* Get transaction by one minute(GET)
* Get transaction for one car by one minute(GET)
* Reffil car balance(PUT)

# EndPoints:

_Cars_
* List of all cars (GET):   api/Cars
* Info by one car(GET):     api/Cars/{"id"}
* Delete car(DELETE):       api/Cars/{"id"}
* Add car(POST):            api/Cars (add car to request body by example: 
                            {"CarId":1,"Balance":1111,"Type":0} 
                            where Type can be Passenger = 0, Truck = 1, Bus =2, Motorcycle =3)

_Parking_
* Count of free space(GET):       api/Parking/free
* Count of occupied places(GET):  api/Parking/busy
* Total incoming(GET):            api/Parking/income

_Transaction_
* Get Transactions.log(GET):                      api/Transaction/log
* Get transaction by one minute(GET):             api/Transaction/minute
* Get transaction for one car by one minute(GET): api/Transaction/bycar/{"id"}
* Reffil car balance(PUT):                        api/Transaction/{"id"} 
                                                  (add car id into request header and add summ to request body, 
                                                  _summ is a number not an object or array_)

# Base URL: http://parkingwebapp.azurewebsites.net/
