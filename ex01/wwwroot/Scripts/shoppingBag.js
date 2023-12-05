

var count = sessionStorage.getItem("count");
var user = JSON.parse(sessionStorage.getItem("user"))
var prod = JSON.parse(sessionStorage.getItem("shopingBag"))
var cPrice = 0;
async function drawBag() {
    const prod = JSON.parse(sessionStorage.getItem("shopingBag"))
    cPrice = 0;
    for (let i = 0; i < prod.length; i++) {
        cPrice += prod[i].price
    }
    document.getElementById('totalAmount').innerHTML = cPrice;
    document.getElementById('itemCount').innerHTML = count;
    for (let i = 0; i < prod.length; i++) {
        const tmpCatg = document.getElementById("temp-row");
        const cln = tmpCatg.content.cloneNode(true);
        cln.querySelector(".price").innerText = prod[i].price + "$";
        cln.querySelector(".image").src = "./images/" + prod[i].img;;
        cln.querySelector(".descriptionColumn").innerText = prod[i].description
        cln.querySelector(".totalColumn").addEventListener('click', () => { deleteItem(prod[i]) });
        document.getElementById("itemList").appendChild(cln);
    }
}
function pluse() {
    sessionStorage.setItem("count", count++);
    document.getElementById('itemCount').innerHTML = count;
}
function minus() {
    sessionStorage.setItem("count", count--);
    document.getElementById('itemCount').innerHTML = count;
}
function deleteItem(prodact) {
    const prod = JSON.parse(sessionStorage.getItem("shopingBag"));
    const updatedList = prod.filter(p => p.productId !== prodact.productId);
    cPrice -= prodact
    count -= 1;
    sessionStorage.setItem("count", count);
    count = count;
    sessionStorage.setItem("shopingBag", []);
    document.getElementById("itemList").innerHTML = "";

    sessionStorage.setItem("shopingBag", JSON.stringify(updatedList));
    drawBag();
}

async function placeOrder() {

    if (user) {
        const order = {
            orderDate: new Date(),
            orderSum: cPrice,
            userId: user.userId,
            orderItems: prod
        }
        try {
            const responsePost = await fetch('api/order', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            });
            if (!responsePost.ok) {
                alert(`the order didnt create`)
            }
            else {
                const newOrder = await responsePost.json();
                
                sessionStorage.setItem("shopingBag", []);
                sessionStorage.setItem("count", "0");
                count = 0;
                alert(`new oreder ${newOrder.OrderId} created!!!!!!!!`)

            }
        }
        catch (error) {
            console.log(error)
        }

    }
    else {
        window.location.href="home.html"
    }

}