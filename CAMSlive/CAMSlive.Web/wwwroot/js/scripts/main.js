//"use strict";

//function RenderChart(chartId, chartOptions) {
async function RenderChart(chartId, chartOptions) {

    //var chart = new ApexCharts(document.getElementById(toString(chartId)), JSON.parse(chartOptions));
    let chart = new ApexCharts(document.getElementById(chartId), JSON.parse(chartOptions));
    //var chart = new ApexCharts(document.getElementById(chartId), chartOptions);

    //render chart
    await chart.render();

    console.log('end of RenderChart()');
};

async function UpdateOptions(chartId, chartOptions) {

    let chart = document.getElementById(chartId);
    //var chartContext = document.getElementById(chartId);
    let tempOptions = JSON.parse(chartOptions);

    let chartToUpdate = new ApexCharts(chart, tempOptions);

    //chartToUpdate.opts = tempOptions;

    //await chartToUpdate.render();
    //await chartToUpdate.update();
    await ApexCharts.exec(chart.id, "updateOptions", tempOptions, false, true);
    
    
    //chartToUpdate.opts = tempOptions; TRY POP/PUSH?
    //await chartToUpdate.updateOptions(tempOptions);
    

    //await chartToUpdate.updateOptions(JSON.parse(chartOptions));
    //chart.updateOptions(JSON.parse(chartOptions));
    //chartToUpdate.updateOptions(tempOptions);
    //chart.updateOptions(tempOptions);
    //chartToUpdate.updateOptions(tempOptions);
    //chartToUpdate.updateSeries([7]);



    //try setting chartToUpdate.opts?

    //await chart.

    //await ApexCharts.exec(chartContext, 'updateOptions', (JSON.parse(chartOptions)));
    //await ApexCharts.exec(chartId, 'render', (JSON.parse(chartOptions), true));

    console.log('end of UpdateOptions()');
};