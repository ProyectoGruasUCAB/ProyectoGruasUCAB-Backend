using API_GruasUCAB.Vehicle.Domain.Exceptions;
using System;
using System.Globalization;

namespace API_GruasUCAB.Vehicle.Domain.ValueObject
{
     public class VehicleCivilLiabilityExpirationDate : ValueObject<VehicleCivilLiabilityExpirationDate>
     {
          public DateTime ExpirationDate { get; }

          public VehicleCivilLiabilityExpirationDate(string expirationDate)
          {
               if (!DateTime.TryParseExact(expirationDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
               {
                    throw new InvalidVehicleCivilLiabilityExpirationDateFormatException(expirationDate);
               }

               if (parsedDate <= DateTime.UtcNow)
               {
                    throw new InvalidVehicleCivilLiabilityExpirationDateExpiredException(parsedDate);
               }

               if (parsedDate > DateTime.UtcNow.AddYears(5))
               {
                    throw new InvalidVehicleCivilLiabilityExpirationDateTooFarException(parsedDate);
               }

               ExpirationDate = parsedDate;
          }

          public DateTime Value => ExpirationDate;

          public override bool Equals(VehicleCivilLiabilityExpirationDate other)
          {
               return ExpirationDate == other.ExpirationDate;
          }

          protected override IEnumerable<object> GetEqualityComponents()
          {
               yield return ExpirationDate;
          }

          public override string ToString()
          {
               return ExpirationDate.ToString("dd-MM-yyyy");
          }
     }
}