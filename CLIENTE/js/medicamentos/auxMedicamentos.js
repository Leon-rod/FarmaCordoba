import { ShowResult, ShowResultError } from '../Utils/toast.js';

export async function loadMarcas(select, selectedId = null) {
    await fetch("https://localhost:44379/api/Marca")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idMarca; 
                option.textContent = item.nombreMarca; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }

        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadLaboratorios(select, selectedId = null) {
    await fetch("https://localhost:44379/api/Laboratorio")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idLaboratorio; 
                option.textContent = item.nombreLaboratorio; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadMonodrogas(select, selectedId = null) {
    await fetch("https://localhost:44379/api/Monodroga")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idMonodroga; 
                option.textContent = item.monodroga1; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadPresentaciones(select, selectedId = null) {
    await fetch("https://localhost:44379/api/Presentacion")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idPresentacion; 
                option.textContent = item.nombrePresentacion; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function deleteMed(id) {
    await fetch(`https://localhost:44379/api/Medicamento?id=${id}`, {
        method: "DELETE"
    })
    .then(response => {
        if (response.ok) {
            ShowResult("Medicamento eliminado con éxito");
        } else {
            ShowResultError("Error al eliminar el medicamento");
        }
    })
    .catch(error => console.error("Error al eliminar el medicamento:", error));
}


export function mapMed(medicamento, deleteConfirmModal, setMedicamentoIdToDelete) {
    const row = document.createElement("tr");

    const nombreCell = document.createElement("td");
    nombreCell.textContent = medicamento.nombreComercial;

    const precioCell = document.createElement("td");
    precioCell.textContent = `$${medicamento.precio.toFixed(2)}`;

    const monodrogaCell = document.createElement("td");
    monodrogaCell.textContent = medicamento.idMonodrogaNavigation.monodroga1;

    const marcaCell = document.createElement("td");
    marcaCell.textContent = medicamento.idMarcaNavigation.nombreMarca;

    const descripcionCell = document.createElement("td");
    descripcionCell.textContent = medicamento.descripcion;

    const labCell = document.createElement("td");
    labCell.textContent = medicamento.idLaboratorioNavigation.nombreLaboratorio;

    const activeCell = document.createElement("td");
    activeCell.textContent = medicamento.activo ? "Activo" : "Inactivo";

    const presentacionCell = document.createElement("td");
    presentacionCell.textContent = medicamento.idPresentacionNavigation.nombrePresentacion;

    const actionsCell = document.createElement("td");
    actionsCell.classList.add("d-flex");

    const editButton = document.createElement("div");
    editButton.classList.add("med-edit-button", "me-2", "cursor-pointer");
    editButton.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square cursor-pointer" viewBox="0 0 16 16">
            <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
            <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
        </svg>
    `;
    editButton.addEventListener("click", () => goToEditMed(medicamento.idMedicamento));

    const deleteButton = document.createElement("div");
    deleteButton.classList.add("med-delete-button", "cursor-pointer");
    deleteButton.innerHTML = `
        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-circle cursor-pointer" viewBox="0 0 16 16">
            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16"/>
            <path d="M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708"/>
        </svg>
    `;
    deleteButton.addEventListener("click", () => {
        setMedicamentoIdToDelete(medicamento.idMedicamento);
        deleteConfirmModal.show();
    });

    actionsCell.appendChild(editButton);
    actionsCell.appendChild(deleteButton);

    row.appendChild(nombreCell);
    row.appendChild(descripcionCell);
    row.appendChild(monodrogaCell);
    row.appendChild(marcaCell);
    row.appendChild(labCell);
    row.appendChild(presentacionCell);
    row.appendChild(precioCell);
    row.appendChild(activeCell);
    row.appendChild(actionsCell);

    document.getElementById("tableBody").appendChild(row);
}



function goToEditMed(id){
    localStorage.setItem("medicamentoId", id)

    window.location.href = "./editMedicamentoForm.html"
}
