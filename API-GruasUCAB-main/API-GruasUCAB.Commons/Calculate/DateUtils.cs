namespace API_GruasUCAB.Common.Calculate
{
     public static class DateUtils
     {
          public static int CalculateYearsDifference(DateTime fromDate, DateTime toDate)
          {
               var age = toDate.Year - fromDate.Year;
               if (fromDate.Date > toDate.AddYears(-age)) age--;
               return age;
          }
     }
}