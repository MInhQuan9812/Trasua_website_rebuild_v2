
let index = 0;
let items = document.querySelectorAll(".item-panel");

function tablist1() {
    
    let transition = document.querySelectorAll(".item-panel.t1");
    console.log(transition);
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);

    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[0].classList.add('active');
}
function tablist2() {

    let transition = document.querySelectorAll(".item-panel.t2");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[1].classList.add('active');
}

function tablist3() {

    let transition = document.querySelectorAll(".item-panel.t3");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[2].classList.add('active');
}
function tablist4() {

    let transition = document.querySelectorAll(".item-panel.t4");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[3].classList.add('active');
}

function tablist5() {

    let transition = document.querySelectorAll(".item-panel.t5");
    console.log(transition);
    // current_Trangchu[index].classList.remove("initial");
    for (let i = 0; i < items.length; i++) {
        items[i].classList.remove("active");
    }
    transition[index].classList.add("active");
    console.log(items);
    let btn = document.querySelectorAll(".btn");
    for (var i = 0; i < btn.length; i++) {
        btn[i].classList.remove("active");
    }
    btn[4].classList.add('active');
}


/*Hold navbar when scroll down */
var body = document.getElementsByTagName("body")[0];
var navigation = document.getElementById("navigation");

window.addEventListener("scroll", function (evt) {
    if (body.scrollTop > navigation.getBoundingClientRect().bottom) {
        // when the scroll's y is bigger than the nav's y set class to fixednav
        navigation.className = "fixednav"
    } else { // Overwise set the class to staticnav
        navigation.className = "staticnav"
    }
});

//back-to-toplet mybutton = document.getElementById("myBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}