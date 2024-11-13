export async function loadObraSocial(select) {
    await fetch("https://localhost:44379/api/ObraSocial")
        .then(response => response.json())
        .then(data => {
            select.innerHTML = '<option selected>Seleccionar</option>';
            data.forEach(item => {
                const option = document.createElement("option");
                option.value =  item.idObraSocial; 
                option.textContent = item.nombre; 
                select.appendChild(option);
            });

        })
        .catch(error => console.error("Error al cargar opciones:", error));
}


export async function mapViewOS(register) {
    const row = document.createElement("tr");

    const añoCell = document.createElement("td");
    añoCell.textContent = register.año;

    const mesCell = document.createElement("td");
    mesCell.textContent = register.mes;

    const obraSocial = document.createElement("td");
    obraSocial.textContent = register.obraSocial;

    const importeAReintegrar = document.createElement("td");
    importeAReintegrar.textContent = '$' + register.importeAReintegrar.toFixed(2);

    row.appendChild(añoCell)
    row.appendChild(mesCell)
    row.appendChild(obraSocial)
    row.appendChild(importeAReintegrar)


    document.getElementById("tableBody").appendChild(row);
}

export async function mapViewCob(register, mes, año) {
    const row = document.createElement("tr");

    const añoCell = document.createElement("td");
    añoCell.textContent = año;

    const mesCell = document.createElement("td");
    mesCell.textContent = mes;

    const obraSocial = document.createElement("td");
    obraSocial.textContent = register.tipoDeCobertura;

    const importeAReintegrar = document.createElement("td");
    importeAReintegrar.textContent = '$' + register.importeAReintegrar.toFixed(2);

    row.appendChild(añoCell)
    row.appendChild(mesCell)
    row.appendChild(obraSocial)
    row.appendChild(importeAReintegrar)


    document.getElementById("tableBodyCobertura").appendChild(row);
}

