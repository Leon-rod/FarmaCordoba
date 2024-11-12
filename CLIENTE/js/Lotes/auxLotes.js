import { ShowResult, ShowResultError } from '../Utils/toast.js';

export async function deleteLote(id) {
    await fetch(`https://localhost:44379/api/MedicamentoLote?id=${id}`, {
        method: "DELETE"
    })
    .then(response => {
        if (response.ok) {
            ShowResult("Lote eliminado con éxito");
        } else {
            ShowResultError("Error al eliminar el lote");
        }
    })
    .catch(error => console.error("Error al eliminar el lote:", error));
}

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

export function mapLote(lote, deleteConfirmModal, setLoteIdToDelete) {
    const row = document.createElement("tr");

    const nombreCell = document.createElement("td");
    nombreCell.textContent = lote.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial;
    nombreCell.classList.add("text-center")

    const loteCell = document.createElement("td");
    loteCell.textContent = lote.idMedicamentoLoteNavigation.lote;
    loteCell.classList.add("text-center")

    const fechaCell = document.createElement("td");
    fechaCell.textContent = lote.idMedicamentoLoteNavigation.fechaVencimiento;
    fechaCell.classList.add("text-center")

    const activeCell = document.createElement("td");
    activeCell.textContent = lote.idMedicamentoLoteNavigation.activo ? 'Activo' : 'Inactivo';
    activeCell.classList.add("text-center")

    const actionsCell = document.createElement("td");
    actionsCell.classList.add("cursor-pointer", "text-center");
    actionsCell.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-circle cursor-pointer" viewBox="0 0 16 16">
            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
            <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
        </svg>
    `;
    actionsCell.addEventListener("click", () => {
        setLoteIdToDelete(lote.idMedicamentoLoteNavigation.idMedicamentoLote);
        deleteConfirmModal.show();
    });

    


    row.appendChild(nombreCell);
    row.appendChild(loteCell);
    row.appendChild(fechaCell);
    row.appendChild(activeCell);
    row.appendChild(actionsCell);
 

    document.getElementById("tableBody").appendChild(row);
}

