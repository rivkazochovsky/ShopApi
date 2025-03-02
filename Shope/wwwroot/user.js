const xx=addEventListener("load", async () => {
    if (sessionStorage.getItem("userId")) {
        const responsePut = await fetch(`api/user/${sessionStorage.getItem('userId')}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

            const dataPost = await responsePut.json();
            document.getElementById("lastname").value = dataPost.lastName;
            document.getElementById("firstname").value = dataPost.firstName;
            document.getElementById("username").value = dataPost.userName;
      
    }
})

const getAllDetailsFromFormForRegister = () => {
    const UserName = document.getElementById("username").value;
    const Password = document.querySelector("#password").value;
    const FirstName = document.querySelector("#firstname").value;
    const LastName = document.querySelector("#lastname").value;
    if (!UserName || !Password || !FirstName || !LastName) {
        alert("all fields are required");
    } else {
        return { UserName, Password, FirstName, LastName };
    }
};

const register = async () => {
    const newUser = getAllDetailsFromFormForRegister();
    const responsePost = await fetch('api/user', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });

    if (responsePost.ok) {
        const dataPost = await responsePost.json();
        console.log('POST Data:', dataPost);
        alert(`hello ${dataPost.firstName}`);
    } else {
        const errorResponse = await responsePost.json();
        for (const key in errorResponse.errors) {
            if (errorResponse.errors.hasOwnProperty(key)) {
                const errors = errorResponse.errors[key];
                errors.forEach(error => {
                    alert(error);
                });
            }
        }
    }
};

const checkPassword = async () => {
    const password = document.querySelector("#password");
    const progress = document.querySelector("#progress");

    const responsePost = await fetch(`api/user/password/?password=${password.value}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const dataPost = await responsePost.json();
    console.log(dataPost);
    progress.value = dataPost;
};

const getDetailsFromFormForLogIn = () => {
    const UserName = document.getElementById("username2").value;
    const Password = document.querySelector("#password2").value;

    if (!UserName || !Password) {
        alert("all fields are required");
    } else {
        return { UserName, Password };
    }
};

const login = async () => {
    console.log("login");
    const newUser = getDetailsFromFormForLogIn();
    try {
        const responsePost = await fetch(`api/user/login/?UserName=${newUser.UserName}&Password=${newUser.Password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        });
        if (!responsePost.ok) {
            throw new Error(`HTTP error status: ${responsePost.status}`);
        }
        if (responsePost.status == 204) {
            alert("user not found");
        } else {
            const dataPost = await responsePost.json();
            sessionStorage.setItem("userId", dataPost.userId);
            console.log(dataPost);
            alert(`hello ${dataPost.firstName}`);
            window.location.href = "ShoppingBag.html";
        }
    } catch (Error) {
        console.log(Error);
    }
};

const updateUser = async () => {
    const newUser = getAllDetailsFromFormForRegister();
    const responsePut = await fetch(`api/user/${sessionStorage.getItem('userId')}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    });
    if (responsePut.ok) {
        alert("update successful");
    } else {
        alert("update not successful");
    }
};
