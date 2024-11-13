import { ShowResult, ShowResultError } from '../Utils/toast.js';




export async function loadMovimientos(select) {
    await fetch("https://localhost:44379/api/Inventario/Movements")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                if(item.movimiento === "Compra" || item.movimiento === "Venta"){
                    const option = document.createElement("option");
                    option.value = item.idTipoMov; 
                    option.textContent = item.movimiento; 
                    select.appendChild(option);
                }

            });
        })
        .catch(error => console.error("Error al cargar opciones:", error));
}


export function mapInventario(inventario) {
    const row = document.createElement("tr");

    const facturaCell = document.createElement("td");
    facturaCell.textContent = inventario.idFactura;

    const dispensacionCell = document.createElement("td");
    dispensacionCell.textContent = inventario.idDispensacion;

    const pedidoCell = document.createElement("td");
    pedidoCell.textContent = inventario.idPedido;

    const detallePedidoCell = document.createElement("td");
    detallePedidoCell.textContent = inventario.idDetallePedido;

    const tipoMovCell = document.createElement("td");
    tipoMovCell.textContent = inventario.idTipoMovNavigation.movimiento;

    const stockCell = document.createElement("td");
    stockCell.textContent = inventario.idStock;

    const cantidadCell = document.createElement("td");
    cantidadCell.textContent = inventario.dispensacione != null ? inventario.dispensacione.cantidad : inventario.detallesPedido.cantidad;

    const fechaCell = document.createElement("td");
    fechaCell.textContent = inventario.detallesPedido != null ? inventario.detallesPedido.idPedidoNavigation.fecha : inventario.dispensacione.idFacturaNavigation.fecha;


    row.appendChild(facturaCell);
    row.appendChild(dispensacionCell);
    row.appendChild(pedidoCell);
    row.appendChild(detallePedidoCell);
    row.appendChild(tipoMovCell);
    row.appendChild(stockCell);
    row.appendChild(cantidadCell);
    row.appendChild(fechaCell);

    document.getElementById("tableBody").appendChild(row);
}


