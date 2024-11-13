function CargarNav(){
    const rol = localStorage.getItem("cargoPersonal");
    const name = localStorage.getItem("nombrePersonal");
    const $navBar = document.getElementById("container__navBar");

    const $userName = document.getElementById("userName");
    const $userRol = document.getElementById("userRol");


    $userName.innerText = name;
    $userRol.innerText = rol;
    $navBar.innerHTML = '';
    if(rol === "Gerente de Logística"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Pedidos</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Pedidos/pedidos.html">Ver pedidos</a></li>
                                <li><a class="dropdown-item" href="../Pedidos/cargarPedido.html">Crear pedido</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
  
                                <li><a class="dropdown-item" href="../Stock/stock.html">Stock</a></li>

                            </ul>
                        </li>

                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);
    }

    if(rol === "Especialista en Farmacoeconomía"){
        const li = document.createElement("li");
        li.innerHTML = `    <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                            <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Dashboard/reporteOS.html">Reporte mensual Obra Social</a></li>
                                <li><a class="dropdown-item" href="../Dashboard/totalesFarmacia.html">Totales facturados por Farmacia</a></li>
                            </ul>
                        </li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);
    }


    if(rol === "Supervisor de Calidad"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                                <li><a class="dropdown-item" href="../Productos/producto.html">Productos</a></li>
                                <li><a class="dropdown-item" href="../Stock/stock.html">Stock</a></li>
                                <li><a class="dropdown-item" href="../Lotes/lotes.html">Lotes</a></li>

                            </ul>
                        </li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);
    }


    if(rol === "Supervisor de Ventas"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Facturas</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Factura/factura.html">Ver facturas</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Dashboard/totalesFacturados.html">Totales facturados por vendedor</a></li>
                            </ul>
                        </li>
    
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);
    }


    if(rol === "Asistente de Ventas"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Facturas</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Factura/factura.html">Ver facturas</a></li>
                                <li><a class="dropdown-item" href="../Factura/cargarFactura.html">Crear factura</a></li>
                            </ul>
                        </li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                                <li><a class="dropdown-item" href="../Productos/producto.html">Productos</a></li>
                                <li><a class="dropdown-item" href="../Stock/stock.html">Stock</a></li>
                                <li><a class="dropdown-item" href="../Lotes/lotes.html">Lotes</a></li>
                            </ul>
                        </li>
    
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);
    }


    if(rol === "Gerente de ventas"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Facturas</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Factura/factura.html">Ver facturas</a></li>
                                <li><a class="dropdown-item" href="../Factura/cargarFactura.html">Crear factura</a></li>
                            </ul>
                        </li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                                <li><a class="dropdown-item" href="../Productos/producto.html">Productos</a></li>
                                <li><a class="dropdown-item" href="../Stock/stock.html">Stock</a></li>
                                <li><a class="dropdown-item" href="../Lotes/lotes.html">Lotes</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Dashboard/totalesFacturados.html">Totales facturados por vendedor</a></li>
                            </ul>
                        </li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);

    }


    if(rol === "Asistente Administrativo"){
        const li = document.createElement("li");
        li.innerHTML = `    <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                            <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                                <li><a class="dropdown-item" href="../Stock/stock.html">Stock</a></li>
                                <li><a class="dropdown-item" href="../Lotes/lotes.html">Lotes</a></li>
                            </ul>
                        </li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);

        
    }

    if(rol === "Director tecnico"){
        const li = document.createElement("li");
        li.innerHTML = `<li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Facturas</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Factura/factura.html">Ver facturas</a></li>
                                <li><a class="dropdown-item" href="../Factura/cargarFactura.html">Crear factura</a></li>
                            </ul>
                        </li>

                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Pedidos</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Pedidos/pedidos.html">Ver pedidos</a></li>
                                <li><a class="dropdown-item" href="../Pedidos/cargarPedido.html">Crear pedido</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Soporte</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Medicamentos/medicamentos.html">Medicamentos</a></li>
                                <li><a class="dropdown-item" href="../Productos/producto.html">Productos</a></li>
                                <li><a class="dropdown-item" href="../Stock/stock.html">Stock</a></li>
                                <li><a class="dropdown-item" href="../Lotes/lotes.html">Lotes</a></li>
                                <li><a class="dropdown-item" href="../Inventarios/inventarios.html">Inventarios</a></li>
                                <li><a class="dropdown-item" href="../Personal/personal.html">Gestión usuarios</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Dashboard/totalesFacturados.html">Totales facturados por vendedor</a></li>
                                <li><a class="dropdown-item" href="../Dashboard/reporteOS.html">Reporte mensual Obra Social</a></li>
                                <li><a class="dropdown-item" href="../Dashboard/totalesFarmacia.html">Totales facturados por Farmacia</a></li>
                            </ul>
                        </li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);


    }
    if (rol === "Analista de Mercado Farmaceutico"){

        const li = document.createElement("li");
        li.innerHTML = `    <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Inicio/inicio.html">Inicio</a></li>
                            <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dashboard</a>
                            <ul class="dropdown-menu dropdown-menu-dark">
                                <li><a class="dropdown-item" href="../Dashboard/totalesFacturados.html">Totales facturados por vendedor</a></li>
                                <li><a class="dropdown-item" href="../Dashboard/reporteOS.html">Reporte mensual Obra Social</a></li>
                                <li><a class="dropdown-item" href="../Dashboard/totalesFarmacia.html">Totales facturados por Farmacia</a></li>
                            </ul>
                        </li>
                        <li class="nav-item"><a class="nav-link active" aria-current="page" href="../Acerca_de/acerca.html">Acerca de</a></li>`;
        $navBar.appendChild(li);


    }
}
document.addEventListener("DOMContentLoaded", CargarNav)


document.getElementById('logoutButton').addEventListener('click', function() {
    localStorage.clear();
    window.location.href = '../Login/login.html';
});