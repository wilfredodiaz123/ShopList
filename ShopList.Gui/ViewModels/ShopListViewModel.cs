using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopList.Gui.Models;
using System.Collections.ObjectModel;



namespace ShopList.Gui.ViewModels
{

    public partial class ShopListViewModel :  ObservableObject
    {
        [ObservableProperty]
        private string _nombreDelArticulo = string.Empty;
        [ObservableProperty]
        private int _cantidadAComprar = 1;
        [ObservableProperty]
        private Item? _itemSelecionado = null;

        //public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection <Item> Items { get;}

       // public string NombreDelArticulo
       // { 
       //     get => _nombreDelArticulo;
       //     set
       //     {
       //         if (_nombreDelArticulo != value)
       //         {
       //             _nombreDelArticulo = value;
       //             OnPropertyChanged(nameof(NombreDelArticulo));

       //         }
       //     }
       // }
       // public int CantidadDeComprar
       // {
       //     get => _cantidadAComprar;
       //     set
       //     {
       //         if (_cantidadAComprar != value)
       //         {
       //             _cantidadAComprar = value;
       //             OnPropertyChanged(nameof(CantidadDeComprar));
       //         }
       //     }
       // }

       //public ICommand AgregarShopListItemCommand { get; private set; }

        public ShopListViewModel()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
            //AgregarShopListItemCommand = new Command(AgregarShopListItems);
        }
        [RelayCommand]
        public void AgregarShopListItems()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo)|| CantidadAComprar <= 0)
            {
                return;
            }
            Random generador = new Random();
            var item = new Item
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadAComprar,
                Comprado = false,
            };
            Items.Add(item);
            NombreDelArticulo = string.Empty;
            CantidadAComprar = 1;
        }

        [RelayCommand]
        public void EliminarShopListItem()
        {
        
            if (ItemSelecionado != null && Items.Contains(ItemSelecionado))
            {
                Items.Remove(ItemSelecionado);
                ItemSelecionado = null;
            }
        }

        private void CargarDatos()
        {
            Items.Add(new Item()
            {
                Id = 1,
                Nombre = "Leche",
                Cantidad = 2,
                Comprado = false,

            });
            Items.Add(new Item()
            {
                Id = 2,
                Nombre = "Pan",
                Cantidad = 1,
                Comprado = false,

            });
            Items.Add(new Item()
            {
                Id = 3,
                Nombre = "Huevos",
                Cantidad = 30,
                Comprado = false,

            });
        }
        //private void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke
        //        (this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
