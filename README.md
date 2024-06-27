# BookTracker App
## Overview

BookTracker was developed to keep track of the books on your bookshelf, including book information, author information, and book completion status. It is an ASP.NET MVC framework, developed using C# and MySQL database. It also utilizes the Open Library Book Cover API to display covers for each book. There are two databases (books and authors) and the user can perform CRUD operations (create, read, update, delete) on both databases. The user is also able to sort the book and author tables by each column. The project also includes a search feature for each table.  

## Features

- **Create:** Add new books or authors to the database.
- **Read:** View details of existing books and authors.
- **Update:** Edit information about existing books and authors.
- **Delete:** Remove book or author from database.

## Technologies Used
- **C#:** Programming language used for application development.
- **ASP.NET MVC Core:** Framework for building web applications and APIs.
- **MySQL:** Relational database management system for storing book and author data.
- **Dapper:** Lightweight ORM for data access.
- **HTML:** Programming language used for application development.
- **CSS:** Programming language used for application development.
- **Open Library API:** Interface used to display book covers.

## Project Structure
- **Controllers:** Contains the MVC controllers responsible for handling user requests.
- **Models:** Contains the data models representing books and authors.
- **Views:** Contains the Razor views for rendering HTML.
- **Repositories:** Contains the Dapper-based repository classes for data access.
- **wwwroot:** Contains static files like CSS, JS, and images.
- **appsettings.json:** Configuration file for application settings, including database connection strings.

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

1. Fork the repository.
2. Create a new branch (git checkout -b feature/YourFeature).
3. Commit your changes (git commit -am 'Add new feature').
4. Push to the branch (git push origin feature/YourFeature).
5. Create a new Pull Request.

## Screenshots


![HomePage](https://github.com/samfranshad/BookTracker/assets/167722316/95238d3f-2163-461c-bb21-214cbb3ecb95)
![Books](https://github.com/samfranshad/BookTracker/assets/167722316/bc048b53-23b6-4153-a038-1cd26db263c5)
![BookDetails](https://github.com/samfranshad/BookTracker/assets/167722316/d0028049-aea5-450e-b298-82e384002668)
![UpdateBook](https://github.com/samfranshad/BookTracker/assets/167722316/6425dcbe-5a65-41cc-9193-462827a7f5f4)
![Authors](https://github.com/samfranshad/BookTracker/assets/167722316/5ead689d-92f6-4b77-a624-5cf8660bf44c)
![AuthorDetails](https://github.com/samfranshad/BookTracker/assets/167722316/a6b3902d-dc20-42be-9db3-cd7e66b10723)
![AddAuthor](https://github.com/samfranshad/BookTracker/assets/167722316/b7badbf4-cb78-4422-8992-8bd105cd7e17)



