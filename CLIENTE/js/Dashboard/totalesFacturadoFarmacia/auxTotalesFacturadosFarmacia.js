

export async function loadYears(select) {
    const year = new Date().getFullYear();

    for(let i = 2020; i<= year; i++){
        const option = document.createElement("option");
        option.value =  i; 
        option.textContent = i; 
        select.appendChild(option);
    }

}

export async function mapSP(register) {
    const row = document.createElement("tr");

    const establecimientoCell = document.createElement("td");
    establecimientoCell.textContent = register.establecimiento;

    const totalFacturadoCell = document.createElement("td");
    totalFacturadoCell.textContent = '$' + register.totalFacturado;

    const mejorAñoCell = document.createElement("td");
    mejorAñoCell.textContent = register.mejorAño;

    row.appendChild(establecimientoCell)
    row.appendChild(totalFacturadoCell)
    row.appendChild(mejorAñoCell)

    document.getElementById("tableBody").appendChild(row);
}

