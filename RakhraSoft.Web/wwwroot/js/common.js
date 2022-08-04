window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 5000 });
    }

    if (type === "error") {
        toastr.error(message, "Operation Fail", { timeOut: 5000 });
    }
}

window.ShowSweetAlert = (type, message) => {

    swal({
        title: type,
        text: message,
        icon: type,
    });
}