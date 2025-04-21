using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Messenger.App.UserControls.ChatControls
{
    public partial class UserLabelControl : UserControl
    {
        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(UserLabelControl), new UIPropertyMetadata(""));

        public UserLabelControl()
        {
            InitializeComponent();
        }
    }
}
