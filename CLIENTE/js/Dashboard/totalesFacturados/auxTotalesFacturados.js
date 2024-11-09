export async function loadPersonal(select) {
    await fetch("https://localhost:44379/api/PersonalEstablecimiento")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value =  item.idPersonalCargosEstablecimientos; 
                option.textContent = item.idPersonalNavigation.nombre + ', ' +item.idPersonalNavigation.apellido; 
                select.appendChild(option);
            });

        })
        .catch(error => console.error("Error al cargar opciones:", error));
}

export async function loadYears(select) {
    const year = new Date().getFullYear();

    for(let i = 2020; i<= year; i++){
        const option = document.createElement("option");
        option.value =  i; 
        option.textContent = i; 
        select.appendChild(option);
    }

}

export async function mapView(register) {
    const row = document.createElement("tr");

    const añoCell = document.createElement("td");
    añoCell.textContent = register.año;

    const mesCell = document.createElement("td");
    mesCell.textContent = register.mes;

    const personalCell = document.createElement("td");
    personalCell.textContent = register.personal;

    const totalFactCell = document.createElement("td");
    totalFactCell.textContent = '$' + register.totalFacturado.toFixed(2);

    const topSellCell = document.createElement("td");
    topSellCell.textContent = '$' + register.ventaMasCara.toFixed(2);

    row.appendChild(añoCell)
    row.appendChild(mesCell)
    row.appendChild(personalCell)
    row.appendChild(totalFactCell)
    row.appendChild(topSellCell)

    document.getElementById("tableBody").appendChild(row);
}

