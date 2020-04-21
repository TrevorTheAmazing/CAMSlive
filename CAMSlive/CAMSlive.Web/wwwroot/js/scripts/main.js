"use strict";

//function RenderChart(chartId, chartOptions) {
function RenderChart(chartId, chartOptions) {

    //var chart = new ApexCharts(document.getElementById(toString(chartId)), JSON.parse(chartOptions));
    var chart = new ApexCharts(document.getElementById(chartId), JSON.parse(chartOptions));
    //var chart = new ApexCharts(document.getElementById(chartId), chartOptions);

    //render chart
    chart.render();

    console.log('end of RenderChart()');
}

function UpdateOptions(chartId, chartOptions) {

    var chart = document.getElementById(chartId);

    //render chart
    //chart.updateOptions(JSON.parse(chartOptions), true);

    ApexCharts.exec(chartId, 'updateOptions', (JSON.parse(chartOptions), true));

    console.log('end of UpdateOptions()');
}