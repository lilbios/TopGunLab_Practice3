function imgload(image) {
    if (image.files[0]) {
        let uploading = new FileReader();
        let imgType = image.files[0].type;
        if (imgType == "image/png" || imgType == "image/jpeg" || imgType == "image/gif") {
            uploading.onload = function (displayImg) {
                $(".img").attr("src", displayImg.target.result)
            }
            uploading.readAsDataURL(image.files[0])
        } else {
            $(".error-msg").append("We support only GIF,JPG AND PNG format");
        }
    }

}