using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PacmanGame.MVVM.Core;
using PacmanGame.MVVM.Interfaces;

namespace PacmanGame.MVVM.Views
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class StartDialogWindow : Window
    {
        private bool _isClosed = false;
        public StartDialogWindow()
        {
            InitializeComponent();
            this.DialogPresenter.DataContextChanged += DialogPresenterDataContextChanged;
            this.Closed += DialogWindowClosed;
        }

        void DialogWindowClosed(object sender, EventArgs e)
        {
            this._isClosed = true;
        }

        private void DialogPresenterDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var d = e.NewValue as IDialogResultVMHelper;

            if (d == null)
                return;

            d.RequestCloseDialog += new EventHandler<RequestCloseDialogEventArgs>(DialogResultTrueEvent).MakeWeak(eh => d.RequestCloseDialog -= eh);
        }

        private void DialogResultTrueEvent(object sender, RequestCloseDialogEventArgs eventargs)
        {
            if (_isClosed) return;

            this.DialogResult = eventargs.DialogResult;
        }

        private void modeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.modeComboBox.SelectedValue.ToString()))
            {
                this.modeTextBlock.Foreground = Brushes.Black;
            }
            else
            {
                this.modeTextBlock.Foreground = Brushes.Red;
            }

            ChangeButtonEnabling();
        }

        private void nameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.nameTextBox.Text))
            {
                this.userTextBlock.Foreground = Brushes.Black;
            }
            else
            {
                this.userTextBlock.Foreground = Brushes.Red;
            }

            ChangeButtonEnabling();
        }

        private void ChangeButtonEnabling()
        {
            if (this.userTextBlock.Foreground == Brushes.Black && this.modeTextBlock.Foreground == Brushes.Black)
            {
                this.startButton.IsEnabled = true;
            }
            else
            {
                this.startButton.IsEnabled = false;
            }
        }
    }
}
