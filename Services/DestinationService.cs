using AI_Tour_Planner_Backend.Models;

namespace AI_Tour_Planner_Backend.Services;

public class DestinationService
{
    private readonly List<Destination> _destinations;

    public DestinationService()
    {
        _destinations = InitializeDestinations();
    }

    public List<Destination> GetAll() => _destinations;

    // App is India-centric — all destinations are international from India.
    // No domestic Indian destinations exist in the DB, so "domestic" returns nothing.
    public List<Destination> GetByType(string tripType, string startPlace) =>
        tripType.ToLower() == "domestic"
            ? new List<Destination>()
            : _destinations.ToList();

    private List<Destination> InitializeDestinations() => new()
    {
        new Destination
        {
            City = "Bangkok", Country = "Thailand", CountryCode = "TH",
            VisaType = "Visa on Arrival", VisaInfo = "30-day visa on arrival for most nationalities. Available at airports.",
            AvgDailyHotelCost = 45, AvgDailyFoodCost = 25, AvgDailyActivitiesCost = 30,
            FlightCostCategory = "medium",
            Description = "Bangkok is a vibrant city of contrasts with ancient temples, bustling street markets, and modern skyscrapers. Experience world-class street food, ornate shrines, and a thrilling nightlife.",
            Highlights = new() { "Grand Palace", "Street Food Paradise", "Night Markets", "Temples", "Spa & Wellness" },
            TopAttractions = new() { "Grand Palace & Wat Phra Kaew", "Wat Arun Temple", "Chatuchak Weekend Market", "Khao San Road", "Chao Phraya River Cruise" },
            Weather = "Tropical — hot and humid year-round (28–35°C)", BestTimeToVisit = "November to February",
            Currency = "Thai Baht (THB)", Language = "Thai",
            Rating = 4.7, TravelTip = "Use the BTS Skytrain to avoid traffic. Try the local street food — it's delicious and cheap!",
            FlightDuration = "~9-17 hrs from US, ~6 hrs from Europe", RecommendedStay = "4–7 days",
            ImageUrl = "https://images.unsplash.com/photo-1563492065599-3520f775eeed?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1508009603885-50cf7c579365?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1555921015-5532091f6026?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1528360983277-13d401cdc186?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Arrival & Temple Exploration", "Markets & Street Food", "Day Trip to Ayutthaya", "Riverside & Nightlife", "Shopping & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="09:00", Activity="Grand Palace & Wat Phra Kaew", Description="Explore the stunning Grand Palace complex and Thailand's most sacred temple", EstimatedCost=20, Icon="temple_buddhist" },
                    new DayActivity { Time="13:00", Activity="Street Food Lunch on Yaowarat", Description="Sample authentic Thai dishes at Chinatown's famous street stalls", EstimatedCost=8, Icon="restaurant" },
                    new DayActivity { Time="15:00", Activity="Wat Pho — Reclining Buddha", Description="See the massive 46m gold reclining Buddha and get a traditional Thai massage", EstimatedCost=15, Icon="spa" },
                    new DayActivity { Time="19:00", Activity="Chao Phraya River Night Cruise", Description="Enjoy Bangkok's sparkling skyline from the river", EstimatedCost=25, Icon="directions_boat" }
                },
                new() {
                    new DayActivity { Time="08:00", Activity="Damnoen Saduak Floating Market", Description="Shop and eat at one of Thailand's most famous floating markets", EstimatedCost=30, Icon="store" },
                    new DayActivity { Time="14:00", Activity="Chatuchak Weekend Market", Description="Browse thousands of stalls at Southeast Asia's largest market", EstimatedCost=20, Icon="shopping_bag" },
                    new DayActivity { Time="18:00", Activity="Rooftop Bar at Lebua", Description="Enjoy cocktails at one of Bangkok's iconic sky bars", EstimatedCost=40, Icon="local_bar" }
                }
            }
        },
        new Destination
        {
            City = "Bali", Country = "Indonesia", CountryCode = "ID",
            VisaType = "Visa on Arrival", VisaInfo = "30-day VOA available for most nationalities at Ngurah Rai Airport. Extendable once.",
            AvgDailyHotelCost = 50, AvgDailyFoodCost = 20, AvgDailyActivitiesCost = 35,
            FlightCostCategory = "medium",
            Description = "Bali is a tropical paradise with emerald rice terraces, sacred temples, world-class surf, and a rich spiritual culture. Perfect for relaxation, adventure, and cultural immersion.",
            Highlights = new() { "Rice Terraces", "Hindu Temples", "Surfing", "Spa Retreats", "Sunset Views" },
            TopAttractions = new() { "Tanah Lot Temple", "Tegallalang Rice Terraces", "Seminyak Beach", "Ubud Monkey Forest", "Mount Batur Sunrise Trek" },
            Weather = "Tropical — dry season May–October, wet season Nov–April", BestTimeToVisit = "May to September",
            Currency = "Indonesian Rupiah (IDR)", Language = "Balinese/Indonesian",
            Rating = 4.8, TravelTip = "Rent a scooter for cheap and flexible transport. Respect temple dress codes — carry a sarong.",
            FlightDuration = "~17-22 hrs from US, ~13 hrs from Europe", RecommendedStay = "5–10 days",
            ImageUrl = "https://images.unsplash.com/photo-1537996194471-e657df975ab4?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1555400038-63f5ba517a47?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1518548419970-58e3b4079ab2?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1604999565976-8913ad2ddb7c?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Arrival & Beach Time", "Ubud Culture & Temples", "Rice Terraces & Cooking Class", "Adventure Day", "Spa & Sunset Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="10:00", Activity="Tanah Lot Sea Temple", Description="Visit Bali's iconic sea temple perched on a rocky outcrop", EstimatedCost=15, Icon="temple_buddhist" },
                    new DayActivity { Time="13:00", Activity="Seminyak Beach & Lunch", Description="Relax on the famous beach and enjoy a beachfront meal", EstimatedCost=20, Icon="beach_access" },
                    new DayActivity { Time="17:00", Activity="Sunset at Uluwatu Temple", Description="Watch the legendary Kecak fire dance at sunset", EstimatedCost=20, Icon="local_fire_department" }
                },
                new() {
                    new DayActivity { Time="08:00", Activity="Tegallalang Rice Terraces", Description="Walk among spectacular emerald terraced rice paddies", EstimatedCost=5, Icon="landscape" },
                    new DayActivity { Time="11:00", Activity="Ubud Art Market", Description="Browse local handicrafts, paintings, and souvenirs", EstimatedCost=15, Icon="palette" },
                    new DayActivity { Time="14:00", Activity="Balinese Cooking Class", Description="Learn to cook authentic Balinese dishes from a local chef", EstimatedCost=35, Icon="restaurant" }
                }
            }
        },
        new Destination
        {
            City = "Dubai", Country = "United Arab Emirates", CountryCode = "AE",
            VisaType = "Visa on Arrival", VisaInfo = "Free 30-day visa on arrival for 50+ nationalities including US, EU, UK, Australia.",
            AvgDailyHotelCost = 120, AvgDailyFoodCost = 50, AvgDailyActivitiesCost = 80,
            FlightCostCategory = "medium",
            Description = "Dubai is a city of superlatives — tallest buildings, largest malls, and most ambitious engineering. Experience luxury shopping, desert adventures, and ultramodern architecture.",
            Highlights = new() { "Burj Khalifa", "Desert Safari", "Luxury Shopping", "Gold Souk", "Palm Jumeirah" },
            TopAttractions = new() { "Burj Khalifa & Dubai Fountain", "Palm Jumeirah", "Dubai Mall", "Desert Safari", "Gold & Spice Souks" },
            Weather = "Desert — very hot summers (40°C+), mild winters (20–25°C)", BestTimeToVisit = "November to March",
            Currency = "UAE Dirham (AED)", Language = "Arabic (English widely spoken)",
            Rating = 4.6, TravelTip = "Visit October–April to avoid extreme heat. Book desert safari in advance. Dubai Metro is clean and cheap.",
            FlightDuration = "~13-14 hrs from US, ~6-7 hrs from Europe", RecommendedStay = "3–5 days",
            ImageUrl = "https://images.unsplash.com/photo-1512453979798-5ea266f8880c?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1597949031490-5f15f22d7f2a?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1582672060674-bc2bd808a8b5?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1548813831-2c27c31ba9b3?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Modern Dubai Highlights", "Desert Adventure", "Shopping & Gold Souk", "Waterfront & JBR", "Burj Khalifa & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="10:00", Activity="Burj Khalifa 'At the Top'", Description="Visit the observation deck of the world's tallest building", EstimatedCost=40, Icon="apartment" },
                    new DayActivity { Time="14:00", Activity="Dubai Mall & Aquarium", Description="Explore the massive mall and see the giant underwater zoo", EstimatedCost=35, Icon="shopping_cart" },
                    new DayActivity { Time="18:00", Activity="Dubai Fountain Show", Description="Watch the world's largest choreographed fountain show", EstimatedCost=0, Icon="water" }
                },
                new() {
                    new DayActivity { Time="15:00", Activity="Desert Safari", Description="Dune bashing, camel riding, and Bedouin camp dinner under the stars", EstimatedCost=75, Icon="terrain" }
                }
            }
        },
        new Destination
        {
            City = "Istanbul", Country = "Turkey", CountryCode = "TR",
            VisaType = "e-Visa", VisaInfo = "Easy online e-Visa available in minutes at evisa.gov.tr. Valid for 90 days.",
            AvgDailyHotelCost = 60, AvgDailyFoodCost = 25, AvgDailyActivitiesCost = 30,
            FlightCostCategory = "medium",
            Description = "Istanbul straddles two continents, blending Ottoman grandeur with Byzantine history and modern Turkish culture. Bazaars, mosques, Bosphorus cruises, and incredible food await.",
            Highlights = new() { "Hagia Sophia", "Grand Bazaar", "Bosphorus Cruise", "Turkish Cuisine", "Topkapi Palace" },
            TopAttractions = new() { "Hagia Sophia", "Blue Mosque", "Topkapi Palace", "Grand Bazaar", "Bosphorus Cruise" },
            Weather = "Mediterranean — hot dry summers, mild wet winters", BestTimeToVisit = "April to June, September to November",
            Currency = "Turkish Lira (TRY)", Language = "Turkish",
            Rating = 4.7, TravelTip = "Get an Istanbul Card for cheap public transport. Turkish tea is free everywhere — embrace it!",
            FlightDuration = "~10-11 hrs from US East Coast, ~3-4 hrs from Europe", RecommendedStay = "3–6 days",
            ImageUrl = "https://images.unsplash.com/photo-1524231757912-21f4fe3a7200?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1541432901042-2d8bd64b4a9b?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1527838832700-5059252407fa?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1600865706059-64d0e27ffed4?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Historic Peninsula", "Palaces & Bazaars", "Bosphorus & Asian Side", "Off-the-Beaten-Path", "Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="09:00", Activity="Hagia Sophia", Description="Marvel at this architectural wonder that served as church and mosque", EstimatedCost=15, Icon="account_balance" },
                    new DayActivity { Time="11:00", Activity="Blue Mosque", Description="Visit the iconic six-minareted mosque free of charge", EstimatedCost=0, Icon="mosque" },
                    new DayActivity { Time="13:00", Activity="Turkish Lunch at Sultanahmet", Description="Enjoy a traditional Turkish meal with fresh bread and meze", EstimatedCost=12, Icon="restaurant" },
                    new DayActivity { Time="15:00", Activity="Grand Bazaar", Description="Shop at one of the world's oldest and largest covered markets", EstimatedCost=20, Icon="store" },
                    new DayActivity { Time="19:00", Activity="Bosphorus Sunset Cruise", Description="See Istanbul's stunning skyline from the water", EstimatedCost=20, Icon="directions_boat" }
                }
            }
        },
        new Destination
        {
            City = "Maldives", Country = "Maldives", CountryCode = "MV",
            VisaType = "Visa on Arrival", VisaInfo = "Free 30-day visa on arrival for all nationalities. Just book your accommodation.",
            AvgDailyHotelCost = 150, AvgDailyFoodCost = 60, AvgDailyActivitiesCost = 80,
            FlightCostCategory = "high",
            Description = "The Maldives offers the ultimate tropical escape: crystal-clear turquoise lagoons, pristine white-sand beaches, and luxurious overwater bungalows. A paradise for divers and romance seekers.",
            Highlights = new() { "Overwater Bungalows", "Snorkeling", "Coral Reefs", "Crystal Lagoons", "Whale Sharks" },
            TopAttractions = new() { "North Male Atoll", "Banana Reef Snorkeling", "Maafushi Island", "Whale Shark Diving", "Sandbank Picnic" },
            Weather = "Tropical — warm year-round (28–30°C), dry season Dec–April", BestTimeToVisit = "November to April",
            Currency = "Maldivian Rufiyaa (MVR) / USD accepted", Language = "Dhivehi (English widely spoken)",
            Rating = 4.9, TravelTip = "Stay on local islands like Maafushi to save money while still enjoying beach luxury. Book speedboat transfers in advance.",
            FlightDuration = "~20+ hrs from US, ~8-10 hrs from Europe", RecommendedStay = "4–7 days",
            ImageUrl = "https://images.unsplash.com/photo-1514282401047-d79a71a590e8?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1573843981267-be1999ff37cd?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1540202404-a2f29016b523?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Arrival & Beach Bliss", "Snorkeling Adventure", "Island Hopping", "Dive or Relax", "Final Sunrise & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="09:00", Activity="House Reef Snorkeling", Description="Explore the vibrant coral reef right off the beach", EstimatedCost=20, Icon="scuba_diving" },
                    new DayActivity { Time="14:00", Activity="Sandbank Excursion", Description="Visit a deserted sandbank in the middle of the turquoise ocean", EstimatedCost=40, Icon="beach_access" },
                    new DayActivity { Time="17:00", Activity="Sunset Dolphin Cruise", Description="Watch hundreds of spinner dolphins play in the waves at sunset", EstimatedCost=35, Icon="water" }
                }
            }
        },
        new Destination
        {
            City = "Sri Lanka", Country = "Sri Lanka", CountryCode = "LK",
            VisaType = "e-Visa", VisaInfo = "Easy online e-Visa at eta.gov.lk. Approved within 24 hours. 30-day stay.",
            AvgDailyHotelCost = 40, AvgDailyFoodCost = 20, AvgDailyActivitiesCost = 25,
            FlightCostCategory = "medium",
            Description = "Sri Lanka packs an incredible variety into a small island — ancient temples, wildlife safaris, tea plantations, and stunning beaches. Often called the teardrop of India.",
            Highlights = new() { "Sigiriya Rock", "Elephant Safari", "Tea Country", "Ancient Ruins", "Beach Paradise" },
            TopAttractions = new() { "Sigiriya Lion Rock", "Dambulla Cave Temple", "Yala National Park Safari", "Nuwara Eliya Tea Estates", "Galle Fort" },
            Weather = "Tropical — varies by region. West coast dry Dec–March, East coast dry May–Sep", BestTimeToVisit = "December to March (west/south)",
            Currency = "Sri Lankan Rupee (LKR)", Language = "Sinhala/Tamil (English widely spoken)",
            Rating = 4.6, TravelTip = "Train rides through the tea country are among the most scenic in the world. Book seats in advance.",
            FlightDuration = "~18 hrs from US, ~10 hrs from Europe", RecommendedStay = "7–14 days",
            ImageUrl = "https://images.unsplash.com/photo-1562602833-0f4ab2fc46e5?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1516690561799-46d8f74f9abf?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1578662996442-48f60103fc96?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1595950653106-6c9ebd614d3a?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Colombo Arrival", "Sigiriya & Dambulla", "Kandy & Temple of Tooth", "Tea Country Train", "Safari & Beach" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="06:00", Activity="Sigiriya Rock Fortress", Description="Climb the ancient 5th-century rock fortress for panoramic views", EstimatedCost=30, Icon="terrain" },
                    new DayActivity { Time="13:00", Activity="Dambulla Cave Temple", Description="Explore Sri Lanka's largest cave temple complex with golden Buddhas", EstimatedCost=10, Icon="temple_buddhist" },
                    new DayActivity { Time="18:00", Activity="Village Dinner Experience", Description="Home-cooked Sri Lankan rice and curry with a local family", EstimatedCost=15, Icon="restaurant" }
                }
            }
        },
        new Destination
        {
            City = "Tbilisi", Country = "Georgia", CountryCode = "GE",
            VisaType = "Visa Free", VisaInfo = "Visa-free for 90+ nationalities for stays up to 1 year. No visa required at all.",
            AvgDailyHotelCost = 35, AvgDailyFoodCost = 15, AvgDailyActivitiesCost = 20,
            FlightCostCategory = "low",
            Description = "Tbilisi is a hidden gem where medieval churches meet colorful balconied houses, excellent wine, and the famously warm Georgian hospitality. Europe's best value destination.",
            Highlights = new() { "Old Town", "Georgian Wine", "Caucasus Mountains", "Sulphur Baths", "Ancient Churches" },
            TopAttractions = new() { "Old Tbilisi", "Narikala Fortress", "Mtskheta Ancient Capital", "Georgian Wine Tour", "Abanotubani Sulfur Baths" },
            Weather = "Continental — hot summers (30°C), cold snowy winters (-2°C)", BestTimeToVisit = "May to October",
            Currency = "Georgian Lari (GEL)", Language = "Georgian (English in tourist areas)",
            Rating = 4.5, TravelTip = "Georgia is famous for its wine — try the amber wine made in clay pots (qvevri). Food portions are enormous!",
            FlightDuration = "~12-14 hrs from US, ~3-5 hrs from Europe", RecommendedStay = "4–7 days",
            ImageUrl = "https://images.unsplash.com/photo-1565008576549-57569a49371d?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1596484552834-6a58f850e0a1?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1565344939594-4e58c3b4e0b0?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Old Town Wander", "Wine & Cuisine Day", "Mountain Excursion", "Monasteries & History", "Final Exploration" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="10:00", Activity="Old Tbilisi Walking Tour", Description="Wander through colorful houses, carved balconies, and cobblestone streets", EstimatedCost=0, Icon="directions_walk" },
                    new DayActivity { Time="13:00", Activity="Georgian Feast at Shavi Lomi", Description="Experience a traditional supra with khinkali, khachapuri, and wine", EstimatedCost=20, Icon="restaurant" },
                    new DayActivity { Time="15:00", Activity="Narikala Fortress & Cable Car", Description="Take the cable car up to the ancient fortress overlooking the city", EstimatedCost=5, Icon="terrain" },
                    new DayActivity { Time="17:00", Activity="Abanotubani Sulfur Baths", Description="Relax in Tbilisi's famous natural sulfur bath houses", EstimatedCost=15, Icon="hot_tub" }
                }
            }
        },
        new Destination
        {
            City = "Kuala Lumpur", Country = "Malaysia", CountryCode = "MY",
            VisaType = "Visa Free / e-Visa", VisaInfo = "Visa-free for 160+ nationalities for 30–90 days. e-NTL visa available online.",
            AvgDailyHotelCost = 45, AvgDailyFoodCost = 20, AvgDailyActivitiesCost = 25,
            FlightCostCategory = "medium",
            Description = "Kuala Lumpur is a dynamic melting pot of Malay, Chinese, and Indian cultures under the iconic Petronas Twin Towers. Incredible food, street markets, and modern attractions at bargain prices.",
            Highlights = new() { "Petronas Towers", "Street Food", "Batu Caves", "Night Markets", "Cultural Heritage" },
            TopAttractions = new() { "Petronas Twin Towers", "Batu Caves", "Jalan Alor Night Food Street", "KL Bird Park", "Central Market" },
            Weather = "Tropical — hot and humid year-round, afternoon showers common", BestTimeToVisit = "May to July, December to February",
            Currency = "Malaysian Ringgit (MYR)", Language = "Malay (English widely spoken)",
            Rating = 4.5, TravelTip = "KL is one of Asia's most affordable cities. The KLIA Ekspres train is the fastest way from the airport.",
            FlightDuration = "~18-20 hrs from US, ~12 hrs from Europe", RecommendedStay = "3–5 days",
            ImageUrl = "https://images.unsplash.com/photo-1596422846543-75c6fc197f07?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1567784177951-6fa58317e16b?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1587479831120-eb25e4e55ee0?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1533394685928-4fb7b349e6ef?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "City Icons", "Cultural Trail", "Food Paradise", "Nature & Relaxation", "Shopping & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="09:00", Activity="Petronas Twin Towers", Description="Visit the iconic towers and Sky Bridge with city panoramas", EstimatedCost=25, Icon="apartment" },
                    new DayActivity { Time="13:00", Activity="Jalan Alor Food Street", Description="Sample satay, hawker food, and fresh juices at this famous food street", EstimatedCost=12, Icon="restaurant" },
                    new DayActivity { Time="16:00", Activity="Batu Caves", Description="Climb 272 steps to the stunning Hindu cave temple", EstimatedCost=0, Icon="temple_hindu" },
                    new DayActivity { Time="20:00", Activity="KL Night Market", Description="Browse local goods and snack on street food at Pasar Malam", EstimatedCost=10, Icon="store" }
                }
            }
        },
        new Destination
        {
            City = "Amman", Country = "Jordan", CountryCode = "JO",
            VisaType = "Visa on Arrival", VisaInfo = "Visa on arrival available for most nationalities at Queen Alia Airport. Jordan Pass covers visa + entry to Petra.",
            AvgDailyHotelCost = 55, AvgDailyFoodCost = 25, AvgDailyActivitiesCost = 40,
            FlightCostCategory = "medium",
            Description = "Jordan is home to the lost city of Petra, the lunar landscape of Wadi Rum, and the buoyant Dead Sea. Ancient history, Bedouin hospitality, and dramatic desert scenery.",
            Highlights = new() { "Petra", "Wadi Rum", "Dead Sea Float", "Jerash Ruins", "Bedouin Culture" },
            TopAttractions = new() { "Petra Treasury", "Wadi Rum Desert", "Dead Sea", "Jerash Roman Ruins", "Aqaba Red Sea" },
            Weather = "Desert/Mediterranean — hot dry summers, cool winters. Petra can be cold.", BestTimeToVisit = "March to May, September to November",
            Currency = "Jordanian Dinar (JOD)", Language = "Arabic (English in tourist areas)",
            Rating = 4.7, TravelTip = "Buy the Jordan Pass before you arrive — it covers visa fees and entry to 40+ sites including Petra.",
            FlightDuration = "~11-12 hrs from US, ~4-5 hrs from Europe", RecommendedStay = "4–7 days",
            ImageUrl = "https://images.unsplash.com/photo-1539437829697-1b4ed67c0db9?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1548786811-dd6e453ccca7?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1526392060635-9d6019884377?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1580834341580-8c17a3a630ca?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Amman City", "Petra Full Day", "Wadi Rum Desert", "Dead Sea Float", "Jerash & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="07:00", Activity="Petra — The Treasury", Description="Enter through the Siq canyon to reveal the iconic rose-red Treasury façade", EstimatedCost=60, Icon="account_balance" },
                    new DayActivity { Time="13:00", Activity="Petra Monastery Hike", Description="Climb 800 steps to the massive Ad Deir Monastery with panoramic views", EstimatedCost=0, Icon="hiking" },
                    new DayActivity { Time="20:00", Activity="Petra by Night", Description="Walk through the candlelit Siq under a sky of stars", EstimatedCost=25, Icon="nights_stay" }
                }
            }
        },
        new Destination
        {
            City = "Siem Reap", Country = "Cambodia", CountryCode = "KH",
            VisaType = "e-Visa", VisaInfo = "Easy online e-Visa at evisa.gov.kh. Approved in 3 business days. $36 fee.",
            AvgDailyHotelCost = 30, AvgDailyFoodCost = 15, AvgDailyActivitiesCost = 25,
            FlightCostCategory = "medium",
            Description = "Siem Reap is the gateway to Angkor Wat, the world's largest religious monument. Explore ancient temple ruins, float villages, and vibrant nightlife on Pub Street.",
            Highlights = new() { "Angkor Wat", "Sunrise at Temples", "Floating Villages", "Pub Street", "Ancient Ruins" },
            TopAttractions = new() { "Angkor Wat Sunrise", "Ta Prohm Temple", "Bayon Temple", "Tonle Sap Lake", "Pub Street Night Market" },
            Weather = "Tropical monsoon — dry season Nov–April, rainy May–Oct", BestTimeToVisit = "November to March",
            Currency = "Cambodian Riel / USD accepted", Language = "Khmer (English in tourist areas)",
            Rating = 4.7, TravelTip = "Wake up early for Angkor Wat sunrise — it's magical. A 3-day temple pass gives the best value.",
            FlightDuration = "~18-22 hrs from US, ~11-13 hrs from Europe", RecommendedStay = "3–5 days",
            ImageUrl = "https://images.unsplash.com/photo-1572375992501-4b0892d50c69?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1508009603885-50cf7c579365?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1591017403286-fd8493524e1e?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1540189549336-e6e99c3679fe?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Angkor Wat Sunrise", "Jungle Temples", "Floating Village", "Local Culture", "Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="05:00", Activity="Angkor Wat Sunrise", Description="Watch the sun rise behind the world's largest religious monument", EstimatedCost=37, Icon="wb_sunny" },
                    new DayActivity { Time="09:00", Activity="Ta Prohm Temple", Description="Explore jungle-covered ruins made famous by Tomb Raider", EstimatedCost=0, Icon="forest" },
                    new DayActivity { Time="14:00", Activity="Bayon Temple", Description="Marvel at 216 giant stone faces of the Bayon temple", EstimatedCost=0, Icon="account_balance" },
                    new DayActivity { Time="19:00", Activity="Pub Street Dinner", Description="Enjoy local Khmer food and cocktails on the lively Pub Street", EstimatedCost=15, Icon="restaurant" }
                }
            }
        },
        new Destination
        {
            City = "New York", Country = "United States", CountryCode = "US",
            IsDomestic = true,
            VisaType = "No Visa (Domestic)", VisaInfo = "No visa required for US citizens. Easy domestic travel.",
            AvgDailyHotelCost = 180, AvgDailyFoodCost = 80, AvgDailyActivitiesCost = 100,
            FlightCostCategory = "low",
            Description = "New York City is the ultimate urban adventure — world-class museums, iconic skyline, diverse neighborhoods, Broadway shows, and the best food scene in the US.",
            Highlights = new() { "Times Square", "Central Park", "World-Class Museums", "Broadway", "Diverse Food" },
            TopAttractions = new() { "Statue of Liberty", "Central Park", "Metropolitan Museum", "Times Square", "Brooklyn Bridge" },
            Weather = "Four seasons — hot humid summers, cold snowy winters, beautiful springs and falls", BestTimeToVisit = "April to June, September to November",
            Currency = "US Dollar (USD)", Language = "English",
            Rating = 4.7, TravelTip = "Get a 7-day MetroCard for unlimited subway rides. Many museums have free or pay-what-you-wish days.",
            FlightDuration = "Domestic — 1-6 hrs depending on city", RecommendedStay = "3–5 days",
            ImageUrl = "https://images.unsplash.com/photo-1496442226666-8d4d0e62e6e9?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1534430480872-3498386e7856?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1522083165195-3424ed129620?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1485871981521-5b1fd3805eee?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Manhattan Iconic", "Culture & Museums", "Brooklyn & Boroughs", "Shopping & Shows", "Final Explore" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="09:00", Activity="Statue of Liberty & Ellis Island", Description="Ferry to the iconic symbol of freedom and explore immigration history", EstimatedCost=25, Icon="account_balance" },
                    new DayActivity { Time="14:00", Activity="Central Park Exploration", Description="Rent a bike and explore 843 acres of urban green space", EstimatedCost=15, Icon="park" },
                    new DayActivity { Time="17:00", Activity="Times Square at Dusk", Description="Experience the electric atmosphere of the 'Crossroads of the World'", EstimatedCost=0, Icon="local_activity" },
                    new DayActivity { Time="20:00", Activity="Broadway Show", Description="Catch a world-class Broadway performance in the Theater District", EstimatedCost=120, Icon="theater_comedy" }
                }
            }
        },
        new Destination
        {
            City = "Las Vegas", Country = "United States", CountryCode = "US",
            IsDomestic = true,
            VisaType = "No Visa (Domestic)", VisaInfo = "No visa required for US citizens. Direct flights from most US cities.",
            AvgDailyHotelCost = 100, AvgDailyFoodCost = 60, AvgDailyActivitiesCost = 150,
            FlightCostCategory = "low",
            Description = "Las Vegas is the ultimate entertainment city — dazzling casinos, world-class shows, celebrity chef restaurants, and easy day trips to the Grand Canyon and Red Rock Canyon.",
            Highlights = new() { "The Strip", "Grand Canyon Day Trip", "World-Class Shows", "Casino Experience", "Amazing Food" },
            TopAttractions = new() { "Las Vegas Strip", "Fremont Street Experience", "Grand Canyon Day Trip", "Red Rock Canyon", "Bellagio Fountains" },
            Weather = "Desert — scorching summers (40°C+), mild winters (10–18°C)", BestTimeToVisit = "March to May, September to November",
            Currency = "US Dollar (USD)", Language = "English",
            Rating = 4.5, TravelTip = "Walk the Strip to see free attractions like Bellagio fountains. Buffets offer great value. Book Grand Canyon tours early.",
            FlightDuration = "Domestic — 1-5 hrs depending on city", RecommendedStay = "2–4 days",
            ImageUrl = "https://images.unsplash.com/photo-1581351721010-8cf859cb14a4?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1605833556294-ea5c7a74f57d?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1617220038770-b6be0c785d49?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1574375927938-d5a98e8ffe85?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Strip Arrival & Casinos", "Grand Canyon Adventure", "Shows & Entertainment", "Red Rock & Relaxation" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="10:00", Activity="Las Vegas Strip Walk", Description="Walk past iconic casinos — Bellagio, Caesars, MGM Grand", EstimatedCost=0, Icon="directions_walk" },
                    new DayActivity { Time="14:00", Activity="High Roller Observation Wheel", Description="Get a bird's eye view of Vegas from the world's tallest observation wheel", EstimatedCost=30, Icon="panorama" },
                    new DayActivity { Time="18:00", Activity="Bellagio Fountain Show", Description="Watch the free world-famous water and light show", EstimatedCost=0, Icon="water" },
                    new DayActivity { Time="21:00", Activity="Vegas Show or Concert", Description="Catch a spectacular show from Cirque du Soleil or a headliner", EstimatedCost=100, Icon="theater_comedy" }
                }
            }
        },
        new Destination
        {
            City = "Cancun", Country = "Mexico", CountryCode = "MX",
            VisaType = "Visa Free", VisaInfo = "US, EU, UK, Canadian citizens do not need a visa. Just fill out a tourist card (FMM) on arrival.",
            AvgDailyHotelCost = 90, AvgDailyFoodCost = 35, AvgDailyActivitiesCost = 60,
            FlightCostCategory = "low",
            Description = "Cancun offers powder-white beaches, turquoise Caribbean waters, ancient Mayan ruins, and vibrant nightlife. Easy to reach from the US with direct flights.",
            Highlights = new() { "Caribbean Beaches", "Chichen Itza", "Cenotes", "Snorkeling", "Mayan Culture" },
            TopAttractions = new() { "Chichen Itza", "Tulum Ruins", "Xcaret Park", "Cenote Swimming", "Isla Mujeres" },
            Weather = "Tropical — warm year-round (26–32°C). Hurricane season June–November", BestTimeToVisit = "December to April",
            Currency = "Mexican Peso (MXN) / USD widely accepted", Language = "Spanish (English in tourist zones)",
            Rating = 4.6, TravelTip = "Rent a car or take ADO buses to explore Mayan ruins. Hotel Zone restaurants are pricey — eat in downtown Cancun.",
            FlightDuration = "~2-4 hrs from US, ~10-11 hrs from Europe", RecommendedStay = "5–7 days",
            ImageUrl = "https://images.unsplash.com/photo-1552074284-5e88ef1aef18?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1518638150340-f706e86654de?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1519451241324-20b4ea2c4220?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1547638375-ebdc6f14ec7b?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Beach Arrival", "Chichen Itza Day Trip", "Cenote Adventures", "Tulum & Ruins", "Water Sports & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="08:00", Activity="Chichen Itza Day Trip", Description="Visit the magnificent Mayan pyramid, one of the New Seven Wonders of the World", EstimatedCost=80, Icon="account_balance" },
                    new DayActivity { Time="14:00", Activity="Cenote Swim", Description="Swim in ancient underground freshwater sinkholes (cenotes)", EstimatedCost=15, Icon="pool" },
                    new DayActivity { Time="19:00", Activity="Sunset Dinner at Beach Club", Description="Fresh ceviche and cocktails with views of the Caribbean", EstimatedCost=40, Icon="restaurant" }
                }
            }
        },
        new Destination
        {
            City = "Nepal", Country = "Nepal", CountryCode = "NP",
            VisaType = "Visa on Arrival", VisaInfo = "Visa on arrival at Tribhuvan Airport. 15/30/90-day options. Online pre-approval available.",
            AvgDailyHotelCost = 25, AvgDailyFoodCost = 12, AvgDailyActivitiesCost = 30,
            FlightCostCategory = "medium",
            Description = "Nepal is the land of the Himalayas — home to Mount Everest, ancient temples, and some of the world's best trekking. Spiritual Kathmandu and adventure in the mountains await.",
            Highlights = new() { "Everest View", "Trekking", "Ancient Temples", "Pokhara Lakes", "Buddhist Culture" },
            TopAttractions = new() { "Everest Base Camp Trek", "Kathmandu Durbar Square", "Pokhara & Phewa Lake", "Chitwan National Park", "Boudhanath Stupa" },
            Weather = "Varies by altitude — Kathmandu warm Mar–May, cold Dec–Feb. Trekking best Mar–May, Oct–Nov", BestTimeToVisit = "October to November, March to April",
            Currency = "Nepalese Rupee (NPR)", Language = "Nepali (English in tourist areas)",
            Rating = 4.8, TravelTip = "Acclimatize properly before trekking. Hire a local guide — it supports the local economy and improves safety.",
            FlightDuration = "~16-18 hrs from US, ~8-10 hrs from Europe", RecommendedStay = "7–14 days for trekking",
            ImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=1280&h=720&fit=crop",
            GalleryImages = new() {
                "https://images.unsplash.com/photo-1544735716-392fe2489ffa?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1585516482105-8a6d6d571d98?w=800&h=600&fit=crop",
                "https://images.unsplash.com/photo-1571647918776-ab6e9e94ee05?w=800&h=600&fit=crop"
            },
            DayThemes = new() { "Kathmandu Temples", "Bhaktapur Day Trip", "Pokhara Arrival", "Sunrise Trek", "Sarangkot & Departure" },
            SampleActivities = new()
            {
                new() {
                    new DayActivity { Time="08:00", Activity="Boudhanath Stupa", Description="Walk around the largest spherical stupa in the world with prayer flags", EstimatedCost=3, Icon="temple_buddhist" },
                    new DayActivity { Time="11:00", Activity="Pashupatinath Temple", Description="Visit the most sacred Hindu temple in Nepal on the Bagmati River", EstimatedCost=5, Icon="temple_hindu" },
                    new DayActivity { Time="14:00", Activity="Swayambhunath Monkey Temple", Description="Climb to the hilltop stupa overlooking Kathmandu Valley", EstimatedCost=3, Icon="terrain" },
                    new DayActivity { Time="18:00", Activity="Thamel Night Market Dinner", Description="Explore the tourist hub and enjoy cheap Nepali thali", EstimatedCost=8, Icon="restaurant" }
                }
            }
        }
    };
}
