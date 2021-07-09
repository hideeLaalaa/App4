using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using utm;
using Windows.System.Threading;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UTM_App
{

	public sealed partial class BlankPage2 : Page
	{
		bool comp=false;
		System.Timers.Timer timer;
		int sec = 0;
		List<resultData> result = new List<resultData>();
		int Test;
		String Stress = "", Strain = "", Strength = "";
		public resultData resultData { get; set; }
        public int freq = 0;
        public int duration = 4;
        DispatcherTimer dispatcher;


        /// <summary>
        /// 
        /// </summary>
        public BlankPage2()
		{
			resultData = new resultData();
			this.InitializeComponent();
			save.Visibility = Visibility.Collapsed;
			delete.Visibility = Visibility.Collapsed;
			
			//operation.Text = MaterialData.Material_Name + " - " + (test == 0 ? "Tension Test" : "Compression Test");

		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			resultData = e.Parameter as resultData;
			operation.Text = resultData.matData.Material_Name + " - " + (resultData.testType == 0 ? "Tension Test" : "Compression Test");

		}

		public void testFinished()
		{
			

		}

		private void elapsedEvent(object sender, ElapsedEventArgs e)
		{
			//Task t = new Task(() => {

				loadingText.Text = "" + new Random().Next(200);

			//}, new CancellationToken(comp));
			//t.RunSynchronously();

		}


		private void Stop_Click(object sender, RoutedEventArgs e)
		{
			
			ContentDialog2 dialog = new ContentDialog2(this);
			dialog.ShowAsync();

		}

		private void Save_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Delete_Click(object sender, RoutedEventArgs e)
		{

		}

		public void saveData()
		{
			resultData.matData.Material_Strength = Strength;
			resultData.matData.Stress = Stress;
			resultData.matData.Strain = Strain;
			material.add(resultData.matData);
		}

        public void timerSetup()
        {
            freq = 0;
            dispatcher = new DispatcherTimer();
            dispatcher.Tick += timerTick;
            dispatcher.Interval = new TimeSpan(0,0,2);
            dispatcher.Start();
        }
        public void timerTick(object sender, object e)
        {
            if (freq <= duration)
            {
                freq += 2;
                loadingBar.Visibility = Visibility.Visible;
                //loadingText.Visibility = Visibility.Visible;

                try
                {
                    Stress = (fireBaseConnect.readFromFirebase("Stress") == "" ? "0" : fireBaseConnect.readFromFirebase("Stress"));
                    stressRes.Text = Stress;
                }
                catch { }
                try
                {
                    Strength = (fireBaseConnect.readFromFirebase("result") == "" ? "0" : fireBaseConnect.readFromFirebase("result"));
                    strengthRes.Text = Strength;
                }
                catch { }
                try
                {
                    Strain = (fireBaseConnect.readFromFirebase("Strain") == "" ? "0" : fireBaseConnect.readFromFirebase("Strain"));
                    strainRes.Text = Strain;
                }
                catch { }
                //loadingBar.Visibility = Visibility.Collapsed;
                //loadingText.Visibility = Visibility.Collapsed;
            }
            else
            {
                loadingBar.Visibility = Visibility.Collapsed;
                dispatcher.Stop();
            }
        }

        public void testDone()
		{
			fireBaseConnect.writeToFirebase("S");
            
			
			try
			{
				Stress = (fireBaseConnect.readFromFirebase("Stress") == "" ? "0" : fireBaseConnect.readFromFirebase("Stress"));
				stressRes.Text = Stress;
			}
			catch { }
			try
			{
				Strength = (fireBaseConnect.readFromFirebase("result") == "" ? "0" : fireBaseConnect.readFromFirebase("result"));
				strengthRes.Text = Strength;
			}
			catch { }
			try
			{
				Strain = (fireBaseConnect.readFromFirebase("Strain") == "" ? "0" : fireBaseConnect.readFromFirebase("Strain"));
				strainRes.Text = Strain;
			}
			catch { }
			operation.Text = operation.Text + " Completed";
			
			loadingBar.Visibility = Visibility.Collapsed;
			loadingText.Visibility = Visibility.Collapsed;
			stop.Visibility = Visibility.Collapsed;
			save.Visibility = Visibility.Visible;
			delete.Visibility = Visibility.Visible;
			save.IsEnabled = true;
			delete.IsEnabled = true;
		}

		private void Save_Click_1(object sender, RoutedEventArgs e)
		{
			ContentDialog2 dialog = new ContentDialog2(this, "Test Saved", "Do you wish to perform another test?", "Yes", "No");
			dialog.ShowAsync();
		}

		private void Delete_Click_1(object sender, RoutedEventArgs e)
		{
			ContentDialog2 dialog = new ContentDialog2(this, "Test Deleted", "Do you wish to perform another test?", "Yes", "No");
			dialog.ShowAsync();
		}

		private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
		{

		}
	}
}
