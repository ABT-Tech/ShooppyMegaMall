// Avoid `console` errors in browsers that lack a console.
(function() {
    var method;
    var noop = function () {};
    var methods = [
        'assert', 'clear', 'count', 'debug', 'dir', 'dirxml', 'error',
        'exception', 'group', 'groupCollapsed', 'groupEnd', 'info', 'log',
        'markTimeline', 'profile', 'profileEnd', 'table', 'time', 'timeEnd',
        'timeline', 'timelineEnd', 'timeStamp', 'trace', 'warn'
    ];
    var length = methods.length;
    var console = (window.console = window.console || {});

    while (length--) {
        method = methods[length];

        // Only stub undefined methods.
        if (!console[method]) {
            console[method] = noop;
        }
    }
}());

// Place any jQuery/helper plugins in here.

        var pauseTime=5800,         // Set here Nivo Slider pauseTime
            animSpeed=500,          // Set here Nivo Slider animSpeed,
            pieWidth='100%',        // max pie width,
            autoPieCenter=true,     // Pie is centered or not (false)
            pieColor='#ccc',     // Pie color
            pieBackground='#333',   // Pie background color e.g. #A5A5A5
            pieType='radial',       // Circular or radial
            pieDiameter=32,         // Circle diameter
            pieTime=pauseTime-animSpeed-1700,
            started=2*animSpeed,
            pieML=0,
            ratio;

        function pieBar() {

            if (pieTime<100) return // Quit if no value added

            testCanvas=$('<canvas width="1px" height="1px"/>');
            $('body').append(testCanvas);
            if (!testCanvas.width()) { // Canvas not supported? radial mode instead
                pieType='radial';
                testCanvas.remove();
            };

            if (pieType=='circular') {

                NB=NBBkg=$('<canvas width='+pieDiameter+'px" height='+pieDiameter+'px"/>');

                $('.nivoSlider').append(NB);

                var ctx=NB[0].getContext('2d');

                ctx.beginPath();
                ctx.arc(pieDiameter/2,pieDiameter/2,Math.round(pieDiameter/2)-4,0,2*Math.PI);
                ctx.lineWidth=8;
                ctx.strokeStyle=pieBackground;
                ctx.stroke();

                NB.css({
                        display:'block',
                        position:'absolute',
                        opacity:0,
                        top:'30px',
                        right:'30px',
                        zIndex:9999
                    })
                .delay(started+300).animate({opacity:1},300);

                if (autoPieCenter) {
                    NB.css({
                        left:'50%',
                        marginLeft:-pieDiameter/2
                    });
                };

                pieT=setTimeout(function() {
                    ratio=0,
                    pieI=setInterval(function () {

                        var ctx=NBBkg[0].getContext('2d');
                        ctx.beginPath();
                        ctx.arc(pieDiameter/2,pieDiameter/2,Math.round(pieDiameter/2)-4,-1/2*Math.PI, ratio*2*Math.PI-1/2*Math.PI );
                        ctx.lineWidth=2;
                        ctx.strokeStyle=pieColor;
                        ctx.stroke();
                        ratio+=0.005
                        if (ratio>1.01) {
                            clearInterval(pieI);
                            NB.animate({opacity:0},300,function() {NB.remove()});
                            started=0;
                        };
                    },pieTime/200);
                },300+started);
            };

            if (pieType=='radial') {

                if (!$('.nivoBar').length) {
                    $('.nivoSlider')
                    .append('<div class="nivoBar"></div><div class="nivoBarBkg"></div>');
                    NB=$('.nivoBar')
                    .css({
                        display:'block',
                        position:'absolute',
                        width:0,
                        height:5,
                        bottom:'100%',
                        left:0,
                        background:pieColor,
                        zIndex:9999
                    });
                };

                var valPieWidth=parseInt(pieWidth,10);
                if (valPieWidth<2) {pieWidth='2%'};
                if (valPieWidth>100) {pieWidth='100%'};
                valPieWidth=parseInt(pieWidth,10);

                if (autoPieCenter) {
                    pieML=(50-valPieWidth/2)+'%';
                    NB.css({
                        marginLeft:pieML
                    });
                };

                $('.nivoBarBkg').css({
                    display:'block',
                    position:'absolute',
                    width:pieWidth,
                    height:NB.height(),
                    bottom:'100%',
                    left:0,
                    marginLeft:pieML,
                    background:pieBackground,
                    zIndex:9998
                }); 

                NB.css({opacity:1})
                .stop(1,1)
                .delay(300+started)
                .animate({width:pieWidth},pieTime,'linear')
                .delay(300)
                .animate({opacity:0},500)
                .css({width:0});

                started=0;

            };

        };

        function checkRemovePieBar() {

            if (pieType=='circular' & ratio<1.01) {
                clearTimeout(pieT);
                clearInterval(pieI);
                NB.stop(1,0).animate({opacity:0},300, function(){NB.remove()});
                started=2*animSpeed;
            };

            if (pieType=='radial' & NB.css('opacity')==1) {
                NB.stop(1,0).animate({opacity:0},300);
                started=animSpeed;
            };
        };

        $(window).load(function() {
            $('.nivoSlider').nivoSlider({
                effect:'sliceUpDownRight',
                pauseTime:pauseTime,  // Do not change (set value above)
                animSpeed:animSpeed,  // Do not change (set value above)
                pauseOnHover:false,   // Do not change this setting
                controlNav:true,
                prevText: '<i class="fa fa-angle-left"></i>',
                nextText: '<i class="fa fa-angle-right"></i>',
                afterLoad: function (){pieBar()},
                beforeChange: function (){checkRemovePieBar()},
                afterChange: function (){pieBar()}
            });
        });
