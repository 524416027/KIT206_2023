using System;
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
	/// Interaction logic for ResearcherListView.xaml
	/// </summary>
	public partial class ResearcherListView : UserControl
	{
		private EmplymentLevel _selectedLevel = EmplymentLevel.EnumCount;
		private string _selectedName = "";

		/* parse to T type based on name string */
		public static T ParseEnum<T>(string value)
		{
			return (T)Enum.Parse(typeof(T), value);
		}

		public ResearcherListView()
		{
			InitializeComponent();
			researcher_list.ItemsSource = ResearcherController.LoadResearcherList();
		}

		private void FilterResearcherList()
		{
			if(_selectedLevel != EmplymentLevel.EnumCount)
			{
				researcher_list.ItemsSource = ResearcherController.FilterResearcher(_selectedLevel, _selectedName);
			}
			else
			{
				researcher_list.ItemsSource = ResearcherController.FilterResearcher(_selectedName);
			}
		}

		private void OnSearcherBoxNameFilterEnter(object sender, KeyEventArgs e)
		{
			_selectedName = (sender as TextBox).Text;

			FilterResearcherList();
		}

		private void OnComboBoxLevelFilterSelect(object sender, SelectionChangedEventArgs e)
		{
			MessageBox.Show(((sender as ComboBox).SelectedItem as TextBlock).Text);
			_selectedLevel = ParseEnum<EmplymentLevel>(((sender as ComboBox).SelectedItem as TextBlock).Text);

			FilterResearcherList();
		}

		private void OnResearcherSelect(object sender, SelectionChangedEventArgs e)
		{

		}
	}
}
