import { ShowResultError } from "../Utils/toast.js"
import { loadMarcas, loadLaboratorios, loadPresentaciones, loadMonodrogas } from "./auxMedicamentos.js";

document.addEventListener("DOMContentLoaded", function() {
    
    const selects = {
        marcas: document.getElementById("marcas"),
        laboratorios: document.getElementById("laboratorios"),
        monodrogas: document.getElementById("monodrogas"),
        presentaciones: document.getElementById("presentaciones")
    };

    const idMed = document.getElementById("idMedAddForm")

    async function loadId(){
       await fetch("https://localhost:44379/api/Medicamento/LastId")
            .then(response =>response.json())
            .then(data =>{
                idMed.value = data + 1;
                console.log(data)
            })
            .catch(error => console.error("Error al cargar el id", error))
    }

    loadMarcas(selects.marcas);
    loadLaboratorios(selects.laboratorios);
    loadMonodrogas(selects.monodrogas)
    loadPresentaciones(selects.presentaciones)
    loadId();


});

document.getElementById("btn-addMed").addEventListener("click", async function() {

    const idMedicamento = document.getElementById("idMedAddForm").value;
    const nombreComercial = document.getElementById("nameMedAddForm").value;
    const idMonodroga = document.getElementById("monodrogas").value;
    const idLaboratorio = document.getElementById("laboratorios").value;
    const idMarca = document.getElementById("marcas").value;
    const idPresentacion = document.getElementById("presentaciones").value;
    const descripcion = document.getElementById("descripcionMedAddForm").value;
    const precio = parseFloat(document.getElementById("precioMedAddForm").value);


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

    await fetch("https://localhost:44379/api/Medicamento", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(medicamento)
    })
    .then(response => {
        if (response.ok) {

            console.log("Medicamento agregado con éxito");    
            localStorage.setItem('status', 200);
            window.location.href = "./medicamentos.html"

        } else {
            console.log("Error al agregar el medicamento")
            ShowResultError("Debe ingresar todos los campos.");
        }
    })
    .catch(error => 
    ShowResultError("Debe ingresar todos los campos."));
});

