using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace App4
{
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

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			this.Hide();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			this.Hide();
			Frame rootFrame = new Frame();
			rootFrame.Navigate(typeof(BlankPage2));
			Window.Current.Content = rootFrame;
			Window.Current.Activate();
		}
	}
}
