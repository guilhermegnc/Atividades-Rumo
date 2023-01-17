using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PetShopManagement.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView 
        {
            get { 
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChange(nameof(CurrentChildView));
            }
        }
        public string Caption 
        {
            get
            {
                return _caption;
                
            }
            set
            {
                _caption = value;
                OnPropertyChange(nameof(Caption));
            }
        }
        public IconChar Icon 
        {
            get
            {
                return _icon;

            }
            set
            {
                _icon = value;
                OnPropertyChange(nameof(Icon));
            }
        }

        // Commands
        public ICommand ShowRegisterViewCommand { get; }
        public ICommand ShowListClientViewCommand { get; }
        public ICommand ShowSearchClientViewCommand { get; }
        public ICommand ShowMonthBirthdaysViewCommand { get; }

        public MainViewModel()
        {
            // Initialize commands
            ShowRegisterViewCommand = new ViewModelCommand(ExecuteShowRegisterViewCommand);
            ShowListClientViewCommand = new ViewModelCommand(ExecuteShowListClientViewCommand);
            ShowSearchClientViewCommand = new ViewModelCommand(ExecuteShowSearchClientViewCommand);
            ShowMonthBirthdaysViewCommand = new ViewModelCommand(ExecuteShowMonthBirthdaysViewCommand);


            ExecuteShowRegisterViewCommand(null);
        }

        private void ExecuteShowMonthBirthdaysViewCommand(object obj)
        {
            CurrentChildView = new RegisterViewModel();
            Caption = "Aniversariantes do mês";
            Icon = IconChar.BirthdayCake;
        }

        private void ExecuteShowSearchClientViewCommand(object obj)
        {
            CurrentChildView = new RegisterViewModel();
            Caption = "Buscar Cliente";
            Icon = IconChar.Search;
        }

        private void ExecuteShowListClientViewCommand(object obj)
        {
            CurrentChildView = new RegisterViewModel();
            Caption = "Listar Clientes";
            Icon = IconChar.PeopleGroup;
        }

        private void ExecuteShowRegisterViewCommand(object obj)
        {
            CurrentChildView = new RegisterViewModel();
            Caption = "Cadastro Cliente";
            Icon = IconChar.PersonCirclePlus;
        }
    }
}
