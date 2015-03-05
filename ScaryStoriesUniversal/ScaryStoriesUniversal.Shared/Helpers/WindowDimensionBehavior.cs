using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;

namespace ScaryStoriesUniversal.Helpers
{

    [TypeConstraint(typeof(FrameworkElement))]
    class WindowDimensionBehavior : DependencyObject, IBehavior
    {
        public WindowDimensionBehavior()
        {
            this.WidthMultiple = 1;
            this.HeightMultiple = 1;
            this.HeightPercentage = double.NaN;
            this.WidthPercentage = double.NaN;
        }
        public DependencyObject AssociatedObject { get; set; }

        public FrameworkElement TypedObject { get; set; }
        public int WidthMultiple { get; set; }

        public double WidthPercentage { get; set; }

        public int HeightMultiple { get; set; }

        public double HeightPercentage { get; set; }

        public void Attach(DependencyObject associatedObject)
        {
            this.AssociatedObject = this.TypedObject = associatedObject as FrameworkElement;

            this.TypedObject.Loaded += TypedObject_Loaded;
            Window.Current.SizeChanged += Current_SizeChanged;

        }

        void TypedObject_Loaded(object sender, RoutedEventArgs e)
        {
            Handle();
        }

        void Current_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            Handle();
        }

        private void Handle()
        {
            var frameWorkElement = (this.TypedObject as FrameworkElement);

            //I base all the percentage calculations on shortest dimension, you can modify this depending on your layouts requirements.
            double shortestDimension = (Window.Current.Bounds.Width <= Window.Current.Bounds.Height) ?
                            Window.Current.Bounds.Width : Window.Current.Bounds.Height;

            if (frameWorkElement != null)
            {
                if (this.WidthPercentage != double.NaN)
                    frameWorkElement.Width = shortestDimension * this.WidthPercentage * this.WidthMultiple;
                if (this.HeightPercentage != double.NaN)
                    frameWorkElement.Height = shortestDimension * this.HeightPercentage * this.HeightMultiple;
            }
        }

        public void Detach()
        {
            Window.Current.SizeChanged -= Current_SizeChanged;
            (this.AssociatedObject as Control).Loaded -= TypedObject_Loaded;

        }
    }
}