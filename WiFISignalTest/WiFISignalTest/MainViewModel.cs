using Henry.MvvmBase;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Timers;
using System.Windows.Input;

namespace WiFISignalTest
{
    public class MainViewModel : ModelBase
    {
        public MainViewModel()
        {
            measureTimer = new Timer(100);
            measureTimer.Elapsed += MeasureTimer_Elapsed;
        }

        private void MeasureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }

        public Timer measureTimer;

        public string ButtonContent
        {
            get
            {
                if (measureTimer.Enabled)
                    return "Stop";
                else
                    return "Start";
            }
        }

        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan MeasureTime { get; set; }

        public ObservableCollection<EventModel> EventModelCollection { get; set; }
            = new ObservableCollection<EventModel>();


        public DataSet ResultDataSet { get; set; } = new DataSet("Result");


        public ICommand StartStopCommand { get { return new DelegateCommand(StartStop); } }

        private void StartStop(object obj)
        {
            if (measureTimer.Enabled)
                EndMeasure();

            else
                StartMeasure();

            NotifyPropertyChanged("ButtonContent");
        }

        private void StartMeasure()
        {
            StartTime = DateTime.Now; NotifyPropertyChanged("StartTime");
            measureTimer.Start();

        }

        private void EndMeasure()
        {
            measureTimer.Stop();
        }
    }
}