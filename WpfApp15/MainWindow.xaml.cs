using Microsoft.EntityFrameworkCore;
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

namespace WpfApp15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private void UpdateData()
        {
            LvSotr.ItemsSource = EfModel.Init().Sotrudnikis.Include(d => d.DoljnNavigation).Include(s => s.SmenaNavigation).Include(t => t.TipStavkiNavigation).Include(z => z.ZonaNavigation).ToList();
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtInfoClick(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void BtUserClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TbSearch_TextShanged(object sender, TextChangedEventArgs e)
        {
           //if (LvSotr != null)
           // {
           //     LvSotr.ItemsSource = EfModel.Init().Sotrudnikis.Where(s => s.FIO.Contains(TbSearch.Text.ToString())).ToList();
           // }
        }
    }
}
