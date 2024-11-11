import { ShowResult, ShowResultError } from '../Utils/toast.js';
import { mapLote } from './auxLotes.js';

document.addEventListener("DOMContentLoaded", function() {

    const establecimiento = localStorage.getItem("establecimientoPersonal");
    const lote = document.getElementById("lote")
    const medicamento = document.getElementById("nombreComercial")


    async function loadLotes() {
        await fetch(`https://localhost:44379/Establishment/Lotes/Filter?id=${establecimiento}`)
            .then(response => response.json())
            .then(data => {
                const tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; 
                
                data.forEach(lote => {
                    mapLote(lote);
                });
            })
            .catch(error => console.error("Error al obtener los datos:", error));
    }

    document.getElementById("searchLote").addEventListener("click", async function() {
        const filtros = {
            Medicamento: document.getElementById("nombreComercial").value,
            Lote: document.getElementById("lote").value,

        };

        console.log(filtros)
    
            
        await fetch(`https://localhost:44379/Establishment/Lotes/Filter?id=${establecimiento}&lote=${filtros.Lote}&medicamento=${filtros.Medicamento}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";
            data.forEach(lote => {
                mapLote(lote);
            });
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    document.getElementById("addLoteBtn").addEventListener("click", function() {
        window.location.href = "./addLoteForm.html";
    });

    loadLotes();
});



document.addEventListener('DOMContentLoaded', () => {
  const status = localStorage.getItem('status');
  const event = localStorage.getItem('event');
  if (status && event) {
    if (status == "200") {
      ShowResult("Lote editado");
    } else {
      ShowResultError("Error al editar lote");
    }
    localStorage.removeItem('status');
    localStorage.removeItem('event');
  }else if(status){
    if (status == "200") {
        ShowResult("Lote agregado");
      } else {
        ShowResultError("Error al agregar medicamento");
      }
      localStorage.removeItem('status');
  }
});

