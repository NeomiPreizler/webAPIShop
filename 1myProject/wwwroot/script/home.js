
const uri = 'api/User';


async function updateUser() {

    const userDetailsUpdate = {
        email: document.getElementById('updateEmail').value,
        password: document.getElementById('updatePassword').value,
        firstname: document.getElementById('updateFirstName').value,
        lastname: document.getElementById('updateLastName').value
    };


    const id = JSON.parse(localStorage.user).userId;
    const user = await fetch(`https://localhost:7061/api/User/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userDetailsUpdate)
    })
        .catch(error => console.error('Unable to updateUser user', error));
   
    await (response => response.json())
    if (user.ok) {
        alert("update succsessfuly");
        document.location.href = '../home.html';
    }
}

function getNameAndDetailsForUpdate() {
    const object = JSON.parse(localStorage.user);
    document.getElementById('welcomeUser').innerHTML = `welcome ${object.firstName}`;
    document.getElementById('updatePassword').setAttribute('value', object.password);
    document.getElementById('updateFirstName').setAttribute('value', object.firstName);
    document.getElementById('updateLastName').setAttribute('value', object.lastName);
    document.getElementById('updateEmail').setAttribute('value', object.email);


}
async function login() {
    const loginDetails = {
        "Email": document.getElementById('loginEmail').value,
        "Password": document.getElementById('loginPassword').value,
    };
    const user = await fetch(uri + "/login", {
        method: 'POST',
        headers: {

            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginDetails)
    })

        .catch(error => console.error('Unable to login.', error));

    if (user.ok) {
        const myUser = await user.json();
        console.log(myUser);
        localStorage.setItem('user', JSON.stringify(myUser));
        document.location.href = '../page/UserDetails.html';
    }
}

async function changeStengthPassword() {

    const password = document.getElementById('password').value;

    const chekPassword = await fetch('api/Password', {
        method: 'POST',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify(password)
    })
        .catch(error => console.error('Unable to changeStengthPassword.', error));
    if (!chekPassword.ok) {
        const data = await chekPassword.json();
    }
    else {
        const data = await chekPassword.json();
        document.getElementById("score").value = data;


    }
}



async function addUser() {
    const userDetails = {
        email: document.getElementById('email').value,
        password: document.getElementById('password').value,
        firstName: document.getElementById('firstName').value,
        lastName: document.getElementById('lastName').value
    };

    const chekPassword = await fetch('api/Password', {
        method: 'POST',
        headers: {

            'Content-Type': 'application/json'

        },
        body: JSON.stringify(userDetails.password)
    })
        .catch(error => console.error('Unable to login.', error));
    if (chekPassword.ok) {
        const data = await chekPassword.json();
        if (data < 1) {
            alert("Password isn't srong, you can't register");
        }
    }



    const user = await fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userDetails)
    })
        .catch(error => console.error('Unable to chekPassword.', error));


    if (user.ok) {
        const myUser = await user.json();
        localStorage.setItem('user', JSON.stringify(myUser));
        alert("created succsessfuly");
    }
    await (response => response.json())

    document.location.href = '../page/UserDetails.html';
}

logout = () => {
    localStorage.clear();
    document.location.href = '../home.html';
}
