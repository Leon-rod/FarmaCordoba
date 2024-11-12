import { loadPersonal, loadYears, mapView } from "./auxTotalesFacturados.js";

document.addEventListener("DOMContentLoaded", function() {

    const selects = {
        personal: document.getElementById("personal"),
        año: document.getElementById("año"),
        mes: document.getElementById("mes")
    };

    loadPersonal(selects.personal);
    loadYears(selects.año);

    const ctx = document.getElementById('totals').getContext('2d');
    let myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Total Facturado por vendedor, mes y año',
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

    const ctx2 = document.getElementById('totals2').getContext('2d');
    let myChart2 = new Chart(ctx2, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Ventas mas caras por vendedor, mes y año',
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
        await fetch('https://localhost:44379/VTotalesFacturados', {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data =>{
            updateChart(data);
            data.forEach(register => {
                mapView(register);
            });
        });
    }

    function updateChart(data) {
        const labels = data.map(item => item.personal + ', ' + item.mes + '-' + item.año); 
        const totals = data.map(item => item.totalFacturado);

        const labels2 = data.map(item => item.personal + ', ' + item.mes + '-' + item.año); 
        const totals2 = data.map(item => item.ventaMasCara);

        myChart.data.labels = labels;
        myChart.data.datasets[0].data = totals;

        myChart2.data.labels = labels2;
        myChart2.data.datasets[0].data = totals2;

        myChart.update();
        myChart2.update();

    }
    document.getElementById("searchView").addEventListener("click", async function() {
        const filtros = {
            Año: document.getElementById("año").value,
            Mes: document.getElementById("mes").value,
            IdPersonal: document.getElementById("personal").value
        };

        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = 0;
            } 
        }
            
        await fetch(`https://localhost:44379/VTotalesFacturados/Filter?id=${filtros.IdPersonal}&year=${filtros.Año}&month=${filtros.Mes}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";

            data.forEach(register => {
                mapView(register);
            });

            updateChart(data); 
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    loadView();
});
