using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api.Entities;
using Telerik.Core.Data;

namespace ScaryStoriesUniversal.ViewModels.Base
{
    public abstract class VirtualizationListViewModel<T>:LoadingScreen where T:IBaseEntity,new()
    {
        
        protected int _currentEndIndex = 0;
        private const int _currentCount = 20;

        private IEnumerable _items;
        private T _selectedItem;

        public VirtualizationListViewModel(INavigationService navigationService)
            :base(navigationService)
        {
            base.IsLoading = true;
            Items = new IncrementalLoadingCollection<T>((res) =>
            {
               var result= GetItems(res);
                _currentEndIndex += _currentCount;
                return result;
            }) { BatchSize = _currentCount };
        }

        public IEnumerable Items
        {
            get { return _items; }
            set
            {
                _items = value;
                base.NotifyOfPropertyChange(()=>Items);
            }
        }

        public T SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                if (value != null)
                {
                    OnSelectItem(value);
                    SelectedItem = default(T);
                }
                base.NotifyOfPropertyChange(()=>SelectedItem);
            }
        }

        

        public abstract Task<IEnumerable<T>> GetItems(uint count);

        public abstract void OnSelectItem(T item);
    }
}
