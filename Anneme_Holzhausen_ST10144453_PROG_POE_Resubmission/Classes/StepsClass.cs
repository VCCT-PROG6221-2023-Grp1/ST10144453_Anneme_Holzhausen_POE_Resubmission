//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.Classes
{
    public class StepsClass : ObservableObjectsClass
    {
        /// <summary>
        /// Property to store the description of a step.
        /// </summary>
        public string StepDescription { get; set; } = String.Empty;
        private string _stepsText;
        public string StepsText
        {
            get { return _stepsText; }
            set
            {
                _stepsText = value;
                OnPropertyChanged(nameof(StepsText));
            }
        }

        public ObservableCollection<StepsClass> StepsList { get; set; } = new ObservableCollection<StepsClass>();
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for StepsClass class to set the StepDescription property.
        /// </summary>
        /// <param name="stepdescription">Step Description</param>
        public StepsClass(string stepdescription)
        {
            this.StepDescription = stepdescription;
        }
        //___________________________________________________________________________________________________________

        /// <summary>
        /// Constructor for the StepsClass class. 
        /// </summary>
        public StepsClass()
        {
        }
        //___________________________________________________________________________________________________________
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//

