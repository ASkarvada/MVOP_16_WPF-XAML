using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Uzivatel u = new Uzivatel { Jmeno = "Adam" };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = u;
            u.PropertyChanged += Zmena;
        }

        private void b_Click(object sender, RoutedEventArgs e)
        {
            // BindingExpression expr =
            //tb_jmeno.GetBindingExpression(TextBox.TextProperty);
            // expr?.UpdateSource();

            //tbl.Text = u.Jmeno;
        }

        public void Zmena(object sender, PropertyChangedEventArgs e)
        {
            tbl.Text = u.Jmeno;
        }
       
    }

    class Uzivatel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string jmeno;
        public string Jmeno 
        { 
            get { return jmeno; }
            set 
            { 
                this.jmeno = value;
                OnPropertyChanged(value);
            }
        
        }


        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
