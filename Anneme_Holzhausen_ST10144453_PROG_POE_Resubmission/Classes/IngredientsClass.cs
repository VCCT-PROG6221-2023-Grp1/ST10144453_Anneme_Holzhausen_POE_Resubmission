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
    //------------------------------------------IngredientClass------------------------------------------//
    public class IngredientsClass : ObservableObjectsClass
    {
        /// <summary>
        /// Property to store the name of the ingredient
        /// </summary>
        private string _ingredientName = string.Empty;
        public string IngredientName
        {
            get { return _ingredientName; }
            set
            {
                _ingredientName = value;
                OnPropertyChanged(nameof(IngredientName));
            }
        }

        /// <summary>
        /// Property to store the quantity of the ingredient
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
        /// Property to store the unit of measurement for the ingredient
        /// </summary>
        private string _ingredientUnit = string.Empty;
        public string IngredientUnit
        {
            get { return _ingredientUnit; }
            set
            {
                _ingredientUnit = value;
                OnPropertyChanged(nameof(IngredientUnit));
            }
        }

        /// <summary>
        /// Property to store the calorie count of the ingredient
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

        /// <summary>
        /// Property to store the food group of the ingredient
        /// </summary>
        private string _ingredientFoodGroup = string.Empty;
        public string IngredientFoodGroup
        {
            get { return _ingredientFoodGroup; }
            set
            {
                _ingredientFoodGroup = value;
                OnPropertyChanged(nameof(IngredientFoodGroup));
            }
        }
        //------------------------------------------Default Constructor------------------------------------------//
        /// <summary>
        /// Default constructor
        /// </summary>
        public IngredientsClass()
        {
        }
        //------------------------------------------Ingredient Object------------------------------------------//
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="ingredientName"></param>
        /// <param name="ingredientQuantity"></param>
        /// <param name="ingredientUnit"></param>
        /// <param name="ingredientCalories"></param>
        /// <param name="ingredientFoodGroup"></param>
        public IngredientsClass(string ingredientName, double ingredientQuantity, string ingredientUnit, double ingredientCalories, string ingredientFoodGroup)
        {
            IngredientName = ingredientName;
            IngredientQuantity = ingredientQuantity;
            IngredientUnit = ingredientUnit;
            IngredientCalories = ingredientCalories;
            IngredientFoodGroup = ingredientFoodGroup;
        }
        //------------------------------------------To String------------------------------------------//
        /// <summary>
        /// Overrides the ToString() method to return the ingredient name
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return IngredientName;
        }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//