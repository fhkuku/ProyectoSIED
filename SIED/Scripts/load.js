function addEvent(element, event, fn) {
    if (element.addEventListener) {
        element.addEventListener(event, fn, false);
    } else if (element.attachEvent) {
        element.attachEvent('on' + event, fn);
    }
}

function loadScript(src, callback) {
    var s,
        r,
        t;
    r = false;
    s = document.createElement('script');
    s.type = 'text/javascript';
    s.src = src;
    s.onload = s.onreadystatechange = function () {
        if (!r && (!this.readyState || this.readyState == 'complete')) {
            r = true;
            if (callback !== undefined) {
                callback();
            }
        }
    };
    t = document.getElementsByTagName('script')[0];
    t.parentNode.insertBefore(s, t);
}

addEvent(window, 'load', function () {
    loadScript('../Scripts/jquery.min.js',
        function () {
            loadScript('../Scripts/global.js',
                function () {
                    loadScript('../Scripts/sweetalert2@8.js',
                        function () {
                            loadScript('../Scripts/popper.min.js',
                                function () {
                                    loadScript('../Scripts/bootstrap.min.js',
                                        function () {
                                            loadScript('../Scripts/perfect-scrollbar.jquery.min.js',
                                                function () {
                                                    loadScript('../Scripts/chartjs.min.js',
                                                        function () {
                                                            loadScript('../Scripts/bootstrap-notify.js',
                                                                function () {
                                                                    loadScript('../Scripts/paper-dashboard.min.js?v=2.0.0',
                                                                        function () {
                                                                            loadScript('../Scripts/demo.js',
                                                                                function () {
                                                                                    loadScript('../Scripts/main.js',
                                                                                        function () {
                                                                                            loadScript('../Scripts/datatables.min.js',
                                                                                                function () {
                                                                                                    loadScript('../Scripts/BancoPreguntas.js');
                                                                                                })
                                                                                        })
                                                                                })
                                                                        })
                                                                })
                                                        })
                                                })
                                        })
                                })
                        })

                })
        })
});