import { loadYears2} from "../totalesFacturados/auxTotalesFacturados.js";
import { loadObraSocial} from "./auxReporteMensualOS.js";
import { mapViewOS } from "./auxReporteMensualOS.js";
import { mapViewCob } from "./auxReporteMensualOS.js";



document.addEventListener("DOMContentLoaded", function() {
    
    const selects = {
        os: document.getElementById("os"),
        año: document.getElementById("año"),
        mes: document.getElementById("mes")
    };

    loadObraSocial(selects.os);
    loadYears2(selects.año);

    const ctx = document.getElementById('report').getContext('2d');
    let myChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Importes a reintegrar por obra social por mes',
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

    const ctxCob = document.getElementById('reportCobertura').getContext('2d');
    let myChartCob = new Chart(ctxCob, {
        type: 'bar',
        data: {
            labels: [],
            datasets: [{
                label: 'Importes a reintegrar por cobertura por mes',
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
        const labels = data.map(item => item.obraSocial + ', ' + item.mes + '-' + item.año); 
        const totals = data.map(item => item.importeAReintegrar);

        myChart.data.labels = labels;
        myChart.data.datasets[0].data = totals;

        myChart.update();
    }
    
    function updateChartCob(data, mes, año) {
        const labels = data.map(item => item.tipoDeCobertura + ', ' + mes + '-' + año); 
        const totals = data.map(item => item.importeAReintegrar);

        myChartCob.data.labels = labels;
        myChartCob.data.datasets[0].data = totals;

        myChartCob.update();
    }

    document.getElementById("searchView").addEventListener("click", async function() {
        const filtros = {
            Año: document.getElementById("año").value,
            Mes: document.getElementById("mes").value,
            ObraSocial: document.getElementById("os").value,
            ObraSocialNombre: document.getElementById("os").selectedOptions[0].text
        };

        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = 0;
            } 
        }
        
        if(filtros.Año === 0 || filtros.Mes === 0 || filtros.ObraSocial === 0){
            const tableBody = document.getElementById("tableBodyCobertura");
            tableBody.innerHTML = "";
            updateChartCob([],0,0);   
        }
        
        if(filtros.Año != 0 && filtros.Mes != 0 && filtros.ObraSocial != 0){
            await fetch(`https://localhost:44379/api/SPTotalesFarmacia/TotalesCoberturas?year=${filtros.Año}&month=${filtros.Mes}&obra=${filtros.ObraSocial}`, {
                method: "GET",
                headers: { "Content-Type": "application/json" }
            })
            .then(response => response.json())
            .then(data => {
                const tableBody = document.getElementById("tableBodyCobertura");
                tableBody.innerHTML = "";
    
                data.forEach(register => {
                    mapViewCob(register, filtros.Mes, filtros.Año);
                });
    
                updateChartCob(data, filtros.Mes, filtros.Año); 
            })
            .catch(error => console.error("Error al obtener los datos filtrados:", error));
        }


        await fetch(`https://localhost:44379/VReporteMensualOS/Filter?os=${filtros.ObraSocialNombre}&year=${filtros.Año}&month=${filtros.Mes}`, {
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



