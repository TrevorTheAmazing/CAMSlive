using CAMSlive.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;
using Serilog;

namespace CAMSlive.Web.Services
{
    public class RecordChangeNotificationService : IRecordChangeNotificationService
    {
        public event RecordChangeDelegate OnChartRecordChanged;
        public event ErrorEventHandler OnError;
        //member variables
        private const string TableName = "TimecardCharts";
        public SqlTableDependency<Chart> _notifier;
        private readonly IConfiguration _configuration;

        //constructor
        public RecordChangeNotificationService(IConfiguration configuration)
        {
            _configuration = configuration;
            _notifier = new SqlTableDependency<Chart>(_configuration.GetConnectionString("CAMSliveSqlServer"), 
                TableName, "", null, null, null, TableDependency.SqlClient.Base.Enums.DmlTriggerType.All, false, true);
            _notifier.OnChanged += this.TableDependency_Changed;
            //_notifier.OnError += this.TableDependency_OnError;

            _notifier.TraceLevel = TraceLevel.Verbose;
            _notifier.TraceListener = new TextWriterTraceListener(File.Create("C:\\Users\\Trevor\\Desktop\\fresh\\CAMSlive\\CAMSlive\\CAMSlive\\CAMSlive\\RecChangeNotifyServiceLog.txt"));

            //Serilog
            Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Debug()
            .WriteTo.File(@"C:\\Users\\Trevor\\Desktop\\fresh\\CAMSlive\\CAMSlive\\CAMSlive\\CAMSlive\\SqlNotify.txt")
            .CreateLogger();

            try
            {
                Log.Information("Starting SqlNotify");
                _notifier.Start();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "CAMSlive.Api terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
            Log.Information($"RecordChangeNotificationService Stop: {DateTime.Now}");
            _notifier.Stop();
            Log.Information($"RecordChangeNotificationService Dispose: {DateTime.Now}");
            _notifier.Dispose();
        }
    }
}
