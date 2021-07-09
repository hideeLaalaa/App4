using UTM_App;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace utm
{

	public class materialData
	{
		public int ID { get; set; }
		public String Material_Name { get; set; }
		public String Material_Type { get; set; }
		public String Stress { get; set; }
		public String Strain { get; set; }
		public String Material_Strength { get; set; }
		public String DateTested { get; set; }

	}

	public class material
	{
		public static List<materialData> data = new List<materialData>();

		public material()
		{

		}

		public static void add(materialData x)
		{
			data.Add(x);
		}

		public static void remove(int x)
		{
			data.RemoveAt(x);
		}

	}

	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		List<materialData> data { get; set; }

		public MainPage(bool ongoing)
		{
			this.InitializeComponent();
			data = material.data;
			Console.Beep();
		}

		/// <summary>
		/// 
		/// </summary>
		public MainPage()
		{
			this.InitializeComponent();
			
			material x = new material();

			data = material.data;
			fireBaseConnect fb = new fireBaseConnect();
			

		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			if (e != null)
			{
				material.data = (e.Parameter as List<materialData>!=null
					? e.Parameter as List<materialData> : material.data);
			}
			
		}

		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			//MessageDialog messageDialog = new MessageDialog("content of the message","fkkfkfk");
			//messageDialog.ShowAsync();

			var cd = new ContentDialog1();
			await cd.ShowAsync();

			//Frame.Navigate(typeof(BlankPage2));
		}

		
	}
}




/*			material.add(new materialData
			{
				ID = 1,
				Material_Name = "rubber",
				Material_Type = "polymers",
				Stress = "20",
				Strain = "12",
				Material_Strength = "30",
				DateTested = "June 13"
			});
			material.add(new materialData
			{
				ID = 2,
				Material_Name = "rubber",
				Material_Type = "polymers",
				Stress = "20",
				Strain = "12",
				Material_Strength = "30",
				DateTested = "June 13"
			});
			material.add(new materialData
			{
				ID = 3,
				Material_Name = "rubber",
				Material_Type = "polymers",
				Stress = "20",
				Strain = "12",
				Material_Strength = "30",
				DateTested = "June 13"
			});
			material.add(new materialData
			{
				ID = 4,
				Material_Name = "rubber",
				Material_Type = "polymers",
				Stress = "20",
				Strain = "12",
				Material_Strength = "30",
				DateTested = "June 13"
			});
			material.add(new materialData
			{
				ID = 5,
				Material_Name = "aluminium",
				Material_Type = "metal",
				Stress = "50",
				Strain = "1",
				Material_Strength = "130",
				DateTested = "June 14"
			});*/
