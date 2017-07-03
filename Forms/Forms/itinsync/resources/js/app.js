function resizeCanvas(canvas) {
    var ratio = window.devicePixelRatio || 1;
    canvas.width = canvas.offsetWidth * ratio;
    canvas.height = canvas.offsetHeight * ratio;
    canvas.getContext("2d").scale(ratio, ratio);
}

var wrapper1 = document.getElementById("signature-pad-1"),
    clearButton1 = wrapper1.querySelector("[data-action=clear1]"),
    canvas1 = wrapper1.querySelector("canvas"),
    signaturePad1;

    resizeCanvas(canvas1);
    signaturePad1 = new SignaturePad(canvas1);

clearButton1.addEventListener("click", function (event) {
    signaturePad1.clear();
});

var wrapper2 = document.getElementById("signature-pad-2"),
     clearButton2 = wrapper2.querySelector("[data-action=clear2]"),
        canvas2 = wrapper2.querySelector("canvas"),
        signaturePad2;

    resizeCanvas(canvas2);
    signaturePad2 = new SignaturePad(canvas2);

    clearButton2.addEventListener("click", function (event) {
        signaturePad2.clear();
    });
        
////PAD 1 STARTS
//var wrapper1 = document.getElementById("signature-pad-1"),
//	clearButton1 = wrapper1.querySelector("[data-action=clear1]"),
//    //savePNGButton1 = wrapper1.querySelector("[data-action=save-png1]"),
//    canvas1 = wrapper1.querySelector("canvas"),
//    signaturePad1;

//resizeCanvas(canvas1);
//signaturePad1 = new SignaturePad(canvas1);

//clearButton1.addEventListener("click", function (event) {
//    signaturePad1.clear();
//});

//savePNGButton1.addEventListener("click", function (event) {
//    if (signaturePad1.isEmpty()) {
//        alert("Please provide signature first.");
//    } else {
//        document.getElementById("CommonMasterBody_FormMasterBody_signature1").value = signaturePad1.toDataURL();
//    }
//});



//PAD 1 ENDS

//PAD 2 STARTS
//var wrapper2 = document.getElementById("signature-pad-2"),
//	clearButton2 = wrapper2.querySelector("[data-action=clear2]"),
//    savePNGButton2 = wrapper2.querySelector("[data-action=save-png2]"),
//    canvas2 = wrapper2.querySelector("canvas"),
//    signaturePad2;

//resizeCanvas(canvas2);
//signaturePad2 = new SignaturePad(canvas2);

//clearButton2.addEventListener("click", function (event) {
//    signaturePad2.clear();
//});

//savePNGButton2.addEventListener("click", function (event) {
//    if (signaturePad2.isEmpty()) {
//        alert("Please provide signature first.");
//    } else {
//        document.getElementById("CommonMasterBody_FormMasterBody_signature2").value = signaturePad2.toDataURL();
//    }
//});


//PAD 2 ENDS

////PAD 3 STARTS
//var wrapper3 = document.getElementById("signature-pad-3"),
//	clearButton3 = wrapper3.querySelector("[data-action=clear3]"),
//    savePNGButton3 = wrapper3.querySelector("[data-action=save-png3]"),
//    canvas3 = wrapper3.querySelector("canvas"),
//    signaturePad3;

//resizeCanvas(canvas3);
//signaturePad3 = new SignaturePad(canvas3);

//clearButton3.addEventListener("click", function (event) {
//    signaturePad3.clear();
//});

//savePNGButton3.addEventListener("click", function (event) {
//    if (signaturePad3.isEmpty()) {
//        alert("Please provide signature first.");
//    } else {
//        window.open(signaturePad3.toDataURL());
//    }
//});


//PAD 3 ENDS
