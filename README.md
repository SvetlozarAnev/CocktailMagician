# CocktailMagician
Web application that allows creation of cocktails and follows their distribution and success in amazing bars.

## Team Members
* Svetlozar Anev - [GitHub](https://github.com/SvetlozarAnev)
* Ivan Venkov - [GitHub](https://github.com/ivanvenkov)

## Project Description
* **Public part** -  accessible without authentication
* **Private part** available for registered users only
* **Administrative part** available for administrators only

#### Public Part
* The public part consists of a home page displaying top rated cocktails and bars as well as login page and register page.
* Upon clicking a bar, the visitor can see details for the bar and the cocktails it offers
* Upon clicking a cocktail, the visitor can see details for the cocktail
* It also includes **searching possibility** for bars and cocktails by name

#### Private Part

* After login, users see everything visible to website visitors and additionally they can:
     * Rate bars
     * Rate cocktails
     * Leave a comment for a bar
     * Leave a comment for a cocktail

#### Administrative Part
* Admins can:
     * Manage cocktails – CRUD operations for cocktails
     * Manage bars – CRUD operations for bars
     * Manage ingredients 

## Technologies
* ASP.NET Core
* ASP.NET Identity
* Entity Framework Core
* MS SQL Server
* Razor
* JavaScript
* HTML
* CSS
* Bootstrap
