using EntityFrameworkTest.Data;
using EntityFrameworkTest.Models;
using NLog;
using System.Windows.Forms;

namespace EntityFrameworkTest
{
    public partial class Form1 : Form
    {
        private DataContext data;
        private ILogger logger;

        public Form1(DataContext _dataCtx, ILogger _logger)
        {
            logger = _logger;
            data = _dataCtx;
            InitializeComponent();

            foreach(Organization org in data.Organizations)
            {
                logger.Info("Org:" + org.Name);
            }
        }
    }
}
