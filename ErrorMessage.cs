using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Noten {
    public class ErrorMessage : Form {
        private Label labHeader;
        private Label labMessage;
        private Button cmdExit;
        private PictureBox picError;

        public ErrorMessage(string schtring) {
            InitializeComponent();
            labMessage.Text = schtring;
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessage));
            this.labHeader = new System.Windows.Forms.Label();
            this.picError = new System.Windows.Forms.PictureBox();
            this.labMessage = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picError)).BeginInit();
            this.SuspendLayout();
            // 
            // labHeader
            // 
            this.labHeader.AutoSize = true;
            this.labHeader.Font = new System.Drawing.Font("Comic Sans MS", 22F);
            this.labHeader.Location = new System.Drawing.Point(132, 23);
            this.labHeader.Name = "labHeader";
            this.labHeader.Size = new System.Drawing.Size(176, 61);
            this.labHeader.TabIndex = 0;
            this.labHeader.Text = "ERROR";
            // 
            // picError
            // 
            this.picError.Image = global::Noten.Properties.Resources.error;
            this.picError.Location = new System.Drawing.Point(21, 23);
            this.picError.Name = "picError";
            this.picError.Size = new System.Drawing.Size(86, 86);
            this.picError.TabIndex = 0;
            this.picError.TabStop = false;
            // 
            // labMessage
            // 
            this.labMessage.AutoSize = true;
            this.labMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.3F);
            this.labMessage.Location = new System.Drawing.Point(52, 112);
            this.labMessage.Name = "labMessage";
            this.labMessage.Size = new System.Drawing.Size(87, 24);
            this.labMessage.TabIndex = 1;
            this.labMessage.Text = "Message";
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.cmdExit.Location = new System.Drawing.Point(160, 175);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(180, 38);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Weiter";
            this.cmdExit.UseVisualStyleBackColor = true;
            // 
            // ErrorMessage
            // 
            this.ClientSize = new System.Drawing.Size(490, 244);
            this.ControlBox = false;
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.labMessage);
            this.Controls.Add(this.picError);
            this.Controls.Add(this.labHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorMessage";
            this.Opacity = 0.14D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
