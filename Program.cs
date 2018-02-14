using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noten {
    public static class Program {
        /// <summary>
        /// Main-Methode des Noten-Diagrammes
        /// </summary>
        [STAThread]
        static void Main() { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Starten des Programmes mit dem Beginn des Dateiladens 
            Application.Run(new Load());  
        } 
    }
}
