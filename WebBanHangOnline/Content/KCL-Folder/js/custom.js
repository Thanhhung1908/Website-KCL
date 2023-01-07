
  (function ($) {
  
    "use strict";
      
    })(window.jQuery);
  
    $(document).ready(function() {
      $("#slidemain-slide").owlCarousel({
        loop: true,
          margin: 0,
          items: 1,
          dots: true,
          smartSpeed: 1000,
          autoplay: true,
          autoplayTimeout: 5000,
        //   autoplayHoverPause:true,
        navText: ["<i class='fa fa-chevron-left' aria-hidden='true'></i>","<i class='fa fa-chevron-right' aria-hidden='true'></i>"],
          responsive: {
              0: {
                  nav: false,
                  items:1
              },
              768: {
                  nav: true,
                  items:1
              }
          }
      });
      $("#owl-service").owlCarousel({
        loop: true,
          margin: 0,
          items: 3,
          dots: false,
          smartSpeed: 1000,
          autoplay: true,
          autoplayTimeout: 7000,
          autoplayHoverPause:false,
          navText: ["<i class='fa fa-chevron-left' aria-hidden='true'></i>","<i class='fa fa-chevron-right' aria-hidden='true'></i>"],
          responsive: {
              0: {
                  nav: false,
                  items:1
              },
              768: {
                  nav: true,
                  items:2
              },
              1192: {
                nav: true,
                items:3
              }
          }
      });
      $("#owl-sp").owlCarousel({
        loop: true,
          margin: 0,
          items: 4,
          dots: false,
          smartSpeed: 1000,
          autoplay: true,
          autoplayTimeout: 5000,
          autoplayHoverPause:true,
          navText: ["<i class='fa fa-chevron-left' aria-hidden='true'></i>","<i class='fa fa-chevron-right' aria-hidden='true'></i>"],
          responsive: {
              0: {
                  nav: false,
                  items:1
              },
              768: {
                  nav: true,
                  items:2
              },
              1192: {
                nav: true,
                items:4
              },
              1300: {
                nav: true,
                items:4
              }
          }
      });
      
      // $("#owl-business").owlCarousel({
      //   loop: true,
      //     margin: 0,
      //     items: 1,
      //     dots: true,
      //     smartSpeed: 1000,
      //     autoplay: true,
      //     autoplayTimeout: 1000,
      //     autoplayHoverPause:true,
      //     navText: ["<i class='fa fa-chevron-left' aria-hidden='true'></i>","<i class='fa fa-chevron-right' aria-hidden='true'></i>"],
      //     responsive: {
      //         0: {
      //             nav: false,
      //             items:1
      //         },
      //         768: {
      //             nav: true,
      //             items:1
      //         }
      //     }
      // });
    });
  

  
  