namespace AI_Tour_Planner_Backend.Models;

public class TripRequest
{
    public double Budget { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string StartPlace { get; set; } = string.Empty;
    public string TripType { get; set; } = "both"; // "domestic", "international", "both"
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 9;
}

public class BudgetBreakdown
{
    public double Flights { get; set; }
    public double Accommodation { get; set; }
    public double Food { get; set; }
    public double Activities { get; set; }
    public double Miscellaneous { get; set; }
    public double Total => Flights + Accommodation + Food + Activities + Miscellaneous;
}

public class DayActivity
{
    public string Time { get; set; } = string.Empty;
    public string Activity { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double EstimatedCost { get; set; }
    public string Icon { get; set; } = string.Empty;
}

public class DayPlan
{
    public int Day { get; set; }
    public string Date { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public List<DayActivity> Activities { get; set; } = new();
    public double DailyBudget { get; set; }
}

public class ItineraryPlan
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Destination { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public bool IsDomestic { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> GalleryImages { get; set; } = new();
    public string VisaType { get; set; } = string.Empty;
    public string VisaInfo { get; set; } = string.Empty;
    public int Duration { get; set; }
    public double TotalCost { get; set; }
    public double SavingsFromBudget { get; set; }
    public BudgetBreakdown BudgetBreakdown { get; set; } = new();
    public List<string> Highlights { get; set; } = new();
    public List<string> TopAttractions { get; set; } = new();
    public List<DayPlan> DailyPlans { get; set; } = new();
    public string Weather { get; set; } = string.Empty;
    public string BestTimeToVisit { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string TravelTip { get; set; } = string.Empty;
    public string FlightDuration { get; set; } = string.Empty;
    public string RecommendedStay { get; set; } = string.Empty;
    public string CurrencySymbol { get; set; } = "$";
    public double ExchangeRateFromUSD { get; set; } = 1.0;
    public string ExchangeRateNote { get; set; } = "";
}

public class TripResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<ItineraryPlan> Plans { get; set; } = new();
    public int TripDuration { get; set; }
    public double Budget { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}

public class Destination
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public bool IsDomestic { get; set; }
    public string VisaType { get; set; } = string.Empty;
    public string VisaInfo { get; set; } = string.Empty;
    public double AvgDailyHotelCost { get; set; }
    public double AvgDailyFoodCost { get; set; }
    public double AvgDailyActivitiesCost { get; set; }
    public string FlightCostCategory { get; set; } = "medium"; // low, medium, high
    public string Description { get; set; } = string.Empty;
    public List<string> Highlights { get; set; } = new();
    public List<string> TopAttractions { get; set; } = new();
    public string Weather { get; set; } = string.Empty;
    public string BestTimeToVisit { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public double Rating { get; set; }
    public string TravelTip { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<string> GalleryImages { get; set; } = new();
    public string FlightDuration { get; set; } = string.Empty;
    public string RecommendedStay { get; set; } = string.Empty;
    public List<string> DayThemes { get; set; } = new();
    public List<List<DayActivity>> SampleActivities { get; set; } = new();
    public string CurrencySymbol { get; set; } = "$";
    public double ExchangeRateFromUSD { get; set; } = 1.0;
    public string ExchangeRateNote { get; set; } = "";
}
