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
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlMoviesRepository a = new SqlMoviesRepository(connectionString);
            IReadOnlyList<Movie> movie = a.ActorMovie(firstName, lastName);

            foreach (Movie i in movie)
            {
                uxResults.Text += i.ToString();
            }
        }

        private void bt_ActorTotalSalary_Click(object sender, EventArgs e)
        {
            string firstName = Interaction.InputBox("First name of the actor: ");

            string lastName = Interaction.InputBox("Last name of the actor: ");
            SqlActorRepository a = new SqlActorRepository(connectionString);
            double salary = a.ActorTotalSalary(firstName, lastName);

        }
    }
}
