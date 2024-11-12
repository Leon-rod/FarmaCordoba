document.addEventListener("DOMContentLoaded", async () => {
    const urlParams = new URLSearchParams(window.location.search);
    const productId = urlParams.get("id");

    if (productId) {
        try {
            await loadMarcas();
            await loadTipos();

            const response = await fetch(`https://localhost:44379/api/Producto/id?id=${productId}`);
            const product = await response.json();
            loadProductData(product);
        } catch (error) {
            console.error("Error al cargar producto:", error);
        }
    }

    document.getElementById("saveChanges").addEventListener("click", saveChanges);
});

async function loadProductData(product) {
    document.getElementById("nombre").value = product.nombre;
    document.getElementById("descripcion").value = product.descripcion;
    document.getElementById("precio").value = product.precio;
    document.getElementById("activo").checked = product.activo;

    document.getElementById("marca").value = product.idMarca;
    document.getElementById("tipoProducto").value = product.tipoProducto;
}

async function loadMarcas() {
    const marcasSelect = document.getElementById("marca");
    try {
        const response = await fetch("https://localhost:44379/api/Marca");
        const marcas = await response.json();
        marcasSelect.innerHTML = "<option>Seleccionar</option>";
        marcas.forEach(marca => {
            const option = document.createElement("option");
            option.value = marca.idMarca;
            option.textContent = marca.nombreMarca;
            marcasSelect.appendChild(option);
        });
    } catch (error) {
        console.error("Error al cargar marcas:", error);
    }
}

async function loadTipos() {
    const tiposSelect = document.getElementById("tipoProducto");
    try {
        const response = await fetch("https://localhost:44379/api/TipoProducto");
        const tipos = await response.json();
        tiposSelect.innerHTML = "<option>Seleccionar</option>";
        tipos.forEach(tipo => {
            const option = document.createElement("option");
            option.value = tipo.idTipoProducto;
            option.textContent = tipo.tipoProducto;
            tiposSelect.appendChild(option);
        });
    } catch (error) {
        console.error("Error al cargar tipos de producto:", error);
    }
}

async function saveChanges() {
    const productId = new URLSearchParams(window.location.search).get("id");
    const productData = {
        idProducto: productId,
        nombre: document.getElementById("nombre").value,
        idMarca: document.getElementById("marca").value,
        tipoProducto: document.getElementById("tipoProducto").value,
        descripcion: document.getElementById("descripcion").value,
        precio: parseFloat(document.getElementById("precio").value), 
        activo: document.getElementById("activo").checked ? true : false
    };

    try {
        await fetch(`https://localhost:44379/api/Producto`, { 
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(productData)
        });
        alert("Producto actualizado correctamente");
        window.location.href = "/pages/Productos/Producto.html"; 
    } catch (error) {
        console.error("Error al actualizar producto:", error);
    }
}



