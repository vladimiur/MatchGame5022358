namespace MatchGame5022358;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
        
    }

	//Al crear el evento Clicked para hacer la navegacion del otro MainPage llamado juego
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Juego());
    }

    
}

