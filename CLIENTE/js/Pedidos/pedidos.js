async function cargarPedidos() {
    try {
        const response = await fetch('https://localhost:44379/api/Pedido');
        const pedidos = await response.json();
        const pedidosTableBody = document.getElementById('pedidosTable').getElementsByTagName('tbody')[0];

        for (const pedido of pedidos) {
            const row = pedidosTableBody.insertRow();
            row.insertCell(0).textContent = pedido.idPedido;
            row.insertCell(1).textContent = `${pedido.idPersonalCargosEstablecimientosNavigation.idPersonalNavigation.nombre} ${pedido.idPersonalCargosEstablecimientosNavigation.idPersonalNavigation.apellido} (${pedido.idPersonalCargosEstablecimientosNavigation.idEstablecimientoNavigation.nombre})`;
            row.insertCell(2).textContent = pedido.idLogisticaNavigation.nombreEmpresa;
            row.insertCell(3).textContent = new Date(pedido.fecha).toLocaleDateString();

            const totalCell = row.insertCell(4);
            const total = await calcularTotalPedido(pedido.idPedido);
            totalCell.textContent = `$${total.toFixed(2)}`;

            const verDetallesBtn = document.createElement('button');
            verDetallesBtn.classList.add('btn', 'btn-info');
            verDetallesBtn.textContent = 'Ver Detalles';
            verDetallesBtn.onclick = () => cargarDetallesPedido(pedido.idPedido);
            row.insertCell(5).appendChild(verDetallesBtn);
        }
    } catch (error) {
        console.error("Error cargando pedidos:", error);
    }
}

async function calcularTotalPedido(idPedido) {
    try {
        const response = await fetch(`https://localhost:44379/api/DetallePedido?id=${idPedido}`);
        const detalles = await response.json();

        let total = 0;
        detalles.forEach(detalle => {
            total += detalle.precioUnitario * detalle.cantidad;
        });

        return total;
    } catch (error) {
        console.error("Error calculando el total del pedido:", error);
        return 0;
    }
}

async function cargarDetallesPedido(idPedido) {
    try {
        const response = await fetch(`https://localhost:44379/api/DetallePedido?id=${idPedido}`);
        const detalles = await response.json();
        
        const detallesTableBody = document.getElementById('detallesPedidoTable').getElementsByTagName('tbody')[0];
        detallesTableBody.innerHTML = '';

        detalles.forEach(detalle => {
            const row = detallesTableBody.insertRow();
            row.insertCell(0).textContent = detalle.idMedicamentoLoteNavigation
                ? `${detalle.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial} (${detalle.idMedicamentoLoteNavigation.lote})`
                : detalle.idProductoNavigation.nombre;

            row.insertCell(1).textContent = detalle.idProveedorNavigation.razonSocial;
            row.insertCell(2).textContent = `$${detalle.precioUnitario}`;
            row.insertCell(3).textContent = detalle.cantidad;

            const subtotalDetail = detalle.precioUnitario * detalle.cantidad;
            row.insertCell(4).textContent = `$${subtotalDetail.toFixed(2)}`;
        });
        
        const modal = new bootstrap.Modal(document.getElementById('detalleModal'), {
            backdrop: 'static',
            keyboard: false
        });
        modal.show();
    } catch (error) {
        console.error("Error cargando detalles del pedido:", error);
    }
}

function filtrarPedidos(columna) {
    const table = document.getElementById('pedidosTable');
    const rows = table.getElementsByTagName('tbody')[0].getElementsByTagName('tr');
    const filterInputs = table.getElementsByTagName('thead')[0].getElementsByTagName('input');
    const filterValue = filterInputs[columna].value.toLowerCase();

    for (let row of rows) {
        const cell = row.getElementsByTagName('td')[columna];
        const cellText = cell ? cell.textContent.toLowerCase() : '';
        row.style.display = cellText.includes(filterValue) ? '' : 'none';
    }
}

document.addEventListener('DOMContentLoaded', cargarPedidos);
