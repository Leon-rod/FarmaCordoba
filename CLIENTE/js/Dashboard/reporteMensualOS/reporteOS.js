import { loadYears} from "../totalesFacturados/auxTotalesFacturados.js";
import { loadObraSocial} from "./auxReporteMensualOS.js";
import { mapViewOS } from "./auxReporteMensualOS.js";

document.addEventListener("DOMContentLoaded", function() {

    const selects = {
        os: document.getElementById("os"),
        año: document.getElementById("año"),
        mes: document.getElementById("mes")
    };

    loadObraSocial(selects.os);
    loadYears(selects.año);

    const ctx = document.getElementById('report').getContext('2d');
    let myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Importes a reintegrar',
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
        await fetch('https://localhost:44379/VReporteMensualOS', {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data =>{
            updateChart(data);
            data.forEach(register => {
                mapViewOS(register);
            });
        });
    }

    function updateChart(data) {
        const labels = data.map(item => item.obraSocial); 
        const totals = data.map(item => item.importeAReintegrar);

        myChart.data.labels = labels;
        myChart.data.datasets[0].data = totals;

        myChart.update();

    }
    document.getElementById("searchView").addEventListener("click", async function() {
        const filtros = {
            Año: document.getElementById("año").value,
            Mes: document.getElementById("mes").value,
            ObraSocial: document.getElementById("os").value
        };

        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = 0;
            } 
        }
            
        await fetch(`https://localhost:44379/VReporteMensualOS/Filter?os=${filtros.ObraSocial}&year=${filtros.Año}&month=${filtros.Mes}`, {
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
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    loadViewOS();
});
