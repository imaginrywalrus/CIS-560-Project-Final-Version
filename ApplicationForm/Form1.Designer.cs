
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
            this.uxResults = new System.Windows.Forms.TextBox();
            this.bt_ActorGenreMovies = new System.Windows.Forms.Button();
            this.bt_ActorInCommon = new System.Windows.Forms.Button();
            this.bt_goodReview = new System.Windows.Forms.Button();
            this.bt_ShowingInfo = new System.Windows.Forms.Button();
            this.bt_Movies = new System.Windows.Forms.Button();
            this.bt_ActorInfo = new System.Windows.Forms.Button();
            this.bt_CinemaInfo = new System.Windows.Forms.Button();
            this.bt_ReviewInfo = new System.Windows.Forms.Button();
            this.cmb_QuestionQueries = new System.Windows.Forms.ComboBox();
            this.bt_QuestionQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxResults
            // 
            this.uxResults.Location = new System.Drawing.Point(580, 18);
            this.uxResults.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uxResults.Multiline = true;
            this.uxResults.Name = "uxResults";
            this.uxResults.ReadOnly = true;
            this.uxResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.uxResults.Size = new System.Drawing.Size(562, 653);
            this.uxResults.TabIndex = 1;
            this.uxResults.WordWrap = false;
            // 
            // bt_ActorGenreMovies
            // 
            this.bt_ActorGenreMovies.Location = new System.Drawing.Point(348, 235);
            this.bt_ActorGenreMovies.Name = "bt_ActorGenreMovies";
            this.bt_ActorGenreMovies.Size = new System.Drawing.Size(168, 74);
            this.bt_ActorGenreMovies.TabIndex = 7;
            this.bt_ActorGenreMovies.Text = "Filter for Movies with Certain Actors and Genres";
            this.bt_ActorGenreMovies.UseVisualStyleBackColor = true;
            this.bt_ActorGenreMovies.Click += new System.EventHandler(this.bt_ActorGenreMovies_Click);
            // 
            // bt_ActorInCommon
            // 
            this.bt_ActorInCommon.Location = new System.Drawing.Point(348, 17);
            this.bt_ActorInCommon.Name = "bt_ActorInCommon";
            this.bt_ActorInCommon.Size = new System.Drawing.Size(168, 75);
            this.bt_ActorInCommon.TabIndex = 9;
            this.bt_ActorInCommon.Text = "Find Actor In Common";
            this.bt_ActorInCommon.UseVisualStyleBackColor = true;
            this.bt_ActorInCommon.Click += new System.EventHandler(this.bt_ActorInCommon_Click);
            // 
            // bt_goodReview
            // 
            this.bt_goodReview.Location = new System.Drawing.Point(348, 134);
            this.bt_goodReview.Name = "bt_goodReview";
            this.bt_goodReview.Size = new System.Drawing.Size(168, 69);
            this.bt_goodReview.TabIndex = 10;
            this.bt_goodReview.Text = "Filter for Good Reviews";
            this.bt_goodReview.UseVisualStyleBackColor = true;
            this.bt_goodReview.Click += new System.EventHandler(this.bt_goodReview_Click);
            // 
            // bt_ShowingInfo
            // 
            this.bt_ShowingInfo.Location = new System.Drawing.Point(348, 343);
            this.bt_ShowingInfo.Name = "bt_ShowingInfo";
            this.bt_ShowingInfo.Size = new System.Drawing.Size(168, 78);
            this.bt_ShowingInfo.TabIndex = 11;
            this.bt_ShowingInfo.Text = "Showing Info";
            this.bt_ShowingInfo.UseVisualStyleBackColor = true;
            this.bt_ShowingInfo.Click += new System.EventHandler(this.bt_ShowingInfo_Click);
            // 
            // bt_Movies
            // 
            this.bt_Movies.Location = new System.Drawing.Point(18, 18);
            this.bt_Movies.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_Movies.Name = "bt_Movies";
            this.bt_Movies.Size = new System.Drawing.Size(112, 74);
            this.bt_Movies.TabIndex = 12;
            this.bt_Movies.Text = "Movies";
            this.bt_Movies.UseVisualStyleBackColor = true;
            this.bt_Movies.Click += new System.EventHandler(this.bt_Movies_Click);
            // 
            // bt_ActorInfo
            // 
            this.bt_ActorInfo.Location = new System.Drawing.Point(18, 148);
            this.bt_ActorInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_ActorInfo.Name = "bt_ActorInfo";
            this.bt_ActorInfo.Size = new System.Drawing.Size(112, 74);
            this.bt_ActorInfo.TabIndex = 13;
            this.bt_ActorInfo.Text = "Actors";
            this.bt_ActorInfo.UseVisualStyleBackColor = true;
            this.bt_ActorInfo.Click += new System.EventHandler(this.bt_ActorInfo_Click);
            // 
            // bt_CinemaInfo
            // 
            this.bt_CinemaInfo.Location = new System.Drawing.Point(18, 277);
            this.bt_CinemaInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_CinemaInfo.Name = "bt_CinemaInfo";
            this.bt_CinemaInfo.Size = new System.Drawing.Size(112, 74);
            this.bt_CinemaInfo.TabIndex = 14;
            this.bt_CinemaInfo.Text = "Cinemas";
            this.bt_CinemaInfo.UseVisualStyleBackColor = true;
            this.bt_CinemaInfo.Click += new System.EventHandler(this.bt_CinemaInfo_Click);
            // 
            // bt_ReviewInfo
            // 
            this.bt_ReviewInfo.Location = new System.Drawing.Point(18, 411);
            this.bt_ReviewInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_ReviewInfo.Name = "bt_ReviewInfo";
            this.bt_ReviewInfo.Size = new System.Drawing.Size(112, 74);
            this.bt_ReviewInfo.TabIndex = 15;
            this.bt_ReviewInfo.Text = "Reviews";
            this.bt_ReviewInfo.UseVisualStyleBackColor = true;
            this.bt_ReviewInfo.Click += new System.EventHandler(this.bt_ReviewInfo_Click);
            // 
            // cmb_QuestionQueries
            // 
            this.cmb_QuestionQueries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_QuestionQueries.FormattingEnabled = true;
            this.cmb_QuestionQueries.Items.AddRange(new object[] {
            "ActorMovie",
            "ActorSalary",
            "DirectorMovie",
            "GenreMovie",
            "MovieReview",
            "ScoreReview",
            "StateCinema",
            "TotalSales"});
            this.cmb_QuestionQueries.Location = new System.Drawing.Point(14, 557);
            this.cmb_QuestionQueries.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmb_QuestionQueries.Name = "cmb_QuestionQueries";
            this.cmb_QuestionQueries.Size = new System.Drawing.Size(180, 28);
            this.cmb_QuestionQueries.TabIndex = 16;
            // 
            // bt_QuestionQuery
            // 
            this.bt_QuestionQuery.Location = new System.Drawing.Point(243, 557);
            this.bt_QuestionQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bt_QuestionQuery.Name = "bt_QuestionQuery";
            this.bt_QuestionQuery.Size = new System.Drawing.Size(153, 89);
            this.bt_QuestionQuery.TabIndex = 17;
            this.bt_QuestionQuery.Text = "Lookup";
            this.bt_QuestionQuery.UseVisualStyleBackColor = true;
            this.bt_QuestionQuery.Click += new System.EventHandler(this.bt_QuestionQuery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 695);
            this.Controls.Add(this.bt_QuestionQuery);
            this.Controls.Add(this.cmb_QuestionQueries);
            this.Controls.Add(this.bt_ReviewInfo);
            this.Controls.Add(this.bt_CinemaInfo);
            this.Controls.Add(this.bt_ActorInfo);
            this.Controls.Add(this.bt_Movies);
            this.Controls.Add(this.bt_ShowingInfo);
            this.Controls.Add(this.bt_goodReview);
            this.Controls.Add(this.bt_ActorInCommon);
            this.Controls.Add(this.bt_ActorGenreMovies);
            this.Controls.Add(this.uxResults);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox uxResults;
        private System.Windows.Forms.Button bt_ActorGenreMovies;
        private System.Windows.Forms.Button bt_ActorInCommon;
        private System.Windows.Forms.Button bt_goodReview;
        private System.Windows.Forms.Button bt_ShowingInfo;
        private System.Windows.Forms.Button bt_Movies;
        private System.Windows.Forms.Button bt_ActorInfo;
        private System.Windows.Forms.Button bt_CinemaInfo;
        private System.Windows.Forms.Button bt_ReviewInfo;
        private System.Windows.Forms.ComboBox cmb_QuestionQueries;
        private System.Windows.Forms.Button bt_QuestionQuery;
    }
}

