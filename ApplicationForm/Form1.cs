﻿using System;
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

            uxResults.Text += total.ToString();
            uxResults.AppendText(Environment.NewLine);
        }

        private void bt_stateCinemas_Click_1(object sender, EventArgs e)
        {
            uxResults.Text = "";
            string state = Interaction.InputBox("State to search for: ");
            SqlCinemaRepository a = new SqlCinemaRepository(connectionString);
            IReadOnlyList<Cinema> cinemas = a.StateCinemas(state);

            foreach (Cinema i in cinemas)
            {
                uxResults.Text += i.Address + ", " + i.City + ", " + i.State;
                uxResults.AppendText(Environment.NewLine);
            }
        }
    }
}
