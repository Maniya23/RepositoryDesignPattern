# Repository Design Pattern

A test project created to learn the architecture of Repository Design Patterns in C#.

## Overview

This ASP.NET Core Web API demonstrates key concepts of the Repository Design Pattern using a simple Weather Forecast service.

## Structure

- **Controllers** — API endpoints
- **Services** — Business logic with interfaces (`IWeatherForecastService`) and implementations (`WeatherForecastService`, `WeatherForecastServiceExtended`)

## Running the Project

```bash
dotnet run
```

The API runs at `http://localhost:5036`. Visit `http://localhost:5036/WeatherForecast` to test the endpoint.
