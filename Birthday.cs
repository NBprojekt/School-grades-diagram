using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noten {
    public class Birthday {
        private string day;
        private string month;
        private string year;
        private int minYear = 1990;
        private int maxYear = 2010;

        public Birthday() {
            day   = "01";
            month = "01";
            year = "1990";
        }
        public Birthday(int day, int month, int year) {
            Day = day.ToString();
            Month = month.ToString();
            Year = year.ToString();
        }
        public Birthday(int [] date) {
            Day = date[0].ToString();
            Month = date[1].ToString();
            Year = date[2].ToString();
        }

        public string Day {
            set {
                if (Convert.ToInt32(value) >= 1 && Convert.ToInt32(value) <= 31) {
                    if (value.Length == 1)
                        day = "0" + value;
                    else
                        day = value;
                }
                else
                    day = "01";
            }
            get { return day; }
        }
        public string Month {
            set {
                if (Convert.ToInt32(value) >= 1 && Convert.ToInt32(value) <= 12) {
                    if (value.Length == 1)
                        month = "0" + value;
                    else
                        month = value;
                }
                else
                    month = "01";
            }
            get { return month; }
        }
        public string Year {
            set {
                if (Convert.ToInt32(value) >= minYear && Convert.ToInt32(value) <= maxYear) 
                        year = value;
                else
                    year = "01";
            }
            get { return year; }
        }
    }
}
