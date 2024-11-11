import { ShowResult, ShowResultError } from '../Utils/toast.js';

export async function loadMedicamento(select) {
    await fetch("https://localhost:44379/api/Medicamento")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idMedicamento; 
                option.textContent = item.nombreComercial; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }

        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export function mapLote(lote) {
    const row = document.createElement("tr");

    const nombreCell = document.createElement("td");
    nombreCell.textContent = lote.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial;

    const loteCell = document.createElement("td");
    loteCell.textContent = lote.idMedicamentoLoteNavigation.lote;

    const fechaCell = document.createElement("td");
    fechaCell.textContent = lote.idMedicamentoLoteNavigation.fechaVencimiento;


    row.appendChild(nombreCell);
    row.appendChild(loteCell);
    row.appendChild(fechaCell);
 

    document.getElementById("tableBody").appendChild(row);
}

