# Stock Management API

This is a stock Management API, made while learning Web API From [Teddy Smith](https://youtu.be/qBTe6uHJS_Y?si=gQ68_ePhNsg0OUQr) using C# ASP.Net Framework.

# Key Features


**User Authentication**
- **User Registration**: Allows new users to create accounts by providing necessary information.
- **User Login**: Enables registered users to log in securely to access booking features.

**Stocks**
- **Stocks Creation**: Authenticated Users can create new Stocks.
- **Stocks Update**: Authenticated Users can Update Stocks.
- **Stocks Deletion**: Authenticated Users can Delete Stocks.
- **Stocks Display**: Authenticated Users can:
		1. Get a list of all stocks and filter them by [Symbol, Company Name, Industry] _(More Coming Soon)_ And/Or 			    	 Sort them by what column they want ( Currently, the Users can only apply sorting by just 1 column, there may be some updates in the future), and choose whether they want to sort them descending or ascending _ascending by default_.
		2.  Get a list of stocks by Id or Symbol _(More Coming Soon)_

**Comments**
- **Adding Comments**: Authenticated Users can add a new Comment on a stock.
- **Updating Comments**: Authenticated Users can update their Comments.
- **Deleting Comments**: Authenticated Users can Delete their Comments.

**Portfolio**
- **Portfolio Display**: Authenticated Users can Display their Portfolio.

## Database Design
**AppUsers**

| Column Name| Data Type    |
|--------------|--------------|
| ID | string |
| Username | string |
| Email | string|
| Password | string |

**Stocks**

| Column Name | Data Type |
|----------------|---------|
| ID | int |
|  Symbol |  string |
| CompanyName | string |
| Purchase | decimal |
| LastDiv | decimal | 
| Industry | string |
| MarketCap | long |
| Comments | List<Comment> | 
| Portfolios | List<Portfolio | 

**Portfolios**
| Column Name | Data Type |
|----------------|---------|
| AppUserId| string |
|  StockId |  int |
| Stock | Stock |
| AppUser | AppUser |

**Comments**
| Column Name | Data Type |
|----------------|---------|
| ID | int |
|  Title |  string |
| Content | string |
| CreatedOn | DateTime|
| StockId | int  | 
| Stock | Stock |
| AppUserId | string  |
| AppUser | AppUser | 

## Endpoints 
**Account**
| HTTP Method | Endpoint | Description |
| --|--|-|
| POST | /api/account/login | process a login request |
| POST | /api/account/Register | process a registering request |

**Comment**
| HTTP Method | Endpoint | Description |
|-|-|-|
| GET | /api/comment | Returns the list of all comments |
| GET | /api/comment/{id} | Returns the comment with commentId = id |
| PUT | /api/comment/{id} | Updates the comment with commentId = id |
| DELETE | /api/comment/{id} | Deletes the comment with commentId = id |
| POST | /api/comment/{stockId} | Creates a new comment and connect it with the stock |

**Portfolio**
| HTTP Method | Endpoint | Description |
|-|-|-|
| GET | /api/portfolio | Returns the portfolio of the authenticated user |
| POST| /api/portfolio | Adds a stock and connect it to the user | 
| DELETE | /api/portfolio | Removes a stock from a user portfolio |

**Stock**
| HTTP Method | Endpoint | Description |
|-|-|-|
| GET | /api/stock | Returns the list of all stocks |
| GET | /api/stock/{id} | Returns the stock with stockId = id | 
| POST | /api/stock | Process the creation of a new stock |
| PUT | /api/stock/{id} | Updates the stock |
| DELETE | /api/stock/{id} | Deletes the stock |  

## Technology stack overview 

**Technologies Used**
- **C#**: Main programming language.
- **ASP.NET**: Framework for building high-performance, cross-platform web APIs.

**Database**
- **Entity Framework Core**: Employing Entity Framework Core for streamlined object-relational mapping (ORM) within the .NET ecosystem, simplifying database interactions.
- **SQL Server**: Utilizing SQL Server for reliable and scalable backend database management, ensuring efficient storage and retrieval of application data.

**API Documentation & Design**
- **Swagger**: For API specification & documentation.
- **Swagger UI**:  Provides a user-friendly interface for API interaction.

**Authentication & Autherization**
-   **JWT (JSON Web Tokens)**: For secure transmission of information between parties.

**Design Patterns**:
- **Repository Pattern**
-  **Factory Pattern**
-  **Strategy Pattern**

# Setup guide
_Coming soon..._
