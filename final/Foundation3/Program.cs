using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var address1 = new Address("123 Sakura St", "Kyoto", "JPKYT", "Japan");
        var address2 = new Address("456 Maple St", "Mapleton", "UT", "USA");
        var address3 = new Address("789 Mango St", "Accra", "Greater Accra", "Ghana");

        var lecture = new Lecture("Growing a Business","Building My Snow Cone Truck Business", new DateTime(2024, 8, 5), "10:00 AM", address1, "Jacob Johnson", 100);
        var reception = new Reception("Company Annual Party", "Annual company celebration", new DateTime(2024, 12, 15), "6:00 PM", address2, "rsvp@company.com");
        var outdoorGathering = new OutdoorGathering("Summer Picnic", "Family-friendly picnic", new DateTime(2024, 7, 20), "1:00 PM", address3, "Sunny");

        var events = new List<Event> { lecture, reception, outdoorGathering };

        foreach (var eventItem in events)
        {
            Console.WriteLine("Standard Details");
            Console.WriteLine(eventItem.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine("Full Details");
            Console.WriteLine(eventItem.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine("Short Description");
            Console.WriteLine(eventItem.GetShortDescription());
            Console.WriteLine();
        }
    }
}
