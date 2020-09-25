using System;

namespace Abc.HabitTracker.Api.HabitAggregate
{   
    public class DaysOffValue
    {
        public DaysOffValue(string[] value)
        {
            string days;

            if(value.Length >= 7) throw new Exception("Cannot assign everyday as a Days off");
            if(!checkDayFormat(value)) 
                throw new Exception("Days name must be : Mon / Tue / Wed / Thu / Fri / Sat / Sun");

            days = stringconverter(value); 

            this.value = days;
        }

        public String value { get; set; }

        public string stringconverter (string[] x)
        {
            string hasil = null;
            for (int i=0; i < x.Length; i++)
            {
                hasil += x[i];
                if(i == x.Length-1) hasil += "";
                else hasil += ", ";
            }
            return hasil;
        }

        public bool checkDayFormat(string[] x)
        {
            foreach ( var i in x )
            {
                if (check(i))
                {
                    for(int j = 0; j < x.Length; j++) {
                        for(int k = 0; k < j-1; k++) {
                            if ( i[j] == i[k] ) return false;
                        }
                    }
                }
                else if(!check(i))
                {
                    return false;    
                }
                else{ //safety net
                    return false;
                }
            }
            return true;
        }

        public bool check(string x)
        {
            if(x.Equals("Mon") || x.Equals("Tue") || x.Equals("Wed") || x.Equals("Thu") || x.Equals("Fri") ||
            x.Equals("Sat") || x.Equals("Sun") )
            {
                return true;
            }
            return false;
        }
    }
}
