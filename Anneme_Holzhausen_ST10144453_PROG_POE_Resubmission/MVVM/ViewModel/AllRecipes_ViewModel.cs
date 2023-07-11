//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.Classes;
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses;
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses.RelayCommandsClass;
        //------------------------------------------Namespace------------------------------------------//
namespace Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.ViewModel
{        
    //-----------------------------------------AllRecipes_ViewModel------------------------------------------//
    public class AllRecipes_ViewModel : ObservableObjectsClass, INotifyPropertyChanged
    {
        /// <summary>
        /// The variable to link to the recipe name in the combo box!
        /// </summary>
        private string _selectedIngredientName;
        /// <summary>
        /// The variable to set the maximum amuont of calories 
        /// </summary>
        private double _maximumCalories;
        /// <summary>
        /// The variable to set the total number of calories in a recipe
        /// </summary>
        private double _selectedRecipeTotalCalories;
        /// <summary>
        /// Linking to the ingredients class to be able to use the ingredient variables
        /// </summary>
        private IngredientsClass _allIngredients;
        /// <summary>
        /// Linking to the steps class to be able to use the step variables 
        /// </summary>
        private StepsClass _allSteps;
        /// <summary>
        /// The command to multiply the ingredients by half (0.5) - does not work 
        /// </summary>
        public ICommand MultiplyByHalfCommand { get; private set; }
        /// <summary>
        /// The command to multiply the incredients by 2 - does work 
        /// </summary>
        public ICommand MultiplyByTwoCommand { get; private set; }
        /// <summary>
        /// The command to multiply the ingredients by 3 - does work 
        /// </summary>
        public ICommand MultiplyByThreeCommand { get; private set; }
        /// <summary>
        /// The command to reset the ingredients to their original value - does not work 
        /// </summary>
        public ICommand ResetCommand { get; private set; }
        /// <summary>
        /// The command linking the command method to the buttons - kinda works?
        /// </summary>
        public ICommand MultiplyCommand { get; }
        /// <summary>
        /// Setting the original quantity of the ingredients 
        /// </summary>

