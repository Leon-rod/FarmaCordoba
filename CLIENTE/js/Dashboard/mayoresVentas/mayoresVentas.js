import { mapViewOS, loadYears } from "./auxMayoresVentas.js";

document.addEventListener("DOMContentLoaded", function() {

    const selects = {
        año: document.getElementById("año")
    };

    loadYears(selects.año);

    const ctx = document.getElementById('report').getContext('2d');
    let myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Reporte de Ventas según Año y cantidades',
                data: [],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

    const ctxMaxAmount = document.getElementById('reportPrecios').getContext('2d');
    let myChartMaxAmount = new Chart(ctxMaxAmount, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Reporte de Ventas según Año y precios',
                data: [],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });




    async function loadViewOS(){
        await fetch('https://localhost:44379/api/SPTotalesFarmacia/MayoresCompras?year=2024&count=1', {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data =>{
            updateChart(data);
            updateChartMaxAmount(data);
            data.forEach(register => {
                mapViewOS(register);
            });
        });
    }

    function updateChart(data) {
        const labels = data.map(item => item.client + ', ' + item.month + '-' + item.year); 
        const totals = data.map(item => item.quantityPurchases);

        myChart.data.labels = labels;
        myChart.data.datasets[0].data = totals;

        myChart.update();


    }
    function updateChartMaxAmount(data) {
        const labels = data.map(item => item.client + ', ' + item.month + '-' + item.year); 
        const totals = data.map(item => item.maxAmount);

        myChartMaxAmount.data.labels = labels;
        myChartMaxAmount.data.datasets[0].data = totals;

        myChartMaxAmount.update();


    }
    document.getElementById("searchView").addEventListener("click", async function() {
        const filtros = {
            Año: document.getElementById("año").value,
            Cantidad: document.getElementById("cantidad").value
        };

        for (let key in filtros) {
            if (filtros[key] === "Seleccionar" || filtros[key] === "") {
                filtros[key] = 0;
            } 
        }
            
        await fetch(`https://localhost:44379/api/SPTotalesFarmacia/MayoresCompras?year=${filtros.Año}&count=${filtros.Cantidad}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";

            data.forEach(register => {
                mapViewOS(register);
            });

            updateChart(data); 
            updateChartMaxAmount(data);
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    loadViewOS();
});
