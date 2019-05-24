$(document).ready(function () {
    console.log('vm2 : ', vm);
     var listLabel = {};
     var listData = {};
     Chart.defaults.global.defaultFontFamily = 'Lato';
     Chart.defaults.global.defaultFontSize = 18;
     Chart.defaults.global.defaultFontColor = '#777';
     function setDataChart(arr) {
         listLabel = [];
         listData = [];
         for (var i = 0; i < arr.length; i++) {
             listLabel.push(arr[i].LABEL);
             listData.push(arr[i].DATA);
         }
     };
     function chartProfit() {
         setDataChart(vm);
         console.log(vm);
         var myChart = $('#chart-profit')[0].getContext('2d');
 
 
         var massPopChart = new Chart(myChart, {
             type: 'line', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
             data: {
                 labels: listLabel,
                 datasets: [{
                     label: 'Doanh thu',
                     data: listData,
                     //backgroundColor:'green',
                     // backgroundColor:[
                     //     'rgba(255, 99, 132, 0.6)',
                     //     'rgba(54, 162, 235, 0.6)',
                     //     'rgba(255, 206, 86, 0.6)',
                     //     'rgba(75, 192, 192, 0.6)',
                     //     'rgba(153, 102, 255, 0.6)'
                     //     ,'rgba(255, 159, 64, 0.6)'
                     //     ,'rgba(255, 99, 132, 0.6)'
                     // ],
                     borderWidth: 1,
                     borderColor: '#777',
                     hoverBorderWidth: 3,
                     hoverBorderColor: '#000'
                 }]
             },
             options: {
                 title: {
                     display: true,
                     text: 'Doanh thu trong tuần',
                     fontSize: 25
                 },
                 legend: {
                     display: false,
                     position: 'right',
                     labels: {
                         fontColor: '#000'
                     }
                 },
                 layout: {
                     padding: {
                         left: 50,
                         right: 0,
                         bottom: 0,
                         top: 0
                     }
                 },
                 tooltips: {
                     enabled: true
                 }
             }
         });
     }
 
     function main() {
 
         chartProfit();
 
     }
 
     main();
});