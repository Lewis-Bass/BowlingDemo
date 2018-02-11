using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace BowlingSample.View
{
    /// <summary>
    /// Interaction logic for GameEntryUC.xaml
    /// </summary>
    public partial class GameEntryUC : UserControl
    {
        public GameEntryUC()
        {
            InitializeComponent();
        }


        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    // recalculate the score
        //    if (DataContext is ViewModel.GameEntryVM)
        //    {
        //        ViewModel.GameEntryVM vm = (ViewModel.GameEntryVM)DataContext;
        //        vm.Recalculate();
        //    }
        //}

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // validate that the input is an integer between 0 and 10
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
