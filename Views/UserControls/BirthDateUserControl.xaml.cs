using Zadontseva03.Tools.Managers;
using Zadontseva03.ViewModels;
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

namespace Zadontseva03.Views.UserControls
{
    /// <summary>
    /// Interaction logic for BirthDateUserControl.xaml
    /// </summary>
    public partial class BirthDateUserControl : UserControl, INavigatable
    {
        public BirthDateUserControl()
        {
            InitializeComponent();
            
            DataContext = new BirthDateViewModel();
        }
    }
}
