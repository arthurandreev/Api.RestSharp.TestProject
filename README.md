# Api test automation project built with RestSharp and NUnit 
This project has been built with RestSharp and NUnit to showcase how a mocking library like JSONPlaceholder can be used to mock responses in your API tests.

## ToDoList
I used a mock ToDoList REST API called JSONPlaceholder which mocks an API and allows developers to test their code - https://jsonplaceholder.typicode.com/guide.html
On the whole, I found this service very easy to use and it certainly helped me write tests to cover happy path flows. 
However, a major downside to this mock API service is that the data sent to it is not persisted(responses are mocked instead) which limits the number of potential client user flows that can be tested. For example, a 409 Conflict status code is not possible to test as Post endpoints on JSONPlaceholder always return a 201 even when a client tries to create the same resource more than once. Because of this limitation, my test suite contains very few tests that exercise negative paths such as 409 Conflict scenario. 

### MVP
- Write tests for CRUD endpoints - DONE
- Write code for CRUD endpoints - DONE
- Add Specflow to the project - TODO
- Refactor to follow best RestSharp practices - TODO

### Possible Extensions
- Host the project on Microsoft Azure to enable automated nightly test runs - TODO
