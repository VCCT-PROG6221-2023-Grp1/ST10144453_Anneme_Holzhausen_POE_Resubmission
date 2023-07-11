//-----------00000000000ooooooooooo..........Start Of File...........ooooooooooo00000000000-----------//
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.Classes;
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.Model;
using Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Anneme_Holzhausen_ST10144453_PROG_POE_Resubmission.MVVM.View
{
    //------------------------------------------AllRecipes_View------------------------------------------//
    /// <summary>
    /// Interaction logic for AllRecipes_View.xaml
    /// </summary>
    public partial class AllRecipes_View : UserControl
    {
        //------------------------------------------DefaultContructor------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public AllRecipes_View()
        {
            InitializeComponent();
        }
        //------------------------------------------DeleteRecipe------------------------------------------//
        /// <summary>
        /// To delete the recipe when teh user presses on the delete "button" (it's not a button)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteRecipe_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (DataContext is AllRecipes_ViewModel viewModel && viewModel.SelectedRecipe != null)
                {
                    // Delete the selected recipe
                    var recipeToDelete = viewModel.SelectedRecipe;

                    // Remove the recipe from the Recipes collection
                    viewModel.Recipes.Remove(recipeToDelete);

                    // Remove the recipe's ingredients from the IngredientsList collection
                    foreach (var ingredient in recipeToDelete.IngredientsList)
                    {
                        viewModel.IngredientsList.Remove(ingredient);
                    }

                    // Reset the selected recipe
                    viewModel.SelectedRecipe = null;
                }
            }

        }

    }
//-----------00000000000ooooooooooo..........End Of File...........ooooooooooo00000000000-----------//

