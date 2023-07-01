using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViraCare.Utilities;
using ViraCare.Models;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.Xpf;

namespace ViraCare.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        DataContext _Context;
        IList<Input> _ItemsSource;
        public IList<Input> ItemsSource
        {
            get
            {
                if (_ItemsSource == null && !DevExpress.Mvvm.ViewModelBase.IsInDesignMode)
                {
                    _Context = new DataContext();
                    _ItemsSource = _Context.Inputs.ToList();
                }
                return _ItemsSource;
            }
        }

        void ValidateRow(RowValidationArgs args)
        {
            var item = (Input)args.Item;
            if (args.IsNewItem)
                _Context.Inputs.Add(item);
            _Context.SaveChanges();
        }
        ICommand _ValidateRowCommandCommand;
        public ICommand ValidateRowCommandCommand
        {
            get
            {
                if (_ValidateRowCommandCommand == null)
                {
                    _ValidateRowCommandCommand = new DelegateCommand<RowValidationArgs>(ValidateRow);
                }
                return _ValidateRowCommandCommand;
            }
        }

        void ValidateRowDeletion(ValidateRowDeletionArgs args)
        {
            var item = (Input)args.Items.Single();
            _Context.Inputs.Remove(item);
            _Context.SaveChanges();
        }
        ICommand _ValidateRowDeletionCommandCommand;
        public ICommand ValidateRowDeletionCommandCommand
        {
            get
            {
                if (_ValidateRowDeletionCommandCommand == null)
                {
                    _ValidateRowDeletionCommandCommand = new DelegateCommand<ValidateRowDeletionArgs>(ValidateRowDeletion);
                }
                return _ValidateRowDeletionCommandCommand;
            }
        }

        void DataSourceRefresh(DataSourceRefreshArgs args)
        {
            _ItemsSource = null;
            _Context = null;
            OnPropertyChanged(nameof(ItemsSource));
        }
        ICommand _DataSourceRefreshCommandCommand;
        public ICommand DataSourceRefreshCommandCommand
        {
            get
            {
                if (_DataSourceRefreshCommandCommand == null)
                {
                    _DataSourceRefreshCommandCommand = new DelegateCommand<DataSourceRefreshArgs>(DataSourceRefresh);
                }
                return _DataSourceRefreshCommandCommand;
            }
        }
    }
}
