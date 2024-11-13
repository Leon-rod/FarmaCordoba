document.addEventListener("DOMContentLoaded", async () => {

    await loadLastProductId();

    await loadMarcas(document.getElementById("marca"));
    await loadTipos(document.getElementById("tipoProducto"));
    
    document.getElementById("createProduct").addEventListener("click", createProduct);
});

async function loadMarcas(select, selectedId = null) {
    await fetch("https://localhost:44379/api/Marca")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idMarca; 
                option.textContent = item.nombreMarca; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones de marcas:", error));
}

async function loadTipos(select, selectedId = null) {
    await fetch("https://localhost:44379/api/TipoProducto")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value = item.idTipoProducto; 
                option.textContent = item.tipoProducto; 
                select.appendChild(option);
            });
            if (selectedId) {
                select.value = selectedId;
            }
        })
        .catch(error => console.error("Error al cargar opciones de tipos de producto:", error));
}

async function loadLastProductId() {
    try {
        const response = await fetch("https://localhost:44379/api/Producto/LastId");
        const data = await response.json();
        console.log("Respuesta de LastId:", data);
        
        if (typeof data === 'number') {
            document.getElementById("idProducto").value = data;
        } else if (data && data.lastId !== undefined) {
            document.getElementById("idProducto").value = data.lastId;
        } else {
            console.error("Estructura de respuesta inesperada para LastId.");
        }
    } catch (error) {
        console.error("Error al cargar el último ID de producto:", error);
    }
}


async function createProduct() {
    const newProductData = {
        idProducto: document.getElementById("idProducto").value,
        nombre: document.getElementById("nombre").value,
        idMarca: document.getElementById("marca").value,
        tipoProducto: document.getElementById("tipoProducto").value,
        descripcion: document.getElementById("descripcion").value,
        precio: parseFloat(document.getElementById("precio").value),
        activo: document.getElementById("activo").checked
    };

    try {
        await fetch("https://localhost:44379/api/Producto", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(newProductData)
        });
        localStorage.setItem("status-producto-agregado", "200")
        window.location.href = "/pages/Productos/Producto.html"; 
    } catch (error) {
        mostrarToast("No se pudo agregar")
    }
}

function mostrarToast(mensaje, color = 'bg-danger', duracion = 3000) {
    const toastElement = document.getElementById("pedidoToast");
    const toastMessage = document.getElementById("toastMessage");

    toastMessage.textContent = mensaje;
    toastElement.className = `toast align-items-center text-white ${color} border-0`;

    const toast = new bootstrap.Toast(toastElement, { delay: duracion });
    toast.show();
}
