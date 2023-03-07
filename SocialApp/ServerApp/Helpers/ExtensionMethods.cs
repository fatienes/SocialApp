using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Helpers
{
    public static class ExtensionMethods
    {
        public static int CalcuateAge(this DateTime DateofBirth){
            int age =0;

            age =DateTime.Now.Year-DateofBirth.Year;

            if(DateTime.Now.DayOfYear< DateofBirth.DayOfYear)
            age-=1;

            return age;
        }
    }
}