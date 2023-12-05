const register = async () => {
    if (!validateUsername() || !validateEmail() || checkCode()) {
    return
   
        }
        
    }

   
  
    const email = document.getElementById("emailRegister").value
    const password = document.getElementById("passwordRegister").value
    const firstName = document.getElementById("firstName").value
    const lastName = document.getElementById("lastName").value
    const user = { email, password, firstName, lastName };
    try {
        const res = await fetch('api/User', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
            
        });
        const dataPost = await res.json();
        alert(dataPost.username +"your registeration is successful")
    }
    catch (er) {
        console.log(er.message)
    }
}
var users;
const login = async () => {


        const Email = document.getElementById("userNameLogin").value
        const password = document.getElementById("passwordLogin").value
        const user = {
            Email, password
        }
        const url = 'api/User/login'
        const res = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
        });
        if (!res.ok) {
            throw new Error("eror!!!")
        }
        else {
            var data = await res.json();
            sessionStorage.setItem("user", JSON.stringify(data))
            window.location.href="./Products.html"

        }
   

}
const checkCode = async () => {
    var strength = {
        0: "Worst",
        1: "Bad",
        2: "Weak",
        3: "Good",
        4: "Strong"
    }

    const meter = document.getElementById('password-strength-meter');
    const text = document.getElementById('password-strength-text');
  
    const Code = document.getElementById("passwordRegister").value;
    try {
        const res = await fetch('api/User/check', {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(Code)
        })
        if (!res.ok)
            throw new Error("error in adding your details to our site")

        const data = await res.json();

        if (data <= 2) {
            alert("your password is weak!! try again")
            return false;
        }
        meter.value = data;
        return true;

        if (Code !== "") {
            text.innerHTML = "Strength: " + strength[data.score];
        } else {
            text.innerHTML = "";
        }
    }
    catch(er) {
        console.log(er)
    }
}


function validateUsername() {

    var usernameInput = document.getElementById("firstName");
 
    var username = usernameInput.value;
    var usernameLabel = document.getElementById("usernameLabel");


    if (username.length >= 10) {
        usernameInput.classList.add("invalid-input");
        usernameLabel.textContent = "user name is so long";
        return false;
    } else {
        usernameLabel.textContent = "";
        return true;
    }
}




function validateEmail() {
    var emailInput = document.getElementById("emailRegister");
    var emailLabel = document.getElementById("emailLabel");
    var email = emailInput.value;

    var emailRegex = /^[^\s@]+@[^\s@]+\./;

    if (!emailRegex.test(email)) {
        emailInput.classList.add("invalid-input");
        emailLabel.textContent = "email adress is not valid";

        return false;
    } else {
         emailLabel.textContent = "";
        emailInput.classList.remove("invalid-input");
        return true;
    }
}