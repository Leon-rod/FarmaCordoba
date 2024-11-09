let idFactura;
async function ObtenerUltimoId(){
    try{
        const $detalleIdFactura = document.getElementById("detalleIdFactura");
        const response = await fetch("https://localhost:44379/api/Factura/GetLastId");
        const data = await response.json();
        document.getElementById("facturaId").value = data + 1;
        idFactura = data + 1;
        $detalleIdFactura.value = data + 1;
    } catch (error) {
        console.log("Error al cargar el id", error);
    }
}
async function CargarClientes(){
    try{
        const $clientSelect = document.getElementById("cliente");
        const response = await fetch("https://localhost:44379/api/Cliente");
        const data = await response.json();
        // $clientSelect.innerHTML = '';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idCliente; 
            option.textContent = `${item.apellido} ${item.nombre}`; 
            $clientSelect.appendChild(option);
        });
    } catch (error) {
        console.log("Error al cargar clientes", error);
    }
}
async function CargarEmpleados(){
    try{
        const $employeeSelect = document.getElementById("empleado");
        const response = await fetch("https://localhost:44379/api/PersonalEstablecimiento");
        const data = await response.json();
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idPersonalCargosEstablecimientos; 
            option.textContent = `${item.idPersonalNavigation.apellido} ${item.idPersonalNavigation.nombre} (${item.idEstablecimientoNavigation.nombre})`; 
            $employeeSelect.appendChild(option);
        });
    } catch (error) {
        console.log("Error al cargar empleados", error);
    }
}
async function CargarCoberturas(){
    try{
        const $detailCoberture = document.getElementById("detalleCobertura");
        const response = await fetch("https://localhost:44379/api/Cobertura");
        const data = await response.json();
        // $detailCoberture.innerHTML = '';
        data.forEach(item => {
            const option = document.createElement("option");
            option.value = item.idTipoCobertura; 
            option.textContent = item.descripcion; 
            $detailCoberture.appendChild(option);
        });
    } catch (error) {
        console.log("Error al cargar coberturas", error);
    }
}

async function CargarMedicamentos(){
    try{
        const $detailMedicine = document.getElementById("detalleMedicamento");
        const idPersonalEstablecimientos = document.getElementById("empleado").value;
        $detailMedicine.innerHTML = '';
        let idEstablecimiento;
        const responsePersonalEstablecimiento = await fetch("https://localhost:44379/api/PersonalEstablecimiento/ID?id=" + idPersonalEstablecimientos);
        const dataPersonalEstablecimiento = await responsePersonalEstablecimiento.json();
        idEstablecimiento = dataPersonalEstablecimiento.idEstablecimiento;
        const responseEstablishment = await fetch("https://localhost:44379/Establishment?id=" + idEstablecimiento);
        const dataEstablishment = await responseEstablishment.json();
        dataEstablishment.forEach(item => {
            if (item.idMedicamentoLoteNavigation != null){
                const option = document.createElement("option");
                option.value = item.idMedicamentoLote; 
                option.textContent = `${item.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial} (${item.idMedicamentoLoteNavigation.idMedicamentoNavigation.idPresentacionNavigation.nombrePresentacion})`; 
                $detailMedicine.appendChild(option);
            }
        });
    } catch (error) {
        console.log("Error al cargar medicamentos", error);
    }
}
document.addEventListener("DOMContentLoaded", () => {
    ObtenerUltimoId();
    CargarClientes();
    CargarEmpleados();
    CargarCoberturas();

    document.getElementById("empleado").addEventListener("change", CargarMedicamentos);

    AgregarSubtotal();

    SetearFecha();
    
})

function AgregarSubtotal(){
    document.getElementById("detallePrecio").addEventListener("keyup", CalcularSubtotal);
    document.getElementById("detalleDescuento").addEventListener("keyup", CalcularSubtotal);
    document.getElementById("detalleCantidad").addEventListener("keyup", CalcularSubtotal);
}

let dispensaciones = [];
let idDetalleFactura = 1;
document.getElementById("detalleId").value = idDetalleFactura;
function agregarDetalle() {
   idDetalleFactura++;

   const idFactura = document.getElementById('detalleIdFactura').value;
   const idDispensacion = document.getElementById('detalleId').value;
   const idMedicamentoLote = document.getElementById('detalleMedicamento').value;
   const idCobertura = document.getElementById('detalleCobertura').value;
   const descuento = document.getElementById('detalleDescuento').value / 100;
   const precioUnitario = document.getElementById('detallePrecio').value;
   const cantidad = document.getElementById('detalleCantidad').value;
   const subtotal = document.getElementById('subtotal').value;
   const matricula = document.getElementById('detalleMatricula').value;
   const codigoValidacion = document.getElementById('detalleCodigo').value;
   const medicamento = document.getElementById('detalleMedicamento').selectedOptions[0].text;
   const cobertura = document.getElementById('detalleCobertura').selectedOptions[0].text;
   
   if (!idMedicamentoLote || !idCobertura || !precioUnitario || !cantidad || !matricula || !codigoValidacion) {
    mostrarToast("Por favor, complete todos los campos del detalle.", "bg-danger");
    return;
    }


    const detalleExistente = dispensaciones.find(detalle => 
        detalle.idMedicamentoLote === idMedicamentoLote && 
        detalle.idCobertura === idCobertura 
    );

    if (detalleExistente) {

        detalleExistente.cantidad = parseFloat(detalleExistente.cantidad) + parseFloat(cantidad);
    }else{
        dispensaciones.push({
            idFactura,
            idDispensacion,
            idMedicamentoLote,
            idCobertura,
            descuento,
            precioUnitario,
            cantidad,
            subtotal,
            matricula,
            codigoValidacion,
            medicamento,
            cobertura
           });
    }



   const $subtotal = document.getElementById("subtotal");
   const $total = document.getElementById("total");
   if ($total.value == "") $total.value = "0";
   const totalAcumulado = parseFloat($total.value) + parseFloat($subtotal.value);
   actualizarTablaDetalles();
   
   document.getElementById("detalleForm").reset();
   $total.value = totalAcumulado;
   document.getElementById("detalleId").value = idDetalleFactura;
   document.getElementById("detalleIdFactura").value = idFactura;
}

