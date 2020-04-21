using CAMSlive.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAMSlive.Api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<Chart> TimecardCharts { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Chart>().HasData(new Chart
        //    {
        //        //ChartId = "chart",
        //        ChartId = "chart1",
        //        ChartOptions = @"series: [44, 55, 13, 33],chart: { height: 300, type: 'donut', },dataLabels: { enabled: true },labels: ['one', 'two', 'three', 'four'],title: { text: 'Payroll Period Progress', align: 'left' },responsive: [{ breakpoint: 480, options: { chart: { width: 200 }, legend: { show: false } } }],legend: { position: 'right', offsetY: 0, height: 230, }"
        //    });
        //}
    }
}