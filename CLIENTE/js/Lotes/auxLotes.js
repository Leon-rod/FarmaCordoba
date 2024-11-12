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
    actionsCell.classList.add("text-center")

    const deleteButton = document.createElement("button");
    deleteButton.classList.add("btn", "btn-outline-danger", "btn-sm", "text-center");
    deleteButton.innerHTML = `
            <i class="bi bi-x-circle"></i>
    `;
    actionsCell.addEventListener("click", () => {
        setLoteIdToDelete(lote.idMedicamentoLoteNavigation.idMedicamentoLote);
        deleteConfirmModal.show();
    });

    actionsCell.appendChild(deleteButton)

    


    row.appendChild(nombreCell);
    row.appendChild(loteCell);
    row.appendChild(fechaCell);
    row.appendChild(activeCell);
    row.appendChild(actionsCell);
 

    document.getElementById("tableBody").appendChild(row);
}

