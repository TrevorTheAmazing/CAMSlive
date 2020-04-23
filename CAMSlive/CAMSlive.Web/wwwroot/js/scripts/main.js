"use strict";

//function RenderChart(chartId, chartOptions) {
async function RenderChart(chartId, chartOptions) {

    //var chart = new ApexCharts(document.getElementById(toString(chartId)), JSON.parse(chartOptions));
    var chart = new ApexCharts(document.getElementById(chartId), JSON.parse(chartOptions));
    //var chart = new ApexCharts(document.getElementById(chartId), chartOptions);

    //render chart
    await chart.render();

    console.log('end of RenderChart()');
}

async function UpdateOptions(chartId, chartOptions) {

    var chart = document.getElementById(chartId);

    //render chart
    //await chart.updateOptions(JSON.parse(chartOptions), true);

    await ApexCharts.exec(chartId, 'updateOptions', (JSON.parse(chartOptions), true));

    console.log('end of UpdateOptions()');
}