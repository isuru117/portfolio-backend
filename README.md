# Portfolio Backend API

This is the backend API for the React-based portfolio project available at [https://github.com/isuru117/portfolio/](https://github.com/isuru117/portfolio/). This ASP.NET Core project handles form submissions and sends emails using the configured SMTP service.

## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Environment Variables](#environment-variables)
- [Setup Instructions](#setup-instructions)


## Features

- Handles contact form submissions.
- Sends emails using Google Workspace SMTP.
- Logs email sending success and errors.

## Prerequisites

- .NET SDK 6.0 or later
- Visual Studio 2022 or later
- Node.js and npm (for the frontend)
- Google Workspace account for SMTP email sending

## Environment Variables

Create a `.env` file in the root of your project with the following environment variables:

```plaintext
EMAIL_HOST=smtp.gmail.com
EMAIL_PORT=587
EMAIL_USERNAME=your-google-workspace-email@example.com
EMAIL_PASSWORD=your-email-password
EMAIL_RECIPIENT=recipient-email@example.com
```

## Setup Instructions

### Clone the Repository
```
git clone https://github.com/isuru117/portfolio-backend.git
cd portfolio-backend
```

### Set Up the Environment Variables

Create a .env file in the root directory and add the environment variables as specified above.

### Open the Project in Visual Studio

- Open Visual Studio 2022.
- Select `File > Open > Project/Solution.`
- Navigate to the cloned repository folder and open the .sln file.
- Restore the NuGet Packages.



