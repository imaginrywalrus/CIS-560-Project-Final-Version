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
        const string username = "";
        const string password = "";
        const string connectionString = @"Server=mssql.cs.ksu.edu;Database=kprice147;Integrated Security=false;UID=" + username + ";password=" + password;
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
            
            uxResults.Text += "Result\t";
            uxResults.Text += "Movie Title";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach (Movie i in movie)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.MovieName;
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_ActorSalary_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            double salary = a.ActorTotalSalary(firstName, lastName);

            uxResults.Text += "Result\t";
            uxResults.Text += "Salary";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            uxResults.Text += "1\t";
            uxResults.Text += salary.ToString();
            uxResults.AppendText(Environment.NewLine);
        }

        private void bt_DirectorMovies_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the director: ");

            string lastName = Interaction.InputBox("Last name of the director: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.DirectorMovies(firstName, lastName);

            uxResults.Text += "Result\t";
            uxResults.Text += "Movie Title";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach (Movie i in movie)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.MovieName;
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_GenreMovies_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Genre to search for: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.GenreMovies(genre);

            uxResults.Text += "Result\t";
            uxResults.Text += "Movie Title";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach (Movie i in movie)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.MovieName;
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_MovieReviews_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Movie to search for: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.MovieReviews(genre);

            uxResults.Text += "Result\t";
            uxResults.Text += "ReviewID\t ";
            uxResults.Text += "ReviewerID\t";
            uxResults.Text += "Rating\t";
            uxResults.Text += "ReviewSite\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach (Review i in review)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.ReviewID + "\t ";
                uxResults.Text += i.ReviewerID + "\t\t";
                uxResults.Text += i.Rating + "\t";
                uxResults.Text += i.ReviewSite + "\t";
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_ScoreReview_Click_1(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string state = Interaction.InputBox("State to search for: ");
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<Cinema> cinemas = a.StateCinemas(state);

            Cinema c = new Cinema(1, "kansas", "manhattan", "111 This street");
            List<Cinema> cinemas = new List<Cinema>();
            cinemas.Add(c);

            uxResults.Text += "Result\t";
            uxResults.Text += "State\t\t";
            uxResults.Text += "City\t\t";
            uxResults.Text += "Address\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach (Cinema i in cinemas)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.State + "\t\t";
                uxResults.Text += i.City + "\t";
                uxResults.Text += i.Address + "\t";
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_TotalSales_Click_1(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string movie = Interaction.InputBox("Movie to search for: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            double total = a.TotalSales(movie);
            uxResults.Text += "Result\t";
            uxResults.Text += "TotalSales\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);

            uxResults.Text += "1\t";
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

            uxResults.Text += "Result\t";
            uxResults.Text += "ActorName\t\t";
            uxResults.Text += "MovieName\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach ((Actor, Actor, Movie) triple in commonList)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += triple.Item2.FirstName + " " + triple.Item2.LastName + "\t\t";
                uxResults.Text += triple.Item3.MovieName;
                uxResults.AppendText(Environment.NewLine);
                x++;
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

            uxResults.Text += "Result\t";
            uxResults.Text += "TotalReviews\t";
            uxResults.Text += "Rating\t";
            uxResults.Text += "MovieName\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach ((Movie, int, int) quin in reviewList)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += quin.Item2 + "\t\t";
                uxResults.Text += quin.Item3 + "\t";
                uxResults.Text += quin.Item1.MovieName + "\t";
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_goodReview_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string score = Interaction.InputBox("Rating to filter by (1-10): ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<(Review, Movie, int[])> review = a.GoodReview(Convert.ToInt32(score));
    
            uxResults.Text += "Result\t";
            uxResults.Text += "DramaCount   ";
            uxResults.Text += "CrimeCount\t";
            uxResults.Text += "ActionCount   ";
            uxResults.Text += "BiographyCount   ";
            uxResults.Text += "HistoryCount   ";
            uxResults.Text += "AdventureCount   ";
            uxResults.Text += "WesternCount   ";
            uxResults.Text += "ReviewerID\t";
            uxResults.Text += "Rating\t";
            uxResults.Text += "MovieName\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach ((Review, Movie, int[]) i in review)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.Item3[0].ToString() + "\t       ";
                uxResults.Text += i.Item3[1].ToString() + "\t\t";
                uxResults.Text += i.Item3[2].ToString() + "\t      ";
                uxResults.Text += i.Item3[3].ToString() + "\t\t   ";
                uxResults.Text += i.Item3[4].ToString() + "\t          ";
                uxResults.Text += i.Item3[5].ToString() + "\t\t      ";
                uxResults.Text += i.Item3[6].ToString() + "\t\t";
                uxResults.Text += i.Item1.ReviewerID + "\t\t";
                uxResults.Text += i.Item1.Rating + "\t";
                uxResults.Text += i.Item2.MovieName + "\t";
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_ShowingInfo_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<(Cinema, string, double, double)> review = a.ShowingInfo();

            uxResults.Text += "Result\t";
            uxResults.Text += "CinemaID\t ";
            uxResults.Text += "State\t\t";
            uxResults.Text += "Sales\t";
            uxResults.Text += "RunningTotal\t";
            uxResults.Text += "MovieName\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach ((Cinema, string, double, double) i in review)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.Item1.CinemaID + "\t";
                uxResults.Text += i.Item1.State + "\t";
                
                uxResults.Text += i.Item3.ToString() + "\t";
                uxResults.Text += i.Item4.ToString() + "\t\t";
                uxResults.Text += i.Item2 + "\t";


                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_ScoreReview_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Score To filter: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.ScoreReviews(Convert.ToInt32(genre));

            uxResults.Text += "Result\t";
            uxResults.Text += "ReviewID\t ";
            uxResults.Text += "ReviewerID\t";
            uxResults.Text += "Rating\t";
            uxResults.Text += "ReviewSite\t";
            uxResults.AppendText(Environment.NewLine);
            uxResults.AppendText(Environment.NewLine);
            int x = 1;
            foreach (Review i in review)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += i.ReviewID + "\t ";
                uxResults.Text += i.ReviewerID + "\t\t";
                uxResults.Text += i.Rating + "\t";
                uxResults.Text += i.ReviewSite + "\t";
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }
    }
} 
