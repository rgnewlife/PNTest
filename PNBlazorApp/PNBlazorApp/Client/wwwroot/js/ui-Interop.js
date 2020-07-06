
window.domMethods =
{
    showUpdateInputs: function (id, name, description, bShow) {
        if (bShow) {
            document.getElementById("spnDescription_" + id).style.display = "none";
            var txtInputDescription = document.getElementById("txtInputDescription_" + id);
            txtInputDescription.style.display = "";
            txtInputDescription.value = description;
            document.getElementById("spnName_" + id).style.display = "none";
            var txtInputName = document.getElementById("txtInputName_" + id);
            txtInputName.style.display = "";
            txtInputName.value = name;
            txtInputName.focus();
            document.getElementById("btnEdit_" + id).style.display = "none";
            document.getElementById("btnUpdate_" + id).style.display = "";
            document.getElementById("btnEditCancel_" + id).style.display = "";
        }
        else {
            document.getElementById("spnDescription_" + id).style.display = "";
            document.getElementById("spnName_" + id).style.display = "";
            document.getElementById("txtInputDescription_" + id).style.display = "none";
            document.getElementById("txtInputName_" + id).style.display = "none";
            document.getElementById("btnEdit_" + id).style.display = "";
            document.getElementById("btnUpdate_" + id).style.display = "none";
            document.getElementById("btnEditCancel_" + id).style.display = "none";
        }
    },

    showAddInputs: function (bShow) {
        if (bShow) {
            document.getElementById("divAddInputs").style.display = "";
            document.getElementById("btnAdd").style.display = "none";
        }
        else {
            document.getElementById("divAddInputs").style.display = "none";
            document.getElementById("btnAdd").style.display = "";
        }
    },

    showAlert: function (message) {
        alert(message);
    }


};


