//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses.ObservableObjectsClass;
using static Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses.RelayCommandsClass;

namespace Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.ViewModel
{
    //------------------------------------------MainWindow_ViewModel------------------------------------------//
    internal class MainWindow_ViewModel : ObservableObjectsClass
    {
        // Command for navigating to the home page
        public RelayCommand HomePageCommand { get; set; }

        /// <summary>
        /// Command for navigating to the all recipes page
        /// </summary>
        public RelayCommand AllRecipesCommand { get; set; }

        /// <summary>
        /// Command for navigating to the new recipe page
        /// </summary>
        public RelayCommand NewRecipeCommand { get; set; }

        /// <summary>
        /// View model for the home page
        /// </summary>
        public HomePage_ViewModel HomePageVM { get; set; }

        /// <summary>
        /// View model for the all recipes page
        /// </summary>
        public AllRecipes_ViewModel AllRecipesVM { get; set; }

        /// <summary>
        /// View model for the new recipe page
        /// </summary>
        public NewRecipe_ViewModel NewRecipeVM { get; set; }

        /// <summary>
        /// Property to track the current view
        /// </summary>
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        //------------------------------------------Default Constructor------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow_ViewModel()
        {
            // Instantiate view models for the home page, all recipes page, and new recipe page
            HomePageVM = new HomePage_ViewModel();
            AllRecipesVM = new AllRecipes_ViewModel();
            NewRecipeVM = new NewRecipe_ViewModel();

            // Set the current view to the home page initially
            CurrentView = HomePageVM;

            // Assign commands to navigate to different views
            HomePageCommand = new RelayCommand(o =>
            {
                CurrentView = HomePageVM;
            });

            AllRecipesCommand = new RelayCommand(o =>
            {
                CurrentView = AllRecipesVM;
            });

            NewRecipeCommand = new RelayCommand(o =>
            {
                CurrentView = NewRecipeVM;
            });
        }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//
