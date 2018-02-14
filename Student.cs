using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noten {
    public class Student {
        // Variabnedeklaration
        private int id;
        private string nachname;
        private string vorname;
        private string anrede;
        private Birthday birthday;
        private int grade;
        private string tendenz;

        public Student(String[] data) {
            // Set values
            id = Convert.ToInt32(data[0]);
            nachname = data[1];
            vorname = data[2];
            anrede = data[3];
            birthday = new Birthday(data[4].Split('.').Select(int.Parse).ToArray());
            grade = Convert.ToInt32(data[5]);
            if (data.Length == 7)
                tendenz = data[6].Trim();
            else
                tendenz = " ";
        }

        public int ID {
            get { return id; }
        }
        public string Nachname {
            get { return nachname;  }
        }
        public string Vorname {
            get { return vorname; }
        }
        public string Anrede {
            get { return anrede; }
        }
        public string Birthday {
            get { return birthday.Day + "." + birthday.Month + "." + birthday.Year; }
        }
        public int Grade {
            get { return grade; }
        }
        public string Tendenz {
            get { return tendenz;  }
        }
    }
}
