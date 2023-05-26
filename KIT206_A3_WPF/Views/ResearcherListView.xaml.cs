using KIT206_A3.Controllers;
using KIT206_A3.Objects;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace KIT206_A3_WPF.Views
{

    public partial class ResearcherListView : UserControl
    {
        public delegate void OnResearcherSelectDelegate(Researcher selectedResearcher);
        public event OnResearcherSelectDelegate OnResearcherSelectListeners = null;

        private EmplymentLevel _selectedLevel = EmplymentLevel.EnumCount;
        private string _selectedName = "";
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
            if (_selectedLevel != EmplymentLevel.EnumCount)
            {
                researcher_list.ItemsSource = ResearcherController.FilterResearcher(_selectedLevel, _selectedName);
            }
            else
            {
                researcher_list.ItemsSource = ResearcherController.FilterResearcher(_selectedName);
            }
        }

        private void OnNameFilterEnter(object sender, KeyEventArgs e)
        {
            _selectedName = (sender as TextBox).Text;
            FilterResearcherList();
        }

        private void OnLevelFilterSelect(object sender, SelectionChangedEventArgs e)
        {
            string selectText = ((sender as ComboBox).SelectedItem as TextBlock).Text;

            if (selectText == "")
            {
                _selectedLevel = EmplymentLevel.EnumCount;
            }
            else
            {
                _selectedLevel = ParseEnum<EmplymentLevel>(selectText);
            }

            FilterResearcherList();
        }

        private void OnResearcherSelect(object sender, SelectionChangedEventArgs e)
        {
            //selected researcher with basic details
            Researcher selectedResearcher = (sender as ListBox).SelectedItem as Researcher;
            if (selectedResearcher != null)
			{
                //load full details for the selected researcher
                ResearcherController.LoadResearcherDetail(selectedResearcher.Id);

                OnResearcherSelectListeners(ResearcherController.SelectedResearcher);
            }
        }
    }
}
