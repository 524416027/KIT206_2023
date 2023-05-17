using KIT206A3WPF.Controllers;
using KIT206A3WPF.Objects;
using System;

namespace KIT206A3WPF.Views
{
    public class ResearcherSelectedEventArgs : EventArgs
    {
        public Researcher SelectedResearcher { get; }

        public ResearcherSelectedEventArgs(Researcher selectedResearcher)
        {
            SelectedResearcher = ResearcherController.
            SelectedResearcher = selectedResearcher;
        }
    }
}

