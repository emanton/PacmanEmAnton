using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PacmanGame.MVVM.Interfaces;
using PacmanGame.MVVM.Views;

namespace PacmanGame.MVVM.Core
{
    public class WpfUIWindowDialogService : IUIWindowDialogService
    {
        public bool? ShowDialog(string title, object datacontext)
        {
            Window win = null;
            switch (title)
            {
                case "StartDialogWindow":
                {
                    win = new StartDialogWindow();
                }
                    break;
                case "ResultsDialogWindow":
                    {
                        win = new ResultsDialogWindow();
                    }
                    break;
            }
            
            win.Title = title;
            win.DataContext = datacontext;

            return win.ShowDialog();
        }

    }
}
