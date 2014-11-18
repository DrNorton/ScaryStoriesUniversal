﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using ScaryStoriesUniversal.Api;
using ScaryStoriesUniversal.Api.Entities;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.ViewModels
{
    public class FindViewModel
        //: VirtualizationListViewModel<Story>
    {

        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private readonly StoryListIdsContainer _idsContainer;

        private string _pattern;
       

        public FindViewModel(INavigationService navigationService, IApiService apiService, StoryListIdsContainer idsContainer)
        {
            _navigationService = navigationService;
            _apiService = apiService;
            _idsContainer = idsContainer;
         
        }

        public string Pattern
        {
            get { return _pattern; }
            set
            {
                _pattern = value;
                Clear();
               // base.NotifyOfPropertyChange(()=>Pattern);
            }
        }

        private void Clear()
        {
          //  _currentEndIndex = 0;
          //  Items.Clear();
        }

      

        public async void Find()
        {
            if (!String.IsNullOrEmpty(_pattern))
            {
                //await GetItems();
            }
        }

       

     

        //public async  Task GetItems()
        //{
        //    if (!String.IsNullOrEmpty(_pattern))
        //    {
        //        base.Wait(true);
        //        var stories = await _apiService.FindStories(_pattern, _fetchCount, _currentEndIndex);
        //        foreach (var story in stories)
        //        {
        //            Items.Add(story);
        //        }
        //        base.Wait(false);
        //    }
        //}

        //public override void OnSelectItem(Story item)
        //{
        //    _idsContainer.SetIds(Items.Select(x => x.Id));
        //    _idsContainer.Position = Items.IndexOf(item);
        //    _navigationService.UriFor<StoryViewModel>().Navigate();
        //}
    }
}
