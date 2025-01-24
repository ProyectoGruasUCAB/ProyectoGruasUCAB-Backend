namespace API_GruasUCAB.ServiceOrder.Domain.ValueObject
{
     public class IncidentDate : ValueObject<IncidentDate>
     {
          public DateTime Date { get; }

          public DateTime Value => Date;

          public IncidentDate(string date)
          {
               if (!DateTime.TryParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidIncidentDateException(parsedDate);
               }

               Date = parsedDate;
          }

          public override bool Equals(IncidentDate other)
          {
               return Date == other.Date;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return Date;
          }

          public override string ToString()
          {
               return Date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
          }
     }
}