using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using Firebase.Database;
using FireSharp;
using FireSharp.Config;
using FireSharp.Extensions;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database.Query;
using Timer = System.Threading.Timer;
using FirebaseClient = Firebase.Database.FirebaseClient;

namespace WFAFirebase1
{
    public partial class Form1 : Form
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://doggywalkerapp-2a5d0-default-rtdb.firebaseio.com/"); //the path to the database
     
        private Timer _checker;         // timer for periodic update
        public Form1()
        {
            //create the view
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the timer to start scheduling the task on form load
            SetWeeklyTimer();
            FillCmb();
        }



        //function for filling the view window with the times of the timer
        private void FillCmb()
        {
            for (int i = 0; i < 24; i++)
            {
                cmbHH.Items.Add(String.Format("{0:00}", i));
            }
            cmbHH.SelectedIndex = 2;
            for (int i = 0; i < 60; i++)
            {
                cmbMM.Items.Add(String.Format("{0:00}", i));
            }
            cmbMM.SelectedIndex = 0;
        }

        private void SetWeeklyTimer()
        {
            // Calculate the time until next Sunday 1:00 AM
            DateTime nextSunday = DateTime.Today.AddDays((7 - (int)DateTime.Today.DayOfWeek) % 7).AddHours(1);
            TimeSpan timeUntilNextSunday = nextSunday - DateTime.Now;

            // If today is Sunday and the current time is already past 1:00 AM, schedule the next run for next Sunday
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday && DateTime.Now.TimeOfDay >= TimeSpan.FromHours(1))
            {
                nextSunday = nextSunday.AddDays(7);
                timeUntilNextSunday = nextSunday - DateTime.Now;
            }
            System.Diagnostics.Debug.WriteLine($"Next execution of SetWeeklyTimer() on: {nextSunday}");

            // Create a timer that will execute the specified function at the next Sunday 1:00 AM and every week thereafter
            _checker = new Timer(state => Checker(), null, timeUntilNextSunday, TimeSpan.FromDays(7));
        }

        //function for filling the view of the timer
        private void SetTimer(int hh, int mm)
        {
            try
            {
                var due = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hh, mm, 0);
                var span = due.Subtract(DateTime.Now);

                while (span.TotalMilliseconds < 0)
                {
                    due = due.AddDays(1);
                    span = due.Subtract(DateTime.Now);
                }
                System.Diagnostics.Debug.WriteLine("Setting checker to check at {0:dd MMM yyyy HH:mm} (~{1} minutes)",
                    due, Math.Round(span.TotalMinutes, 0));

                _checker = new Timer(ob => Checker(), null, (long)span.TotalMilliseconds, (long)Timeout.Infinite);
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }

        //function for exucute the function UpdateDogWalkersList()
        private void Checker()
        {
            this.Invoke((MethodInvoker) async delegate
            {
                await UpdateDogWalkersList();
                MessageBox.Show("Data updated");
            });
        }

        //button of the set timer
        private void btnSetTimer_Click(object sender, EventArgs e)
        {
            SetTimer(cmbHH.SelectedIndex, cmbMM.SelectedIndex);
        }

        private async Task UpdateDogWalkersList()
        {
            // ArrayList to store the data
            List<Data> dogWalkersList = new List<Data>();


            // Retrieve all data under the "DogWalkersFolder/DogWalkers" 
            var dataSnapshot = await firebaseClient
               .Child("DogWalkersFolder")
               .Child("DogWalkers")
               .OnceAsync<Data>();


            foreach (var item in dataSnapshot)
            {
                Data data = item.Object;
                System.Diagnostics.Debug.WriteLine(data);
                dogWalkersList.Add(data);
            }

            // update the other days refernces with the dogWalkersList
            string[] weekdays = new string[] {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };

            //update each day with the right list
            foreach (string day in weekdays)
            {
                await UpdateReference(dogWalkersList, day);
            }


        }

        //update reference with the dog walkers list that includes dog walker class
        private async Task UpdateReference(List<Data> dogWalkersList, string path)
        {
            try
            {
                var updateReference = firebaseClient.Child("DogWalkersFolder/" + path);

                foreach (var data in dogWalkersList)
                {
                    await updateReference
                        .Child(data.walkerId)
                        .PutAsync(data);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred while updating the new reference: {ex.Message}");
            }

        }
    }
}
