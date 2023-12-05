


async function filterProducts() {
  
 
    if (sessionStorage.getItem("shopingBag")) {
        cart = JSON.parse(sessionStorage.getItem("shopingBag"))
    }
    let checkedArr = [];
    const allCategoriesOptions = document.querySelectorAll(".opt");

    for (i = 0; i < allCategoriesOptions.length; i++) {
        if (allCategoriesOptions[i].checked) {
            checkedArr.push(i+1);
        }
    }

    const minPrice = document.getElementById("minPrice").value;
    const maxPrice = document.getElementById("maxPrice").value;
    const name = document.getElementById("nameSearch").value;


    var url = 'api/Product';

    if (name || minPrice || maxPrice || checkedArr) url += `?`;

    if (name) url += `&desc=${name}`;

    if (minPrice) url += `&minPrice=${minPrice}`;

    if (maxPrice) url += `&maxPrice=${maxPrice}`;
    if (checkedArr) {
        for (let i = 0; i < checkedArr.length; i++) {
            url += `&categoryIds=${checkedArr[i]}`;
        }
    }
  
    try {
        const res = await fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json"
            }
        });
        if (!res.ok) {
            throw new Error("Error in product fetch")

        }

        const products = await res.json()
  
    document.getElementById("PoductList").replaceChildren(clonProducts);
    for (let i = 1; i < products.length; i++) {
        const tmp = document.getElementById("temp-card");
        var clonProducts = tmp.content.cloneNode(true);
        clonProducts.querySelector("img").src = "./images/" + products[i].img;
        clonProducts.querySelector(".description").innerText = products[i].description;
        clonProducts.querySelector(".price").innerText = products[i].price +"$";
   
        clonProducts.querySelector("button").addEventListener('click', () => { addtoshop(products[i]) });
        document.getElementById("PoductList").appendChild(clonProducts);

        }
        return products;
      }
    catch (e) { console.log(e) }
    
   
}




async function getAllCategory() { 
    count=sessionStorage.getItem("count")
    document.getElementById("ItemsCountText").innerHTML = count;

    const res = await fetch(`api/Category`);
    const catetegoryData = await res.json();
    return catetegoryData;
}
async function drawCategory() {
    const categories = await getAllCategory();

    for (let i = 0; i < categories.length; i++) {
        const tmp = document.getElementById("temp-category");
        const clonCategories = tmp.content.cloneNode(true);
        clonCategories.querySelector("span.OptionName").innerText = categories[i].name;

        clonCategories.querySelector(".opt").value = categories[i].id;
        document.getElementById("categoryList").appendChild(clonCategories);


    }
}

var cart = [];
var count=0;
   


function addtoshop(product) {
  
        cart.push(product);
        count++;
        sessionStorage.setItem("count", JSON.stringify(count))
        document.getElementById("ItemsCountText").innerText = count;
        sessionStorage.setItem('shopingBag', JSON.stringify(cart));
    


    

}

