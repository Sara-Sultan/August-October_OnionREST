# August-October_OnionREST
August-October_OnionREST
Building REST API using .Net Core - Practice assignment

After finishing the course, please use ASP.Net Core to implement simple REST API according to the below requirements.

Functional requirements:


Create simple MS SQL server database with the following tables
o   Products (ID, Name, Price, Quantity, ImgURL, CateogryID)

o   Category (ID, Name)

Create the following API endpoints:
Categories controller:
GET: /categories
Products controller:
GET: /products
GET: /products /{id}
GET: /products?categoryID={id}
POST: /products
PUT: /products/{id}
Handle API response to be well-organized, suggested API response structure:
{

                  success: Boolean,

                  results: [] or {} //according to needed response // in case of success

                  messages: string[]  //in case of the request wasn’t complete due validation errors

}

·       Handle help with Swagger, to list available endpoints and required details.

·       Install and handle CORS in your API.

·       It’s recommended to use Entity framework core with Code-first approach.

·       Don’t implement the business login in controllers, use services instead and, organize the folder structure and use separated folders for: Entities, Services, controllers,…etc (You can Use Onion architecture instead [Bonus])

------------------------------------------------------------------------------------------------------------

Delivery requirements (Delivery should be on ITWorx academy – Assignment submission only):

1.       Upload the project to GitHub and send the GitHub link in the assignment submission text on ITWorx academy (Required, don’t send only the project code).

2.       Send API test results or links by one of the following methods:

o   Use Postman to create collection for all API endpoints and share the postman collection via JSON Link or export as file and send the file or the link with your submission on ITWorx academy.

o   /OR/ Upload the API to any free hosting (GitHub pages, Heroku,…) and send the publish link in the assignment submission text on ITWorx academy

------------------------------------------------------------------------------------------------------------------------------------------

Optional requirements (Bonus):

·       Handle the following endpoints in Products controller:

o   PATCH: /products/{id}

o   DELETE: /products/{id}

·       Handle authentication in your Web API project.

o   Create Login, register endpoints

o   Make POST, PUT, DELETE endpoints for products authorized.

·       Use repository pattern and proper architecture for your project (Onion architecture for example).

·       Handle paging in GET products endpoints.

·       Handle API versioning.

·       Test your APIs in simple web application (use JavaScript to call the APIs).
