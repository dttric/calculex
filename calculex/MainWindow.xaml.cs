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
using NCalc;
using System.Windows.Shapes;

namespace calculex
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void getres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NCalc.Expression expr = new NCalc.Expression(resin.Text);
                object res = expr.Evaluate();
                int resinlen = resin.Text.Length;
                Run resoutrun = new Run(resin.Text + "\n"+ string.Join("", Enumerable.Repeat(" ", resinlen - 1)) + res.ToString() + "\n\n");
                respar.Inlines.Add(resoutrun);
                resflow.Blocks.Add(respar);
                resout.Document = resflow;
                resin.Text = "";
            }
            catch (Exception ex)
            {
                // Обработка исключения
                MessageBox.Show(
                    ex.Message,
                    "Error"
                );
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            resin.Text = "";
        }
    }
}
