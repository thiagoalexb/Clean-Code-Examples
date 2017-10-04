
using System;

namespace CleanCode.DuplicatedCode
{
    #region Wrong
    class DuplicatedCodeWrong
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            int time;
            int hours = 0;
            int minutes = 0;
            if (!string.IsNullOrWhiteSpace(admissionDateTime))
            {
                if (int.TryParse(admissionDateTime.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("admissionDateTime");
                }

            }
            else
                throw new ArgumentNullException("admissionDateTime");

            // Some more logic 
            // ...
            if (hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            int time;
            int hours = 0;
            int minutes = 0;
            if (!string.IsNullOrWhiteSpace(admissionDateTime))
            {
                if (int.TryParse(admissionDateTime.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                {
                    throw new ArgumentException("admissionDateTime");
                }
            }
            else
                throw new ArgumentNullException("admissionDateTime");

            // Some more logic 
            // ...
            if (hours < 10)
            {

            }
        }
    }
    #endregion
    #region Wrong
    class DuplicatedCode
    {
        public void AdmitGuest(string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);
            if (time.Hours < 10)
            {

            }
        }

        public void UpdateAdmission(int admissionId, string name, string admissionDateTime)
        {
            // Some logic 
            // ...

            var time = Time.Parse(admissionDateTime);
            if (time.Hours < 10)
            {

            }
        }



        public class Time
        {
            public int Hours { get; set; }
            public int Minutes { get; set; }

            public Time(int hours, int minutes)
            {
                Hours = hours;
                Minutes = minutes;
            }

            public static Time Parse(string str)
            {
                int time;
                int hours = 0;
                int minutes = 0;
                if (!string.IsNullOrWhiteSpace(str) && int.TryParse(str.Replace(":", ""), out time))
                {
                    hours = time / 100;
                    minutes = time % 100;
                }
                else
                    throw new ArgumentNullException("str");

                return new Time(hours, minutes);
            }
        }
    }
    #endregion
}
