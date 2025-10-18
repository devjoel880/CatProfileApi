# 🐱 CatProfile API — Stage 0 Task

Welcome to my submission for Stage 0! This is a simple .NET Core Web API that returns my profile info and a dynamic cat fact from the Cat Facts API.

## 🚀 Endpoint

**GET /me**

Returns:
```json
{
  "status": "success",
  "user": {
    "email": "your.email@example.com",
    "name": "Your Full Name",
    "stack": ".NET Core/Web API"
  },
  "timestamp": "2025-10-17T12:34:56.789Z",
  "fact": "Cats sleep for 70% of their lives."
}
```

## 🛠️ Tech Stack

ASP.NET Core Web API

C#

HttpClientFactory

Visual Studio 2022

## 🧪 How to Run Locally

Clone the repo:

```bash
git clone https://github.com/yourusername/CatProfileApi.git
cd CatProfileApi
```

Open in Visual Studio 2022

Run the project (F5 or Ctrl+F5)

Navigate to:

```Code
https://localhost:<port>/me
```

## 📦 Dependencies

Microsoft.AspNetCore.App

System.Net.Http

Newtonsoft.Json (optional)

## 🌐 External API

```link
https://catfact.ninja/fact
```

## 🧠 What I Learned

Consuming third-party APIs with HttpClientFactory

Structuring JSON responses

Handling API failures gracefully

Logging and debugging in .NET Core

