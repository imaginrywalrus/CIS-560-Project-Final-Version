
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
            this.bt_GenreMovies = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_ActorMovie
            // 
            this.bt_ActorMovie.Location = new System.Drawing.Point(17, 16);
            this.bt_ActorMovie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_ActorMovie.Name = "bt_ActorMovie";
            this.bt_ActorMovie.Size = new System.Drawing.Size(100, 28);
            this.bt_ActorMovie.TabIndex = 0;
            this.bt_ActorMovie.Text = "ActorMovie";
            this.bt_ActorMovie.UseVisualStyleBackColor = true;
            this.bt_ActorMovie.Click += new System.EventHandler(this.bt_ActorMovie_Click);
            // 
            // uxResults
            // 
            this.uxResults.Location = new System.Drawing.Point(637, 15);
            this.uxResults.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxResults.Multiline = true;
            this.uxResults.Name = "uxResults";
            this.uxResults.Size = new System.Drawing.Size(376, 480);
            this.uxResults.TabIndex = 1;
            // 
            // bt_ActorSalary
            // 
            this.bt_ActorSalary.Location = new System.Drawing.Point(191, 16);
            this.bt_ActorSalary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_ActorSalary.Name = "bt_ActorSalary";
            this.bt_ActorSalary.Size = new System.Drawing.Size(100, 28);
            this.bt_ActorSalary.TabIndex = 2;
            this.bt_ActorSalary.Text = "ActorSalary";
            this.bt_ActorSalary.UseVisualStyleBackColor = true;
            this.bt_ActorSalary.Click += new System.EventHandler(this.bt_ActorSalary_Click);
            // 
            // bt_DirectorMovies
            // 
            this.bt_DirectorMovies.Location = new System.Drawing.Point(348, 16);
            this.bt_DirectorMovies.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bt_DirectorMovies.Name = "bt_DirectorMovies";
            this.bt_DirectorMovies.Size = new System.Drawing.Size(135, 28);
            this.bt_DirectorMovies.TabIndex = 3;
            this.bt_DirectorMovies.Text = "DirectorMovies";
            this.bt_DirectorMovies.UseVisualStyleBackColor = true;
            this.bt_DirectorMovies.Click += new System.EventHandler(this.bt_DirectorMovies_Click);
            // 
            // bt_GenreMovies
            // 
            this.bt_GenreMovies.Location = new System.Drawing.Point(17, 113);
            this.bt_GenreMovies.Name = "bt_GenreMovies";
            this.bt_GenreMovies.Size = new System.Drawing.Size(100, 23);
            this.bt_GenreMovies.TabIndex = 4;
            this.bt_GenreMovies.Text = "GenreMovies";
            this.bt_GenreMovies.UseVisualStyleBackColor = true;
            this.bt_GenreMovies.Click += new System.EventHandler(this.bt_GenreMovies_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.bt_GenreMovies);
            this.Controls.Add(this.bt_DirectorMovies);
            this.Controls.Add(this.bt_ActorSalary);
            this.Controls.Add(this.uxResults);
            this.Controls.Add(this.bt_ActorMovie);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button bt_GenreMovies;
    }
}

