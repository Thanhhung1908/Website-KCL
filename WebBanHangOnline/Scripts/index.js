// $(document).ready(function () {

//   $('#menu').click(function () {
//     $(this).toggleClass('fa-times');
//     $('.navbar').toggleClass('nav-toggle');
//   });

//   $(window).on('load scroll', function () {

//     $('#menu').removeClass('fa-times');
//     $('.navbar').removeClass('nav-toggle');

//     if ($(window).scrollTop() > 0) {
//       $('header').addClass('sticky');
//     } else {
//       $('header').removeClass('sticky');
//     }

//     if ($(window).scrollTop() > 0) {
//       $('.scroll-top').show();
//     } else {
//       $('.scroll-top').hide();
//     }

//     // scroll spy 
//     $('section').each(function () {
//       let top = $(window).scrollTop();
//       let offset = $(this).offset().top - 200;
//       let id = $(this).attr('id');
//       let height = $(this).height();

//       if (top > offset && top < offset + height) {
//         $('.navbar a').removeClass('active');
//         $('.navbar').find(`[href="#${id}"]`).addClass('active');
//       }
//     });
//   });

//   // smooth scrolling 
//   $('a[href*="#"]').on('click', function (e) {
//     $('html, body').animate({
//       scrollTop: $($(this).attr('href')).offset().top,
//     },
//       500,
//       'linear'
//     );
//   });
// });





$(window).on('load scroll', function () {

  if ($(window).scrollTop() > 0) {
    $('header').addClass('sticky');
  } else {
    $('header').removeClass('sticky');
  }

});


// Back to top
let mybutton = document.getElementById("btn-back-to-top");

window.onscroll = function () {
  scrollFunction();
};

function scrollFunction() {
  if (
    document.body.scrollTop > 20 ||
    document.documentElement.scrollTop > 20
  ) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }

}
mybutton.addEventListener("click", backToTop);

function backToTop() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}


//// slider News
//let slideIndex = 1;
//showSlides(slideIndex);

//function plusSlides(n) {
//  showSlides(slideIndex += n);
//}

//function currentSlide(n) {
//  showSlides(slideIndex = n);
//}

//function showSlides(n) {
//  let i;
//  let slides = document.getElementsByClassName("mySlides");
//  let dots = document.getElementsByClassName("dot");
//  if (n > slides.length) { slideIndex = 1 }
//  if (n < 1) { slideIndex = slides.length }
//  for (i = 0; i < slides.length; i++) {
//    slides[i].style.display = "none";
//  }
//  for (i = 0; i < dots.length; i++) {
//    dots[i].class = dots[i].class.replace(" active", "");
//  }
//  slides[slideIndex - 1].style.display = "block";
//}
















