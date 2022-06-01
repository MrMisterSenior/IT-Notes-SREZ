using System;
using System.Collections.Generic;
using System.Text;
using SQLitePCL;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using SQLite;

namespace ITNotes
{
    public class Database
    {
        private const string _db = "ITNotes.db";
        private SQLiteConnection _connection = null;

        public Database(string path)
        {
            string _dbpath = Path.Combine(path, _db);

            _connection = new SQLiteConnection(_dbpath);
            _connection.CreateTable<Note>();

        }
        ~Database()
        {
            if (_connection != null)
                _connection.Close();
        }

        public int AddNote(Note item)
        {
            var result = _connection.Insert(item);
            return result;
        }

        public int UpdateNote(Note item)
        {
            var result = _connection.Update(item);
            return result;
        }

        public int DeleteNote(Note item)
        {
            var result = _connection.Delete(item);
            return result;
        }

        public IQueryable<Note> GetAllNotes()
        {
            var result = _connection.Table<Note>();
            return result.AsQueryable();
        }
    }
}