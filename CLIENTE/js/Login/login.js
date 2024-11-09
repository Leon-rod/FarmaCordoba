async function Loguear(){
    $username = document.getElementById("username").value;
    $password = document.getElementById("password").value;
    let flag = false;
    try{
        const response = await fetch("https://localhost:44379/api/PersonalEstablecimiento");
        const data = await response.json();
        data.forEach(item => {
            if($username == item.idPersonalNavigation.nroDoc && $password == item.idPersonalNavigation.psw){
                localStorage.setItem("nombrePersonal", `${item.idPersonalNavigation.nombre} ${item.idPersonalNavigation.apellido}`);
                localStorage.setItem("cargoPersonal", item.idCargoNavigation.cargo1);
                window.location.href = "../Inicio/inicio.html";
                flag = true;
            }
        });
        if(!flag){

            LimpiarFormulario();
        }
    } catch (error) {
        console.log("Error al cargar empleados", error);
    }
}

function LimpiarFormulario(){
    
    document.getElementById("loginForm").reset();
    mostrarToast("Credenciales incorrectas")
}

document.addEventListener("DOMContentLoaded",()=>{
    document.getElementById("loginBtn").addEventListener("click", Loguear);
})

function mostrarToast(mensaje, color = 'bg-danger', duracion = 3000) {
    const toastElement = document.getElementById("pedidoToast");
    const toastMessage = document.getElementById("toastMessage");

    toastMessage.textContent = mensaje;
    toastElement.className = `toast align-items-center text-white ${color} border-0`;

    const toast = new bootstrap.Toast(toastElement, { delay: duracion });
    toast.show();
}
