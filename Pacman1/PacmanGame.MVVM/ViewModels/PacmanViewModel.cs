using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Ninject;
using PacmanGame.BLL.Interfaces;
using PacmanGame.BLL.Packages;
using PacmanGame.BLL.Services;
using PacmanGame.ComputerLogics.Core;
using PacmanGame.ComputerLogics.Interfaces;
using PacmanGame.ComputerLogics.Logics;
using PacmanGame.ComputerLogics.Models;
using PacmanGame.MVVM.Core;
using PacmanGame.MVVM.Interfaces;
using PacmanGame.MVVM.Models;
using z.Core;

namespace PacmanGame.MVVM.ViewModels
{
    public class PacmanGameViewModel : ObservableObject, IDialogResultVMHelper
    {
        private readonly WpfUIWindowDialogService uiDialogService = new WpfUIWindowDialogService();
        private readonly IUserService userService;
        private List<PointXY> blocks;
        private IMovingLogic computerLogic;
        private bool isGameEnded;
        private int score;
        private List<Thread> threads;

        public PacmanGameViewModel()
        {
            userService = MyNInject.GetKernel().Get<UserService>();
            LogicModes = new List<string>();
            LogicModes.Add("MyLogic");
            var result = uiDialogService.ShowDialog("StartDialogWindow", this);
        }

        public IEnumerable<UserPackage> Results { get; set; }

        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                RaisePropertyChangedEvent("Score");
            }
        }

        private ObservableCollection<PointXY> fieldPoints { get; set; }

        public ObservableCollection<PointXY> FieldPoints
        {
            get { return fieldPoints; }
            set
            {
                fieldPoints = value;
                RaisePropertyChangedEvent("FieldPoints");
            }
        }

        public Pacman pacman { get; set; }
        public List<Ghost> ghosts { get; set; }
        public List<string> LogicModes { get; set; }
        public string SelectedLogic { get; set; }
        public string UserName { get; set; }

        public ICommand ShowResultsCommand
        {
            get { return new DelegateCommand(ShowResults); }
        }

        public ICommand RunGameCommand
        {
            get { return new DelegateCommand(RunGame); }
        }

        public ICommand TurnLeftCommand
        {
            get { return new DelegateCommand(TurnLeft); }
        }

        public ICommand TurnUpCommand
        {
            get { return new DelegateCommand(TurnUp); }
        }

        public ICommand TurnRightCommand
        {
            get { return new DelegateCommand(TurnRight); }
        }

        public ICommand TurnDownCommand
        {
            get { return new DelegateCommand(TurnDown); }
        }

        public ICommand LoginCommand
        {
            get { return new DelegateCommand(Login); }
        }

        public event EventHandler<RequestCloseDialogEventArgs> RequestCloseDialog;

        private void Login()
        {
            switch (SelectedLogic)
            {
                case "MyLogic":
                {
                    computerLogic = new MyLogic();
                }
                    break;
            }

            InvokeRequestCloseDialog(new RequestCloseDialogEventArgs(true));
        }

        private void ShowResults()
        {
            Results = new List<UserPackage>();
            Results = userService.GetAll().OrderBy(us => us.Score).Reverse();
            var result = uiDialogService.ShowDialog("ResultsDialogWindow", this);
        }

        private void RunGame()
        {
            if (threads != null)
            {
                foreach (var thread in threads)
                {
                    thread.Abort();
                }
            }
            Score = 0;
            isGameEnded = false;
            var map = new Map();
            blocks = map.Maps[0];
            FieldPoints = new ObservableCollection<PointXY>();
            foreach (var block in blocks)
            {
                FieldPoints.Add(block);
            }

            FillYam();
            threads = new List<Thread>();
            pacman = new Pacman(0, 0);
            FieldPoints.Add(pacman);
            var pacmanThread = new Thread(MovePacmanGame);
            pacmanThread.Start();
            threads.Add(pacmanThread);
            ghosts = new List<Ghost>();
            for (var i = 0; i < 4; i++)
            {
                ghosts.Add(new Ghost(i*40 + 40, 0, computerLogic));
                FieldPoints.Add(ghosts[i]);
                var ghostThread = new Thread(MoveGhost);
                ghostThread.Start(i);
                threads.Add(ghostThread);
            }
        }

        private void FillYam()
        {
            bool isEnabled;
            for (var i = 0; i < 12; i++)
            {
                for (var j = 0; j < 7; j++)
                {
                    isEnabled = true;
                    foreach (var block in blocks)
                    {
                        if (block.X == i*40 && block.Y == j*40)
                        {
                            isEnabled = false;
                            break;
                        }
                    }

                    if (isEnabled)
                    {
                        FieldPoints.Add(new Yam {X = i*40, Y = j*40});
                    }
                }
            }
        }

        private void MovePacmanGame()
        {
            while (!isGameEnded)
            {
                Thread.Sleep(100);
                if (pacman.IsMovingAlowed(blocks))
                {
                    pacman.Move();
                    Score += GameManager.CheckForYam(pacman, FieldPoints);
                    var isFinished = true;
                    foreach (var smt in FieldPoints)
                    {
                        if (smt is Yam)
                        {
                            isFinished = false;
                            break;
                        }
                    }

                    if (isFinished)
                    {
                        AddResult();
                        isGameEnded = true;
                    }
                }
            }
        }

        private void MoveGhost(object state)
        {
            var id = (int) state;
            while (!isGameEnded)
            {
                Thread.Sleep(150);
                ghosts[id].DoMove(blocks, pacman);
            }
        }

        private void TurnLeft()
        {
            if (pacman.IsMovingAlowed(blocks, 4))
            {
                pacman.Direction = 4;
            }
        }

        private void TurnUp()
        {
            if (pacman.IsMovingAlowed(blocks, 1))
            {
                pacman.Direction = 1;
            }
        }

        private void TurnRight()
        {
            if (pacman.IsMovingAlowed(blocks, 2))
            {
                pacman.Direction = 2;
            }
        }

        private void TurnDown()
        {
            if (pacman.IsMovingAlowed(blocks, 3))
            {
                pacman.Direction = 3;
            }
        }

        private void AddResult()
        {
            var a = userService.Add(new UserPackage {Id = 1, Name = UserName, Score = Score});
            DispatchService.Invoke(() => { ShowResults(); });
        }

        private void InvokeRequestCloseDialog(RequestCloseDialogEventArgs e)
        {
            var handler = RequestCloseDialog;
            if (handler != null)
                handler(this, e);
        }
    }
}