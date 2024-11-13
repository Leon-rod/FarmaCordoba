import { ShowResult, ShowResultError } from '../Utils/toast.js';
import { loadMovimientos, mapInventario } from './auxInventario.js';

document.addEventListener("DOMContentLoaded", function() {


    const selects = {
        movimientos: document.getElementById("tipoMovimiento")
    };

    loadMovimientos(selects.movimientos)

    const establecimiento = localStorage.getItem("establecimientoPersonal")


    async function loadInventarios() {
        await fetch(`https://localhost:44379/api/Inventario/Filters?Establecimiento=${establecimiento}`)
            .then(response => response.json())
            .then(data => {
                const tableBody = document.getElementById("tableBody");
                tableBody.innerHTML = ""; 
                
                data.forEach(inventario => {
                    mapInventario(inventario);
                });
            })
            .catch(error => console.error("Error al obtener los datos:", error));
    }

    document.getElementById("searchMed").addEventListener("click", async function() {
        const filtros = {
            factura: document.getElementById("Factura").value,
            pedido: document.getElementById("Pedido").value,
            tipoMovimiento: document.getElementById("tipoMovimiento").value,
            dateFrom: document.getElementById("dateFrom").value,
            dateTo: document.getElementById("dateTo").value
        };
        const establecimiento = localStorage.getItem("establecimientoPersonal")

        console.log(filtros)
    
        for (let key in filtros) {
            if (filtros[key] === "Seleccionar") {
                filtros[key] = "";
            } 
        }
            
        await fetch(`https://localhost:44379/api/Inventario/Filters?IdFactura=${filtros.factura}&IdPedido=${filtros.pedido}&IdTipoMov=${filtros.tipoMovimiento}&FechaDesde=${filtros.dateFrom}&FechaHasta=${filtros.dateTo}&Establecimiento=${establecimiento}`, {
            method: "GET",
            headers: { "Content-Type": "application/json" }
        })
        .then(response => response.json())
        .then(data => {
            const tableBody = document.getElementById("tableBody");
            tableBody.innerHTML = "";

            console.log(data)
    
            data.forEach(inventario => {
                mapInventario(inventario);
            });
        })
        .catch(error => console.error("Error al obtener los datos filtrados:", error));
    });


    loadInventarios();
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

