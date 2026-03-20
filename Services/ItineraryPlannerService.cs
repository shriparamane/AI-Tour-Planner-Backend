using AI_Tour_Planner_Backend.Models;

namespace AI_Tour_Planner_Backend.Services;

public class ItineraryPlannerService
{
    private readonly DestinationService _destinationService;
    private const double InrPerUsd = 83.0;

    // Flight cost estimates based on category and distance (in USD)
    private readonly Dictionary<string, (double min, double max)> _flightCosts = new()
    {
        { "low", (150, 400) },
        { "medium", (500, 900) },
        { "high", (900, 1400) },
        { "very_high", (1400, 2000) }
    };

    public ItineraryPlannerService(DestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    public TripResponse GeneratePlans(TripRequest request)
    {
        var duration = (int)(request.EndDate - request.StartDate).TotalDays;
        if (duration < 1) duration = 1;

        var budgetInUsd = request.Budget / InrPerUsd; // request.Budget is in INR
        var destinations = _destinationService.GetByType(request.TripType, request.StartPlace);
        var affordablePlans = new List<ItineraryPlan>();

        foreach (var dest in destinations)
        {
            var plan = BuildPlan(dest, request, duration, budgetInUsd);
            if (plan != null)
                affordablePlans.Add(plan);
        }

        // Sort by: best value (high rating, low cost ratio), then rating
        affordablePlans = affordablePlans
            .OrderByDescending(p => p.Rating * (1 - (p.TotalCost / request.Budget) * 0.3))
            .ThenByDescending(p => p.Rating)
            .Take(50)
            .ToList();

        var totalCount = affordablePlans.Count;
        var pageSize = Math.Clamp(request.PageSize, 6, 12);
        var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        var page = Math.Clamp(request.Page, 1, Math.Max(1, totalPages));
        var pagedPlans = affordablePlans.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        return new TripResponse
        {
            Success = true,
            Message = totalCount > 0
                ? $"Found {totalCount} great itineraries within your ₹{request.Budget:N0} budget!"
                : "No destinations found within budget. Try increasing your budget or adjusting dates.",
            Plans = pagedPlans,
            TripDuration = duration,
            Budget = request.Budget,
            TotalCount = totalCount,
            TotalPages = totalPages,
            CurrentPage = page,
            PageSize = pageSize
        };
    }

    private ItineraryPlan? BuildPlan(Destination dest, TripRequest request, int duration, double budgetInUsd)
    {
        // Calculate flight cost in USD (round trip)
        var (flightMin, flightMax) = _flightCosts[dest.FlightCostCategory];
        var flightCost = (flightMin + flightMax) / 2;

        var accommodationCost = dest.AvgDailyHotelCost * duration;
        var foodCost = dest.AvgDailyFoodCost * duration;
        var activitiesCost = dest.AvgDailyActivitiesCost * duration;
        var miscCost = (flightCost + accommodationCost + foodCost + activitiesCost) * 0.08;

        var totalUsd = flightCost + accommodationCost + foodCost + activitiesCost + miscCost;

        if (totalUsd > budgetInUsd) return null;

        // Convert all costs to INR for the response
        var totalInr = Math.Round(totalUsd * InrPerUsd, 0);
        var breakdown = new BudgetBreakdown
        {
            Flights = Math.Round(flightCost * InrPerUsd, 0),
            Accommodation = Math.Round(accommodationCost * InrPerUsd, 0),
            Food = Math.Round(foodCost * InrPerUsd, 0),
            Activities = Math.Round(activitiesCost * InrPerUsd, 0),
            Miscellaneous = Math.Round(miscCost * InrPerUsd, 0)
        };

        var dailyPlans = GenerateDailyPlans(dest, request.StartDate, duration);

        return new ItineraryPlan
        {
            Destination = $"{dest.City}, {dest.Country}",
            Country = dest.Country,
            CountryCode = dest.CountryCode,
            IsDomestic = false, // All destinations are international from India
            Description = dest.Description,
            ImageUrl = dest.ImageUrl,
            GalleryImages = dest.GalleryImages,
            VisaType = dest.VisaType,
            VisaInfo = dest.VisaInfo,
            Duration = duration,
            TotalCost = totalInr,
            SavingsFromBudget = Math.Round(request.Budget - totalInr, 0),
            BudgetBreakdown = breakdown,
            Highlights = dest.Highlights,
            TopAttractions = dest.TopAttractions,
            DailyPlans = dailyPlans,
            Weather = dest.Weather,
            BestTimeToVisit = dest.BestTimeToVisit,
            Currency = dest.Currency,
            Language = dest.Language,
            Rating = dest.Rating,
            TravelTip = dest.TravelTip,
            FlightDuration = dest.FlightDuration,
            RecommendedStay = dest.RecommendedStay,
            CurrencySymbol = dest.CurrencySymbol,
            ExchangeRateFromUSD = dest.ExchangeRateFromUSD,
            ExchangeRateNote = dest.ExchangeRateNote
        };
    }

    private List<DayPlan> GenerateDailyPlans(Destination dest, DateTime startDate, int duration)
    {
        var plans = new List<DayPlan>();
        var themes = dest.DayThemes ?? new List<string>();
        var sampleActivities = dest.SampleActivities ?? new List<List<DayActivity>>();

        for (int day = 1; day <= duration; day++)
        {
            var date = startDate.AddDays(day - 1);
            var theme = day <= themes.Count ? themes[day - 1] : $"Day {day} Exploration";
            var activities = GetActivitiesForDay(day, duration, dest, sampleActivities, date);

            plans.Add(new DayPlan
            {
                Day = day,
                Date = date.ToString("yyyy-MM-dd"),
                Title = theme,
                Activities = activities,
                DailyBudget = activities.Sum(a => a.EstimatedCost)
            });
        }

        return plans;
    }

    private List<DayActivity> GetActivitiesForDay(int day, int totalDays, Destination dest, List<List<DayActivity>> sampleActivities, DateTime date)
    {
        List<DayActivity> activities;

        if (day == 1)
        {
            activities = new List<DayActivity>
            {
                new() { Time = "12:00", Activity = $"Fly to {dest.City}", Description = $"Depart from India and fly to {dest.City}. Check in at your hotel and freshen up.", EstimatedCost = 0, Icon = "flight" },
                new() { Time = "15:00", Activity = "Hotel Check-in & Orientation", Description = "Settle in, explore the neighborhood around your hotel.", EstimatedCost = dest.AvgDailyHotelCost, Icon = "hotel" },
                new() { Time = "19:00", Activity = "Welcome Dinner", Description = $"Try local cuisine at a nearby restaurant. Experience your first taste of {dest.Country}.", EstimatedCost = dest.AvgDailyFoodCost, Icon = "restaurant" }
            };
        }
        else if (day == totalDays)
        {
            activities = new List<DayActivity>
            {
                new() { Time = "09:00", Activity = "Final Morning Exploration", Description = $"Last chance to see {dest.City}. Visit any missed sights or pick up souvenirs.", EstimatedCost = 20, Icon = "explore" },
                new() { Time = "12:00", Activity = "Farewell Lunch", Description = $"Enjoy a final meal of local {dest.Country} cuisine.", EstimatedCost = dest.AvgDailyFoodCost, Icon = "restaurant" },
                new() { Time = "15:00", Activity = "Departure", Description = "Transfer to airport and fly back to India with amazing memories.", EstimatedCost = 0, Icon = "flight_land" }
            };
        }
        else
        {
            int activityIndex = (day - 2) % Math.Max(1, sampleActivities.Count);
            activities = activityIndex < sampleActivities.Count
                ? sampleActivities[activityIndex]
                : new List<DayActivity>
                {
                    new() { Time = "09:00", Activity = $"Morning at {dest.TopAttractions.FirstOrDefault() ?? dest.City}", Description = $"Explore one of {dest.City}'s top attractions.", EstimatedCost = dest.AvgDailyActivitiesCost * 0.4, Icon = "explore" },
                    new() { Time = "13:00", Activity = "Local Lunch", Description = "Enjoy authentic local cuisine at a popular restaurant.", EstimatedCost = dest.AvgDailyFoodCost * 0.4, Icon = "restaurant" },
                    new() { Time = "15:00", Activity = "Afternoon Exploration", Description = $"Discover more of {dest.City} at your own pace.", EstimatedCost = dest.AvgDailyActivitiesCost * 0.4, Icon = "directions_walk" },
                    new() { Time = "19:00", Activity = "Evening Dinner & Culture", Description = $"Experience the evening scene of {dest.City}.", EstimatedCost = dest.AvgDailyFoodCost * 0.6, Icon = "nightlife" }
                };
        }

        // Convert all activity costs from USD to INR
        foreach (var activity in activities)
            activity.EstimatedCost = Math.Round(activity.EstimatedCost * InrPerUsd, 0);

        return activities;
    }
}
