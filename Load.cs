using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Noten{
    public class Load : Form {
        // Variableninizialisierung von Variablen
        private List<Student> studentList;
        private OpenFileDialog openFileDialog;
        private StreamReader streamReader; 
        private Label labPathname;
        private TextBox txtPathname;
        private Button cmdStart;
        private Button cmdQuit;
        private PictureBox cmdOpenFile;
        private String pathname; 

        public Load() {
            // Variablendeklarieren und Dateifenster starten
            InitializeComponent();
            init();
        }
        private void init() {
            // File choser inizialisieren
            openFileDialog = new OpenFileDialog(); 
            openFileDialog.Multiselect = false;
            openFileDialog.Title = "Wählen Sie die Schülerliste (bevorzugt .csv)";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.InitialDirectory = @"H:\";
            openFileDialog.Filter = "Comma Seperated Values|*.csv|Textdateinen|*.txt|Alles|*.*";
            // String Array-Liste inizialisierung
            studentList = new List<Student>();
        } 

        private void splitList() { 
            // Datei auslesen
            streamReader = new StreamReader(new FileStream(pathname, FileMode.Open), Encoding.Default);
            // Erste Zeile überspringen
            streamReader.ReadLine();
            // List mit den Zeilen füllen
            while (streamReader.Peek() != -1) 
                studentList.Add(new Student(streamReader.ReadLine().Split(';')));
        }
        private void openFile(object sender, EventArgs eentArgs) {
            // Versuchen die Datei zu leden
            try {
                // Dateiabffrage öffnen
                openFileDialog.ShowDialog();
                txtPathname.Text = openFileDialog.FileName;
                // Wenn ein fehler kommt wir das Programm sofort beendet
            } catch (IOException eIO) { 
                new ErrorMessage(eIO.Message);
                return;
            } catch (Exception e) {
                new ErrorMessage(e.Message);
                return;
            } 
        }

        // Wenn sich der Text ändert wird dieser abbgespeichert
        private void textChanged(object sender, EventArgs e) {
            // Der dateipfad muss mindenstens 5 Zeichen lang sein
            if (txtPathname.Text.Length <= 4)
                cmdStart.Enabled = false;
            else
                cmdStart.Enabled = true;
            // Dateipfad speichern
            pathname = txtPathname.Text.Trim();
        }
        private void startAusgabe(object sender, EventArgs eventArgs) {
            startForm();
        } 
        private void Quit(object sender, EventArgs e) {
            // Programm beenden
            Environment.Exit(0);
        }
         
        private void enterPressed(object sender, KeyPressEventArgs e) {
            // Wenn enter gedrückt wird
            if (e.KeyChar == 13 && cmdStart.Enabled) {
                startForm();
            }
        }
        private void startForm() {
            // Liste erstellen
            splitList();
            // Fenster starten 
            Output output = new Output(new Diagramm(studentList));
            output.Show();
            this.Hide();
        }
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Load));
            this.labPathname = new System.Windows.Forms.Label();
            this.txtPathname = new System.Windows.Forms.TextBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.cmdQuit = new System.Windows.Forms.Button();
            this.cmdOpenFile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmdOpenFile)).BeginInit();
            this.SuspendLayout();
            // 
            // labPathname
            // 
            this.labPathname.AutoSize = true;
            this.labPathname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labPathname.Location = new System.Drawing.Point(36, 18);
            this.labPathname.Name = "labPathname";
            this.labPathname.Size = new System.Drawing.Size(229, 17);
            this.labPathname.TabIndex = 0;
            this.labPathname.Text = "Bitte den Notendateipfad angeben:";
            // 
            // txtPathname
            // 
            this.txtPathname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtPathname.Location = new System.Drawing.Point(39, 48);
            this.txtPathname.Name = "txtPathname";
            this.txtPathname.Size = new System.Drawing.Size(358, 23);
            this.txtPathname.TabIndex = 1;
            this.txtPathname.TextChanged += new System.EventHandler(this.textChanged);
            this.txtPathname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterPressed);
            // 
            // cmdStart
            // 
            this.cmdStart.Enabled = false;
            this.cmdStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmdStart.Location = new System.Drawing.Point(248, 87);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(203, 31);
            this.cmdStart.TabIndex = 3;
            this.cmdStart.Text = "Diagramm öffnen";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.startAusgabe);
            // 
            // cmdQuit
            // 
            this.cmdQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.cmdQuit.Location = new System.Drawing.Point(39, 87);
            this.cmdQuit.Name = "cmdQuit";
            this.cmdQuit.Size = new System.Drawing.Size(203, 31);
            this.cmdQuit.TabIndex = 4;
            this.cmdQuit.Text = "Beenden";
            this.cmdQuit.UseVisualStyleBackColor = true;
            this.cmdQuit.Click += new System.EventHandler(this.Quit);
            // 
            // cmdOpenFile
            // 
            this.cmdOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.cmdOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdOpenFile.Image = global::Noten.Properties.Resources.datei;
            this.cmdOpenFile.Location = new System.Drawing.Point(411, 42);
            this.cmdOpenFile.Name = "cmdOpenFile";
            this.cmdOpenFile.Size = new System.Drawing.Size(34, 34);
            this.cmdOpenFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cmdOpenFile.TabIndex = 5;
            this.cmdOpenFile.TabStop = false;
            this.cmdOpenFile.Click += new System.EventHandler(this.openFile);
            // 
            // Load
            // 
            this.ClientSize = new System.Drawing.Size(496, 133);
            this.Controls.Add(this.cmdOpenFile);
            this.Controls.Add(this.cmdQuit);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.txtPathname);
            this.Controls.Add(this.labPathname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schülerdatei laden";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterPressed);
            ((System.ComponentModel.ISupportInitialize)(this.cmdOpenFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
