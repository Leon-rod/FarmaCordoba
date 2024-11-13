import { loadYears, mapSP } from "./auxTotalesFacturadosFarmacia.js";

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
                label: 'Total Facturado por Establecimiento por año',
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





    async function loadView(){
        await fetch('https://localhost:44379/api/SPTotalesFarmacia/TotalesFarmacia?year=2024', {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data =>{
            updateChart(data);
            data.forEach(register => {
                mapSP(register);
            });
        });
    }

    function updateChart(data) {
        const labels = data.map(item => item.establecimiento + ', año ' + (selects.año.value == 'Seleccionar' ? 2024 : selects.año.value)); 
        const totals = data.map(item => item.totalFacturado);

        console.log(data)

        myChart.data.labels = labels;
        myChart.data.datasets[0].data = totals;

        myChart.update();

    }
    document.getElementById("searchView").addEventListener("click", async function() {
        const filtros = {
            Año: document.getElementById("año").value
        };

        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = 2024;
            } 
        }
            
        await fetch(`https://localhost:44379/api/SPTotalesFarmacia/TotalesFarmacia?year=${filtros.Año}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";

            data.forEach(register => {
                mapSP(register);
            });

            updateChart(data); 
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    loadView();
});
