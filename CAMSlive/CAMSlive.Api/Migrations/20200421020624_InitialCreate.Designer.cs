﻿// <auto-generated />
using CAMSlive.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CAMSlive.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200421020624_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CAMSlive.Models.Chart", b =>
                {
                    b.Property<string>("ChartId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ChartOptions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ChartId");

                    b.ToTable("TimecardCharts");

                    b.HasData(
                        new
                        {
                            ChartId = "chart1",
                            ChartOptions = "series: [44, 55, 13, 33],chart: { height: 300, type: 'donut', },dataLabels: { enabled: true },labels: ['one', 'two', 'three', 'four'],title: { text: 'Payroll Period Progress', align: 'left' },responsive: [{ breakpoint: 480, options: { chart: { width: 200 }, legend: { show: false } } }],legend: { position: 'right', offsetY: 0, height: 230, }"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
