
function mostrarToast(mensaje, color = 'bg-success') {
    const toastElement = document.getElementById("pedidoToast");
    const toastMessage = document.getElementById("toastMessage");


    toastMessage.textContent = mensaje;
    toastElement.className = `toast align-items-center text-white ${color} border-0`;


    const toast = new bootstrap.Toast(toastElement);
    toast.show();
}

async function cargarPedidoId() {
    const response = await fetch('https://localhost:44379/api/Pedido/LastId');
    const lastId = await response.json();
    document.getElementById('pedidoId').value = lastId + 1;
}

async function cargarEmpleado() {
    const response = await fetch("https://localhost:44379/api/PersonalEstablecimiento");
    const empleados = await response.json();
    const empleadoSelect = document.getElementById("empleado");
    empleados.forEach(empleado => {
        const option = document.createElement("option");
        option.value = empleado.idPersonal;
        option.textContent = `${empleado.idPersonalNavigation.nombre} ${empleado.idPersonalNavigation.apellido} (${empleado.idEstablecimientoNavigation.nombre})`;
        empleadoSelect.appendChild(option);
    });
}

async function cargarLogistica() {
    const response = await fetch("https://localhost:44379/api/Logistica");
    const logistica = await response.json();
    const logisticaSelect = document.getElementById("logistica");
    logistica.forEach(item => {
        const option = document.createElement("option");
        option.value = item.cuit;
        option.textContent = item.nombreEmpresa;
        logisticaSelect.appendChild(option);
    });
}

async function cargarMedicamento() {
    const response = await fetch("https://localhost:44379/api/MedicamentoLote");
    const medicamentos = await response.json();
    const medicamentoSelect = document.getElementById("detalleMedicamento");
    medicamentos.forEach(medicamento => {
        const option = document.createElement("option");
        option.value = medicamento.idMedicamentoLote;
        option.textContent = `${medicamento.idMedicamentoNavigation.nombreComercial} (${medicamento.lote})`;
        medicamentoSelect.appendChild(option);
    });
}

async function cargarProveedor() {
    const response = await fetch("https://localhost:44379/api/Proveedor");
    const proveedores = await response.json();
    const proveedorSelect = document.getElementById("detalleProveedor");
    proveedores.forEach(proveedor => {
        const option = document.createElement("option");
        option.value = proveedor.idProveedor;
        option.textContent = proveedor.razonSocial;
        proveedorSelect.appendChild(option);
    });
}

/////////////////////////////////////////////////////////////////////////////////////////////////////

let detalles = [];
let idDetalleCounter = 1;

function agregarDetalle() {
    const idPedido = document.getElementById("pedidoId").value;
    const idMedicamento = document.getElementById("detalleMedicamento").value;
    const nombreMedicamento = document.getElementById("detalleMedicamento").selectedOptions[0].text;
    const idProveedor = document.getElementById("detalleProveedor").value;
    const nombreProveedor = document.getElementById("detalleProveedor").selectedOptions[0].text;
    const precioUnitario = parseFloat(document.getElementById("detallePrecio").value);
    const cantidad = parseInt(document.getElementById("detalleCantidad").value);
    const subtotal = document.getElementById("subtotal").value;


    if (!idMedicamento || !idProveedor || !precioUnitario || !cantidad) {
        mostrarToast("Por favor, complete todos los campos del detalle.", "bg-danger");
        return;
    }


    const detalleExistente = detalles.find(detalle => 
        detalle.idMedicamento === idMedicamento && 
        detalle.idProveedor === idProveedor &&
        detalle.precioUnitario === precioUnitario
    );

    if (detalleExistente) {
 
        detalleExistente.cantidad += cantidad;
    } else {

        detalles.push({
            idPedido,
            idDetallePedido: idDetalleCounter++,
            idMedicamento,
            nombreMedicamento,
            idProveedor,
            nombreProveedor,
            precioUnitario,
            cantidad,
            subtotal
        });
    }

    const $subtotal = document.getElementById("subtotal");
    const $total = document.getElementById("total");
    if ($total.value == "") $total.value = "0";
    const totalAcumulado = parseFloat($total.value) + parseFloat($subtotal.value);
    actualizarTablaDetalles();
    document.getElementById("detalleForm").reset();
    $total.value = totalAcumulado;
}

