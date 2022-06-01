using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ITNotes.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public Note Note { get; set; }
        public EditPage(Note note)
        {
            Note = note;
            InitializeComponent();
        }
        private async void AddPhoto(object sender, EventArgs e)
        {
            FileResult photo = await MediaPicker.PickPhotoAsync();
            //FileResult photo = await MediaPicker.CapturePhotoAsync();

            img.Source = ImageSource.FromFile(photo.FullPath);

            byte[] imageArray = null;

            using (MemoryStream memory = new MemoryStream())
            {

                Stream stream = await photo.OpenReadAsync();
                stream.CopyTo(memory);
                imageArray = memory.ToArray();
            }

            Note.Photo = imageArray;
        }
        private void Save(object sender, EventArgs e)
        {
            App.db.UpdateNote(Note);
            Navigation.PopAsync();
        }
    }
}