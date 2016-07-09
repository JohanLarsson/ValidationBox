namespace ValidationBox
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnFetchErrorClick(object sender, RoutedEventArgs e)
        {
            var errors = Validation.GetErrors(this.TextBox);
            this.ErrorBlock.Text = FirstErrorOrDefaultConverter.Default.Convert(errors, null, null, null)
                                                               .ToString();
        }
    }
}
