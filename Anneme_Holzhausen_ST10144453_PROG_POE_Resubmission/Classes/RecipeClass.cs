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
    //------------------------------------------RecipeClass------------------------------------------//
    public class RecipeClass : ObservableObjectsClass
    {
        /// <summary>
        /// Stores the name of a recipe
        /// </summary>
        public string recipeName;

        /// <summary>
        /// Property to get or set the name of a recipe
        /// </summary>
        public string RecipeName
        {
            get { return recipeName; }
            set { recipeName = value; }
        }
        /// <summary>
        /// Stores the steps of the recipe as text
        /// </summary>
        public string StepsText { get; set; }

        /// <summary>
        /// Stores the ingredients of the recipe as text
        /// </summary>
        private string _ingredientsText;

        /// <summary>
        /// Property to get or set the ingredients of the recipe as text
        /// </summary>
        public string IngredientsText
        {
            get { return _ingredientsText; }
            set
            {
                _ingredientsText = value;
                OnPropertyChanged(nameof(IngredientsText));
            }
        }
        // <summary>
        /// Stores an instance of the IngredientsClass
        /// </summary>
        public IngredientsClass IngredientsHere { get; set; }

        /// <summary>
        /// Stores an instance of the StepsClass with a default value
        /// </summary>
        public StepsClass StepsHere { get; set; } = new StepsClass();

        /// <summary>
        /// Represents a list of IngredientsClass objects
        /// </summary>
        public ObservableCollection<IngredientsClass> IngredientsList { get; set; } = new ObservableCollection<IngredientsClass>();

        /// <summary>
        /// Represents a list of StepsClass objects
        /// </summary>
        public ObservableCollection<StepsClass> StepsList { get; set; } = new ObservableCollection<StepsClass>();

        /// <summary>
        /// Represents a collection of unique ingredient names
        /// </summary>
        public ObservableCollection<string> IngredientNames =>
            new ObservableCollection<string>(IngredientsList.Select(ingredient => ingredient.IngredientName).Distinct());

        /// <summary>
        /// Represents a collection of unique food groups
        /// </summary>
        public ObservableCollection<string> FoodGroups =>
            new ObservableCollection<string>(IngredientsList.Select(ingredient => ingredient.IngredientFoodGroup).Distinct());

        //------------------------------------------Default Constructor------------------------------------------//
        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeClass()
        {
            IngredientsHere = new IngredientsClass();
            StepsHere = new StepsClass();
        }
        //------------------------------------------TotalCalories------------------------------------------//
        /// <summary>
        /// Calculates the total calories of all ingredients in the recipe
        /// </summary>
        /// <returns></returns>
        public double TotalCalories()
        {
            double totalCalories = 0;

            foreach (IngredientsClass ingredient in IngredientsList)
            {
                totalCalories += ingredient.IngredientCalories;
            }

            return totalCalories;
        }
        //------------------------------------------UpdateIngredientText------------------------------------------//
        /// <summary>
        /// Updates the IngredientsText property with formatted text representing the ingredients
        /// </summary>
        public void UpdateIngredientsText()
        {
            IngredientsText = string.Join(Environment.NewLine, IngredientsList.Select(ingredient =>
                $"  {ingredient.IngredientQuantity} {ingredient.IngredientUnit} of {ingredient.IngredientName} " +
                $"\r\n           {ingredient.IngredientCalories} calories  " +
                $"\r\n           In {ingredient.IngredientFoodGroup} food group"));
        }
        //------------------------------------------UpdateStepsText------------------------------------------//
        /// <summary>
        /// Updates the StepsText property with formatted text representing the steps
        /// </summary>
        public void UpdateStepsText()
        {
            StepsText = string.Join(Environment.NewLine, StepsList.Select((step, index) =>
                $"  {index + 1}. {step.StepDescription}"));

            OnPropertyChanged(nameof(StepsText));
        }
        //------------------------------------------UpdateIngredientName------------------------------------------//
        /// <summary>
        /// Notifies the UI to update the IngredientNames property
        /// </summary>
        public void UpdateIngredientNames()
        {
            OnPropertyChanged(nameof(IngredientNames));
        }
        //------------------------------------------UpdateFoodGroups------------------------------------------//
        /// <summary>
        /// Notifies the UI to update the FoodGroups property
        /// </summary>
        public void UpdateFoodGroups()
        {
            OnPropertyChanged(nameof(FoodGroups));
        }
        //------------------------------------------ToString------------------------------------------//
        /// <summary>
        /// Overrides the ToString() method to return the recipe name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return RecipeName;
        }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//
