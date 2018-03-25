using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrivagoTests.Utils
{
    public static class DateUtility
    {
        public static DateTime calculateThreeMonthsAhead()//Calculates the current date three months from today
        {
            DateTime today = new DateTime();
            DateTime threeMonthsAhead = new DateTime();

            today = DateTime.Today;
            threeMonthsAhead = today.AddMonths(3);
            return threeMonthsAhead;
        }

        public static string getMonthText(int month)//Returns the month value for the int passed in
        {
            string[] months = { "", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
            return months[month];
        }
    }
}
