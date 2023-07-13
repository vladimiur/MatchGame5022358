using System.Timers;
namespace MatchGame5022358;

public partial class Juego : ContentPage
{
    //Creamos un contador  
    private TimeOnly time = new();
    private bool isRunning;
    
	public Juego()
	{
		InitializeComponent();
        SetUpGame();
    }

    //Creamos la funcion del boton
    private void Button_Clicked(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (encontrandoMatch == false)
        {
            button.IsVisible = false;
            ultimoButtonClicked = button;
            encontrandoMatch = true;
        }
        else if (button.Text == ultimoButtonClicked.Text)
        {
            button.IsVisible = false;
            encontrandoMatch = false;
        }
        else
        {
            ultimoButtonClicked.IsVisible = true;
            encontrandoMatch = false;
        }
    }

    //Creamos un metodo para cambiar el texto por los emojis
    public void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
        {
            "🦊","🦊",
            "🐺","🐺",
            "🐲","🐲",
            "🍩","🍩",
            "👩‍👦","👩‍👦",
            "🎮","🎮",
            "🎲","🎲",
            "🎹","🎹",

        };
        //Hacemos que sea random
        Random random = new Random();
        foreach (Button view in Grid1.Children)
        {
            int index = random.Next(animalEmoji.Count);
            String NextEmoji = animalEmoji[index];
            view.Text = NextEmoji;
            animalEmoji.RemoveAt(index);
        }

    }

    Button ultimoButtonClicked;
    bool encontrandoMatch = false;

    
    //Le damos funcion al boton para que resete el juego
    private void btnReset_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new Juego());
    }

    //El boton puede pausar y comenzar el cronometro
    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        isRunning = !isRunning;
        startsStopButton.Text = isRunning ? "pause" : "play";

        while (isRunning)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
            setTime();
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    private void setTime()
    {
        tiempo.Text = $"{time.Minute}:{time.Second:000}";
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        System.Environment.Exit(0);
    }
}