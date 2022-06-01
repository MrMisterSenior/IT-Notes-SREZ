using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace ITNotes
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public byte[] Photo { get; set; }
        public ImageSource CompatiblePhoto
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(Photo));
            }
        }
        public string Text { get; set; }
    }
}