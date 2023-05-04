
window.onload = () => {
    const cart = JSON.parse(sessionStorage.getItem("cart")) || [];
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
        clone.querySelector(".expandoHeight").onclick = () => { removeItem(p.productId) }
        document.querySelector("tbody").appendChild(clone);
        countProducts += p.count;
        sumPrice += p.price * p.count;
    })
    document.querySelector("#itemCount").innerText = countProducts;
    document.querySelector("#totalAmount").innerText = sumPrice;
}

removeItem = (id) => {
    let deleteProductIndex=-1;
    const cart = JSON.parse(sessionStorage.getItem("cart"));
    cart.map((p,i) =>
    {
        if (p.productId == id)
        {
            if (p.count > 1)
            {
                p.count -= 1;
            }
            else
            {
                deleteProductIndex = i;
            }
        }
    })
    if (deleteProductIndex>-1)
    {
        cart[deleteProductIndex] = null;
    }
    sessionStorage.setItem("cart", JSON.stringify(updatedCart));
    document.querySelector("tbody").removeChild(document.querySelector("tbody").querySelector(`#prod${id}`));
    
    //השורות הבאות עובדות באיחור
    document.querySelector("#itemCount").innerText = cart.reduce((accumulator, prod) => {
        return accumulator + prod.count;
    }, 0);
    document.querySelector("#totalAmount").innerText = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0);
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