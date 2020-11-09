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

namespace CalculadoraBasica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, RoutedEventArgs e)
        {
            if (operandoTextBox.Text == "+")
                resultadoTextBox.Text = (int.Parse(operador1TextBox.Text) + int.Parse(operador2TextBox.Text)).ToString();
            else if (operandoTextBox.Text == "-")
                resultadoTextBox.Text = (int.Parse(operador1TextBox.Text) - int.Parse(operador2TextBox.Text)).ToString();
            else if (operandoTextBox.Text == "*")
                resultadoTextBox.Text = (int.Parse(operador1TextBox.Text) * int.Parse(operador2TextBox.Text)).ToString();
            else
                throw new Exception();
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            operador1TextBox.Text = "";
            operador2TextBox.Text = "";
            operandoTextBox.Text = "";
            resultadoTextBox.Text = "";
            calcularButton.IsEnabled = false;
        }

        private void operandoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex operadoresValidos = new Regex("(/+|/*|/-)?");
            if (operadoresValidos.IsMatch(operandoTextBox.Text))
                calcularButton.IsEnabled = true;
            else
                calcularButton.IsEnabled = false;            
        }
    }
}
