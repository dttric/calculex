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
                int reslen = res.ToString().Length;
                int resinlen = resin.Text.Length;
                if (reslen > resinlen)
                {
                    reslen = resinlen;
                }
                Run resoutrun = new Run(resin.Text + "\n"+ string.Join("", Enumerable.Repeat(" ", resinlen - reslen)) + res.ToString() + "\n\n");
                resoutrun.Foreground = Brushes.White;
                respar.Inlines.Add(resoutrun);
                resflow.Blocks.Add(respar);
                resout.Document = resflow;
                resin.Text = "";
            }
            catch (Exception ex)
            {
                Run resoutrun = new Run("Error:\n     " + ex.Message + "\n\n");
                resoutrun.Foreground = Brushes.Red;
                respar.Inlines.Add(resoutrun);
                resflow.Blocks.Add(respar);
                resout.Document = resflow;
                resin.Text = "";
            }
        }

        private void AC_Click(object sender, RoutedEventArgs e)
        {
            resin.Text = "";
        }

        private void clickexit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void gethelp(object sender, RoutedEventArgs e)
        {
            Run resoutrun = new Run("https://github.com/dttric/calculex/wiki" + "\n\n");
            resoutrun.Foreground = Brushes.Yellow;
            respar.Inlines.Add(resoutrun);
            resflow.Blocks.Add(respar);
            resout.Document = resflow;
            resin.Text = "";
        }

        private void clickchistory(object sender, RoutedEventArgs e)
        {
            respar.Inlines.Clear();
            resout.Document.Blocks.Clear();
        }
    }

}
