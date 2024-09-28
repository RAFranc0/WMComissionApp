using Android.App;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using WMCommission.Models;

namespace WMCommission
{
    public class VendaAdapter : BaseAdapter<Venda>
    {
        private readonly List<Venda> _vendas;
        private readonly Activity _context;
        private readonly WMCDatabase _database;

        public VendaAdapter(Activity context, List<Venda> vendas, WMCDatabase database) : base()
        {
            _context = context;
            _vendas = vendas;
            _database = database;
        }

        public override Venda this[int position] => _vendas[position];

        public override long GetItemId(int position) => _vendas[position].Id;

        public override int Count => _vendas.Count;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _vendas[position];
            if (convertView == null)
            {
                convertView = _context.LayoutInflater.Inflate(Resource.Layout.venda_list_item, null);
            }

            // Texto com detalhes da venda
            convertView.FindViewById<TextView>(Resource.Id.txtVendaInfo).Text = $"Data: {item.Data.ToShortDateString()} - Valor: R$ {item.Valor}";

            // Botão de editar
            convertView.FindViewById<Button>(Resource.Id.btnEditar).Click += (sender, e) =>
            {
                // Lógica para editar a venda
                Toast.MakeText(_context, "Função de editar ainda não implementada", ToastLength.Short).Show();
            };

            // Botão de deletar
            convertView.FindViewById<Button>(Resource.Id.btnDeletar).Click += (sender, e) =>
            {
                _database.DeleteVenda(item);
                _vendas.RemoveAt(position);
                NotifyDataSetChanged();
                Toast.MakeText(_context, "Venda deletada!", ToastLength.Short).Show();
            };

            return convertView;
        }
    }
}
