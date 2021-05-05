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
        const string database = "kprice147";
        const string username = "kprice147";
        const string password = "Hershykissess1.";
        const string connectionString = @"Server=mssql.cs.ksu.edu;Database=" + database + ";Integrated Security=false;UID=" + username + ";password=" + password;

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Movies_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";

            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.DisplayMovieInfo();
            if (movie == null)
            {
                MessageBox.Show("No Results Found");
            }
            int x = 1;
            foreach (Movie i in movie)
            {
                uxResults.Text += x.ToString() + "\t";
                uxResults.Text += "MovieID: " + i.MovieID.ToString() + "\t";
                uxResults.Text += "Movie Name: " + i.MovieName + "\t";
                uxResults.Text += "Genre1: " + i.Genre1 + "\t";
                uxResults.Text += "Genre2: " + i.Genre2 + "\t";
                uxResults.Text += "Genre3: " + i.Genre3 + "\t";
                uxResults.Text += "Cost of Production: " + i.CostOfProduction.ToString() + "\t";
                uxResults.Text += "Release Date: " + i.ReleaseDate.ToString() + "\t";
                uxResults.AppendText(Environment.NewLine);
                x++;
            }
        }

        private void bt_ActorInfo_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";

            SqlActorRepository a = new SqlActorRepository(connectionString);
            IReadOnlyList<Actor> actor = a.DisplayActorInfo();
            if (actor == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Actor i in actor)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "ActorID: " + i.ActorID.ToString() + "\t";
                    uxResults.Text += "Actor Name: " + i.FirstName + " " + i.MiddleName + " " + i.LastName + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void bt_CinemaInfo_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";

            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<Cinema> cinema = a.DisplayCinemaInfo();
            if (cinema == null)
            {
                MessageBox.Show("No Results Found");
            }
            else { 
            int x = 1;
                foreach (Cinema i in cinema)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "CinemaID: " + i.CinemaID.ToString() + "\t";
                    uxResults.Text += "State: " + i.State + "\t";
                    uxResults.Text += "City: " + i.City + "\t";
                    uxResults.Text += "Address: " + i.Address + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void bt_ReviewInfo_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";

            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.DisplayReviewInfo();
            if (review == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Review i in review)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "ReviewID: " + i.ReviewID.ToString() + "\t";
                    uxResults.Text += "UserID: " + i.ReviewerID.ToString() + "\t";
                    uxResults.Text += "MovieID: " + i.MovieID.ToString() + "\t";
                    uxResults.Text += "Rating: " + i.Rating.ToString() + "\t";
                    uxResults.Text += "Review Site: " + i.ReviewSite + "\t";
                    uxResults.Text += "Review: " + i.ReviewText + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (cmb_AddData.Text == "Actor")
            {
                AddActor();
            }
            else if (cmb_AddData.Text == "Cinema")
            {
                AddCinema();
            }
            else if (cmb_AddData.Text == "Director")
            {
                AddDirector();
            }
            else if (cmb_AddData.Text == "Movie")
            {
                AddMovie();
            }
            else if (cmb_AddData.Text == "Review")
            {
                AddReview();
            }
            else if (cmb_AddData.Text == "Reviewer")
            {
                AddReviewer();
            }
            else if (cmb_AddData.Text == "Add Existing Actor to Existing Movie")
            {
                AddMovieActor();
            }
            else if (cmb_AddData.Text == "Set an existing movie to play at an existing cinema")
            {
                AddMovieCinema();
            }
            else if (cmb_AddData.Text == "Add Existing Director to Existing Movie")
            {
                AddMovieDirector();
            }
            else
            {
                uxResults.Text += "";
                uxResults.Text += "Please Select an option in the drop down box";
            }
        }

        private void AddActor()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");
            string middleName = Interaction.InputBox("Middle name of the actor: ");
            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            Actor actor = a.AddActor(firstName, middleName, lastName);
            if (actor == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddCinema()
        {
            uxResults.Text = "";
            string state = Interaction.InputBox("State the cinema is in: ");
            string city = Interaction.InputBox("City the cinema is in: ");
            string address = Interaction.InputBox("Address of the cinema: ");
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            Cinema cinema = a.AddCinema(state, city, address);
            if (cinema == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddDirector()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the director: ");
            string middleName = Interaction.InputBox("Middle name of the director: ");
            string lastName = Interaction.InputBox("Last name of the director: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            Director director = a.AddDirector(firstName, middleName, lastName);
            if (director == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddMovie()
        {
            uxResults.Text = "";
            string movieName = Interaction.InputBox("Name of the movie: ");
            string genre1 = Interaction.InputBox("First genre of movie: ");
            string genre2 = Interaction.InputBox("Second genre of movie: ");
            string genre3 = Interaction.InputBox("Third genre of movie: ");
            string releaseDate = Interaction.InputBox("Release date of movie: \nYear-Month-Date (1999-12-04)");
            string costofProduction = Interaction.InputBox("Cost of production for the movie: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            Movie movie = a.AddMovie(movieName, genre1, genre2, genre3, Convert.ToDateTime(releaseDate), Convert.ToDouble(costofProduction));
            if (movie == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddReview()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the reviewer: ");
            string lastName = Interaction.InputBox("Last name of the reviewer: ");
            string movieName = Interaction.InputBox("Name of the movie ");
            string rating = Interaction.InputBox("Rating of the movie: ");
            string Review = Interaction.InputBox("The review of the movie: ");
            string reviewSite = Interaction.InputBox("Website that review was left on: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            Review review = a.AddReview(firstName, lastName, movieName, Convert.ToInt32(rating), Review, reviewSite);
            if (review == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddReviewer()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the reviewer: ");
            string lastName = Interaction.InputBox("Last name of the reviewer: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            Reviewer reviewer = a.AddReviewer(firstName, lastName);
            if (reviewer == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddMovieActor()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the Actor: ");
            string lastName = Interaction.InputBox("Last name of the Actor: ");
            string movieName = Interaction.InputBox("Name of the movie ");
            string salary = Interaction.InputBox("The salary of the actor on the movie: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            MovieActor movieActor = a.AddMovieActor(Convert.ToDouble(salary), firstName, lastName, movieName);
            if (movieActor == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddMovieDirector()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the Actor: ");
            string lastName = Interaction.InputBox("Last name of the Actor: ");
            string movieName = Interaction.InputBox("Name of the movie ");
            string salary = Interaction.InputBox("The salary of the actor on the movie: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            MovieDirector movieDirector = a.AddMovieDirector(Convert.ToDouble(salary), firstName, lastName, movieName);
            if (movieDirector == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void AddMovieCinema()
        {
            uxResults.Text = "";
            string address = Interaction.InputBox("Address of the cinema: ");
            string moveName = Interaction.InputBox("Name of the movie: ");
            string playingTime = Interaction.InputBox("Playing time of the movie: \nYear-Month-Date Hour:Minute:Second (1999-12-04 11:30:00)");
            string ticketsSold = Interaction.InputBox("Tickets sold for the movie: ");
            string ticketPrice = Interaction.InputBox("Ticket price of the movie: ");
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            MovieCinema review = a.AddMovieCinema(address, moveName, Convert.ToDateTime(playingTime), Convert.ToDouble(ticketsSold), Convert.ToDouble(ticketPrice));
            if (review == null)
            {
                MessageBox.Show("Insert attempt failed");
            }
        }

        private void bt_ActorInCommon_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            IReadOnlyList<(Actor, Actor, Movie)> commonList = a.ActorInCommon(firstName, lastName);
            if (commonList == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach ((Actor, Actor, Movie) triple in commonList)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "Actor Name: " + triple.Item2.FirstName + " " + triple.Item2.MiddleName + " " + triple.Item2.LastName + "\t";
                    uxResults.Text += "Movie Name: " + triple.Item3.MovieName;
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
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
            if (reviewList == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach ((Movie, int, int) quin in reviewList)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "Total Reviews: " + quin.Item2 + "\t";
                    uxResults.Text += "Rating: " + quin.Item3 + "\t";
                    uxResults.Text += "Movie Name: " + quin.Item1.MovieName + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void bt_goodReview_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string score = Interaction.InputBox("Rating to filter by (1-10): ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<(Review, Movie, int[])> review = a.GoodReview(Convert.ToInt32(score));
            if (review == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach ((Review, Movie, int[]) i in review)
                {
                    uxResults.Text += x.ToString() + "\t" + "MovieName: " + i.Item2.MovieName + "\t" + "ReviewerID: " + i.Item1.ReviewerID + "\t" + "Rating: " + i.Item1.Rating + "\t" +
                        "DramaCount: " + i.Item3[0].ToString() + "\t" + "CrimeCount: " + i.Item3[1].ToString() + "\t" + "ActionCount: " + i.Item3[2].ToString() + "\t" +
                        "BiographyCount: " + i.Item3[3].ToString() + "\t" + "HistoryCount: " + i.Item3[4].ToString() + "\t" + "AdventureCount: " + i.Item3[5].ToString() + "\t" +
                        "WesternCount: " + i.Item3[6].ToString() + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void bt_ShowingInfo_Click(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string state = Interaction.InputBox("Enter State to Search for: ");
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<(Cinema, string, double, double)> review = a.ShowingInfo(state);
            if (review == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach ((Cinema, string, double, double) i in review)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "CinemaID: " + i.Item1.CinemaID + "\t";
                    uxResults.Text += "State: " + i.Item1.State + "\t";
                    uxResults.Text += "Sales: " + i.Item3.ToString() + "\t";
                    uxResults.Text += "RunningTotal: " + i.Item4.ToString() + "\t";
                    uxResults.Text += "MovieName: " + i.Item2 + "\t";


                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void bt_QuestionQuery_Click(object sender, EventArgs e)
        {
            if (cmb_QuestionQueries.Text == "Find Actor Movies")
            {
                ActorMovie();
            }
            else if (cmb_QuestionQueries.Text == "Find Actor Salary")
            {
                ActorSalary();
            }
            else if (cmb_QuestionQueries.Text == "Find Director Movies")
            {
                DirectorMovies();
            }
            else if (cmb_QuestionQueries.Text == "Find Genre Movies")
            {
                GenreMovies();
            }
            else if (cmb_QuestionQueries.Text == "Find Movie Review")
            {
                MovieReviews();
            }
            else if (cmb_QuestionQueries.Text == "Find Score Review")
            {
                ScoreReview();
            }
            else if (cmb_QuestionQueries.Text == "Find State Cinemas")
            {
                stateCinemas();
            }
            else if (cmb_QuestionQueries.Text == "Get Total Sales")
            {
                TotalSales();
            }
            else
            {
                uxResults.Text += "";
                uxResults.Text += "Please Select an option in the drop down box";
            }
        }

        private void ActorMovie()
        {
            uxResults.Text = "";

            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");

            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.ActorMovie(firstName, lastName);
            if (movie == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Movie i in movie)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "Movie Title: " + i.MovieName;
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }

        }

        private void ActorSalary()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            double salary = a.ActorTotalSalary(firstName, lastName);
            if (salary == -1)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                uxResults.Text += "Salary: " + salary.ToString();
                uxResults.AppendText(Environment.NewLine);
            }
        }

        private void DirectorMovies()
        {
            uxResults.Text = "";
            string firstName = Interaction.InputBox("First name of the director: ");

            string lastName = Interaction.InputBox("Last name of the director: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.DirectorMovies(firstName, lastName);
            if (movie == null)
            {
                MessageBox.Show("No Results Found");
            }
            else { 
            int x = 1;
                foreach (Movie i in movie)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "Movie Title: " + i.MovieName;
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void GenreMovies()
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Genre to search for: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.GenreMovies(genre);
            if (movie == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Movie i in movie)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "Movie Title: " + i.MovieName;
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void MovieReviews()
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Movie to search for: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.MovieReviews(genre);
            if (review == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Review i in review)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "ReviewID: " + i.ReviewID + "\t ";
                    uxResults.Text += "ReviewerID: " + i.ReviewerID + "\t";
                    uxResults.Text += "Rating: " + i.Rating + "\t";
                    uxResults.Text += "Review Site: " + i.ReviewSite + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void ScoreReview()
        {
            uxResults.Text = "";
            string genre = Interaction.InputBox("Score To filter: ");
            SqlReviewRepository a = new SqlReviewRepository(connectionString);
            IReadOnlyList<Review> review = a.ScoreReviews(Convert.ToInt32(genre));
            if (review == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Review i in review)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "ReviewID: " + i.ReviewID + "\t ";
                    uxResults.Text += "ReviewerID: " + i.ReviewerID + "\t";
                    uxResults.Text += "Rating: " + i.Rating + "\t";
                    uxResults.Text += "Review Site: " + i.ReviewSite + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }


        private void stateCinemas()
        {
            uxResults.Text = "";
            string state = Interaction.InputBox("State to search for: ");
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<Cinema> cinemas = a.StateCinemas(state);
            if (cinemas == null)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                int x = 1;
                foreach (Cinema i in cinemas)
                {
                    uxResults.Text += x.ToString() + "\t";
                    uxResults.Text += "State: " + i.State + "\t\t";
                    uxResults.Text += "City: " + i.City + "\t";
                    uxResults.Text += "Address: " + i.Address + "\t";
                    uxResults.AppendText(Environment.NewLine);
                    x++;
                }
            }
        }

        private void TotalSales()
        {
            uxResults.Text = "";
            string movie = Interaction.InputBox("Movie to search for: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            double total = a.TotalSales(movie);
            if (total == -1)
            {
                MessageBox.Show("No Results Found");
            }
            else
            {
                uxResults.Text += "Total Sales: " + total;
                uxResults.AppendText(Environment.NewLine);
            }
        }


    }
} 
