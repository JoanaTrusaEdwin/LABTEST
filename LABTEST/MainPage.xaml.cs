namespace LABTEST
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            
            label1.Text = $"{(int)e.NewValue}";

            if (e.NewValue < 40)
            {
                label2.Text = "Failed";
                label2.TextColor = Microsoft.Maui.Graphics.Color.FromHex("#FF0000"); 

            }
            else if (e.NewValue >= 40 && e.NewValue < 80)
            {
                label2.Text = "Passed";
                label2.TextColor = Microsoft.Maui.Graphics.Color.FromHex("#000000"); 

            }
            else 
            {
                label2.Text = "Excellent";
                label2.TextColor = Microsoft.Maui.Graphics.Color.FromHex("#008000"); 
            }
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
