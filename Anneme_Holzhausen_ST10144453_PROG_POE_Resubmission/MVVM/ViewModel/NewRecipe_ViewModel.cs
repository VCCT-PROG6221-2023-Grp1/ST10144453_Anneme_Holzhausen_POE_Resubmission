//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.Classes;
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses;
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.CoreClasses.RelayCommandsClass;

namespace Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.ViewModel
{
    //-----------------------------------------NewRecipe_ViewModel------------------------------------------//
    internal class NewRecipe_ViewModel : ObservableObjectsClass
    {
        /// <summary>
        /// Collection to store the ingredients of a recipe
        /// </summary>
        private ObservableCollection<IngredientsClass> ingredientList { get; set; } = new ObservableCollection<IngredientsClass>();

        // Property to store the name of an ingredient
        private string _IngredientName = string.Empty;
        public string IngredientName
        {
            get { return _IngredientName; }
            set
            {
                _IngredientName = value;
                OnPropertyChanged(nameof(IngredientName));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private double _ingredientQuantity;
        public double IngredientQuantity
        {
            get { return _ingredientQuantity; }
            set
            {
                _ingredientQuantity = value;
                OnPropertyChanged(nameof(IngredientQuantity));
            }
        }

        /// <summary>
        /// Property to store the unit of measurement for an ingredient
        /// </summary>
        private String _ingredientunit;
        public String IngredientUnit
        {
            get { return _ingredientunit; }
            set
            {
                _ingredientunit = value;
                OnPropertyChanged(nameof(_ingredientunit));
            }
        }

        /// <summary>
        /// Property to store the calorie count of an ingredient
        /// </summary>
        private double _ingredientCalories;
        public double IngredientCalories
        {
            get { return _ingredientCalories; }
            set
            {
                _ingredientCalories = value;
                OnPropertyChanged(nameof(IngredientCalories));
            }
        }

        // Property to store the food group of an ingredient
        private String _selectedFoodGroup;
        public string IngredientFoodGroup
        {
            get { return _selectedFoodGroup; }
            set
            {
                _selectedFoodGroup = value;
                OnPropertyChanged(nameof(IngredientFoodGroup));
            }
        }

        /// <summary>
        /// Collection to store the steps of a recipe
        /// </summary>
        private ObservableCollection<StepsClass> stepsList = new ObservableCollection<StepsClass>();

         /// <summary>
         /// Property to store the description of a step
         /// </summary>
        private String _StepDescription;
        public string StepDescription
        {
            get { return _StepDescription; }
            set
            {
                _StepDescription = value;
                OnPropertyChanged(nameof(StepDescription));
            }
        }

        /// <summary>
        /// Property to store the name of the recipe
        /// </summary>
        public RecipeClass recipeClass { get; set; }
        private String _RecipeName;
        public string RecipeName
        {
            get { return _RecipeName; }
            set
            {
                _RecipeName = value;
                OnPropertyChanged(nameof(RecipeName));
            }
        }
        //-----------------------------------------Default Constructor------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public NewRecipe_ViewModel()
        {
            // Creating commands for adding an ingredient, a step, a recipe, and a recipe name
            AddIngredientCommand = new RelayCommand(AddIngredient);
            AddStepCommand = new RelayCommand(AddStep);
            AddRecipeCommand = new RelayCommand(AddRecipe);
            AddRecipeNameCommand = new RelayCommand(AddRecipeName);
        }

        /// <summary>
        /// Command for adding an ingredient
        /// </summary>
        public RelayCommand AddIngredientCommand { get; private set; }

        /// <summary>
        /// Command for adding a step
        /// </summary>
        public RelayCommand AddStepCommand { get; private set; }

        /// <summary>
        /// Command for adding a recipe
        /// </summary>
        public RelayCommand AddRecipeCommand { get; private set; }

        /// <summary>
        /// Command for adding a recipe name
        /// </summary>
        public RelayCommand AddRecipeNameCommand { get; private set; }

        //-----------------------------------------AddIngredient------------------------------------------//

        /// <summary>
        /// Method to add an ingredient to the ingredientList
        /// </summary>
        /// <param name="p"></param>
        private void AddIngredient(Object p)
        {
            var ingredient = new IngredientsClass
            {
                IngredientName = this.IngredientName,
                IngredientQuantity = this.IngredientQuantity,
                IngredientUnit = this.IngredientUnit,
                IngredientCalories = this.IngredientCalories,
                IngredientFoodGroup = this.IngredientFoodGroup,
            };

            ingredientList.Add(ingredient);

            // Resetting the ingredient properties after adding an ingredient
            this.IngredientName = String.Empty;
            this.IngredientQuantity = 0;
            this.IngredientUnit = String.Empty;
            this.IngredientCalories = 0;
            this.IngredientFoodGroup = String.Empty;
        }
        //-----------------------------------------AddStep------------------------------------------//
        /// <summary>
        /// Method to add a step to the stepsList
        /// </summary>
        /// <param name="p"></param>
        private void AddStep(Object p)
        {
            var step = new StepsClass
            {
                StepDescription = this.StepDescription,
            };

            stepsList.Add(step);

            // Resetting the step description after adding a step
            this.StepDescription = String.Empty;
        }
        //-----------------------------------------AddRecipeName------------------------------------------//
        /// <summary>
        /// Method to store the recipe name
        /// </summary>
        /// <param name="p"></param>
        private void AddRecipeName(Object p)
        {
            RecipeName = this.RecipeName;
        }
        //-----------------------------------------AddRecipe------------------------------------------//
        /// <summary>
        /// Method to add a recipe with ingredients and steps
        /// </summary>
        /// <param name="p"></param>
        private void AddRecipe(Object p)
        {
            var recipe = new RecipeClass
            {
                RecipeName = this.RecipeName,
                IngredientsList = new ObservableCollection<IngredientsClass>(this.ingredientList),
                StepsList = new ObservableCollection<StepsClass>(this.stepsList)
            };

            // Adding the recipe to the RecipeList_Model
            RecipeList_Model.AddRecipe(recipe);

            // Displaying a message box with the recipe name
            MessageBox.Show(recipe.RecipeName);

            // Resetting the recipe properties, ingredientList, and stepsList after adding a recipe
            this.RecipeName = String.Empty;
            ingredientList.Clear();
            stepsList.Clear();
        }
    }
}
//-----------00000000000ooooooooooo..........En Of File...........ooooooooooo00000000000-----------//
