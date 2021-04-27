
namespace ApplicationForm
{
    partial class Form1
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
            this.bt_ActorMovie = new System.Windows.Forms.Button();
            this.uxResults = new System.Windows.Forms.TextBox();
            this.bt_ActorSalary = new System.Windows.Forms.Button();
            this.bt_DirectorMovies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_ActorMovie
            // 
            this.bt_ActorMovie.Location = new System.Drawing.Point(13, 13);
            this.bt_ActorMovie.Name = "bt_ActorMovie";
            this.bt_ActorMovie.Size = new System.Drawing.Size(75, 23);
            this.bt_ActorMovie.TabIndex = 0;
            this.bt_ActorMovie.Text = "ActorMovie";
            this.bt_ActorMovie.UseVisualStyleBackColor = true;
            this.bt_ActorMovie.Click += new System.EventHandler(this.bt_ActorMovie_Click);
            // 
            // uxResults
            // 
            this.uxResults.Location = new System.Drawing.Point(478, 12);
            this.uxResults.Multiline = true;
            this.uxResults.Name = "uxResults";
            this.uxResults.Size = new System.Drawing.Size(283, 391);
            this.uxResults.TabIndex = 1;
            // 
            // bt_ActorSalary
            // 
            this.bt_ActorSalary.Location = new System.Drawing.Point(143, 13);
            this.bt_ActorSalary.Name = "bt_ActorSalary";
            this.bt_ActorSalary.Size = new System.Drawing.Size(75, 23);
            this.bt_ActorSalary.TabIndex = 2;
            this.bt_ActorSalary.Text = "ActorSalary";
            this.bt_ActorSalary.UseVisualStyleBackColor = true;
            this.bt_ActorSalary.Click += new System.EventHandler(this.bt_ActorSalary_Click);
            // 
            // bt_DirectorMovies
            // 
            this.bt_DirectorMovies.Location = new System.Drawing.Point(261, 13);
            this.bt_DirectorMovies.Name = "bt_DirectorMovies";
            this.bt_DirectorMovies.Size = new System.Drawing.Size(101, 23);
            this.bt_DirectorMovies.TabIndex = 3;
            this.bt_DirectorMovies.Text = "DirectorMovies";
            this.bt_DirectorMovies.UseVisualStyleBackColor = true;
            this.bt_DirectorMovies.Click += new System.EventHandler(this.bt_DirectorMovies_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_DirectorMovies);
            this.Controls.Add(this.bt_ActorSalary);
            this.Controls.Add(this.uxResults);
            this.Controls.Add(this.bt_ActorMovie);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_ActorMovie;
        private System.Windows.Forms.TextBox uxResults;
        private System.Windows.Forms.Button bt_ActorSalary;
        private System.Windows.Forms.Button bt_DirectorMovies;
    }
}

