using Shared_Lib.MVVM;
using System.Threading.Tasks;

namespace Study_WPF
{
    public class ViewModel : BaseVModel
    {
        public ViewModel()
        {
            Setup_StartCMD();
        }

        private void Setup_StartCMD()
        {
            CMD_Start = new cus_CMD();
            CMD_Start.Name = "Start";
            CMD_Start.Action = async (a) =>
            {
                //a protection to avoid executing an already running Command
                if (CMD_Start.CommandState == cus_CMD.ButtonStat.DontExecute)
                {
                    return;
                }
                CMD_Start.SetButtonState(cus_CMD.ButtonStat.DontExecute);
                CMD_Start.Name = "Working...";

                await Start();
                CMD_Start.SetButtonState(cus_CMD.ButtonStat.CanExecute);
                CMD_Start.Name = "Start";
            };
        }

        async private Task Start()
        {
            for (int i = 3; i > 0; i--)
            {
                Text = $"Starting in {i} Seconds";
                await Task.Delay(1000);
            }
            ProgressValue = 0;
            MaxValue = 100;
            for (int i = 0; i < 100; i++)
            {
                ProgressValue += 1;
                Text = $"Testing { ProgressValue} of { MaxValue}";
                await Task.Delay(100);
            }
            Text = "All Tests are Done";
        }

        #region CMD_Start

        private cus_CMD _CMD_Start;

        public cus_CMD CMD_Start
        {
            get
            {
                return _CMD_Start;
            }
            set { SetProperty(ref _CMD_Start, value); }
        }

        #endregion CMD_Start

        #region Text

        private string _Text;

        public string Text
        {
            get
            {
                return _Text;
            }
            set { SetProperty(ref _Text, value); }
        }

        #endregion Text

        #region MaxValue

        private double _MaxValue = 100;

        public double MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set { SetProperty(ref _MaxValue, value); }
        }

        #endregion MaxValue

        #region ProgressValue

        private double _ProgressValue;

        public double ProgressValue
        {
            get
            {
                return _ProgressValue;
            }
            set { SetProperty(ref _ProgressValue, value); }
        }

        #endregion ProgressValue
    }
}