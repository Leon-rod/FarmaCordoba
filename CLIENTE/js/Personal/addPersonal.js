import { ShowResultError } from "../Utils/toast.js"
import { loadBarrio, loadGenero, loadCargo, loadTipoDoc } from "./auxPersonal.js";

document.addEventListener("DOMContentLoaded", function() {
    


    const cargoSelect = document.getElementById("cargo");
    const barrioSelect = document.getElementById("barrio");
    const generoSelect = document.getElementById("genero");
    const tipoDocSelect = document.getElementById("tipoDoc");



    loadBarrio(barrioSelect);
    loadGenero(generoSelect);
    loadCargo(cargoSelect);
    loadTipoDoc(tipoDocSelect);


});

document.getElementById("btn-addPersonal").addEventListener("click", async function() {

    let idPersonal = 0;
    let idPersonalCargoEstablecimiento = 0;

    async function loadIdPersonal(){
        await fetch("https://localhost:44379/api/Personal/LastId")
             .then(response =>response.json())
             .then(data =>{
                 idPersonal = data + 1;
                 console.log(data)
             })
             .catch(error => console.error("Error al cargar el id", error))
     }
 
     async function loadIdPersonalCargosEstablecimientos(){
         await fetch("https://localhost:44379/api/PersonalEstablecimiento/LastId")
              .then(response =>response.json())
              .then(data =>{
                 idPersonalCargoEstablecimiento = data + 1;
                  console.log(data)
              })
              .catch(error => console.error("Error al cargar el id", error))
      }
 
     await loadIdPersonal();
     await loadIdPersonalCargosEstablecimientos();

     const establecimiento = localStorage.getItem("establecimientoPersonal");
     const nombre = document.getElementById("name").value;
     const apellido = document.getElementById("lastName").value;
     const fechaNac = document.getElementById("fechaNac").value;
     const cargo = document.getElementById("cargo").value;
     const calle = document.getElementById("calle").value;
     const nroCalle = document.getElementById("numeroCalle").value;
     const barrio = document.getElementById("barrio").value;
     const tipoDoc = document.getElementById("tipoDoc").value;
     const numeroDoc = document.getElementById("numeroDoc").value;
     const genero = document.getElementById("genero").value;
     const contraseña = document.getElementById("contraseña").value;




    const oPersonal = {
        idPersonal: idPersonal,
        nombre: nombre,
        apellido: apellido,
        fechaNac: fechaNac,
        calle: calle,
        numero: nroCalle,
        idBarrio: barrio,
        tipoDoc: tipoDoc,
        nroDoc: numeroDoc,
        idGenero: genero,
        psw: contraseña
    };

    const oPersonalCargoEstablecimiento ={
        idPersonalCargosEstablecimientos: idPersonalCargoEstablecimiento,
        idPersonal: idPersonal,
        idCargo: cargo,
        idEstablecimiento: establecimiento
    } 
    try {
        const response = await fetch("https://localhost:44379/api/Personal", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(oPersonal)
        });

        if (response.ok) {
            const response2 = await fetch("https://localhost:44379/api/PersonalEstablecimiento", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(oPersonalCargoEstablecimiento)
            });

            if (response2.ok) {
                localStorage.setItem('status', 200);
                console.log("Personal y PersonalCargosEstablecimientos agregados correctamente");
                window.location.href = "./personal.html"
            } else {
                console.log("Error al agregar PersonalCargosEstablecimientos");
                ShowResultError("Error al agregar PersonalCargosEstablecimientos.");
            }
        } else {
            console.log("Error al agregar al personal");
            ShowResultError("Debe ingresar todos los campos.");
        }
    } catch (error) {
        console.error("Error al realizar los POSTs", error);
        ShowResultError("Ocurrió un error al procesar la solicitud.");
    }
});

