# CMPG-323-Project-2---32582625-v2

## *This is my 3rd revision of my Project 2 repository. In the previous 2 repositories, I accidentally forgot to add the debug folders into the .gitignore leading to me leaking my passwords through the commit history. I deleted the first repository in panic and did not read the Rubric. I only followed the project 2 brief and did not see any indication of a requirement of a 7 day old commit. My apologies.*
*Also using .net 6 allowed me to bypass the API configuration of swagger, thus not appearing in the Azure API Management service*
# How to use this API

Select any way to test and use the API through the indicated buttons. (GET, POST, PUT, DELETE)

## Recommended Extension to view JSON format easier on 
> Chrome: https://chrome.google.com/webstore/detail/json-viewer/gbmdgpbipfallnflgajpaliibnhdgobh/related
> Firefox: https://addons.mozilla.org/en-US/firefox/addon/jsonview/


The API is accessed by **https://32582625project2.azurewebsites.net/api/{request}/{id}**

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
 
```json
https://32582625project2.azurewebsites.net/api/Categories/3fa85f64-5717-4562-b3fc-2c963f66afa6
 Returns:
 {
    "categoryId": "065c1253-1cc1-45ac-a5e4-013ab73110da",
    "categoryName": "Smart Home",
    "categoryDescription": "Smart Home system capable of internet connectivity and voice commands",
    "dateCreated": "2022-09-07T10:44:15.263"
 } 
```

## Delete requests work differently and have to be handeled with Swagger, Postman or any other API tester.
## Swagger can be accessed with this url: https://32582625project2.azurewebsites.net/swagger/ where DELETE, POST and PUT requests can be handeled and tested with ease.