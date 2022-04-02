let txtPicture = document.getElementById("txtPicture");
let file = document.getElementById("file");
file.addEventListener("change", function () {
    txtPicture.value = "";
    txtPicture.value = file.files[0].name;
});