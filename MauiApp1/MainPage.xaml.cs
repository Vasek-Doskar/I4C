using MauiApp1.Data;
using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public readonly Context _context;
        public MainPage(Context context)
        {
            _context = context;
            InitializeComponent();
            DbList.ItemsSource = _context.Persons.ToList();
        }

        private async void DbList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int id = (e.Item as Person)!.Id;
            Person? selected = _context.Persons.Include(p => p.Cars).FirstOrDefault(p => p.Id == id);

            if (selected is not null)
            {
                string output = "";
                foreach (Car c in selected.Cars!)
                {
                    output += $"{c}\n";
                }

                await DisplayAlert($"{selected}", output, "OK");
                DbList.ItemsSource = null;
                DbList.ItemsSource = _context.Persons.ToList();
            }
        }
    }

}