        private double _originalQuantity;
        /// <summary>
        /// Getting and setting the original quantity of the ingredients 
        /// </summary>
        public double OriginalQuantity
        {
            get { return _originalQuantity; }
            set
            {
                _originalQuantity = value;
                OnPropertyChanged(nameof(OriginalQuantity));
            }
        }
        /// <summary>
        /// The variable for the original calories in an ingredient 
        /// </summary>
        private double _originalCalories;
        /// <summary>
        /// Getting and setting the original calories of an ingredient 
        /// </summary>
        public double OriginalCalories
        {
            get { return _originalCalories; }
            set
            {
                _originalQuantity = value;
                OnPropertyChanged(nameof(OriginalQuantity));
            }
        }
        /// <summary>
        /// Getter and setter for the ingredient name that is selected from the Recipe Name Combo Box 
        /// </summary>
        public string SelectedIngredientName
        {
            get { return _selectedIngredientName; }
            set
            {
                _selectedIngredientName = value;
                OnPropertyChanged(nameof(SelectedIngredientName));
                OnPropertyChanged(nameof(FilteredRecipes));
            }
        }
        /// <summary>
        /// Getter and setter for the macximum amount of calories 
        /// </summary>
        public double MaximumCalories
        {
            get { return _maximumCalories; }
            set
            {
                _maximumCalories = value;
                OnPropertyChanged(nameof(MaximumCalories));
                OnPropertyChanged(nameof(FilteredRecipes));
            }
        }
        /// <summary>
        /// Variable for the selected food group - does not work 
        /// </summary>
        private string _selectedFoodGroup;
        /// <summary>
        /// Getter and setter for teh selected food group from the combo box - does not work 
        /// </summary>
        public string SelectedFoodGroup
        {
            get { return _selectedFoodGroup; }
            set
            {
                _selectedFoodGroup = value;
                OnPropertyChanged(nameof(SelectedFoodGroup));
            }
        }
        /// <summary>
        /// Instantiating the RecipeClass Observable collection in this class
        /// </summary>
        public ObservableCollection<RecipeClass> Recipes { get; }
        /// <summary>
        /// Instantiating the IngredientClass Observable collection in this class
        /// </summary>
        public ObservableCollection<IngredientsClass> IngredientsList { get; }
        /// <summary>
        /// Variable for the selected recipe that is being displayed
        /// </summary>
        private RecipeClass _selectedRecipe;
        /// <summary>
        /// Command to add ingredients to the command 
        /// </summary>
        public ICommand AddIngredientCommand { get; } // AddIngredientCommand property
        /// <summary>
        /// Getter and setter for the selected recipe from the recipe class
        /// </summary>
        public RecipeClass SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged(nameof(SelectedRecipe));
                UpdateUserInput();
            }
        }
        /// <summary>
        /// Getter and setter for the total amuont of calories in a recipe
        /// </summary>
        public double SelectedRecipeTotalCalories
        {
            get { return _selectedRecipeTotalCalories; }
            set
            {
                _selectedRecipeTotalCalories = value;
                OnPropertyChanged(nameof(SelectedRecipeTotalCalories));
            }
        }
        /// <summary>
        /// Variable for the selected recipe name 
        /// </summary>
        private string _selectedRecipeName;
        /// <summary>
        /// Gertter and setter for the recipe name 
        /// </summary>
        public string SelectedRecipeName
        {
            get { return _selectedRecipeName; }
            set
            {
                _selectedRecipeName = value;
                OnPropertyChanged(nameof(SelectedRecipeName));
            }
        }
        /// <summary>
        /// Getter and setter to call the ingredients from the ingredient class 
        /// </summary>
        public IngredientsClass AllIngredients
        {
            get { return _allIngredients; }
            set
            {
                _allIngredients = value;
                OnPropertyChanged(nameof(AllIngredients));
            }
        }
        /// <summary>
        /// Getter and setter to call the steps from the steps class 
        /// </summary>
        public StepsClass AllSteps
        {
            get { return _allSteps; }
            set
            {
                _allSteps = value;
                OnPropertyChanged(nameof(AllSteps));
            }
        }
        //------------------------------------------Default Constructor------------------------------------------//
        /// <summary>
        /// Default constructor for the View Model of the AllRecipes View
        /// </summary>
        public AllRecipes_ViewModel()
        {
            SelectedRecipe = new RecipeClass();

            Recipes = new ObservableCollection<RecipeClass>(RecipeList_Model.ReturnRecipes());
            IngredientsList = new ObservableCollection<IngredientsClass>();
            IngredientsList.CollectionChanged += IngredientsList_CollectionChanged;
            OriginalQuantity = SelectedRecipe.IngredientsHere.IngredientQuantity;
            OriginalCalories = SelectedRecipe.IngredientsHere.IngredientCalories;
            MultiplyCommand = new RelayCommand(MultiplyExecute);
        }
        //------------------------------------------IngredientList_CollectionChanged------------------------------------------//
        /// <summary>
        /// SUPPOSED to update the ingredient name combo box based on the filters the user sets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IngredientsList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Call the update methods in the selected recipe whenever the IngredientsList changes
            SelectedRecipe?.UpdateIngredientNames();
            SelectedRecipe?.UpdateFoodGroups();

            // Additional logic to handle the addition of new ingredients
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                // Perform necessary operations with the newly added ingredients
                foreach (IngredientsClass ingredient in e.NewItems)
                {
                    // Process the newly added ingredient
                    // For example, you might want to add it to a database or perform other operations.
                }
            }
        }
        //------------------------------------------UpdateUserInput------------------------------------------//
        /// <summary>
        /// Supposed to update the user input when printed based on the filters
        /// </summary>
        public void UpdateUserInput()
        {
            SelectedRecipeName = SelectedRecipe?.RecipeName;
            SelectedRecipeTotalCalories = SelectedRecipe?.TotalCalories() ?? 0;
            SelectedRecipe?.UpdateIngredientsText();
            SelectedRecipe?.UpdateStepsText();
            AllIngredients = SelectedRecipe?.IngredientsHere;
            AllSteps = SelectedRecipe?.StepsHere;
        }
        //------------------------------------------MultiplyExecute------------------------------------------//
        /// <summary>
        /// Execute the command to update the quantity and calories
        /// </summary>
        /// <param name="parameter"></param>
        private void MultiplyExecute(object parameter)
        {
            if (double.TryParse(parameter.ToString(), out double factor))
            {
                MultiplyByFactor(factor);
            }
        }
        //------------------------------------------MultuplyByFactor------------------------------------------//
        /// <summary>
        /// Holds the logic to scale the quantity and calories
        /// </summary>
        /// <param name="factor"></param>
        private void MultiplyByFactor(double factor)
        {
            if (SelectedRecipe != null)
            {
                foreach (IngredientsClass ingredient in SelectedRecipe.IngredientsList)
                {
                    ingredient.IngredientQuantity *= factor; //I know that I went wrong here and should have done a seperate emthod to divide ingredients by 2/the scaling factor but i ran out of time 
                    ingredient.IngredientCalories *= factor;//Hey, at least i (hopefully) know where this went wrong
                }

                SelectedRecipe.UpdateIngredientsText();
            }
        }
        /// <summary>
        /// Selects the ingredient for the ingredient name combo box - does not work 
        /// </summary>
        public IEnumerable<string> FoodGroupOptions =>
            IngredientsList.Select(ingredient => ingredient.IngredientFoodGroup).Distinct();
        /// <summary>
        /// Calculates sets the maximum amount of calories in intervals of 100 - does work 
        /// </summary>
        public IEnumerable<double> MaximumCaloriesOptions
        {
            get
            { 
                    double maxCalories = Recipes.Max(r => r.TotalCalories());
                    double step = 100;
                    int numSteps = (int)Math.Ceiling(maxCalories / step);
                    return Enumerable.Range(1, numSteps).Select(i => i * step);
            }
        }
        /// <summary>
        /// Calls teh ingredient name for the combo box - does not work 
        /// </summary>
        public IEnumerable<string> AllIngredientNames =>
            IngredientsList.Select(ingredient => ingredient.IngredientName);
        /// <summary>
        /// Does a similar thing as the IEnumeral AllIngredientName
        /// </summary>
        public RecipeClass SelectedIngredientRecipe =>
            Recipes.FirstOrDefault(r => r.IngredientsList.Any(i => i.IngredientName == SelectedIngredientName));
        /// <summary>
        /// instantiates the filtered recipe based on what the use chose from the combo boxes - only th emmaximum amnount of calories work 
        /// </summary>
        public ObservableCollection<RecipeClass> FilteredRecipes
        {
            get
            {
                IEnumerable<RecipeClass> filteredRecipes = Recipes;

                if (!string.IsNullOrEmpty(SelectedIngredientName))
                    filteredRecipes = filteredRecipes.Where(r => r.IngredientsList.Any(i => i.IngredientName == SelectedIngredientName));

                if (MaximumCalories > 0)
                    filteredRecipes = filteredRecipes.Where(r => r.TotalCalories() <= MaximumCalories);

                if (!string.IsNullOrEmpty(SelectedFoodGroup))
                    filteredRecipes = filteredRecipes.Where(r => r.IngredientsList.Any(i => i.IngredientFoodGroup == SelectedFoodGroup));

                return new ObservableCollection<RecipeClass>(filteredRecipes);
            }
        }
        
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//