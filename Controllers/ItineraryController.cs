using AI_Tour_Planner_Backend.Models;
using AI_Tour_Planner_Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AI_Tour_Planner_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItineraryController : ControllerBase
{
    private readonly ItineraryPlannerService _plannerService;
    private readonly DestinationService _destinationService;

    public ItineraryController(ItineraryPlannerService plannerService, DestinationService destinationService)
    {
        _plannerService = plannerService;
        _destinationService = destinationService;
    }

    [HttpPost("plan")]
    public IActionResult Plan([FromBody] TripRequest request)
    {
        if (request.Budget <= 0)
            return BadRequest(new { error = "Budget must be greater than 0" });

        if (request.EndDate <= request.StartDate)
            return BadRequest(new { error = "End date must be after start date" });

        if (string.IsNullOrWhiteSpace(request.StartPlace))
            return BadRequest(new { error = "Start place is required" });

        if (!IsIndianCity(request.StartPlace))
            return Ok(new TripResponse
            {
                Success = false,
                Message = "Departure city must be in India. Please enter a valid Indian city.",
                Plans = new(),
                TripDuration = 0,
                Budget = request.Budget,
                TotalCount = 0,
                TotalPages = 0,
                CurrentPage = 1,
                PageSize = request.PageSize
            });

        var result = _plannerService.GeneratePlans(request);
        return Ok(result);
    }

    private static bool IsIndianCity(string startPlace)
    {
        var lower = startPlace.ToLower();
        var indianCities = new[]
        {
            "mumbai", "delhi", "bangalore", "bengaluru", "hyderabad", "chennai", "kolkata",
            "pune", "ahmedabad", "jaipur", "surat", "lucknow", "kanpur", "nagpur", "indore",
            "thane", "bhopal", "visakhapatnam", "vizag", "pimpri", "patna", "vadodara",
            "ghaziabad", "ludhiana", "agra", "nashik", "faridabad", "meerut", "rajkot",
            "varanasi", "srinagar", "aurangabad", "dhanbad", "amritsar", "allahabad",
            "prayagraj", "ranchi", "howrah", "coimbatore", "jabalpur", "gwalior", "vijayawada",
            "jodhpur", "madurai", "raipur", "kota", "chandigarh", "guwahati", "solapur",
            "hubli", "dharwad", "bareilly", "moradabad", "mysuru", "mysore", "gurgaon",
            "gurugram", "noida", "kochi", "cochin", "bhubaneswar", "dehradun", "thiruvananthapuram",
            "trivandrum", "mangalore", "mangaluru", "tiruchirappalli", "trichy", "tiruppur",
            "jalandhar", "bhopal", "udaipur", "shimla", "jammu", "pondicherry", "puducherry",
            "kolhapur", "navi mumbai"
        };
        return indianCities.Any(c => lower.Contains(c));
    }

    [HttpGet("destinations")]
    public IActionResult GetDestinations([FromQuery] string type = "both")
    {
        var destinations = _destinationService.GetByType(type, "");
        return Ok(destinations.Select(d => new {
            d.City, d.Country, d.CountryCode, d.IsDomestic,
            d.VisaType, d.Rating, d.ImageUrl,
            d.AvgDailyHotelCost, d.AvgDailyFoodCost, d.AvgDailyActivitiesCost,
            d.Description, d.BestTimeToVisit, d.Weather
        }));
    }
}
