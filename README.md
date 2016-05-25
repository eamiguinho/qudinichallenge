# Qudini challenge

## Objective

Develop an Windows tablet app that will fetch a list of customers from an API and display them on screen as detailed below. 
The API is: https://app.qudini.com/api/queue/gj9fs
The Username and password for the API are: 
·  Username: codetest1
·  Password: codetest100

1. The API will need to be authenticated against using HTTP Basic auth and will return a JSON object that contains some queue data containing a list of customer objects. 

2. The app should make a request to this api and display the list of customers name and their ‘expectedTime' and ordered by the expected time closest time first. 

3. It should also fetch the profile image of the customer by using the Gravatar Image request api (use their email for this, or show a placeholder if no email is present): https://en.gravatar.com/site/implement/images/

4. The app should ensure that the list reloads automatically every 30 seconds and that the UI is not blocked. 

5. The project will be covered by Unit Test.

The completed project should be uploaded to github and the URL submitted along with a description on how you coded it and reasons for doing things in the way you chose. Could you complete the task using native Windows languages (C# and Xaml). 


## Developer resume
Application was developed for Universal Windows Platform (Windows 10 and Windows Phone 10) all the steps request were complete with sucess, including 92.57% code test coverage.

This architecture is ready for Xamarin iOS and Android and even ready for different sources of data without changing the app domain (DDD).

#### Technologies & Patterns used
1. Onion Architecture, DDD (Domain driven design), MVVM were the patterns used in this challenge.
2. Dependency Injection, IoC, NSubstitute (Mock Dependecies), Rx.NET (Reactive Extensions, basically to do a timer inside of PCL)







