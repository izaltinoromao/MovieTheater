# Movie Theater Management System

<div style="text-align: center;">
    <img src="logo.jpeg" alt="Logo" width="200"/>
</div>

## Overview

This is a Movie Theater Management System developed in ASP.NET. It allows users to manage movie theaters, add new movies, purchase tickets, and view details about parking slots.

## Features

- **Manage Movie Theaters**: Create, edit, and manage movie theaters.
- **Add Movies**: Add new movies to multiple theaters and manage their schedules.
- **Buy Tickets**: Purchase tickets for movies.
- **Parking Details**: View and manage parking slot details for movie theaters.

## Extra Features

- **List Movie Theaters by Movie**: List all Movie Theaters that is displaing a Movie.
- **List all details from a Movie Theater**: 
    - List Movie Theater properties.
    - Show parking slot details.
    - List all Movies that is staring at the moment.
    - List all valid tickets. A ticket is valid if it is less than 3 days old.

## Suggested order to test

- **Create a Movie Theater**: Create a custom Movie Theater.
- **Create a Parking Detail**: Create a parking detail for this Movie Theater.
- **Create some Movies**: Create some Movies to display at this Movie Theater.
- **Create some Tickets**: Create some tickets to simulate a purchase.
- **Test the Extra Features**: After this point you will be able to test the extra features.

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/izaltinoromao/MovieTheater
    cd MovieTheater
    ```

2. Install dependencies:
    ```bash
    dotnet restore
    ```

3. Update the configuration files with your database settings.

4. Run the application:
    ```bash
    dotnet run
    ```

## Usage

### Authentication

- **Register**: `POST /auth/register`
- **Login**: `POST /auth/login`
- **Refresh Token**: `POST /auth/refresh`
- **Confirm Email**: `GET /auth/confirmEmail`
- **Resend Confirmation Email**: `POST /auth/resendConfirmationEmail`
- **Forgot Password**: `POST /auth/forgotPassword`
- **Reset Password**: `POST /auth/resetPassword`
- **Manage 2FA**: `POST /auth/manage/2fa`
- **Get User Info**: `GET /auth/manage/info`
- **Update User Info**: `POST /auth/manage/info`
- **Logout**: `POST /auth/logout`

### Movie Management

- **Get Movies**: `GET /movie`
- **Add Movie**: `POST /movie`
- **Edit Movie**: `PUT /movie`
- **Get Movie by ID**: `GET /movie/{id}`
- **Delete Movie**: `DELETE /movie/{id}`

### Movie Theater Management

- **Get Theaters**: `GET /movie-theater`
- **Add Theater**: `POST /movie-theater`
- **Edit Theater**: `PUT /movie-theater`
- **Get Theater by ID**: `GET /movie-theater/{id}`
- **Delete Theater**: `DELETE /movie-theater/{id}`
- **Get Theater Details**: `GET /movie-theater/details/{id}`
- **Get Movies in Theater**: `GET /movie-theater/movies/{movieName}`

### Parking Details

- **Get Parking Details**: `GET /parking-detail`
- **Add Parking Detail**: `POST /parking-detail`
- **Edit Parking Detail**: `PUT /parking-detail`
- **Get Parking Detail by ID**: `GET /parking-detail/{id}`
- **Delete Parking Detail**: `DELETE /parking-detail/{id}`

### Ticket Management

- **Get Tickets**: `GET /ticket`
- **Add Ticket**: `POST /ticket`
- **Edit Ticket**: `PUT /ticket`
- **Get Ticket by ID**: `GET /ticket/{id}`
- **Delete Ticket**: `DELETE /ticket/{id}`

## API Documentation

The API is documented using OpenAPI 3.0.1. You can view the API documentation [here](http://localhost:5034/Swagger/index.html).

## Class Diagram

<div style="text-align: center;">
    <img src="Diagrama de Classe.png" alt="Logo" width="500"/>
</div>

## Learnings

The ASP.NET course provided me with valuable knowledge that enabled me to adopt new design patterns, leading to cleaner and more maintainable code.
