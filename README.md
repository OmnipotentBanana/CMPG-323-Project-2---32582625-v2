# CMPG-323-Project-2---32582625-v2

## *This is my 3rd revision of my Project 2 repository. In the previous 2 repositories, I accidentally forgot to add the debug folders into the .gitignore leading to me leaking my passwords through the commit history. I deleted the first repository in panic and did not read the Rubric. I only followed the project 2 brief and did not see any indication of a requirement of a 7 day old commit. My apologies.*

## *Reference List is uploaded to this repository under **Reference List.txt***

*Also using .net 6 allowed me to bypass the API configuration of swagger, thus not appearing in the Azure API Management service*

# How to use this API

Select any way to test and use the API through the indicated buttons. (GET, POST, PUT, DELETE)

## Recommended Extension to view JSON format easier on 
> Chrome: https://chrome.google.com/webstore/detail/json-viewer/gbmdgpbipfallnflgajpaliibnhdgobh/related
> Firefox: https://addons.mozilla.org/en-US/firefox/addon/jsonview/


The API is accessed by **https://32582625project2.azurewebsites.net/api/{request}/{id}**
*sidenote: I did not know you could use the API Management Service's Base URL to handle requests. I just used my App Service to handle all my Swagger and API requests.**https://apim-cmpg323pr2.azure-api.net** is the APIM Base URL and can be used instead of the project2.azurewebsites url :)*

This request can be Categories, Devices and Zones
These can be further refined to search for individual components by using the GUID lookup
Some examples:

https://32582625project2.azurewebsites.net/api/Categories
Returns:
```json
[
  {
    "categoryId": "065c1253-1cc1-45ac-a5e4-013ab73110da",
    "categoryName": "Smart Home",
    "categoryDescription": "Smart Home system capable of internet connectivity and voice commands",
    "dateCreated": "2022-09-07T10:44:15.263"
  },
  {
    "categoryId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "categoryName": "Smart Watches",
    "categoryDescription": "Smart Watches with Mobile OS",
    "dateCreated": "2022-09-07T08:33:42.727"
  }
 ]
```
https://32582625project2.azurewebsites.net/api/Categories/3fa85f64-5717-4562-b3fc-2c963f66afa6
Returns:
```json
 {
    "categoryId": "065c1253-1cc1-45ac-a5e4-013ab73110da",
    "categoryName": "Smart Home",
    "categoryDescription": "Smart Home system capable of internet connectivity and voice commands",
    "dateCreated": "2022-09-07T10:44:15.263"
 } 
```

## Zone id search within Devices
https://32582625project2.azurewebsites.net/api/Devices/GetDeviceByZone/6530ea63-e628-47df-81fd-c5f2a4b92ddb
Returns:
```json
[
  {
    "deviceId": "24808084-b1b0-440d-a734-0a7c950e297f",
    "deviceName": "Amazon Alexa",
    "categoryId": "065c1253-1cc1-45ac-a5e4-013ab73110da",
    "zoneId": "6530ea63-e628-47df-81fd-c5f2a4b92ddb",
    "status": "Monitored",
    "isActvie": true,
    "dateCreated": "2022-09-07T11:10:16.637"
  }
]
```
https://32582625project2.azurewebsites.net/api/Categories/GetNumberOfZones/id?id=065c1253-1cc1-45ac-a5e4-013ab73110da
Returns:
#### There are 2 zones currently using a Smart Home IOT Device
```json 
  2
```

## Delete requests work differently and have to be handeled with Swagger, Postman or any other API tester to send a request body to be formatted correctly with the input parameters.
## Swagger can be accessed with this url: https://32582625project2.azurewebsites.net/swagger/ where DELETE, POST and PUT requests can be handeled and tested with ease.