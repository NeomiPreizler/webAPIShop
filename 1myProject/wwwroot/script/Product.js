
/*const uri = 'api/Product';*/
addToCart = (product) => {
    var cart = JSON.parse(localStorage.getItem("cart")) || [];
    const existingProd = cart.find(p => p.productId == product.productId);
    if (existingProd) existingProd.count += 1;
    else cart.push({ ...product, count: 1 });
    localStorage.setItem("cart", JSON.stringify(cart));
    document.querySelector("#ItemsCountText").innerText = cart.length;
}

function loadData() {
    loadProducts();
    loadCategories();
}
document.addEventListener("load",loadData())


async function loadProducts() {
    const products = await fetchProductsData()
    viewProducts(products);
}
async function fetchProductsData() {
    const products = await fetch('https://localhost:7061/api/Product', {
        method: 'GET',
        headers: {
            //'Accept': 'application/json',
            'Content-Type': 'application/json'
        }
    }).catch(error => console.error('Unable to load products.', error));

   
    const productsJson = await (products.json());
    console.log(productsJson);
    localStorage.setItem("products", JSON.stringify(productsJson));
   
    return productsJson;
}
async function viewProducts(products) {
    await products.map(product => createCard(product));
/*    cards.forEach(c => document.getElementById('PoductList').appendChild(c))*/

}
async function createCard(product) {
    //const card = createTemplate('#temp-card');
    const temp = document.querySelector('#temp-card');
    const card = temp.content.cloneNode(true);
    card.querySelector('img').src = `/img/${product.img}`;
    card.querySelector('h1').innerText = product.productName;
    card.querySelector('.price').innerText = `${product.price} ₪`;
    card.querySelector('.description').innerText = product.description;
    //card.querySelector('button').value = product.productId;
    card.querySelector('button').addEventListener("click", () =>  addToCart(product) );
    document.getElementById('PoductList').appendChild(card);
    //return card;
}
//async function createTemplate(name) {
//    const temp = document.querySelector(name);
//    const clon = temp.content.cloneNode(true);
//    return clon;
//}



async function loadCategories() {
    const categories = await fetchGetCategories();
    drawCategories(categories);
}

async function fetchGetCategories() {

    const resCategories = await fetch('https://localhost:7061/api/Category', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    if (!resCategories.ok)
        alert("ERROR caregory");
    else
        if (resCategories == 204) alert("no data");
        else {/*.catch(error => console.error('Unable to load category.', error))*/
            const jsonCategories = await (resCategories.json());
            console.log(jsonCategories);
            return jsonCategories;
        }

}
async function createTemplateCategory(category) {
    console.log(category)
    const temp = document.querySelector('#temp-category')
    const card = temp.content.cloneNode(true);
    card.querySelector('.OptionName').innerText = category.categoryName;
    //card.querySelector('.Count').innerText = category.categoryName;
    card.querySelector('.opt').value = category.categoryId;
    
    document.getElementById('categoryList').appendChild(card);
}

async function drawCategories(categories) {
    console.log(categories)
    const cards = await categories.map(category => createTemplateCategory(category));
}

filterProducts = async () => {
    var maxPrice = document.getElementById("maxPrice").value;
    var minPrice = document.getElementById("minPrice").value;

    var name = document.getElementById("nameSearch").value;
    var start = 1;
    var limit = 20;
    var direction = "ASC";
    var orderBy = "price";
    var categories = "";

    var categoryList = document.getElementsByClassName("opt");
    for (var i = 0; i < categoryList.length; i++) {
        if (categoryList[i].checked) {
            categories += `&categories=${categoryList[i].value}`;
        }
    }

    const url = `https://localhost:7061/api/Product/?nameProduct=${name}${categories}&maxPrice=${maxPrice}&minPrice=${minPrice}&start=${start}&limit=${limit}&orderBy=${orderBy}&direction=${direction}`;
    const res = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
 
    if (!res.ok)
        alert("Error! filter!");
    else if (res.status == 204) {
        alert("no data");
        return;
    }
    else {
        const data = await res.json();
        deleteItem();
        viewProducts(data);

    }

}


deleteItem = () => {
    var cards = document.getElementsByClassName("card");
    for (var i = cards.length; i > 0; i--) {
        cards[0].remove();
    }
}

