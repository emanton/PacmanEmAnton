using System;
using System.Windows;
using PacmanGame.MVVM.Core;
using PacmanGame.MVVM.Interfaces;

namespace PacmanGame.MVVM.Views
{
    /// <summary>
    ///     Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class ResultsDialogWindow : Window
    {
        private bool _isClosed;

        public ResultsDialogWindow()
        {
            InitializeComponent();
            DialogPresenter.DataContextChanged += DialogPresenterDataContextChanged;
            Closed += DialogWindowClosed;
        }

        private void DialogWindowClosed(object sender, EventArgs e)
        {
            _isClosed = true;
        }

        private void DialogPresenterDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var d = e.NewValue as IDialogResultVMHelper;

            if (d == null)
                return;

            d.RequestCloseDialog +=
                new EventHandler<RequestCloseDialogEventArgs>(DialogResultTrueEvent).MakeWeak(
                    eh => d.RequestCloseDialog -= eh);
        }

        private void DialogResultTrueEvent(object sender, RequestCloseDialogEventArgs eventargs)
        {
            //Wichtig damit für ein geschlossenes Window kein DialogResult mehr gesetzt wird
            //GC räumt Window irgendwann weg und durch MakeWeak fliegt es auch beim IDialogResultVMHelper raus
            if (_isClosed) return;

            DialogResult = eventargs.DialogResult;
        }
    }
}