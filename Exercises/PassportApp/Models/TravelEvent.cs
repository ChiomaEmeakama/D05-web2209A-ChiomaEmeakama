using System;

namespace PassportApp.Models
{
    public class TravelEvent
    {
        public int PassportId { get; }
        public string Country { get; }
        public DateTime TimeOfEntry { get; }
        public TimeSpan TimeSinceEntry => DateTime.UtcNow - TimeOfEntry;

        public TravelEvent(int passportId, string country, DateTime timeOfEntry)
        {
            if (country == null)
                throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country must not be empty or whitespace.", nameof(country));

            PassportId = passportId;
            Country = country;
            TimeOfEntry = timeOfEntry;
        }

        public override string ToString()
        {
            return $"Passport {PassportId} traveled to {Country} at {TimeOfEntry}.";
        }
    }
}
