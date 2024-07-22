namespace Green_Light
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            StartButton.IsVisible = false;
            PauseButton.IsVisible = true;
            StopButton.IsVisible = true;
        }

        private void OnStopButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnPauseButtonClicked(object sender, EventArgs e)
        {

        }
    }

}
