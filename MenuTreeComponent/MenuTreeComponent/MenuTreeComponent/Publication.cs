using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MenuTreeComponent
{
    public enum PStatus { Indefinite, InProgress, Success, Failed };

    public class Publication : INotifyPropertyChanged
    {
        public static readonly Dictionary<PStatus, Visual> StatusIcons = new Dictionary<PStatus, Visual>()
        {
            { PStatus.Indefinite, App.Current.Resources["appbar_question"] as Visual },
            { PStatus.InProgress, App.Current.Resources["appbar_progress"] as Visual },
            { PStatus.Success, App.Current.Resources["appbar_check"] as Visual },
            { PStatus.Failed, App.Current.Resources["appbar_close"] as Visual }
        };

        public string ApiKey { get; private set; }

        public string Name { get; private set; }

        public ObservableCollection<Command> Commands { get; private set; }

        private Timer Timer = new Timer(100);

        public Publication(string apiKey, string name, ObservableCollection<Command> commands)
        {
            this.ApiKey = apiKey;
            this.Name = name;
            this.Commands = commands;
            this.Timer.Elapsed += Tick;
        }

        public PStatus Status
        {
            get
            {
                if (this.Commands != null && this.Commands.Count > 0)
                {
                    if (this.Commands.Any(c => c.Status == PStatus.InProgress))
                        return PStatus.InProgress;
                    if (this.Commands.All(c => c.Status == PStatus.Success))
                        return PStatus.Success;
                    if (this.Commands.Any(c => c.Status == PStatus.Failed))
                        return PStatus.Failed;
                }
                return PStatus.Indefinite;
            }
        }

        public Visual StatusIcon
        {
            get
            {
                return Publication.StatusIcons[this.Status];
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void Execute()
        {
            this.ExecutionStart();
            foreach(Command cmd in this.Commands)
            {
                Task.Run(() => { cmd.Execution(cmd); });
            }
        }

        public void ExecutionStart()
        {
            if (!this.Timer.Enabled)
            {
                this.Timer.Start();
            }
        }

        public bool CanRestart
        {
            get
            {
                return this.Status == PStatus.Failed;
            }
        }

        public void Restart()
        {
            if (this.CanRestart)
            {
                this.ExecutionStart();
                foreach (Command cmd in this.Commands.Where(c => c.CanRestart))
                {
                    Task.Run(() => { cmd.Execution(cmd); });
                }
            }
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged("StatusIcon");
            OnPropertyChanged("CanRestart");
            if (this.Status != PStatus.InProgress)
            {
                this.Timer.Stop();
            }
        }
    }

    public class Command : INotifyPropertyChanged
    {
        public string ID { get; private set; }

        public string FileName { get; private set; }

        public string Start { get; private set; }

        public string End { get; private set; }

        private PStatus _status;

        public PStatus Status
        {
            get
            {
                return _status;
            }
            private set
            {
                _status = value;
                OnPropertyChanged("StatusIcon");
                OnPropertyChanged("CanRestart");
            }
        }

        public Visual StatusIcon
        {
            get
            {
                return Publication.StatusIcons[this.Status];
            }
        }

        public Command() { }

        public Command(string fileName, Action<Command> execution)
        {
            this.ID = Guid.NewGuid().ToString();
            this.FileName = fileName;
            this.Execution = execution;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Action<Command> Execution { get; private set; }

        public void ExecutionStart()
        {
            this.Status = PStatus.InProgress;
            this.Start = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            this.End = null;
            OnPropertyChanged("Start");
            OnPropertyChanged("End");
        }

        public void ExecutionEnd(PStatus status)
        {
            this.Status = status;
            this.End = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
            OnPropertyChanged("End");
        }

        public bool CanRestart
        {
            get
            {
                return this.Status == PStatus.Failed;
            }
        }

        public void Restart()
        {
            if (this.CanRestart)
            {
                this.Execution(this);
            }
        }
    }
}
