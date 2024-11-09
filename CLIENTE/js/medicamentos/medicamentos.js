import { ShowResult, ShowResultError } from '../Utils/toast.js';
import { loadLaboratorios, loadMarcas, loadMonodrogas, loadPresentaciones, deleteMed, mapMed } from './auxMedicamentos.js';

document.addEventListener("DOMContentLoaded", function() {

    let medicamentoIdToDelete = null;
    const deleteConfirmModal = new bootstrap.Modal(document.getElementById("deleteConfirmModal"));
    const confirmDeleteBtn = document.getElementById("confirmDeleteBtn");

    const selects = {
        marcas: document.getElementById("marcas"),
        laboratorios: document.getElementById("laboratorios"),
        monodrogas: document.getElementById("monodrogas"),
        presentaciones: document.getElementById("presentaciones")
    };

    loadMarcas(selects.marcas);
    loadLaboratorios(selects.laboratorios);
    loadMonodrogas(selects.monodrogas);
    loadPresentaciones(selects.presentaciones);

    function setMedicamentoIdToDelete(id) {
        medicamentoIdToDelete = id;
    }

    confirmDeleteBtn.addEventListener("click", async () => {
        if (medicamentoIdToDelete) {
            await deleteMed(medicamentoIdToDelete);
            deleteConfirmModal.hide();
            loadMedicamentos(); 
        }
    });

    async function loadMedicamentos() {
        await fetch("https://localhost:44379/api/Medicamento/Filter?Activo=true")
            .then(response => response.json())
            .then(data => {
                const tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; 
                
                data.forEach(medicamento => {
                    mapMed(medicamento, deleteConfirmModal, setMedicamentoIdToDelete);
                });
            })
            .catch(error => console.error("Error al obtener los datos:", error));
    }

    document.getElementById("searchMed").addEventListener("click", async function() {
        const filtros = {
            IdLaboratorio: document.getElementById("laboratorios").value,
            IdMarca: document.getElementById("marcas").value,
            IdMonodroga: document.getElementById("monodrogas").value,
            IdPresentacion: document.getElementById("presentaciones").value,
            NombreComercial: document.getElementById("nombreComercial").value,
            Activo: document.getElementById("active").checked 
        };

        console.log(filtros)
    
        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = 0;
            } 
        }
            
        await fetch(`https://localhost:44379/api/Medicamento/Filter?IdMarca=${filtros.IdMarca}&IdLaboratorio=${filtros.IdLaboratorio}&NombreComercial=${filtros.NombreComercial}&IdMonodroga=${filtros.IdMonodroga}&IdPresentacion=${filtros.IdPresentacion}&Activo=${filtros.Activo}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";
    
            data.forEach(medicamento => {
                mapMed(medicamento, deleteConfirmModal, setMedicamentoIdToDelete);
            });
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    document.getElementById("addMedBtn").addEventListener("click", function() {
        window.location.href = "./addMedicamentoForm.html";
    });

    loadMedicamentos();
});



document.addEventListener('DOMContentLoaded', () => {
  const status = localStorage.getItem('status');
  const event = localStorage.getItem('event');
  if (status && event) {
    if (status == "200") {
      ShowResult("Medicamento editado");
    } else {
      ShowResultError("Error al editar medicamento");
    }
    localStorage.removeItem('status');
    localStorage.removeItem('event');
  }else if(status){
    if (status == "200") {
        ShowResult("Medicamento agregado");
      } else {
        ShowResultError("Error al agregar medicamento");
      }
      localStorage.removeItem('status');
  }
});

