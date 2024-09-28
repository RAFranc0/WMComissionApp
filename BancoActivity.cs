using Android.App;
using Android.OS;
using Android.Widget;
using WMCommission.Models;
using System.IO;
using System.Collections.Generic;

namespace WMCommission
{
    [Activity(Label = "Banco")]
    public class BancoActivity : Activity
    {
        private WMCDatabase _database;
        private ListView _listViewVendas;
        private List<Venda> _vendas;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_banco);

            // Caminho do banco de dados
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "wmc.db3");
            _database = new WMCDatabase(dbPath);

            // Inicializando o ListView
            _listViewVendas = FindViewById<ListView>(Resource.Id.listViewVendas);

            // Buscando as vendas do banco de dados
            _vendas = _database.GetVendas();

            // Configurando o adaptador para exibir a lista
            var adapter = new VendaAdapter(this, _vendas, _database);
            _listViewVendas.Adapter = adapter;
        }
    }
}
