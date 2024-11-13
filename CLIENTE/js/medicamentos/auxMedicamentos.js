import { ShowResult, ShowResultError } from '../Utils/toast.js';

export async function loadMarcas(select, selectedId = null) {
    let  marcas = [];
    await fetch("https://localhost:44379/api/Medicamento")
        .then(response => response.json())
        .then(data => {
            data.forEach(item =>{
                marcas.push(item.idMarcaNavigation.idMarca)
            })

            marcas = [...new Set(marcas)];
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                if (marcas.includes(item.idMarcaNavigation.idMarca)) {
                    const option = document.createElement("option");
                    option.value = item.idMarcaNavigation.idMarca; 
                    option.textContent = item.idMarcaNavigation.nombreMarca; 
                    select.appendChild(option);
                    marcas = marcas.filter(m => m !== item.idMarcaNavigation.nombreMarca);
                }
            });
            if (selectedId) {
                select.value = selectedId;
            }

        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadAllMarcas(select, selectedId = null) {
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

    const editButton = document.createElement("button");
    editButton.classList.add("btn", "btn-outline-primary", "btn-sm", "me-2");
    editButton.innerHTML = `
                <i class="bi bi-pencil-square"></i>
    `;
    editButton.addEventListener("click", () => goToEditMed(medicamento.idMedicamento));

    const deleteButton = document.createElement("button");
    deleteButton.classList.add("btn", "btn-outline-danger", "btn-sm");
    deleteButton.innerHTML = `
            <i class="bi bi-x-circle"></i>
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
