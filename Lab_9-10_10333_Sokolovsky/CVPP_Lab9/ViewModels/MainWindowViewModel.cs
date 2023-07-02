using Microsoft.Win32;
using SVPP_Lab9.Business.Infrastucture;
using SVPP_Lab9.Business.Managers;
using SVPP_Lab9.Commands;
using SVPP_Lab9.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SVPP_Lab9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ManagersFactory factory;
        StoreManager storeManager;
        PCManager PCManager;
        #region Public properties
        public ObservableCollection<PC> PCs { get; set; }
        public ObservableCollection<Store> Stores { get; set; }
        public string Title { get => title; set => title = value; }
        #region Выбранный магазин
        private Store _selectedStore;
        public Store SelectedStore
        {
            get => _selectedStore;
            set
            {
                Set(ref _selectedStore, value);
            }
        }
        #endregion
        #region Выбранный товар

        private PC _selectedPC;
        public PC SelectedPC
        {
            get => _selectedPC;
            set
            {
                Set(ref _selectedPC, value);
            }
        }

        #endregion
        #endregion

        private string title = "Stores Window";
        public MainWindowViewModel()
        {
            factory = new ManagersFactory("DefaultConnection");
            storeManager = factory.GetStoreManager();

            if(storeManager.Stores.Count() == 0) {
                DbTestData.SetupData(storeManager);
            }

            

            PCManager = factory.GetPcManager();
            PCs = new ObservableCollection<PC>();
            Stores = new ObservableCollection<Store>(storeManager.Stores);

            if (Stores.Count > 0) 
                OnGetPCExecuted(Stores[0].StoreId);
        }

        #region Commands
        #region Выбор магазина в списке
        private ICommand _getPCCommand;
        public ICommand getPCCommand => _getPCCommand ?? new RelayCommand(OnGetPCExecuted);

        private async void OnGetPCExecuted(object id)
        {
            PCs.Clear();
            var pcs = await storeManager.GetPCOfStoreAsync((int)id);
            foreach ( PC pc in pcs) { PCs.Add(pc); }
        }
        #endregion
        #region Добавление товара

        private ICommand _newPCCommand;
        public ICommand NewPCCommand =>
            _newPCCommand ??= new RelayCommand(OnNewPCExecuted);
        private void OnNewPCExecuted(object id)
        {
            var dialog = new EditPCWindow
            {
                BuildDate = DateTime.Now,
                Price = 0
            };
            if (dialog.ShowDialog() != true) return;
            var pc = new PC
            {
                Brand = dialog.Brand,
                BuildDate = dialog.BuildDate
            };
            var fileName = Path.GetFileName(dialog.ImagePass);
            pc.ImageFileName = fileName;
            storeManager.AddPCToStore(pc,
                _selectedStore.StoreId);
            var target = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            File.Copy(dialog.ImagePass, target);
            PCs.Add(pc);
        }

        #endregion

        #region Изменение товара

        private ICommand _editPCCommand;
        public ICommand EditPCCommand => _editPCCommand ??= new RelayCommand(OnEditPCExecuted, EditPCCanExecute);

        private bool EditPCCanExecute(object p) => _selectedPC != null;
        private void OnEditPCExecuted(object id)
        {
            var dialog = new EditPCWindow
            {
                Brand = _selectedPC.Brand,
                BuildDate = _selectedPC.BuildDate,
                ImagePass = _selectedPC.ImageFileName,
                Price = _selectedPC.Price
            };
            if(dialog.ShowDialog() != true) return;
            var imageFolderPass = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!_selectedPC.ImageFileName.Equals(dialog.ImagePass)){
                File.Delete(Path.Combine(imageFolderPass, _selectedPC.ImageFileName));
                var newImage = Path.GetFileName(dialog.ImagePass);
                File.Copy(dialog.ImagePass, Path.Combine(imageFolderPass, newImage));
                _selectedPC.ImageFileName = newImage;
            }
            _selectedPC.Price = dialog.Price;
            _selectedPC.Brand = dialog.Brand;
            _selectedPC.BuildDate = dialog.BuildDate;
            PCManager.UpdatePC(_selectedPC);
            OnGetPCExecuted(_selectedStore.StoreId);

        }
        #endregion

        #region Удаление товара

        private ICommand _deletePCCommand;
        public ICommand DeletePCCommand =>
            _deletePCCommand
            ??= new RelayCommand(OnDeletePCExecuted, DeletePCCanExecute);
        private bool DeletePCCanExecute(object p) =>
            _selectedPC != null;
        private void OnDeletePCExecuted(object id)
        {
            var imageFolderPass = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            File.Delete(Path.Combine(imageFolderPass, _selectedPC.ImageFileName));
            PCManager.DeletePC(_selectedPC.PCId);

            OnGetPCExecuted(_selectedStore.StoreId);
        }
        #endregion
        #endregion


    }

}
