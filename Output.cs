using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Noten {
    class Output : Form {
        // Variablendekleration
        private Diagramm diagramm;
        private Panel drawPanel;
        private Graphics graphicsForm;
        private Graphics graphicsPanel;
        private Font font;
        private SolidBrush pen;
        private int minWidth;
        private int minHeight;

        public Output(Diagramm diagramm) {
            // Inizialisieren
            InitializeComponent();
            this.diagramm = diagramm;
            drawPanel.Location = new Point(150, 160);
            graphicsForm = this.CreateGraphics();
            graphicsPanel = drawPanel.CreateGraphics();
            // Werte setzen
            font = new Font("Microsoft Sans Serif", (float)12);
            pen = new SolidBrush(Color.Black);
            // Set bounds
            this.Height = minHeight = 500;
            this.Width = minWidth = 700;
            // Update background
            drawPanel.BackColor = this.BackColor;
            // Update graphics 
            updateGraphics();
        }
         
        private void draw(object sender, PaintEventArgs e) {
            // Notentabelle  
            updateBars(graphicsPanel);
            drawGradeTable(graphicsForm);
            // Draw bars 
            foreach( Grade g in diagramm.getGrade()){ 
                g.draw(graphicsPanel);
            }
            // Cut 
            graphicsPanel.FillRectangle(new SolidBrush(drawPanel.BackColor), 
                new Rectangle(new Point(0, 0), new Size(20, drawPanel.Height)));
            // Coord system
            drawCoordSystem(graphicsForm);
        }
        private void drawGradeTable(Graphics graphics) {
            // Draw Header
            graphics.DrawString(Convert.ToString("Notendiagramm"), new Font("Times New Roman", 18), pen,
                new Point(258 + ((this.Width - minWidth) / 2), 21));
            // Notentabelle
            graphics.DrawString(Convert.ToString("Note"), font, pen, new Point(20 + ((this.Width - minWidth) / 2), 70)); 
            graphics.DrawString(Convert.ToString("Anzahl"), font, pen, new Point(20 + ((this.Width - minWidth) / 2), 100));
            // Schleife über alle noten
            for ( int i = 0; i < 6; i++){
                graphics.DrawString(Convert.ToString(i + 1), font, pen, new Point( 70 * i + 90 + ((this.Width - minWidth) / 2), 70));
                graphics.DrawLine(new Pen(Color.Black, 1), new Point(70 * i + 80 + ((this.Width - minWidth) / 2), 70),
                    new Point(70 * i + 80 + ((this.Width - minWidth) / 2), 120));
                graphics.DrawString(Convert.ToString(diagramm.getGrade()[i].Count()), font, pen, 
                    new Point(70 * i + 90 + ((this.Width - minWidth) / 2), 100));
            }
            // Durchschnitt
            if (diagramm.Average() < 2.9)
                graphics.DrawString(Convert.ToString("Durchschnitt: " + diagramm.Average().ToString()), font,
                    new SolidBrush(Color.Green), new Point(525 + ((this.Width - minWidth) / 2), 85));
            else if (diagramm.Average() < 4.9)
                graphics.DrawString(Convert.ToString("Durchschnitt: " + diagramm.Average().ToString()), font, 
                    new SolidBrush(Color.Orange), new Point(525 + ((this.Width - minWidth) / 2), 85));
            else
                graphics.DrawString(Convert.ToString("Durchschnitt: " + diagramm.Average().ToString()), font, 
                    new SolidBrush(Color.Red), new Point(525 + ((this.Width - minWidth) / 2), 85));
            // Trennstrich
            graphics.DrawLine(new Pen(Color.Black, 1), new Point(20 + ((this.Width - minWidth) / 2), 95), 
                new Point(500 + ((this.Width - minWidth) / 2), 95)); 
            // Draw gradedescription
            Grade [] grades = diagramm.getGrade();
            for (int i = 0; i < grades.Length; i++) {
                Grade g = grades[i];
                graphics.DrawString(g.Description, font, new SolidBrush(Color.Black), 
                    new Point(20, (int)( (drawPanel.Location.Y + 10 + (g.getHeight() * 0.4) + (g.getHeight() + 3)* i ))));
            }
        }
        private void updateBars(Graphics graphics) {
            // Max Notenanzahl bestimmen
            Grade[] grades = diagramm.getGrade();
            int maxGrade = 0;
            int maxHeight = (drawPanel.Height / grades.Length );
            int maxWidth = drawPanel.Width - 20;
            foreach (Grade grade in grades) { 
                if (grade.CountFull > maxGrade)
                    maxGrade = grade.CountFull;
                if (grade.CountPlus > maxGrade)
                    maxGrade = grade.CountPlus;
                if (grade.CountMinus > maxGrade)
                    maxGrade = grade.CountMinus;
            }
            // Max Notenanzahl setzen und die max Koordinaten
            for (int i = 0; i < grades.Length; i++) {
                grades[i].setMaxGrades(maxGrade);
                grades[i].setCaps(maxWidth, maxHeight);
                grades[i].setCoord(0, (grades[i].getHeight() + 5) * i);
            }
            // Das Diagramm updaten
            diagramm.updateGrade(grades);
        }

        private void drawCoordSystem(Graphics graphics) {
            // Draw X-axis 
            graphics.DrawLine(new Pen(Color.Black, 1),
                new Point(drawPanel.Location.X - 5, drawPanel.Location.Y + drawPanel.Height + 6),
                new Point(drawPanel.Location.X + drawPanel.Width - 35, drawPanel.Location.Y + drawPanel.Height + 6));
            // Draw Y-axis 
            graphics.DrawLine(new Pen(Color.Black, 1),
                new Point(drawPanel.Location.X -1, drawPanel.Location.Y),
                new Point(drawPanel.Location.X -1, drawPanel.Location.Y + drawPanel.Height + 10));
        }

        private void sizeChanged(object sender, EventArgs e) {
            updateGraphics();
        }
        private void updateGraphics() {
            // Check bounds
            if (this.Width < minWidth)
                this.Width = minWidth;
            if (this.Height < minHeight)
                this.Height = minHeight;

            // Set new size 
            drawPanel.Size = new Size(this.Width - drawPanel.Location.X - 20, this.Height - drawPanel.Location.Y - 65);
            graphicsForm.Clear(this.BackColor);
            graphicsForm = this.CreateGraphics();
            graphicsPanel.Clear(drawPanel.BackColor);
            graphicsPanel = drawPanel.CreateGraphics();
            this.Invalidate();
        } 
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Output));
            this.drawPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.Color.LightCoral;
            this.drawPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.drawPanel.Location = new System.Drawing.Point(1598, 760);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(153, 113);
            this.drawPanel.TabIndex = 1;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.draw);
            // 
            // Output
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.drawPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Output";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notendiagramm";
            this.AutoSizeChanged += new System.EventHandler(this.sizeChanged);
            this.MaximumSizeChanged += new System.EventHandler(this.sizeChanged);
            this.MinimumSizeChanged += new System.EventHandler(this.sizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.onClosing);
            this.ResizeEnd += new System.EventHandler(this.sizeChanged);
            this.ClientSizeChanged += new System.EventHandler(this.sizeChanged);
            this.FontChanged += new System.EventHandler(this.sizeChanged);
            this.SizeChanged += new System.EventHandler(this.sizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.draw);
            this.Resize += new System.EventHandler(this.sizeChanged);
            this.ResumeLayout(false);

        } 
        private void onClosing(object sender, FormClosingEventArgs e) {
            Environment.Exit(0);
        }
    }
}
