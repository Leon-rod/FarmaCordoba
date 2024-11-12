import { ShowResult, ShowResultError } from '../Utils/toast.js';

export async function loadBarrio(select) {
    await fetch("https://localhost:44379/api/Barrio")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idBarrio; 
                option.textContent = item.barrio1; 
                select.appendChild(option);
            });


        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadTipoDoc(select) {
    await fetch("https://localhost:44379/api/TipoDocumento")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idTipoDoc; 
                option.textContent = item.tipoDocumento; 
                select.appendChild(option);
            });


        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadGenero(select) {
    await fetch("https://localhost:44379/api/Genero")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idGenero; 
                option.textContent = item.nombreGenero; 
                select.appendChild(option);
            });


        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadCargo(select) {
    await fetch("https://localhost:44379/api/Cargo")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idCargo; 
                option.textContent = item.cargo1; 
                select.appendChild(option);
            });


        })
        .catch(error => console.error("Error al cargar opciones:", error));
}


export function mapPersonal(personal) {
    const row = document.createElement("tr");

    const nombreCell = document.createElement("td");
    nombreCell.textContent = personal.idPersonalNavigation.nombre + ", " +personal.idPersonalNavigation.apellido

    const documentoCell = document.createElement("td");
    documentoCell.textContent = personal.idPersonalNavigation.nroDoc;

    const cargoCell = document.createElement("td");
    cargoCell.textContent = personal.idCargoNavigation.cargo1;


    row.appendChild(nombreCell);
    row.appendChild(documentoCell);
    row.appendChild(cargoCell);
 

    document.getElementById("tableBody").appendChild(row);
}

