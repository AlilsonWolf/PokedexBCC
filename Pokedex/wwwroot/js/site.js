function filter(type){
    let cards, i;
    let count = 0;
    cards = document.getElementsByClassName("card");
    buttons = document.getElementsByClassName("btn-filter");
    for (i = 0; i <cards.length; i++){
        cards[i].parentElement.style.display ='none';
        if 
            (cards[i].classList.contains(type) || type === "all") {
            cards[i].parentElement.style.display = 'block';
            count += 1;
            }
        }
    }
    for (i = 0; i < buttons.length; i++) {
        if (buttons[i].id == `btn-${type}`) {
            buttons[i].classList.remove("btn-sm");
            buttons[i].classList.add("btn-md");
        }
        else {
            buttons[i].classList.remove("btn-md");
            buttons[i].classList.add("btn-sm");
        }
    };
    if (type === "all"){
        document.getElementById("btn-all").classList.remove("btn-sm");
        document.getElementById("btn-all").classList.add("btn-md");

    };
    if (count == 0)
    document.getElementById("zeroPokemon").classList.remove("d-none");
    else 
    document.getElementById("zeroPokemon").classList.add("d-none");


