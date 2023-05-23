﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KIT206_A3.Controllers;
using KIT206_A3.Objects;

namespace KIT206_A3_WPF.Views
{
	/// <summary>
	/// Interaction logic for PublicationListView.xaml
	/// </summary>
	public partial class PublicationListView : UserControl
	{
		private int _startYear = 0;
		private int _endYear = DateTime.Now.Year;

		public PublicationListView()
		{
			InitializeComponent();
		}

		public void UpdatePublicationList(Researcher researcher)
		{
			publication_list.ItemsSource = PublicationController.LoadPublicationList(researcher);
		}

		private void OnYearFromFilterEnter(object sender, KeyEventArgs e)
		{
			if(!Int32.TryParse((sender as TextBox).Text, out _startYear))
			{
				_startYear = 0;
			}
			
			publication_list.ItemsSource = PublicationController.LoadPublicationList(_startYear, _endYear);
		}

		private void OnYearToFilterEnter(object sender, KeyEventArgs e)
		{
			if(!Int32.TryParse((sender as TextBox).Text, out _endYear))
			{
				_endYear = DateTime.Now.Year;
			}

			publication_list.ItemsSource = PublicationController.LoadPublicationList(_startYear, _endYear);
		}

		private void OnInvertButtonPress(object sender, RoutedEventArgs e)
		{
			publication_list.ItemsSource = PublicationController.InvertPublicationList();
		}

		private void OnPublicationSelect(object sender, SelectionChangedEventArgs e)
		{
			
		}
	}
}