document.write('<DIV id="pageloading"><BR><BR>Loading... Please wait..!</DIV>');
window.onload=function(){
    document.getElementById("pageloading").style.display = "none";
}

$(document).ready(function () {

    // Bind normal buttons
    $('.ladda-button').ladda('bind', { timeout: 2000 });

    // Bind progress buttons and simulate loading progress
    Ladda.bind('.progress-demo .ladda-button', {
        callback: function (instance) {
            var progress = 0;
            var interval = setInterval(function () {
                progress = Math.min(progress + Math.random() * 0.1, 1);
                instance.setProgress(progress);

                if (progress === 1) {
                    instance.stop();
                    clearInterval(interval);
                }
            }, 200);
        }
    });


    var l = $('.ladda-button-demo').ladda();

    l.click(function () {
        // Start loading
        l.ladda('start');

        // Timeout example
        // Do something in backend and then stop ladda
        setTimeout(function () {
            l.ladda('stop');
        }, 12000)


    });

});


function validate() {
    debugger
    var validator = new IValidation("forms", true)
             validator.initValidation();
            return iFormIsValid(validator);
        }

function message(msg) {
    $.Notification.notify('error', 'top right', 'Sample Notification', msg)
}