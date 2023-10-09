# Cookie Stand API Project

This project is an API for managing cookie stands. It provides endpoints for creating, updating, deleting, and retrieving cookie stands along with their hourly sales data.

## Table of Contents

- [Controller](#controller)
- [Service](#service)
- [Models](#models)

---

## Controller

### `CookieStandsController`

The `CookieStandsController` is responsible for handling HTTP requests related to cookie stands.

- **GET: api/CookieStands**
  - Endpoint to retrieve a list of all cookie stands.
- **GET: api/CookieStands/{id}**
  - Endpoint to retrieve a specific cookie stand by its ID.
- **PUT: api/CookieStands/{id}**
  - Endpoint to update a specific cookie stand.
- **POST: api/CookieStands**
  - Endpoint to create a new cookie stand.
- **DELETE: api/CookieStands/{id}**
  - Endpoint to delete a specific cookie stand by its ID.

---

## Service

### `CookieStandService`

The `CookieStandService` contains the business logic for handling cookie stands.

- **AddCookieStand**
  - Adds a new cookie stand to the database.
- **GenerateHourlySales**
  - Generates hourly sales data for a cookie stand.
- **GetAllCookieStand**
  - Retrieves a list of all cookie stands.
- **GetCookieStandByID**
  - Retrieves a specific cookie stand by its ID.
- **RemoveCookieStand**
  - Deletes a specific cookie stand by its ID.
- **UpdateCookieStand**
  - Updates an existing cookie stand.
- **UpdateHourlySales**
  - Updates hourly sales data for a cookie stand.

---

## Models

### `CookieStand`

Represents a cookie stand with the following properties:

- ID (int): Unique identifier for the cookie stand.
- Location (string): Location of the cookie stand.
- Description (string): Description of the cookie stand.
- Minimum_Customers_PerHour (int): Minimum number of customers per hour.
- Maximum_Customers_PerHour (int): Maximum number of customers per hour.
- Average_Cookies_PerSale (double): Average number of cookies sold per customer.
- Owner (string): Owner of the cookie stand.
- HourlySales (List of HourlySales): List of hourly sales data associated with the cookie stand.

### `HourlySales`

Represents hourly sales data for a cookie stand with the following properties:

- ID (int): Unique identifier for the hourly sales entry.
- CookieStandID (int): ID of the associated cookie stand.
- HourlySale (int): Number of cookies sold per hour.

---

Feel free to reach out if you have any questions or need further assistance with the project!