function actualizarTablaDetalles() {
    const table = document.getElementById('detallesTable').getElementsByTagName('tbody')[0];
    table.innerHTML = '';
    dispensaciones.forEach((detalle, index) => {
        const row = table.insertRow();
        row.innerHTML = `
            <td>${detalle.idFactura}</td>
            <td>${index + 1}</td>
            <td>${detalle.medicamento}</td>
            <td>${detalle.cobertura}</td>
            <td>${detalle.descuento}</td>
            <td>${detalle.precioUnitario}</td>
            <td>${detalle.cantidad}</td>
            <td>${detalle.subtotal}</td>
            <td>${detalle.matricula}</td>
            <td>${detalle.codigoValidacion}</td>
            <td><button type="button" class="btn btn-danger btn-sm" onclick="eliminarDetalle(${index})" id="deleteBtn">Eliminar</button></td>
        `;
    });
}

function eliminarDetalle(index) {
    const $total = document.getElementById("total");
    let totalAcumulado = parseFloat($total.value);
    const dispensacionEliminada = dispensaciones.splice(index, 1);
    totalAcumulado -= parseFloat(dispensacionEliminada[0].subtotal);
    $total.value = totalAcumulado;
    dispensaciones.forEach((detalle, i) => detalle.idDetalleFactura = i );
    actualizarTablaDetalles();
}

async function realizarFactura() {
    const facturaData = {
        idFactura: document.getElementById("facturaId").value,
        idCliente: document.getElementById("cliente").value,
        idPersonalCargosEstablecimientos: document.getElementById("empleado").value,
        fecha: document.getElementById("fecha").value
    };

    const facturaResponse = await fetch("https://localhost:44379/api/Factura", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(facturaData)
    });

    if (facturaResponse.ok) {
        for(var detalle of dispensaciones) {
            try {
                const detalleResponse = await fetch("https://localhost:44379/api/Dispensacion", {
                    method: "POST",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        idFactura: detalle.idFactura,
                        idDispensacion: detalle.idDispensacion,
                        idMedicamentoLote: detalle.idMedicamentoLote,
                        idCobertura: detalle.idCobertura,
                        descuento: detalle.descuento,
                        precioUnitario: detalle.precioUnitario,
                        cantidad: detalle.cantidad,
                        matricula: detalle.matricula,
                        codigoValidacion: detalle.codigoValidacion
                    })
                });
                if (!detalleResponse.ok) {
                    mostrarToast("Error al enviar una dispensacion (id: " + detalle.idDispensacion + ") " + "Status: "+detalleResponse.status, "bg-danger");
                }
            } catch (error) {
                mostrarToast("Error al intentar conectar con el servidor " + error, "bg-danger");
            }
        }


        const toastElement = document.getElementById("facturaToast");
        const toast = new bootstrap.Toast(toastElement);
        toast.show();


        document.getElementById("empleado").value = "";
        document.getElementById("cliente").value = "";
        document.getElementById("fecha").value = "";


        dispensaciones = [];
        idDetalleFactura = 1;
        document.getElementById("detalleId").value = idDetalleFactura;
        actualizarTablaDetalles();
        

        ObtenerUltimoId();
        SetearFecha();

    } else {
        mostrarToast("Error al enviar la factura " + "Status: "+facturaResponse.status, "bg-danger");
    }
}

function CalcularSubtotal() {
    const precioUnitario = document.getElementById('detallePrecio').value;
    const cantidad = document.getElementById('detalleCantidad').value;
    const descuento = document.getElementById('detalleDescuento').value / 100;
    if (precioUnitario != "" && cantidad != "" && descuento !== "") {
        const subtotal = Math.round((precioUnitario * cantidad - (precioUnitario*cantidad*descuento)));
        document.getElementById('subtotal').value = subtotal;
    }
}

function SetearFecha(){
    let fechaActual = new Date();
    let anio = fechaActual.getFullYear();
    let mes = String(fechaActual.getMonth() + 1).padStart(2, '0'); 
    let dia = String(fechaActual.getDate()).padStart(2, '0');
    document.getElementById('fecha').value = `${anio}-${mes}-${dia}`;
}


function mostrarToast(mensaje, color = 'bg-success') {
    const toastElement = document.getElementById("facturaToast");
    const toastMessage = document.getElementById("toastMessage");


    toastMessage.textContent = mensaje;
    toastElement.className = `toast align-items-center text-white ${color} border-0`;


    const toast = new bootstrap.Toast(toastElement);
    toast.show();
}
