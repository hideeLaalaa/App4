using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using utm;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UTM_App
{

	public class resultData
	{
		public materialData matData { get; set; }
		public int testType { get; set; }
	}

	public sealed partial class ContentDialog1 : ContentDialog
	{
		public ContentDialog1()
		{
			this.InitializeComponent();
		}

		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			int test = testType.SelectedIndex;
			fireBaseConnect.writeToFirebase((test==0?"T":"C"));
			this.Hide();
			Frame rootFrame = new Frame();
			var Parameter = new resultData
			{
				matData = new materialData
				{
					ID = material.data.ToArray().Length+1,
					Material_Name = materialName.Text,
					Material_Type = materialType.SelectionBoxItem.ToString(),
					Stress = "0",
					Strain = "0",
					Material_Strength = "0",
					DateTested = DateTime.Now.ToString()
				},
				testType = test
			};
			rootFrame.Navigate(typeof(BlankPage2), Parameter);
			Window.Current.Content = rootFrame;
			Window.Current.Activate();
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
		}

		private void MoveUp_Click(object sender, RoutedEventArgs e)
		{
			fireBaseConnect.writeToFirebase("U");
		}

		private void MoveDown_Click(object sender, RoutedEventArgs e)
		{
			fireBaseConnect.writeToFirebase("D");
		}
	}
}
