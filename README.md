# Commerce Project

This repository contains a simple API which allows CRUD operations for customers, and allows its customer to make purchases.

- [Commerce Project](#commerce-project)
  - [Commece Tests Cases](#commece-tests-cases)
  - [## Customer endpoints](#-customer-endpoints)
  - [## Order endpoints](#-order-endpoints)
  - [## Run the tests](#-run-the-tests)
  - [## Run the API](#-run-the-api)
  - [## Run the integration tests](#-run-the-integration-tests)


## Commece Tests Cases

* Add a customer without providing the required values.
* Add a customer with valid data.
* Retrieve all the customers
* Retrieve the customer added at the begining
* Retrieve an invalid customer
* Update an invalid customer
* Update an existing customer
* Remove an invalid customer
* Remove an existing customer
* Try the remove the customer previously removed
* Add an order for an invalid customer
* Add an order including an invalid product
* Add an order without including order lines
* Add an order with valid data

## Customer endpoints
---

| Action | Action name | Description | Endpoint |
| ------ | ----------- | ----------- | -------- |
| GET    | GetCustomer | Retrieves all the customer registered in the application | /api/customers/ |
| GET    | GetCustomerById | Retrieves a customer based on the specified id | /api/customers/{customerId} |
| POST   | CreateCustomer | Creates and returns the route where the customer can be retrieved | /api/customers/ |
| PUT    | UpdateCustomer | Updates an existing customer | /api/customers/{customerId} |
| DELETE | DeleteCustomer | Deletes an existing customer | /api/customers/{customerId} |

## Order endpoints
---
| Action | Action name | Description | Endpoint |
| ------ | ----------- | ----------- | -------- |
| POST   | CreateOrder | Creates and returns the cost of the purchase | /api/customers/{customerId}/orders/ |

## Run the tests
---
Before you run the following command, ensure that you're in the project **root folder**.

`dotnet test Commerce.Tests/Commerce.Tests.csproj`

## Run the API
---
Before you run the following command, ensure that you're in the project **root folder**.

`dotnet run --project Commerce.Api/Commerce.Api.csproj`

## Run the integration tests
---
Before you run the following command, ensure that you're in the **Commerce.Postman** folder.

* Install **Postman Newman**

    `npm install -g newman`

* Run the postman collection

    `newman run Commerce.collection.json -e Local.environment.json`