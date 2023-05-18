
const uri = 'api/User';


async function updateUser() {

    const userDetailsUpdate = {
        email: document.getElementById('updateEmail').value,
        password: document.getElementById('updatePassword').value,
        firstname: document.getElementById('updateFirstName').value,
        lastname: document.getElementById('updateLastName').value
    };
    console.log(userDetailsUpdate);
   
    const id = JSON.parse(localStorage.user).userId;
    const user = await fetch(`https://localhost:7061/api/User/${id}`, {
        method: 'PUT',
        headers:{
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userDetailsUpdate)
    })
        .catch(error => console.error('Unable to add user.', error));
    if (user.ok) {
        alert("update succsessfuly");
    }
    await (response => response.json())
}

function getNameAndDetailsForUpdate() {
    const object = JSON.parse(localStorage.user);
    console.log(object);
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
    console.log(loginDetails);
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
        alert("logged in successfully");
        document.location.href = '../page/UserDetails.html';
    }
}

async function changeStengthPassword() {
   
    const password = document.getElementById('password').value;
    console.log(password)

    const chekPassword = await fetch('api/Password', {
        method: 'POST',
        headers: {
            //'Accept': 'application/json',
            'Content-Type': 'application/json' 
            //charset=utf - 8'
        },
        body: JSON.stringify(password)
    })
      .catch (error => console.error('Unable to login.', error));
    if (!chekPassword.ok)
    {
        const data = await chekPassword.json();
        console.log(data);
        alert
        //throw new Error("Error 404");
    }
    else {
        const data = await chekPassword.json();
       // console.log(data);
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
     console.log(userDetails);

     const chekPassword = await fetch('api/Password', {
         method: 'POST',
         headers: {
             //'Accept': 'application/json',
             'Content-Type': 'application/json'
             //charset=utf - 8'
         },
         body: JSON.stringify(userDetails.password)
     })
         .catch (error => console.error('Unable to login.', error));
     if (chekPassword.ok) {
         const data = await chekPassword.json();
         if (data < 1) { 
             console.log("pass",data)
                 alert("Password isn't srong, you can't register");
             }}
     
    

     const user = await fetch(uri,{
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userDetails)
      })
         .catch(error => console.error('Unable to add user.', error));
    
       
         if (user.ok) {
             const myUser = await user.json();
             console.log(myUser);
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
