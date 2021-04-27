using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoviesData.Models;
using MoviesData;
using DataAccess;
using Microsoft.VisualBasic;

namespace ApplicationForm
{
    public partial class Form1 : Form
    {
        const string connectionString = @"Server=mssql.cs.ksu.edu;Database=kprice147;Integrated Security=false;UID=kprice147;password=sHsiyshse1eskr.";
        private SqlMoviesRepository movie;
        private SqlActorRepository actor;
        private SqlCinemaRepository cinema;
        private SqlReviewRepository review;

        public Form1()
        {
            InitializeComponent();
            movie = new SqlMoviesRepository(connectionString);
            actor = new SqlActorRepository(connectionString);
            cinema = new SqlCinemaRepository(connectionString);
            review = new SqlReviewRepository(connectionString);
        }

        private void bt_ActorMovie_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.ActorMovie(firstName, lastName);

            foreach (Movie i in movie)
            {
                uxResults.Text += i.MovieName;
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_ActorSalary_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            double salary = a.ActorTotalSalary(firstName, lastName);
            uxResults.Text += salary.ToString();
        }

        private void bt_DirectorMovies_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the director: ");

            string lastName = Interaction.InputBox("Last name of the director: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.DirectorMovies(firstName, lastName);
            foreach (Movie i in movie)
            {
                uxResults.Text += i.MovieName;
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_GenreMovies_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Genre to search for: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.GenreMovies(genre);
            foreach (Movie i in movie)
            {
                uxResults.Text += i.MovieName;
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_MovieReviews_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Movie to search for: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.MovieReviews(genre);
            
            foreach (Review i in review)
            {
                uxResults.Text += i.ReviewID + "   ";
                uxResults.Text += i.ReviewerID + "   ";
                uxResults.Text += i.Rating + "   ";
                uxResults.Text += i.ReviewSite + "   ";
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_ScoreReview_Click_1(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Rating to filter by (1-10): ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.ScoreReviews(Convert.ToInt32(genre));

            foreach (Review i in review)
            {
                uxResults.Text += i.ReviewID + "   ";
                uxResults.Text += i.MovieID + "   ";
                uxResults.Text += i.Rating + "   ";
                uxResults.Text += i.ReviewerID + "   ";
                uxResults.Text += i.ReviewSite + "   ";
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_TotalSales_Click_1(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string movie = Interaction.InputBox("Movie to search for: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            double total = a.TotalSales(movie);

            uxResults.Text += total;
            uxResults.AppendText(Environment.NewLine);
        }

        private void bt_ActorInCommon_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            IReadOnlyList<(Actor, Actor, Movie)> commonList = a.ActorInCommon(firstName, lastName);
            foreach ((Actor, Actor, Movie) triple in commonList)
            {
                uxResults.Text += triple.Item2.FirstName + " " + triple.Item2.LastName + " in ";
                uxResults.Text += triple.Item3.MovieName;
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_ActorGenreMovies_Click(object sender, EventArgs e)
        {
            //For a given actor, show all movies they were in that was a certain genre and in a given range of review scores along with
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            string genre = Interaction.InputBox("Genre to search for: ");
            int ratingMin = Convert.ToInt32(Interaction.InputBox("Minimum rating to allow: "));
            int ratingMax = Convert.ToInt32(Interaction.InputBox("Maximum rating to allow: "));
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<(Movie, int, int)> reviewList = a.ActorGenreMovies(firstName, lastName, genre, ratingMin, ratingMax);
            foreach ((Movie, int, int) quin in reviewList)
            {
                uxResults.Text += quin.Item1.MovieName;
                uxResults.Text += quin.Item2 + ", ";
                uxResults.Text += quin.Item3;
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_goodReview_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string score = Interaction.InputBox("Rating to filter by (1-10): ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<(Review, Movie, int, int, int, int, int, int, int)> review = a.GoodReview(Convert.ToInt32(score));

            foreach ((Review, Movie, int, int, int, int, int, int, int) i in review)
            {
              
                uxResults.Text += i.Item1.ReviewerID + "   ";
                uxResults.Text += i.Item2.MovieName + "   ";
                uxResults.Text += i.Item1.Rating + "   ";
                uxResults.Text += i.Item3.ToString() + "   ";
                uxResults.Text += i.Item4.ToString() + "   ";
                uxResults.Text += i.Item5.ToString() + "   ";
                uxResults.Text += i.Item6.ToString() + "   ";
                uxResults.Text += i.Item7.ToString() + "   ";
                uxResults.Text += i.Item8.ToString() + "   ";
                uxResults.Text += i.Item9.ToString() + "   ";
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_ShowingInfo_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<(Cinema, string, double, double)> review = a.ShowingInfo();

            foreach((Cinema, string, double, double) i in review)
            {
                uxResults.Text += i.Item1.CinemaID + "   ";
                uxResults.Text += i.Item1.State + "   ";
                uxResults.Text += i.Item2 + "   ";
                uxResults.Text += i.Item3.ToString() + "   ";
                uxResults.Text += i.Item4.ToString() + "   ";
                

                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void bt_ScoreReview_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Score To filter: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.ScoreReviews(Convert.ToInt32(genre));

            foreach (Review i in review)
            {
                uxResults.Text += i.ReviewID + "   ";
                uxResults.Text += i.ReviewerID + "   ";
                uxResults.Text += i.Rating + "   ";
                uxResults.Text += i.ReviewSite + "   ";
                uxResults.AppendText(Environment.NewLine);
            }
        }
    }
}
