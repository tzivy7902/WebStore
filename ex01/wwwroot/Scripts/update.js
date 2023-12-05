
const user1 = sessionStorage.getItem("user")

const jsonUser = JSON.parse(user1)
console.log(jsonUser)
const loadPage = () => {
    const jsonUser = JSON.parse(user1)
    welcome.innerHTML = `hello to ${jsonUser.email}`
    const userNameUpdate = document.getElementById("userNameUpdate")
    userNameUpdate.value = jsonUser.email
    const passwordUpdate = document.getElementById("passwordUpdate")
    passwordUpdate.value = jsonUser.password

    const firstNameUpdate = document.getElementById("firstNameUpdate")
    firstNameUpdate.value = jsonUser.firstName;

    const lastNameUpdate = document.getElementById("lastNameUpdate")
    lastNameUpdate.value = jsonUser.lastName
}



const update = async () => {
    const userId = jsonUser.userId
    const email = document.getElementById("userNameUpdate").value
    const password = document.getElementById("passwordUpdate").value
    const firstName = document.getElementById("firstNameUpdate").value
    const lastName = document.getElementById("lastNameUpdate").value
    const User = { userId, email, password, firstName, lastName }
    try {
        const url = 'api/user' + "/" + userId
        const res = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(User)

        });
        window.location.href = "Products.html"
        const dataPost = await res.json();
    }
    catch (er) {
        console.log(er);
    }


}

