
removeItem = (productId) => {
    let cart = JSON.parse(localStorage.getItem("cart")) || [];
    const deleteProductIndex = cart.findIndex(p => p.productId == productId);
    if (cart[deleteProductIndex].count > 1) {
        cart[deleteProductIndex].count--;
    }
    else {

        const newCart = cart.filter(p => productId != p.productId);
        cart = newCart;
    }
    localStorage.setItem('cart', JSON.stringify(cart));

    drawOrderProducts();

}



drawOrderProducts = () => {
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    document.getElementsByTagName("tbody")[0].innerHTML = ''
    var countProducts = 0;
    var sumPrice = 0;

    cart.map((p, i) => {
        const temp = document.getElementById("temp-row");
        const clone = temp.content.cloneNode(true);
        clone.querySelector("tr").id = "prod" + p.productId;
        clone.querySelector('img').src = `/img/${p.img}`;
        clone.querySelector(".descriptionColumn").innerText = p.productName;
        clone.querySelector(".descriptionColumn").innerText = p.count;
        clone.querySelector(".price").innerText = p.price * p.count;
        clone.querySelector(".expandoHeight").addEventListener('click', () => {
            removeItem(p.productId);
        });
        document.querySelector("tbody").appendChild(clone);
        countProducts += p.count;
        sumPrice += p.price * p.count;
    })
    document.querySelector("#itemCount").innerText = countProducts;
    document.querySelector("#totalAmount").innerText = sumPrice;
}


placeOrder = async () => {

    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    if (cart.length == 0) return;
    const orderDate = (new Date()).toISOString();
    const orderSum = cart.reduce((accumulator, prod) => {
        return accumulator + prod.price * prod.count;
    }, 0);
    const user = JSON.parse(localStorage.getItem("user"));
    if (!user) { alert("for shopping you need to login first!"); window.location.href = "../home.html"; return; }
    const orderItems = cart.map(p => { return { productId: p.productId } })
    const response = await fetch("https://localhost:7061/api/Order", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ orderDate, orderSum, userId: user.userId, orderItems })
    })
    const data = await response.json();
    if (response.ok) {
        localStorage.setItem("cart", null);
        drawOrderProducts();
        alert(`Order ${data.orderId} added successfully`);
    };


}

window.onload = () => { drawOrderProducts() };