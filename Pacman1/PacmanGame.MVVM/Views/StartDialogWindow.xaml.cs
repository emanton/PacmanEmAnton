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
            //Wichtig damit für ein geschlossenes Window kein DialogResult mehr gesetzt wird
            //GC räumt Window irgendwann weg und durch MakeWeak fliegt es auch beim IDialogResultVMHelper raus
            if (_isClosed) return;

            this.DialogResult = eventargs.DialogResult;
        }
    }
}
