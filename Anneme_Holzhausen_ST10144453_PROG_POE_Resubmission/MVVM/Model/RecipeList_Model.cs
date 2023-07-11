//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.Model
{
    internal class RecipeList_Model
    {
        private static ObservableCollection<RecipeClass> recipeList = new ObservableCollection<RecipeClass>();
        private static ObservableCollection<RecipeClass> IngredientList = new ObservableCollection<RecipeClass>();

        public RecipeList_Model()
        {
        }

        public static void AddRecipe(RecipeClass recipe)
        {
            recipeList.Add(recipe);
        }
        public static ObservableCollection<RecipeClass> ReturnRecipes()
        {
            return recipeList;
        }
      
        public static void RemoveRecipe(RecipeClass recipe)
        {
            recipeList.Remove(recipe);
        }
    }
}
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//
