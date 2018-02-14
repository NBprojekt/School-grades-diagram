using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Noten {
    public class Grade { 
        // Variablendeklaration
        private int grade;
        private string gradeName;
        private int countPlus;
        private int countMinus;
        private int countFull;
        private int percentagePlus;
        private int percentageMinus;
        private int percentageFull;
        private int maxGrades;
        private int maxWidth;
        private int greenPlus;
        private int redPlus;
        private int greenMinus;
        private int redMinus;
        private int greenFull;
        private int redFull;
        private Size sizePlus;
        private Size sizeMinus;
        private Size sizeFull;
        private Point point;

        // Konstruktor
        public Grade(int grade, string gradeName) {
            this.grade = grade;
            this.gradeName = gradeName;
            point = new Point();
            sizePlus = sizeMinus = sizeFull = new Size();
            greenPlus = greenMinus = greenFull = 255;
            redPlus = redMinus = redFull = 255;
            countPlus = countMinus = countFull = 0;
        }  

        // Zusatz-Methoden
        public void setMaxGrades(int maxGrades) { 
            this.maxGrades = maxGrades; 
        } 
        public void setCaps(int maxWidth, int maxHeight) {
            percentagePlus = (countPlus * 100) / maxGrades;
            percentageMinus = (countMinus * 100) / maxGrades;
            percentageFull = (countFull * 100) / maxGrades;
            this.maxWidth = maxWidth;
            sizePlus = new Size(((maxWidth - 40) * percentagePlus) / 100, maxHeight / 3 -1);
            sizeMinus = new Size(((maxWidth - 40) * percentageMinus) / 100, maxHeight / 3 - 1);
            sizeFull = new Size(((maxWidth - 40) * percentageFull) / 100, maxHeight / 3 - 1);
            setColor();
            // Test debug output
            //MessageBox.Show(gradeName + " \r\n Percentage : " + percentage + "% \r\n width:   "
            //    + size.Width + "\r\n height:   " + size.Height);
        }
        public void setCoord(int x, int y) {
            point = new Point(x + 20, y + 2);
        }
        public int getHeight() {
            return sizeFull.Height + sizeMinus.Height + sizeMinus.Height;
        }
        private void setColor() {
            // Plus
            if (percentagePlus > 70) {
                greenPlus = 255;
                redPlus = 0;
            }
            else if (percentagePlus > 30) greenPlus = redPlus = 255;
            else {
                greenPlus = 0;
                redPlus = 255;
            }
            // Minus
            if (percentageMinus > 70) {
                greenMinus = 255;
                redMinus = 0;
            }
            else if (percentageMinus > 30) greenMinus = redMinus = 255;
            else {
                greenMinus = 0;
                redMinus = 255;
            }
            // Full
            if (percentageFull > 70) {
                greenFull = 255;
                redFull = 0;
            }
            else if (percentageFull > 30) greenFull = redFull = 255;
            else {
                greenFull = 0;
                redFull = 255;
            }
        }
        public int CountMinus {
            get { return countMinus; }
        }
        public int CountPlus {
            get { return countPlus; }
        }
        public int CountFull {
            get { return countFull; }
        }
        public void addNew( string tendenz) {
            if (tendenz == "+") countPlus++;
            else if (tendenz == "-") countMinus++;
            else countFull++;
        }
        public int Count() {
            return countFull + countPlus + countMinus;
        }
        public Point Point {
            set { point = value; }
            get { return point; }
        }
        public string Description {
            get { return gradeName; }
        }

        public void draw(Graphics graphics) { 
            // Background
            graphics.FillRectangle(new SolidBrush(Color.Gainsboro),
                new Rectangle(point, new Size(maxWidth - 40, sizePlus.Height + sizeMinus.Height + sizeFull.Height))); 
            double p = 0.05;
            double s = 0.9;
            // Solange Bis die volle Ferbfülle werreicht ist
            for (int i = 0; i < 255; i += 30) {
                // Neuen Punkte der Plus und Minus bars
                Point full = new Point(point.X, point.Y + sizeFull.Height);
                Point minus = new Point(point.X, full.Y + sizeMinus.Height);
                // Create color
                int rPlus, rFull, rMinus;
                int gPlus, gFull, gMinus;
                rPlus = rFull = rMinus = gPlus = gFull = gMinus = i;
                    // Set Color for all grades
                // Plus
                if (gPlus > greenPlus) gPlus = greenPlus;
                if (rPlus > redPlus) rPlus = redPlus;
                // Full
                if (gFull > greenFull) gFull = greenFull;
                if (rFull > redFull) rFull = redFull;
                // Minus
                if (gMinus > greenMinus) gMinus = greenMinus;
                if (rMinus > redMinus) rMinus = redMinus;
                    // Draw the bar
                // Plus
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(rPlus, gPlus, 100)),
                    new Rectangle(
                        new Point(
                            point.X, 
                            point.Y + (int)(sizePlus.Height * p)), 
                        new Size(
                            sizePlus.Width,
                            (int)(sizePlus.Height * s)))
                        );
                // Full
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(rFull, gFull, 100)),
                    new Rectangle(
                        new Point(
                            full.X,
                            full.Y + (int)(sizeFull.Height * p)),
                        new Size(
                            sizeFull.Width,
                            (int)(sizeFull.Height * s)))
                        );
                // Minus
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(rMinus, gMinus, 100)),
                    new Rectangle(
                        new Point(
                            minus.X,
                            minus.Y + (int)(sizeMinus.Height * p)),
                        new Size(
                            sizeMinus.Width,
                            (int)(sizeMinus.Height * s)))
                        );
                // Update bounds
                s -= 0.1;
                p += 0.05;
            }  
        }
    }
}
