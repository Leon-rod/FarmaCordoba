const ShowResult = (message) =>{
    Toastify({
        text: `${message}`,
        duration: 3000,
        newWindow: true,
        close: true,
        gravity: "top", 
        position: "right", 
        stopOnFocus: false, 
        style: {
          background: "linear-gradient(to right, #00b09b, #96c93d)",
        },
        onClick: function(){} 
    }).showToast();
}

const ShowResultError = (message) =>{
  Toastify({
      text: `${message}`,
      duration: 3000,
      newWindow: true,
      close: true,
      gravity: "top", 
      position: "right", 
      stopOnFocus: false, 
      style: {
        background: "red",
      },
      onClick: function(){} 
  }).showToast();
}
export {ShowResult, ShowResultError} 