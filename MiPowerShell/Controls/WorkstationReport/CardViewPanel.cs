using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiPowerShell.Controls.WorkstationReport
{
    public partial class CardViewPanel : UserControl
    {
        public CardViewPanel()
        {
            InitializeComponent();

            PrintQueue printQueue = LocalPrintServer.GetDefaultPrintQueue();
            PrintJobInfoCollection printSystemJobInfos = printQueue.GetPrintJobInfoCollection();

            AttachClickHandlerToChildren(this);
        }

        private void AttachClickHandlerToChildren(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                child.Click += (sender, args) => this.OnClick(args);
                AttachClickHandlerToChildren(child);
            }
        }

        private string _cardTitle = "Title";
        private int _headerHeight = 30;
        private SizeType _headerRowSizeType = SizeType.Percent;
        private int _titleTextSize = 10;
        private FontStyle _titleTextStyle = FontStyle.Regular;
        private string _value = "Value";
        private FontStyle _valueTextStyle = FontStyle.Regular;
        private int _valueTextSize = 10;
        private int _headerRowIndex = 0;

        public String CardTitle
        {
            get { return _cardTitle; }
            set
            {
                _cardTitle = value;
                headerLabel.Text = _cardTitle;
            }
        }
        [TypeConverter(typeof(EnumConverter))]
        public FontStyle CardTitleTextStyle
        {
            get { return _titleTextStyle; }
            set
            {
                _titleTextStyle = value;
                headerLabel.Font = new Font(headerLabel.Font.FontFamily, _titleTextSize, _titleTextStyle);
            }
        }
        public int CardTitleTextSize
        {
            get { return _titleTextSize; }
            set
            {
                _titleTextSize = value;
                headerLabel.Font = new Font(headerLabel.Font.FontFamily, _titleTextSize, _titleTextStyle);
            }
        }
        [TypeConverter(typeof(EnumConverter))]
        public SizeType CardHeaderSizeType
        {
            get { return _headerRowSizeType; }
            set
            {
                _headerRowSizeType = value;
                mainTablePanel.RowStyles[_headerRowIndex].SizeType = _headerRowSizeType;
            }
        }

        public int CardHeaderHeight
        {
            get
            {
                // Make sure the index is in bounds
                if (_headerRowIndex >= 0 && _headerRowIndex < mainTablePanel.RowStyles.Count)
                {
                    return _headerHeight;
                }
                else
                {
                    throw new IndexOutOfRangeException("The adjustable row index is out of range.");
                }
            }

            set
            {
                // Make sure the index is in bounds
                if (_headerRowIndex >= 0 && _headerRowIndex < mainTablePanel.RowStyles.Count)
                {
                    _headerHeight = value;
                    mainTablePanel.RowStyles[_headerRowIndex].Height = _headerHeight;
                }
                else
                {
                    throw new IndexOutOfRangeException("The adjustable row index is out of range.");
                }
            }
        }
        public string CardValue
        {
            get { return _value; }
            set
            {
                _value = value;
                valueLabel.Text = _value;
            }
        }
        [TypeConverter(typeof(EnumConverter))]
        public FontStyle CardValueTextStyle
        {
            get { return _valueTextStyle; }
            set
            {
                _valueTextStyle = value;
                valueLabel.Font = new Font(valueLabel.Font.FontFamily, _valueTextSize, _valueTextStyle);
            }
        }
        public int CardValueTextSize
        {
            get { return _valueTextSize; }
            set
            {
                _valueTextSize = value;
                valueLabel.Font = new Font(valueLabel.Font.FontFamily, _valueTextSize, _valueTextStyle);
            }
        }
    }
}
