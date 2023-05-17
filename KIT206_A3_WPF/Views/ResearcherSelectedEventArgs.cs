using KIT206_A3.Objects;
using System;

namespace KIT206_A3_WPF.Views
{
    public class ResearcherSelectedEventArgs : EventArgs
    {
        public Researcher SelectedResearcher { get; }

        public ResearcherSelectedEventArgs(Researcher selectedResearcher)
        {
            SelectedResearcher = selectedResearcher;
        }
    }
}

