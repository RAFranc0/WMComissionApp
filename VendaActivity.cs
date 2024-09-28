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
using WMCommission.Models;
using System.IO;

namespace WMCommission
{
    [Activity(Label = "Venda")]
    public class VendaActivity : Activity
    {
        private WMCDatabase _database;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_venda); // Associa o layout "activity_venda.xml"

            // Caminho do banco de dados
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "wmc.db3");
            _database = new WMCDatabase(dbPath);

            // Referenciar os elementos da UI
            EditText valorVendaEditText = FindViewById<EditText>(Resource.Id.valorVenda);
            Button btnAddVenda = FindViewById<Button>(Resource.Id.btnAddVenda);

            // Ação do botão para adicionar uma venda
            btnAddVenda.Click += (sender, e) =>
            {
                if (decimal.TryParse(valorVendaEditText.Text, out decimal valor))
                {
                    // Cria uma nova venda com o valor digitado e a data atual
                    Venda novaVenda = new Venda(DateTime.Now, valor);

                    // Adiciona a venda ao banco de dados
                    _database.AddVenda(novaVenda);

                    // Exibe uma mensagem de sucesso
                    Toast.MakeText(this, "Venda adicionada!", ToastLength.Short).Show();

                    // Limpa o campo de texto após a inserção
                    valorVendaEditText.Text = string.Empty;
                }
                else
                {
                    // Exibe mensagem de erro se o valor não for válido
                    Toast.MakeText(this, "Valor inválido. Digite um número válido.", ToastLength.Short).Show();
                }
            };
        }
    }
}