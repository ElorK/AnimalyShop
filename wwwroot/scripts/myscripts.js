$("#imgPrev").click(function () {
    $("#imgUp").trigger("click");
});
$("#imgUp").on("input", function () {
    $("#prev").attr("src", URL.createObjectURL(event.target.files[0]))
});