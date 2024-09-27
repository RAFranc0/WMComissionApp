using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace WMCommission.Models
{
    public class Venda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public Venda() { }

        public Venda(DateTime data, decimal valor)
        {
            this.Data = data;
            this.Valor= valor;
        }

        public Venda(decimal valor)
        {
            this.Valor = valor;
        }

        public Venda(DateTime data)
        {
            this.Data = data;
        }
    }
}