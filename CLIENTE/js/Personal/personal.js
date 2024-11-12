import { ShowResult, ShowResultError } from '../Utils/toast.js';
import {mapPersonal} from './auxPersonal.js'

document.addEventListener("DOMContentLoaded", function() {

    const establecimiento = localStorage.getItem("establecimientoPersonal");
    const nombre = document.getElementById("nombre")
    const apellido = document.getElementById("apellido")


    async function loadPersonal() {
        await fetch(`https://localhost:44379/api/PersonalEstablecimiento/Establishment?id=${establecimiento}`)
            .then(response => response.json())
            .then(data => {
                const tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; 
                
                data.forEach(personal => {
                    mapPersonal(personal);
                });
            })
            .catch(error => console.error("Error al obtener los datos:", error));
    }

    document.getElementById("searchPersonal").addEventListener("click", async function() {
        const filtros = {
            nombre: document.getElementById("nombre").value,
            apellido: document.getElementById("apellido").value,
            documento: document.getElementById("documento").value
        };

        console.log(filtros)
    
            
        await fetch(`https://localhost:44379/api/PersonalEstablecimiento/Filter?id=${establecimiento}&nombre=${filtros.nombre}&apellido=${filtros.apellido}&documento=${filtros.documento}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";
            data.forEach(personal => {
                mapPersonal(personal);
            });
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });

    document.getElementById("addPersonalBtn").addEventListener("click", function() {
        window.location.href = "./addPersonalForm.html";
    });

    loadPersonal();
});



document.addEventListener('DOMContentLoaded', () => {
  const status = localStorage.getItem('status');
  const event = localStorage.getItem('event');
  if (status && event) {
    if (status == "200") {
      ShowResult("Personal editado");
    } else {
      ShowResultError("Error al editar personal");
    }
    localStorage.removeItem('status');
    localStorage.removeItem('event');
  }else if(status){
    if (status == "200") {
        ShowResult("Personal agregado");
      } else {
        ShowResultError("Error al agregar personal");
      }
      localStorage.removeItem('status');
  }
});

