<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>

<body>
  <h1>Eksi Sozluk</h1>

  <h2>Project Structure</h2>
  <p>The project repository consists of the following folders:</p>
  <ul>
    <li><code>api</code>: This folder contains the backend code of the application. It is implemented in .NET using the
      Onion Architecture, CQRS pattern, and MediatR library.</li>
    <li><code>clients</code>: This folder contains the web application developed using Blazor WebAssembly. The client-side
      code is written in HTML, CSS, and utilizes the API for data retrieval and interaction.</li>
    <li><code>projections</code>: This folder contains three projection services: voting, faving, and user service. These
      services leverage RabbitMQ for communication and handle operations related to voting, favoriting, and user-related
      functionalities.</li>
  </ul>

  <h2>Technologies Used</h2>
  <ul>
    <li><code>.NET</code>: The backend of the application is implemented using the .NET framework, providing a robust and
      scalable foundation for the API.</li>
    <li><code>Onion Architecture</code>: The application follows the principles of the Onion Architecture, which promotes
      modularity and separation of concerns.</li>
    <li><code>CQRS Pattern</code>: The CQRS pattern separates the read and write operations, improving scalability and
      performance.</li>
    <li><code>MediatR</code>: MediatR is used as a mediator pattern implementation for handling requests and commands.</li>
    <li><code>Blazor WebAssembly</code>: The web application is built using Blazor WebAssembly, allowing for the development
      of interactive web applications using C#.</li>
    <li><code>HTML and CSS</code>: The client-side code is written in HTML and styled using CSS for a responsive and visually
      appealing user interface.</li>
    <li><code>PostgreSQL</code>: The project uses PostgreSQL as the chosen database management system, providing reliability
      and extensibility for storing application data.</li>
    <li><code>Entity Framework (EF) Code First</code>: The application uses Entity Framework with the Code First approach,
      allowing for the definition of the database schema using code.</li>
    <li><code>RabbitMQ</code>: RabbitMQ is utilized as a message broker, facilitating communication between different
      components of the application.</li>
    <li><code>JWT</code>: JWT (JSON Web Tokens) is used for authentication and authorization, ensuring secure access to the
      application's features.</li>
  </ul>

