using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace InvoicingSystem_XML.Views
{
    /// <summary>
    /// Interaction logic for ValidationComponent.xaml
    /// </summary>
    public partial class ValidationComponent
    {

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register("ErrorText", typeof(string), typeof(ValidationComponent));



        public ReadOnlyObservableCollection<ValidationError> Errors
        {
            get { return (ReadOnlyObservableCollection<ValidationError>)GetValue(ErrorsProperty); }
            set { SetValue(ErrorsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Errors.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ErrorsProperty =
            DependencyProperty.Register("Errors", typeof(ReadOnlyObservableCollection<ValidationError>), typeof(ValidationComponent));

        public TextBox MyProperty
        {
            get { return (TextBox)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(Control), typeof(ValidationComponent), new FrameworkPropertyMetadata(Test));

        private static void Test(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var sender = d as ValidationComponent;

            var binding = new Binding();
            binding.Source = sender;
            var errors = Validation.GetErrors(sender.MyProperty);
            sender.Errors = errors;
            var error = string.Empty;
            if (errors.Any())
                sender.ErrorText = errors[0].ErrorContent.ToString();
            binding.Path = new PropertyPath(sender.ErrorText);
            BindingOperations.SetBinding(sender.TextBlock, TextBlock.TextProperty, binding);
        }


        public ValidationComponent()
        {
            InitializeComponent();
        }
    }
}
