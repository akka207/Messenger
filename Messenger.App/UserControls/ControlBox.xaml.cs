using System.Windows.Controls;
using System.Windows.Input;

namespace Messenger.App.UserControls
{
    /// <summary>
    /// Interaction logic for ControlBox.xaml
    /// </summary>
    public partial class ControlBox : UserControl
    {
        public event EventHandler OnDrag;
        public event EventHandler OnMinimize;
        public event EventHandler OnClose;

        public ControlBox()
        {
            InitializeComponent();
        }

        private void DragPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OnDrag?.Invoke(this, e);
        }

        private void minimize_OnClick(object sender, EventArgs e)
        {
            OnMinimize?.Invoke(this, e);
        }

        private void close_OnClick(object sender, EventArgs e)
        {
            OnClose?.Invoke(this, e);
        }
    }
}
