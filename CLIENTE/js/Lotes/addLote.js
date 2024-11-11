import { ShowResultError } from "../Utils/toast.js"
import { loadMedicamento } from "./auxLotes.js";

document.addEventListener("DOMContentLoaded", function() {
    

    const idLote = document.getElementById("idLoteAddForm");
    const medicamentoSelect = document.getElementById("medicamento");

    async function loadId(){
       await fetch("https://localhost:44379/api/MedicamentoLote/LastId")
            .then(response =>response.json())
            .then(data =>{
                idLote.value = data + 1;
                console.log(data)
            })
            .catch(error => console.error("Error al cargar el id", error))
    }

    loadId();
    loadMedicamento(medicamentoSelect);


});

document.getElementById("btn-addLote").addEventListener("click", async function() {

    const loteId = document.getElementById("idLoteAddForm").value;
    const medicamento = document.getElementById("medicamento").value;
    const lote = document.getElementById("loteAddForm").value
    const fechaVencimiento = document.getElementById("dateLoteAddForm").value;




    const oLote = {
        idMedicamentoLote: loteId,
        idMedicamento: medicamento,
        lote: lote,
        fechaVencimiento: fechaVencimiento        
    };

    await fetch("https://localhost:44379/api/MedicamentoLote", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(oLote)
    })
    .then(response => {
        if (response.ok) {

            console.log("Medicamento agregado con éxito");    
            localStorage.setItem('status', 200);
            window.location.href = "./lotes.html"

        } else {
            console.log("Error al agregar el medicamento")
            ShowResultError("Debe ingresar todos los campos.");
        }
    })
    .catch(error => 
    ShowResultError("Debe ingresar todos los campos."));
});

