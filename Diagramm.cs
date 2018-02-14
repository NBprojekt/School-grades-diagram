using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noten {
    public class Diagramm {
        // Variablendeklarieren
        private List<Student> students;
        private Grade [] grades; 
        private double average;
        private int countAll;

        public Diagramm(List<Student> students) {
            // Liste speichern
            init();
            this.students = students;
            // Durchschnitt berechnen und noten abspeichern
            foreach (Student tmpStudent in students) {
                for (int i = 0; i < 6; i++)
                    if (i + 1 == tmpStudent.Grade)
                        grades[i].addNew(tmpStudent.Tendenz);
                average += tmpStudent.Grade;
                countAll++;
            }
            // Durchschnitt und Prozente berechnen
            average = Math.Round(average /= students.Count * 1.0, 1); 
        }
        private void init() {
            // Variableninizialisieren
            grades = new Grade[]{
                new Grade(1, "Sehr Gut"),
                new Grade(2, "Gut"),
                new Grade(3, "Befriedigend"),
                new Grade(4, "Ausreichend"),
                new Grade(5, "Mangelhaft"),
                new Grade(6, "Ungenügend"),
            }; 
            average = 0;
        }
        public Grade[] getGrade() {
            return grades;
        }
        public void updateGrade(Grade[] grades) {
            // Prufen ob es 6 noten sind und dise auch nicht leer
            if (grades.Length > 6)
                return;
            foreach (Grade grade in grades)
                if (grade == null)
                    return;
            // Wemm es keine fehler gibt wird das Array gespeichert
            this.grades = grades;
        }
        public double Average() {
            return average;
        }
        public void Draw(Graphics graphics) {

        }
    }
}
