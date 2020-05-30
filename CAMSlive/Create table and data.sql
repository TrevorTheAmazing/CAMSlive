USE [CAMSlive]
GO

/****** Object: Table [dbo].[TimecardCharts] Script Date: 5/29/2020 11:03:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TimecardCharts] (
    [ChartId]      NVARCHAR (450) NOT NULL,
    [ChartOptions] NVARCHAR (MAX) NULL
);


/* DATA */
INSERT INTO [dbo].[TimecardCharts] ([ChartId], [ChartOptions]) VALUES (N'chart1', N'{"series":[49,5,1,30],"chart":{"id":"chart1","height":300,"type":"donut"},"plotOptions":{"pie":{"donut":{"labels":{"show":true,"name":{"fontSize":"22px"},"value":{"fontSize":"16px"},"total":{"show":true,"label":"Total"}}}}},"dataLabels":{"enabled":true},"labels":["one","two","three","four"],"title":{"text":"Payroll Period Progress","align":"left"},"responsive":[{"breakpoint":480,"options":{"chart":{"width":200},"legend":{"show":false}}}],"legend":{"position":"left","offsetY":0,"height":230}}')
INSERT INTO [dbo].[TimecardCharts] ([ChartId], [ChartOptions]) VALUES (N'chart2', N'{"series":[7,1,1,21], "chart":{"id":"chart2","height":300,"type":"radialBar"}, "title":{"text":"$L/E/O/M Totals, Payroll Period to Date"},"plotOptions":{"radialBar":{"dataLabels":{"name":{"fontSize":"22px"},"value":{"fontSize":"16px"},"total":{"show":true,"Total":"$1,234.56"}}}}, "labels":["Labor", "Equipment", "Overhead", "Material"]}')
INSERT INTO [dbo].[TimecardCharts] ([ChartId], [ChartOptions]) VALUES (N'chart3', N'{"series":[{"name":"Bubble1","data":[[221,41,15],[420,32,41],[388,35,67],[416,60,52],[57,39,36],[692,54,74],[363,28,54],[680,47,65],[678,43,71],[698,57,43],[608,54,49],[269,43,33],[668,16,24],[402,38,69],[736,47,23],[381,51,33],[539,46,25],[596,26,61],[515,44,71],[306,40,61]]}],"chart":{"id":"chart3","height":350,"type":"bubble"},"dataLabels":{"enabled":false},"fill":{"opacity":0.8},"title":{"text":"Simple Bubble Chart"},"xaxis":{"tickAmount":12,"type":"category"},"yaxis":{"max":70}}')
INSERT INTO [dbo].[TimecardCharts] ([ChartId], [ChartOptions]) VALUES (N'chart4', N'{"series":[{"name":"Marine Sprite","data":[44,56,41,37,22,43,22]},{"name":"Striking Calf","data":[53,32,33,52,13,43,32]},{"name":"Tank Picture","data":[12,17,11,9,15,11,20]},{"name":"Bucket Slope","data":[9,7,5,8,6,9,4]},{"name":"Reborn Kid","data":[25,12,19,32,25,24,10]}],"chart":{"id":"chart4","type":"bar","height":350,"stacked":true},"plotOptions":{"bar":{"horizontal":false}},"stroke":{"width":1,"colors":["#fff"]},"title":{"text":"Fiction Books Sales"},"xaxis":{"categories":[2008,2009,2010,2011,2012,2013,2014],"labels":{}},"yaxis":{"title":{}},"tooltip":{"y":{}},"fill":{"opacity":1},"legend":{"position":"top","horizontalAlign":"left","offsetX":40}}')
INSERT INTO [dbo].[TimecardCharts] ([ChartId], [ChartOptions]) VALUES (N'chart5', N'{"series":[{"name":"South","data":[[1486771200000,25],[1486857600000,12],[1486944000000,11],[1487030400000,53],[1487116800000,44],[1487203200000,14],[1487289600000,54],[1487376000000,55],[1487462400000,35],[1487548800000,51],[1487635200000,36],[1487721600000,43],[1487808000000,57],[1487894400000,58],[1487980800000,23],[1488067200000,60],[1488153600000,12],[1488240000000,24],[1488326400000,51],[1488412800000,20]]},{"name":"North","data":[[1486771200000,18],[1486857600000,13],[1486944000000,13],[1487030400000,10],[1487116800000,10],[1487203200000,13],[1487289600000,10],[1487376000000,16],[1487462400000,16],[1487548800000,20],[1487635200000,16],[1487721600000,10],[1487808000000,10],[1487894400000,18],[1487980800000,12],[1488067200000,13],[1488153600000,14],[1488240000000,17],[1488326400000,10],[1488412800000,14]]},{"name":"Central","data":[[1486771200000,11],[1486857600000,14],[1486944000000,12],[1487030400000,15],[1487116800000,15],[1487203200000,12],[1487289600000,14],[1487376000000,12],[1487462400000,13],[1487548800000,15],[1487635200000,15],[1487721600000,10],[1487808000000,12],[1487894400000,10],[1487980800000,12],[1488067200000,14],[1488153600000,10],[1488240000000,13],[1488326400000,15],[1488412800000,11]]}],"chart":{"id":"chart5","type":"area","height":350,"stacked":true,"events":{}},"colors":["#008FFB","#00E396","#CED4DC"],"dataLabels":{"enabled":false},"stroke":{"curve":"smooth"},"fill":{"type":"gradient","gradient":{"opacityFrom":0.6,"opacityTo":0.8}},"legend":{"position":"top","horizontalAlign":"left"},"xaxis":{"type":"datetime"}}')
