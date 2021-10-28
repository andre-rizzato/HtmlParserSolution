// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

function RenderGraph(chartdata) {

var options = {
    series: [{
        data: chartdata.data
    }],
    chart: {
        type: 'bar',
        height: 380
    },
    plotOptions: {
        bar: {
            barHeight: '100%',
            distributed: true,
            horizontal: true,
            dataLabels: {
                position: 'bottom'
            },
        }
    },
    colors: ['#33b2df', '#546E7A', '#d4526e', '#13d8aa', '#A5978B', '#2b908f', '#f9a3a4', '#90ee7e',
        '#f48024', '#69d2e7'
    ],
    dataLabels: {
        enabled: true,
        textAnchor: 'start',
        style: {
            colors: ['#fff']
        },
        formatter: function (val, opt) {
            return opt.w.globals.labels[opt.dataPointIndex] + ":  " + val
        },
        offsetX: 0,
        dropShadow: {
            enabled: true
        }
    },
    stroke: {
        width: 1,
        colors: ['#fff']
    },
    xaxis: {
        categories: chartdata.categories,
    },
    yaxis: {
        labels: {
            show: false
        }
    },
    title: {
        text: 'Most occurring words',
        align: 'center',
        floating: true
    },
 
    tooltip: {
        theme: 'dark',
        x: {
            show: false
        },
        y: {
            title: {
                formatter: function () {
                    return ''
                }
            }
        }
    }
};

var chart = new ApexCharts(document.querySelector("#chart"), options);
chart.render();
}

function SelectedIndexChanged() {

    var label = document.getElementById("ParsingType");

    //get the dropDown selected option text
    var dropDown = document.getElementById("ParsingTypeDropDown");
    var dropDownText = dropDown.value;


    if (dropDownText === "Regex"){
        label.innerText = "Beta Version"
    }
    else {
        label.innerText = "";
    }

}