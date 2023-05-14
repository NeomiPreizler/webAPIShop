
removeItem = (productId) => {
    console.log("removeItem");
    const cart = JSON.parse(sessionStorage.getItem("cart")) || [];
    const deleteProductIndex = cart.findIndex(p => p.productId == productId);
    if (cart[deleteProductIndex].count > 1) {
        cart[deleteProductIndex].count--;
    }
    else {
        cart = cart.filter(p => productId != p.productId);
    }
    sessionStorage.setItem('cart', JSON.stringify(cart));

    drawOrderProducts();


}



drawOrderProducts = () => {
    const cart = JSON.parse(sessionStorage.getItem("cart")) || [];
    document.getElementsByTagName("tbody")[0].innerHTML = ''
    var countProducts = 0;
    var sumPrice = 0;
    //console.log(cart);
    cart.map((p, i) => {
        console.log(p,i);
        const temp = document.getElementById("temp-row");
        const clone = temp.content.cloneNode(true);
        clone.querySelector("tr").id = "prod" + p.productId;
        clone.querySelector('img').src = `/img/${p.img}`;
        clone.querySelector(".descriptionColumn").innerText = p.productName;
        clone.querySelector(".descriptionColumn").innerText = p.count;
        clone.querySelector(".price").innerText = p.price;
        //clone.querySelector(".expandoHeight").onclick = () => { removeItem(p.productId) }
        clone.querySelector(".expandoHeight").addEventListener('click', () => {
            removeItem(p.productId);
        });
        console.log(p)
        document.querySelector("tbody").appendChild(clone);
        countProducts += p.count;
        sumPrice += p.price * p.count;
    })
    document.querySelector("#itemCount").innerText = countProducts;
    document.querySelector("#totalAmount").innerText = sumPrice;
}


placeOrder = async () => {
    const cart = JSON.parse(sessionStorage.getItem("cart")) || [];
    if (cart.length == 0) return;
    const orderDate = (new Date()).toISOString();
    const orderSum = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0);
    const user = JSON.parse(sessionStorage.getItem("user"));
    if (!user) { alert("please sign in!"); return; }
    const orderItems = cart.map(p => { return { productId: p.productId/*, quantity: p.count*/ } })
    const response = await fetch("https://localhost:7061/api/Order", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ orderDate, orderSum, userId: user.userId, orderItems })
    })
    console.log(response.status);
    if (response.ok) sessionStorage.setItem("cart", null);
}


/*document.addEventListener("load", atLoad());*/
window.onload = () => { drawOrderProducts() };