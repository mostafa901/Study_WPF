using System;
using System.Windows;
using System.Windows.Media;

namespace Shared_Lib.MVVM
{
    public class BaseDataObject : ObservableObject
    {
        public BaseDataObject()
        {
            GuId = Guid.NewGuid();
        }

        #region Name

        private string name = "";

        virtual public string Name
        {
            get
            {
                return name;
            }
            set { SetProperty(ref name, value); }
        }

        #endregion Name

        #region Code

        private string code;

        virtual public string Code
        {
            get
            {
                return code;
            }
            set { SetProperty(ref code, value); }
        }

        #endregion Code

        #region CMD

        private cus_CMD cMD;

        public cus_CMD CMD
        {
            get
            {
                if (cMD == null)
                {
                    cMD = new cus_CMD();
                }

                return cMD;
            }
            set { SetProperty(ref cMD, value); }
        }

        #endregion CMD

        #region CMD_Refresh

        private cus_CMD _CMD_Refresh;

        public cus_CMD CMD_Refresh
        {
            get
            {
                if (_CMD_Refresh == null) _CMD_Refresh = new cus_CMD();
                return _CMD_Refresh;
            }
            set { SetProperty(ref _CMD_Refresh, value); }
        }

        #endregion CMD_Refresh

        #region Icon

        private object _Icon;

        public object Icon
        {
            get
            {
                return _Icon;
            }
            set { SetProperty(ref _Icon, value); }
        }

        #endregion Icon

        #region Width

        private double _Width = 25;

        public double Width
        {
            get
            {
                return _Width;
            }
            set { SetProperty(ref _Width, value); }
        }

        #endregion Width

        #region Height

        private double _Height = 30;

        public double Height
        {
            get
            {
                return _Height;
            }
            set { SetProperty(ref _Height, value); }
        }

        #endregion Height

        #region Angle

        private double _Angle;

        public virtual double Angle
        {
            get
            {
                return _Angle;
            }
            set { SetProperty(ref _Angle, value); }
        }

        #endregion Angle

        #region ToolTip

        private string _ToolTip;

        public string ToolTip
        {
            get
            {
                if (string.IsNullOrEmpty(_ToolTip))
                {
                    _ToolTip = ((dynamic)this).GetType()?.Name;
                }
                return _ToolTip;
            }
            set { SetProperty(ref _ToolTip, value); }
        }

        #endregion ToolTip

        #region DisBrush

        private Brush _DisBrush;

        public Brush DisBrush

        {
            get
            {
                return _DisBrush;
            }
            set
            {
                SetProperty(ref _DisBrush, value);
            }
        }

        #endregion DisBrush

        #region Visibility

        private Visibility _Visible;

        public Visibility Visible

        {
            get
            {
                return _Visible;
            }
            set { SetProperty(ref _Visible, value); }
        }

        #endregion Visibility
    }
}