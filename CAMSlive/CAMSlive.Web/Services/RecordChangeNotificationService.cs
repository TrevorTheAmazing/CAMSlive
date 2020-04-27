using CAMSlive.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace CAMSlive.Web.Services
{
    public class RecordChangeNotificationService : IRecordChangeNotificationService
    {
        public event RecordChangeDelegate OnChartRecordChanged;

        //member variables
        private const string TableName = "TimecardCharts";
        public SqlTableDependency<Chart> _notifier;
        private readonly IConfiguration _configuration;

        //constructor
        public RecordChangeNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _notifier = new SqlTableDependency<Chart>(_configuration.GetConnectionString("CAMSliveSqlServer"), TableName, "", null, null, null, TableDependency.SqlClient.Base.Enums.DmlTriggerType.All, false, true);
            _notifier.OnChanged += this.TableDependency_Changed;
            _notifier.Start();
        }

        //member methods
        private void TableDependency_Changed(object sender, RecordChangedEventArgs<Chart> e)
        {
            if (this.OnChartRecordChanged != null)
            {
                OnChartRecordChanged(this, new RecordChangeEventArgs(e.Entity, e.EntityOldValues));
            }
        }

        public void Dispose()
        {
            _notifier.Stop();
            _notifier.Dispose();
        }
    }
}
