using System;

public class Reception : Event
{
    private string _rsvpEmail;

    public Reception(string title, string description, DateTime date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        _rsvpEmail = rsvpEmail;
    }

    public string RsvpEmail => _rsvpEmail;

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP Email: {_rsvpEmail}";
    }
}
