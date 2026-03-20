# AI Tour Planner — Backend

A .NET 9 Web API that generates AI-curated international travel itineraries for Indian travellers, with server-side pagination and INR-based budget filtering.

## Tech Stack

- **Runtime:** .NET 9 (ASP.NET Core Web API)
- **Language:** C#
- **Docs:** Swagger / OpenAPI (Swashbuckle)
- **CORS:** Microsoft.AspNetCore.Cors

## Project Structure

```
AI-Tour-Planner-Backend/
├── Controllers/
│   └── ItineraryController.cs   # API endpoints
├── Models/
│   └── TripModels.cs            # Request/response models
├── Services/
│   ├── DestinationService.cs    # Destination data & filtering
│   └── ItineraryPlannerService.cs # Plan generation & INR conversion
└── Program.cs                   # App startup, CORS, Swagger
```

## API Endpoints

### `POST /api/itinerary/plan`

Generates paginated trip plans within the given INR budget.

**Request body:**
```json
{
  "startPlace": "Mumbai",
  "budget": 150000,
  "tripType": "international",
  "startDate": "2026-04-01T00:00:00",
  "endDate": "2026-04-08T00:00:00",
  "page": 1,
  "pageSize": 9
}
```

| Field | Type | Description |
|---|---|---|
| `startPlace` | string | Departure city — must be an Indian city |
| `budget` | number | Total budget in **INR** (min ₹10,000) |
| `tripType` | string | `"international"` or `"both"` (`"domestic"` returns empty) |
| `startDate` | ISO date | Departure date |
| `endDate` | ISO date | Return date |
| `page` | int | Page number (default: 1) |
| `pageSize` | int | Cards per page — clamped to 6–12 (default: 9) |

**Response:**
```json
{
  "success": true,
  "message": "Found 10 great itineraries within your ₹1,50,000 budget!",
  "plans": [ ... ],
  "tripDuration": 7,
  "budget": 150000,
  "totalCount": 10,
  "totalPages": 2,
  "currentPage": 1,
  "pageSize": 9
}
```

### `GET /api/itinerary/destinations?type=international`

Returns the raw destination list (no budget filtering, no pagination).

## Key Behaviour

- **India-centric:** Departure city is validated against a list of 60+ Indian cities. Non-Indian cities return an empty response.
- **INR budget:** The budget is received in INR. Internally, costs are calculated in USD (using a fixed rate of **1 USD = ₹83**) and all returned costs are converted back to INR.
- **Budget filter:** All destinations with a total cost ≤ the given INR budget are returned (up to 50 results), then paginated.
- **No caching:** Every request returns fresh data.
- **Destinations:** 12 pre-loaded international destinations (Bangkok, Bali, Dubai, Istanbul, Maldives, Sri Lanka, Tbilisi, Kuala Lumpur, Amman, Siem Reap, New York, Las Vegas).

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Run

```bash
cd AI-Tour-Planner-Backend
dotnet run
```

The API starts on `http://localhost:5011`.
Swagger UI is available at `http://localhost:5011/swagger`.

### Build

```bash
dotnet build
```

## Currency Conversion

All destination costs (flights, accommodation, food, activities, miscellaneous, and daily activity costs) are stored internally in USD and converted to INR at a fixed rate of **₹83 per USD** before being returned in the API response.

To change the rate, update `InrPerUsd` in `ItineraryPlannerService.cs`:

```csharp
private const double InrPerUsd = 83.0;
```
