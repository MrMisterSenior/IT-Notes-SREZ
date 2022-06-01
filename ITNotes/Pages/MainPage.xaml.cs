using ITNotes.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace ITNotes
{
    public partial class MainPage : ContentPage
    {
        public List<Note> Notes { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            Notes = App.db.GetAllNotes().ToList();
            if (Notes.Count == 0)
            {
                bool result = await DisplayAlert("", "У вас пока что нет заметок. Хотите создать новую?", "Да", "Нет");
                if (result == true)
                    await Navigation.PushAsync(new AddPage());
            }
            lv.ItemsSource = Notes;
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            Note note = Notes.Where(x => x.Id.ToString() == ((Button)sender).CommandParameter.ToString()).First();
            Navigation.PushAsync(new EditPage(note));
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            Note note = Notes.Where(x => x.Id.ToString() == ((Button)sender).CommandParameter.ToString()).First();
            Notes.Remove(note);
            App.db.DeleteNote(note);

            lv.ItemsSource = null;
            lv.ItemsSource = Notes;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage());
        }
    }
}