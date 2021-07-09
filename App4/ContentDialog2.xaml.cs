using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using utm;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
	public sealed partial class ContentDialog2 : ContentDialog
	{
		BlankPage2 page;
		bool stopOption = true;
		public ContentDialog2(BlankPage2 bp)
		{
			this.InitializeComponent();
			page = bp;
		}

		public ContentDialog2( BlankPage2 bp,String title,String message,String left,String right)
		{
			this.InitializeComponent();
			this.title.Text = title;
			contentMessage.Text = message;
			leftButton.Content = left;
			leftButton.Background = new SolidColorBrush(Color.FromArgb(255,55,38,122));
			leftButton.Foreground = new SolidColorBrush(Color.FromArgb(255,255,255,255));
			rightButton.Content = right;
			rightButton.Background = null;
			rightButton.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
			rightButton.BorderBrush = leftButton.BorderBrush;
			leftButton.BorderBrush = new SolidColorBrush(Color.FromArgb(255,255,255,255));
			stopOption = false;
			page = bp;
		}

		private void leftButton_Click(object sender, RoutedEventArgs e)
		{
			if (stopOption)
			{
				page.testDone();
				this.Hide();
                page.timerSetup();
			}
			else
			{//start new test
				if (title.Text.Equals("Test Saved"))
					page.saveData();
				this.Hide();
				var cd = new ContentDialog1();
			
				cd.ShowAsync();
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
		}

		private void rightButton_Click(object sender, RoutedEventArgs e)
		{
			if (stopOption)
			{
				this.Hide();
			}
			else
			{//case go to home page
				if(title.Text.Equals("Test Saved"))
					page.saveData();
				this.Hide();
				Frame rootFrame = new Frame();
				bool stat = true;
				var parameter = material.data;
				rootFrame.Navigate(typeof(MainPage),parameter);
				Window.Current.Content = rootFrame;
				Window.Current.Activate();
				
			}
		}
		private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

	}
}
