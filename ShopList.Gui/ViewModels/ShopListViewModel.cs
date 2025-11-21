using ShopList.Gui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopList.Gui.ViewModels
{
    public class ShopListViewModel : INotifyPropertyChanged
    {
        private string _nombreDelArticulo = string.Empty;
        private int _cantidadAComprar = 1;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection <Item> Items { get;}

        public string NombreDelArticulo
        { 
            get => _nombreDelArticulo;
            set
            {
                if (_nombreDelArticulo != value)
                {
                    _nombreDelArticulo = value;
                    OnPropertyChanged(nameof(NombreDelArticulo));

                }
            }
        }
        public int CantidadDeComprar
        {
            get => _cantidadAComprar;
            set
            {
                if (_cantidadAComprar != value)
                {
                    _cantidadAComprar = value;
                    OnPropertyChanged(nameof(CantidadDeComprar));
                }
            }
        }

       public ICommand AgregarShopListItemCommand { get; private set; }

        public ShopListViewModel()
        {
            Items = new ObservableCollection<Item>();
            CargarDatos();
            AgregarShopListItemCommand = new Command(AgregarShopListItems);
        }
        public void AgregarShopListItems()
        {
            if (string.IsNullOrEmpty(NombreDelArticulo)|| CantidadDeComprar <= 0)
            {
                return;
            }
            Random generador = new Random();
            var item = new Item
            {
                Id = generador.Next(),
                Nombre = NombreDelArticulo,
                Cantidad = CantidadDeComprar,
                Comprado = false,
            };
            Items.Add(item);
            NombreDelArticulo = string.Empty;
            CantidadDeComprar = 1;
        }
        public void EliminarShopListItem()
        {

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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
