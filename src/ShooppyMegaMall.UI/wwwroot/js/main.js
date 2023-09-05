(function ($) {
 "use strict";
$(function(){
/*--------------------------------
 mobile menu tab
---------------------------------- */
    jQuery('nav#dropdown').meanmenu();  
/*--------------------------------
 Active tab
---------------------------------- */
    $('#tabs').tab();
/*--------------------------------
 Active tab grid list
---------------------------------- */
    $('#gridlist').tab();
/*--------------------------------
 Active tab grid list
---------------------------------- */
    $('#viewproduct').tab();
/*--------------------------------
 Active single tabs
---------------------------------- */
    $('#single-tabs').tab();
/*--------------------------------
 scrollUp
---------------------------------- */    
    $(window).scroll(function(){
      if ($(this).scrollTop() > 250) {
       $('.bstore-scrollertop').fadeIn();
      } else {
       $('.bstore-scrollertop').fadeOut();
      }
    });
    //Click event to scroll to top
    $('.bstore-scrollertop').on( "click", function(){
    $('html, body').animate({scrollTop : 0},800);
    return false;
    });   
/*--------------------------------
 owlCarousel
---------------------------------- */
    var owl = $(".carosel-product,.carosel-product1,.carosel-product2,.carosel-product3,.carosel-product4");
      owl.owlCarousel({
      nav:true,
      slideSpeed : 1000,
      dots : false,
      addClassActive : true,
      lazyLoad : true,
      margin: 30,
      items :4,
      navText : ['<i class="icon-left-open"><i class="fa fa-angle-left"></i></i>','<i class="icon-right-open"><i class="fa fa-angle-right"></i></i>'],
      responsive: {
        0: {
            items: 1
        },
        576: {
            items: 2
        },
        768: {
            items: 2
        },
        992: {
            items: 3
        },
        1200: {
            items: 4
        }
      }
  });
/*--------------------------------
 owlCarousel5
---------------------------------- */
    var owl = $(".carosel-product5");
      owl.owlCarousel({
      nav:true,
      slideSpeed : 1000,
      dots : false,
      addClassActive : true,
      lazyLoad : true,
      margin: 30,
      items :5,
      navText : ['<i class="icon-left-open"><i class="fa fa-angle-left"></i></i>','<i class="icon-right-open"><i class="fa fa-angle-right"></i></i>'],
      responsive: {
        0: {
            items: 2
        },
        576: {
            items: 2
        },
        768: {
            items: 3
        },
        992: {
            items: 4
        },
        1200: {
            items: 5
        }
      }
  });
/*--------------------------------
 pos logo slide
---------------------------------- */
    var owl = $(".pos-logo-slide");
      owl.owlCarousel({
      addClassActive : true,
      autoPlay:false,
      dots : false,
      items :6,
      margin: 30,
      responsive: {
        0: {
            items: 2
        },
        576: {
            items: 3
        },
        768: {
            items: 4
        },
        992: {
            items: 6
        }
      }
    });       
/*--------------------------------
 owlCarousel5
---------------------------------- */
    var owl = $(".carosel-product6,.carosel-product7");
      owl.owlCarousel({
      nav:true,
      slideSpeed : 1000,
      dots : false,
      addClassActive : true,
      lazyLoad : true,
      items :1,
      navText : ['<i class="icon-left-open"><i class="fa fa-angle-left"></i></i>','<i class="icon-right-open"><i class="fa fa-angle-right"></i></i>']
  });
/*--------------------------------
 owlCarousel5
---------------------------------- */
      var owl = $(".carosel-product8");
      owl.owlCarousel({
      nav:true,
      slideSpeed : 1000,
      dots : false,
      items :2,
      navText : ['<i class="icon-left-open"><i class="fa fa-angle-left"></i></i>','<i class="icon-right-open"><i class="fa fa-angle-right"></i></i>'],
      responsive: {
        0: {
            items: 1
        },
        768: {
            items: 2
        }
      }
  });
/*--------------------------------
 product-view
---------------------------------- */
    var owl = $(".product-view");
      owl.owlCarousel({
      nav:true,
      loop: true,
      slideSpeed : 1000,
      dots : false,
      items :4,
      margin:10,
      navText : ['<i class="icon-left-open"><i class="fa fa-angle-left"></i></i>','<i class="icon-right-open"><i class="fa fa-angle-right"></i></i>'],
    });
    /*--------------------------
    tab active
    ---------------------------- */
	var ProductDetailsSmall = $('.product-view a');
    ProductDetailsSmall.on('click', function(e) {
        e.preventDefault();
        var $href = $(this).attr('href');
        ProductDetailsSmall.removeClass('active');
        $(this).addClass('active');
        $('.product-details-large .tab-pane').removeClass('active');
        $('.product-details-large ' + $href).addClass('active');
    })
    
    
    
/*--------------------------------
 single-pro-sidebar
---------------------------------- */
    var owl = $(".single-pro-sidebar");
      owl.owlCarousel({
      nav:true,
      slideSpeed : 1000,
      dots : false,
      items :1,
      navText : ['<i class="icon-left-open fa fa-angle-left"></i>','<i class="icon-right-open fa fa-angle-right"></i>']
  });
/*--------------------------------
 Accessories-active
---------------------------------- */
    var owl = $(".Accessories-active");
      owl.owlCarousel({
      nav:true,
      slideSpeed : 1000,
      dots : false,
      items :6,
      margin: 30,
      navText : ['<i class="icon-left-open fa fa-angle-left"></i>','<i class="icon-right-open fa fa-angle-right"></i>'],
      responsive: {
        0: {
            items: 1
        },
        768: {
            items: 3
        },
        992: {
            items: 5
        },
        1200: {
            items: 6
        }
      }
  });
/*--------------------------------
 about-su-active
---------------------------------- */
    $(".about-us-slide").owlCarousel({
      autoPlay:6000,
      paginationSpeed : 10000,
      dots : false,
      items : 1,
      transitionStyle : "goDown"
    }); 

/*--------------------------------
 about-su-active
---------------------------------- */
    $(".about-us-testimonial").owlCarousel({
      autoPlay:3000,
      paginationSpeed : 3000,
      dots : true,
      items : 1,
      transitionStyle : "goDown",
        
    });     
/*---------------------
 countdown
--------------------- */
    $('[data-countdown]').each(function() {
      var $this = $(this), finalDate = $(this).data('countdown');
      $this.countdown(finalDate, function(event) {
      $this.html(event.strftime('<span class="cdown days"><span class="time-count">%-D</span> <p>Days</p></span> <span class="cdown hour"><span class="time-count">%-H</span> <p>Hour</p></span> <span class="cdown minutes"><span class="time-count">%M</span> <p>Min</p></span> <span class="cdown second"> <span><span class="time-count">%S</span> <p>Sec</p></span>'));
      });
    });            
/*--------------------------------
 owlCarousel5
---------------------------------- */
    $('.fancybox').fancybox();     
/*--------------------------------
 about accordion
---------------------------------- */
    function toggleChevron(e) {
        $(e.target)
            .prev('.panel-heading')
            .find("i.indicator")
            .toggleClass('fa-chevron-down fa-chevron-up');
    }
    $('#accordion').on('hidden.bs.collapse', toggleChevron);
    $('#accordion').on('shown.bs.collapse', toggleChevron);
});
         
})(jQuery);
