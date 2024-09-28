using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.BottomNavigation;
using System;
using WMCommission.Models;

namespace WMCommission
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textMessage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button btnVenda = FindViewById<Button>(Resource.Id.btnVenda);
            Button btnBanco = FindViewById<Button>(Resource.Id.btnBanco);

            btnVenda.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(VendaActivity));
                StartActivity(intent);
            };

            // Ação do botão Banco
            btnBanco.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(BancoActivity));
                StartActivity(intent);
            };

            textMessage = FindViewById<TextView>(Resource.Id.message);
            /*
            // Instancia a lista de vendas
            var listaDeVendas = new ListaDeVendas();

            // Exemplo: Adicionando uma venda
            listaDeVendas.AdicionarVenda(new Venda(DateTime.Now, 100m));

            // Calculando a comissão (por exemplo, 10%)
            decimal comissao = listaDeVendas.CalcularComissao(10m);
            Console.WriteLine($"Comissão do mês: {comissao}");
            */
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        /*public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_venda:
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_gerenciar:
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
            }
            return false;
        }*/
    }
}

