using MauiApp1.Data;

namespace MauiApp1.Pages;

public partial class AddPersonPage : ContentPage
{
	private readonly Context _context;
	public AddPersonPage(Context context)
	{
		_context = context;
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string name = ForName.Text;
		_context.Persons.Add(new Models.Person { Name = name });
		_context.SaveChanges();
		ForName.Text = "";
        await Shell.Current.GoToAsync("MainPage".ToLower());

    }
}