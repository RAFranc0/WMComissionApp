using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMCommission.Models
{
    public class WMCDatabase
    {
        private readonly SQLiteConnection _database;

        public WMCDatabase(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Venda>();
        }

        public List<Venda> GetVendas()
        {
            return _database.Table<Venda>().ToList();
        }

        public int AddVenda(Venda venda)
        {
            return _database.Insert(venda);
        }

        public int DeleteVenda(Venda venda)
        {
            return _database.Delete(venda);
        }

        public int UpdateVenda(Venda venda)
        {
            return _database.Update(venda);
        }
    }
}