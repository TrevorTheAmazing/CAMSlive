//"use strict";

async function RenderChart(chartId, chartOptions) {

    let chart = new ApexCharts(document.getElementById(chartId), JSON.parse(chartOptions));

    await chart.render();

    console.log('end of RenderChart()');
};

async function UpdateOptions(chartId, chartOptions) {

    //let chart = document.getElementById(chartId);

    //let tempOptions = JSON.parse(chartOptions);

    //let chartToUpdate = new ApexCharts(chart, tempOptions);

    //await ApexCharts.exec(chart.id, "updateOptions", tempOptions, false, true);

    let chart = window.ApexCharts.getChartByID(chartId);

    let tempOptions = JSON.parse(chartOptions);

    //chart.opts.series = tempOptions.series;
    await chart.updateSeries(tempOptions.series);
    //await ApexCharts.exec(chart.id, "updateOptions", tempOptions, false, true);
    
    console.log('end of UpdateOptions()');
};