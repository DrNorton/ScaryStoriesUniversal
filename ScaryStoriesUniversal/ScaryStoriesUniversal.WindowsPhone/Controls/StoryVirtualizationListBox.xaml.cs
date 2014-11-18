using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using Caliburn.Micro;
using ScaryStoriesUniversal.Helpers;
using ScaryStoriesUniversal.ViewModels;
using ScaryStoriesUniversal.ViewModels.Base;

namespace ScaryStoriesUniversal.Controls
{
    public sealed partial class StoryVirtualizationListBox : UserControl
    {
        public StoryVirtualizationListBox()
        {
            this.InitializeComponent();
        }

    }
}
