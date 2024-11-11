document.addEventListener("DOMContentLoaded", () => {
    const idEstablecimiento = localStorage.getItem("establecimientoPersonal");
    const tableBody = document.querySelector("#stockTable tbody");

    const medicamentoSelect = document.getElementById("medicamentoSelect");
    const productoSelect = document.getElementById("productoSelect");

    loadStockData(idEstablecimiento);

    loadMedicamentos();
    loadProductos();

    document.getElementById("buscarMedicamento").addEventListener("click", () => {
        const idMedicamento = medicamentoSelect.value;
        loadStockData(idEstablecimiento, idMedicamento, null);
    });

    document.getElementById("buscarProducto").addEventListener("click", () => {
        const idProducto = productoSelect.value;
        loadStockData(idEstablecimiento, null, idProducto);
    });

    async function loadStockData(idEstablecimiento, idMedicamento = null, idProducto = null) {
        let url = `https://localhost:44379/api/Stock/Lotes/Establecimiento?establecimiento=${idEstablecimiento}`;
        if (idMedicamento) url += `&medicamento=${idMedicamento}`;
        if (idProducto) url += `&producto=${idProducto}`;

        try {
            const response = await fetch(url);
            if (!response.ok) throw new Error("Error en la respuesta del servidor");
            const data = await response.json();
            populateTable(data);
        } catch (error) {
            console.error("Error loading stock data:", error);
        }
    }

    function populateTable(data) {
        tableBody.innerHTML = "";
        data.forEach(item => {
            const row = document.createElement("tr");
            row.innerHTML = `
                <td>${item.idStock}</td>
                <td>${new Date(item.fecha).toLocaleDateString()}</td>
                <td>${item.cantidad}</td>
                <td>${item.cantidadMinima}</td>
                <td>${item.idProductoNavigation ? item.idProductoNavigation.nombre : item.idMedicamentoLoteNavigation.idMedicamentoNavigation.nombreComercial}</td>
                <td>${item.idEstablecimiento}</td>
            `;
            tableBody.appendChild(row);
        });
    }

    async function loadMedicamentos() {
        try {
            const response = await fetch("https://localhost:44379/api/Medicamento");
            if (!response.ok) throw new Error("Error al cargar los medicamentos");
            const medicamentos = await response.json();
            medicamentoSelect.innerHTML = '<option value="">Seleccione un medicamento</option>';
            medicamentos.forEach(medicamento => {
                const option = document.createElement("option");
                option.value = medicamento.idMedicamento;
                option.textContent = medicamento.nombreComercial;
                medicamentoSelect.appendChild(option);
            });
        } catch (error) {
            console.error("Error loading medicamentos:", error);
        }
    }

    async function loadProductos() {
        try {
            const response = await fetch("https://localhost:44379/api/Producto");
            if (!response.ok) throw new Error("Error al cargar los productos");
            const productos = await response.json();
            productoSelect.innerHTML = '<option value="">Seleccione un producto</option>';
            productos.forEach(producto => {
                const option = document.createElement("option");
                option.value = producto.idProducto;
                option.textContent = producto.nombre;
                productoSelect.appendChild(option);
            });
        } catch (error) {
            console.error("Error loading productos:", error);
        }
    }
});
