using System;

class Program
{
    static void Main(string[] args)
    {
        // Create addresses
        Address address1 = new Address("123 Main St", "City1", "State1", "Country1");
        Address address2 = new Address("456 Elm St", "City2", "State2", "Country2");
        Address address3 = new Address("789 Oak St", "City3", "State3", "Country3");

        // Create events
        Event event1 = new Event("Event 1", "Event 1 Description", DateTime.Now.AddDays(7), new TimeSpan(15, 30, 0), address1);
        Lecture lecture1 = new Lecture("Lecture 1", "Lecture 1 Description", DateTime.Now.AddDays(14), new TimeSpan(10, 0, 0), address2, "Speaker 1", 100);
        Reception reception1 = new Reception("Reception 1", "Reception 1 Description", DateTime.Now.AddDays(21), new TimeSpan(18, 0, 0), address3, "rsvp@example.com");
        OutdoorGathering outdoorGathering1 = new OutdoorGathering("Outdoor Gathering 1", "Outdoor Gathering 1 Description", DateTime.Now.AddDays(28), new TimeSpan(13, 45, 0), address1, "Sunny");

        // Display marketing messages
        Console.WriteLine("Event 1 - Standard Details:");
        Console.WriteLine(event1.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Lecture 1 - Full Details:");
        Console.WriteLine(lecture1.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Reception 1 - Short Description:");
        Console.WriteLine(reception1.GetShortDescription());
        Console.WriteLine();

        Console.WriteLine("Outdoor Gathering 1 - Full Details:");
        Console.WriteLine(outdoorGathering1.GetFullDetails());

        Console.ReadLine();
    }
}

// Base class: Event
class Event
{
    private string eventTitle;
    private string eventDescription;
    private DateTime eventDate;
    private TimeSpan eventTime;
    private Address eventAddress;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        eventTitle = title;
        eventDescription = description;
        eventDate = date;
        eventTime = time;
        eventAddress = address;
    }

    public string GetStandardDetails()
    {
        return $"Event Title: {eventTitle}\nDescription: {eventDescription}\nDate: {eventDate.ToShortDateString()}\nTime: {eventTime}\nAddress: {eventAddress.GetAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: {GetType().Name}\nEvent Title: {eventTitle}\nDate: {eventDate.ToShortDateString()}";
    }
}

// Derived class: Lecture
class Lecture : Event
{
    private string speakerName;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        speakerName = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nSpeaker: {speakerName}\nCapacity: {capacity}";
    }
}

// Derived class: Reception
class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string email)
        : base(title, description, date, time, address)
    {
        rsvpEmail = email;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nRSVP Email: {rsvpEmail}";
    }
}

// Derived class: OutdoorGathering
class OutdoorGathering : Event
{
    private string weatherForecast;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string forecast)
        : base(title, description, date, time, address)
    {
        weatherForecast = forecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nWeather Forecast: {weatherForecast}";
    }
}

// Address class
class Address
{
    private string streetAddress;
    private string city;
    private string state;
    private string country;

    public Address(string street, string cityName, string stateName, string countryName)
    {
        streetAddress = street;
        city = cityName;
        state = stateName;
        country = countryName;
    }

    public string GetAddress()
    {
        return $"{streetAddress}, {city}, {state}, {country}";
    }
}
