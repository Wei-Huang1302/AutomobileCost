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

namespace AutomobileCost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int MonthPerYear = 12;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalPymt_Click(object sender, RoutedEventArgs e)
        {
            ///https://stackoverflow.com/questions/32462176/how-can-i-set-the-value-of-textbox-to-0-if-blank-or-empty, some people dont usually
            ///type "0" when they dont have any values for that field, they just skip and leave empty there.
            ///Convert empty string or not input to "0" when possible.
            if (string.IsNullOrEmpty(LoanCst.Text))
            {
                LoanCst.Text = "0";
            }
            if (string.IsNullOrEmpty(InsuCst.Text))
            {
                InsuCst.Text = "0";
            }
            if (string.IsNullOrEmpty(GasCst.Text))
            {
                GasCst.Text = "0";
            }
            if (string.IsNullOrEmpty(OilCst.Text))
            {
                OilCst.Text = "0";
            }
            if (string.IsNullOrEmpty(TireCst.Text))
            {
                TireCst.Text = "0";
            }
            if (string.IsNullOrEmpty(MtnCst.Text))
            {
                MtnCst.Text = "0";
            }
            ///Extract values from textboxes, and remind user to input valid currency amount if any entry is not valid
            try
            {
                //convert textinputs to strings
                string LoanCostConvert = LoanCst.Text;
                string InsuCostConvert = InsuCst.Text;
                string GasCostConvert = GasCst.Text;
                string OilCostConvert = OilCst.Text;
                string TiresCostConvert = TireCst.Text;
                string MaintCostCovert = MtnCst.Text;
                //convert to decimal
                decimal LoanPerMth = decimal.Parse(LoanCostConvert);
                decimal InsurancePerMth = decimal.Parse(InsuCostConvert);
                decimal GasPerMth = decimal.Parse(GasCostConvert);
                decimal OilPerMth = decimal.Parse(OilCostConvert);
                decimal TiresPerMth = decimal.Parse(TiresCostConvert);
                decimal MtnPerMth = decimal.Parse(MaintCostCovert);
                //calculate monthly and yearly payments
                ToMonCst.Content = LoanPerMth + InsurancePerMth + GasPerMth + OilPerMth + TiresPerMth + MtnPerMth;
                ToYrCst.Content = (LoanPerMth + InsurancePerMth + GasPerMth + OilPerMth + TiresPerMth + MtnPerMth) * MonthPerYear;
            }
            catch
            {
                MessageBox.Show("Please ensure you put your money amount in the calculator!", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void ReSet_Click(object sender, RoutedEventArgs e)
        {
            //rest all values to empty strings to let user perform next calculation
            LoanCst.Text = "";
            InsuCst.Text = "";
            GasCst.Text = "";
            OilCst.Text = "";
            TireCst.Text = "";
            MtnCst.Text = "";
            ToMonCst.Content = "";
            ToYrCst.Content = "";
        }
    }
}
