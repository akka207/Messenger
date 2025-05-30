using System.Windows;
using System.Windows.Controls;

namespace Messenger.App.UserControls
{
    /// <summary>
    /// Interaction logic for CircleImageButton.xaml
    /// </summary>
    public partial class CircleImageButton : UserControl
    {
		#region Attached properties area
		public string IconPath
		{
			get { return (string)GetValue(IconPathProperty); }
			set { SetValue(IconPathProperty, value); }
		}

		public static readonly DependencyProperty IconPathProperty =
			DependencyProperty.Register("IconPath", typeof(string), typeof(CircleImageButton), new UIPropertyMetadata(""));

		public int ImageWidth
		{
			get { return (int)GetValue(ImageWidthProperty); }
			set { SetValue(ImageWidthProperty, value); }
		}

		public static readonly DependencyProperty ImageWidthProperty =
			DependencyProperty.Register("ImageWidth", typeof(int), typeof(CircleImageButton), new UIPropertyMetadata(0));

		public int ImageHeight
		{
			get { return (int)GetValue(ImageHeightProperty); }
			set { SetValue(ImageHeightProperty, value); }
		}

		public static readonly DependencyProperty ImageHeightProperty =
			DependencyProperty.Register("ImageHeight", typeof(int), typeof(CircleImageButton), new UIPropertyMetadata(0));
		#endregion

		public event EventHandler OnClick;

        public CircleImageButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OnClick?.Invoke(this, e);
        }
    }
}
