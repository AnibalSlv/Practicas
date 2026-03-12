using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Prueba001
{
    public partial class MainWindow : Window
    {
        private string? num1;
        private string? num2;
        private decimal result;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate(object sender, RoutedEventArgs e) //Asi tal cual Avalonia espera que sus eventos de boton esten o eso parece
        {
            num1 = Number1.Text;
            num2 = Number2.Text;
            if (int.TryParse(num1, out var number1) && int.TryParse(num2, out var number2))
            {
                result = number1 + number2;
                ResultText.Text = result.ToString(); // Me sale este "error" pq no le tengo para convertirlo a una cultura osea:
                //- En inglés (US): 1234.56
                //- En español (VE): 1234,56

            }
            else
            {
                num1 = "Fallo :b";
                ResultText.Text = num1;
            }
        }
    }
}