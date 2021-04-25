# MMTDigital
MMT digital Api in .Net core and EF core -- i have implemented clean architecture and Domain Driven Design Architectire pattern and Repository Pattern.
Open solution in folder- "MMT.CustomerOrder.Api"
When you run the Api solution swagger should automatically launch. 
To make Api better / release to production following can be implemented
1) Unit tests and integration test need to be written.
2) Need to have appsettings.Production to replace SQl server connection strings and Api Url
3) For user Authentication Userid and Email can be send thorugh headers and then can be authenticated in Middleware.
4) Exception handling can be implented in middleware
