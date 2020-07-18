﻿using IhkObserver.Observer.Classes;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IhkObserver.WpfResultViewer.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private ObservableCollection<MenuItemViewModel> _menuItems;
        private ObservableCollection<MenuItemViewModel> _menuOptionItems;

        // The DialogCoordinator

        public MainViewModel()
        {
            // Load from Config
            string prNr = ConfigurationManager.AppSettings.Get("prNr");
            string idNr = ConfigurationManager.AppSettings.Get("idNr");

            // Create credentials
            Credentials cred = new Credentials(idNr, prNr);

            this.CreateMenuItems(cred);           
        }

        public void CreateMenuItems(Credentials cred)
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>
            {
                new HomeViewModel(this, cred)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Home},
                    Label = "Home",
                    ToolTip = "Welcome Home"
                },

                 new SettingsViewModel(this, cred)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.AccountSettings},
                    Label = "Settings",
                    ToolTip = "Configure your settings"
                },

                new AboutViewModel(this)
                {
                    Icon = new PackIconMaterial() {Kind = PackIconMaterialKind.Help},
                    Label = "About",
                    ToolTip = "About this one..."
                }
            };
        }

        public ObservableCollection<MenuItemViewModel> MenuItems
        {
            get => _menuItems;
            set => SetProperty(ref _menuItems, value);
        }

        public ObservableCollection<MenuItemViewModel> MenuOptionItems
        {
            get => _menuOptionItems;
            set => SetProperty(ref _menuOptionItems, value);
        }
    }
}