function actualizarTablaDetalles() {
    const tableBody = document.getElementById("detallesTable").getElementsByTagName("tbody")[0];
    tableBody.innerHTML = "";

    detalles.forEach((detalle, index) => {
        const row = tableBody.insertRow();
        row.innerHTML = `
            <td>${detalle.idPedido}</td>
            <td>${detalle.idDetallePedido}</td>
            <td>${detalle.nombreMedicamento}</td>
            <td>${detalle.nombreProveedor}</td>
            <td>${detalle.precioUnitario}</td>
            <td>${detalle.cantidad}</td>
            <td>${detalle.precioUnitario * detalle.cantidad}</td>
            <td><button type="button" class="btn btn-danger btn-sm" onclick="eliminarDetalle(${index})">Eliminar</button></td>
        `;
    });
}

function eliminarDetalle(index) {
    const $total = document.getElementById("total");
    let totalAcumulado = parseFloat($total.value);
    const detalleEliminado = detalles.splice(index, 1);
    totalAcumulado -= parseFloat(detalleEliminado[0].subtotal);
    $total.value = totalAcumulado;
    detalles.forEach((detalle, i) => detalle.idDetallePedido = i + 1);
    actualizarTablaDetalles();
}

async function realizarPedido() {
    const idEmpleado = document.getElementById("empleado").value;
    const idLogistica = document.getElementById("logistica").value;
    const fecha = document.getElementById("fecha").value;


    if (!idEmpleado || !idLogistica || !fecha) {
        mostrarToast("Por favor, complete todos los campos de cabecera del pedido.", "bg-danger");
        return;
    }
    if (detalles.length === 0) {
        mostrarToast("Por favor, agregue al menos un detalle al pedido.", "bg-danger");
        return;
    }

    const pedidoData = {
        idPedido: document.getElementById("pedidoId").value,
        idPersonalCargosEstablecimientos: idEmpleado,
        idLogistica,
        fecha
    };

    const pedidoResponse = await fetch("https://localhost:44379/api/Pedido", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(pedidoData)
    });

    if (pedidoResponse.ok) {
        await Promise.all(detalles.map(detalle => {
            return fetch("https://localhost:44379/api/DetallePedido", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    idPedido: detalle.idPedido,
                    idDetallePedido: detalle.idDetallePedido,
                    idMedicamentoLote: detalle.idMedicamento,
                    idProveedor: detalle.idProveedor,
                    precioUnitario: detalle.precioUnitario,
                    cantidad: detalle.cantidad
                })
            });
        }));

        mostrarToast("Pedido realizado con éxito.", "bg-success");


        document.getElementById("empleado").value = "";
        document.getElementById("logistica").value = "";
        document.getElementById("fecha").value = "";


        detalles = [];
        idDetalleCounter = 1;
        actualizarTablaDetalles();
        

        cargarPedidoId();
        SetearFecha();
    } else {
        mostrarToast("Error al enviar el pedido.", "bg-danger");
    }
}

function CalcularSubtotal() {
    const precioUnitario = document.getElementById('detallePrecio').value;
    const cantidad = document.getElementById('detalleCantidad').value;
    if (precioUnitario != "" && cantidad != "") {
        const subtotal = Math.round(precioUnitario * cantidad);
        document.getElementById('subtotal').value = subtotal;
    }
}

function AgregarSubtotal(){
    document.getElementById("detallePrecio").addEventListener("keyup", CalcularSubtotal);
    document.getElementById("detalleCantidad").addEventListener("keyup", CalcularSubtotal);
}

function SetearFecha(){
    let fechaActual = new Date();
    let anio = fechaActual.getFullYear();
    let mes = String(fechaActual.getMonth() + 1).padStart(2, '0'); 
    let dia = String(fechaActual.getDate()).padStart(2, '0');
    document.getElementById('fecha').value = `${anio}-${mes}-${dia}`;
}


document.addEventListener("DOMContentLoaded", () => {
    cargarPedidoId();
    cargarEmpleado();
    cargarLogistica();
    cargarMedicamento();
    cargarProveedor();
    AgregarSubtotal();
    SetearFecha();
});
