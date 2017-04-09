namespace pocACIAF
{
    public class MathData
    {
        public float FArg1 { get; set; }
        public float FArg2 { get; set; }
        public float FRsltArg { get; set; }

        public string StrArg1 { get; set; }
        public string StrArg2 { get; set; }
        public string StrConcatRslt { get; set; }

    }


    partial class pocACIAFagent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.launchAsACIAFagent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // launchAsACIAFagent
            // 
            this.launchAsACIAFagent.Location = new System.Drawing.Point(117, 226);
            this.launchAsACIAFagent.Name = "launchAsACIAFagent";
            this.launchAsACIAFagent.Size = new System.Drawing.Size(138, 23);
            this.launchAsACIAFagent.TabIndex = 0;
            this.launchAsACIAFagent.Text = "launchAsACIAFagent";
            this.launchAsACIAFagent.UseVisualStyleBackColor = true;
            this.launchAsACIAFagent.Click += new System.EventHandler(this.launchAsACIAFagent_Click);
            // 
            // pocACIAFagent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.launchAsACIAFagent);
            this.Name = "pocACIAFagent";
            this.Text = "ACIAFagent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button launchAsACIAFagent;
    }
}

