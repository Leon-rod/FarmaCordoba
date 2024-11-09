import { loadLaboratorios, loadMarcas, loadPresentaciones, loadMonodrogas } from "./auxMedicamentos.js";
import { ShowResult, ShowResultError } from "../Utils/toast.js";

document.addEventListener("DOMContentLoaded", async function() {
    const id = localStorage.getItem("medicamentoId");


    const idMedicamento = document.getElementById("idMedEditForm");
    const nombreComercial = document.getElementById("nameMedEditForm");
    const idMonodroga = document.getElementById("monodrogas");
    const idLaboratorio = document.getElementById("laboratorios");
    const idMarca = document.getElementById("marcas");
    const idPresentacion = document.getElementById("presentaciones");
    const descripcion = document.getElementById("descripcionMedEditForm");
    const precio = document.getElementById("precioMedEditForm");
    const ventaLibreSi = document.querySelector('input[name="ventaLibre"][value="true"]');
    const ventaLibreNo = document.querySelector('input[name="ventaLibre"][value="false"]');
    const activoSi = document.querySelector('input[name="activo"][value="true"]');
    const activoNo = document.querySelector('input[name="activo"][value="false"]');


    if (!id) {
        console.error("No se encontró el ID del medicamento en localStorage.");
        return;
    }

    await fetch(`https://localhost:44379/api/Medicamento/Id?id=${id}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then(data => {
        console.log(data)

        idMedicamento.value = data.idMedicamento;
        nombreComercial.value = data.nombreComercial;
        
        loadMonodrogas(idMonodroga, data.idMonodroga)

        idLaboratorio.value = data.idLaboratorio;
        loadLaboratorios(idLaboratorio, data.idLaboratorio)

        idMarca.value = data.idMarca;
        loadMarcas(idMarca, data.idMarca)

        idPresentacion.value = data.idPresentacion;
        loadPresentaciones(idPresentacion, data.idPresentacion)

        descripcion.value = data.descripcion;
        precio.value = data.precio;


        if (data.ventaLibre) {
            ventaLibreSi.checked = true;
        } else {
            ventaLibreNo.checked = true;
        }


        if (data.activo) {
            activoSi.checked = true;
        } else {
            activoNo.checked = true;
        }
    })
    .catch(error => console.error("Error al obtener el medicamento:", error));
});

document.getElementById("btn-editMed").addEventListener("click", function() {

    const idMedicamento = document.getElementById("idMedEditForm").value;
    const nombreComercial = document.getElementById("nameMedEditForm").value;
    const idMonodroga = document.getElementById("monodrogas").value;
    const idLaboratorio = document.getElementById("laboratorios").value;
    const idMarca = document.getElementById("marcas").value;
    const idPresentacion = document.getElementById("presentaciones").value;
    const descripcion = document.getElementById("descripcionMedEditForm").value;
    const precio = parseFloat(document.getElementById("precioMedEditForm").value);



    const ventaLibre = document.querySelector('input[name="ventaLibre"]:checked').value === "true";
    const activo = document.querySelector('input[name="activo"]:checked').value === "true";


    const medicamento = {
        idMedicamento: idMedicamento,
        nombreComercial: nombreComercial,
        idMonodroga: idMonodroga,
        idLaboratorio: idLaboratorio,
        idMarca: idMarca,
        idPresentacion: idPresentacion,
        descripcion: descripcion,
        precio: precio,
        ventaLibre: ventaLibre,  
        activo: activo           
    };

    fetch("https://localhost:44379/api/Medicamento", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(medicamento)
    })
    .then(response => {
        if (response.ok) {

            console.log("Medicamento editado con éxito");    
            localStorage.setItem('status', 200);
            localStorage.setItem('event', 'edit')
            window.location.href = "medicamentos.html"

        } else {
            console.log("Error al editar el medicamento")
            ShowResultError("Debe ingresar todos los campos.");
        }
    })
    .catch(error => 
    ShowResultError("Debe ingresar todos los campos."));
});

