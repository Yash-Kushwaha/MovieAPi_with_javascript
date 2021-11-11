function RegisterUser() {
    let a = document.getElementById("register_userName").value;
    let b = document.getElementById("register_email").value;
    let c = document.getElementById("register_password").value;
    fetch(`https://localhost:44374/api/User/register`, {
        method: 'POST',
        body: JSON.stringify({ UserName: a, Gmail: b, Password: c }),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(data => console.log(data))
        .catch(err => console.log(err));
}

function LoginUser() {
    let userName = document.getElementById("login_userName").value;
    let password = document.getElementById("login_password").value;
    fetch(`https://localhost:44374/api/User/login`, {
        method: 'POST',
        body: JSON.stringify({ userName, password }),
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(res => res.json())
        .then(data => {
            localStorage.setItem("JWTToken", data.token);
            document.getElementById("register_button").style.display = "none";
            document.getElementById("login_button").style.display = "none";
            document.getElementById("logout_button").style.display = "block";
        })
        .catch(err => console.log(err));
}

function Logout() {
    localStorage.removeItem("JWTToken");
    document.getElementById("register_button").style.display = "block";
    document.getElementById("login_button").style.display = "block";
    document.getElementById("logout_button").style.display = "none";
    document.getElementById("MyMoviecards").innerHTML = "";
}

function DeleteMovie(id) {
    fetch(`https://localhost:44364/api/Movie/${id}`, {
        method: 'DELETE',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem("JWTToken")
        }
    }).then(res => MyMovies());
}


function MyMovies() {
    fetch(`https://localhost:44364/api/Movie`, {
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem("JWTToken")
        }
    })
        .then(res => res.json())
        .then(data => {
            let row = '';
            data.map(item => {
                row += `<div class="card" style="width: 18rem;">
                <img id="${item.imdbID}Poster" src="${item.poster}" class="card-img-top" alt="...">
                <div class="card-body">
                  <h5 id="${item.imdbID}_Title" class="card-title">${item.title}</h5>
                  <p id="${item.imdbID}_year" class="card-text">${item.year}</p>
                  <p id="${item.imdbID}_Type" class="card-text">${item.type}</p>
                  <p id="${item.imdbID}_imdbID" class="card-text">${item.imdbID}</p>
                  <button onclick="DeleteMovie('${item.imdbID}')">Delete</button>
                </div>
              </div><br>`
            });
            document.getElementById('MyMoviecards').innerHTML = row;
        });
}


function SearchMovie() {
    let Moviename = document.getElementById("Moviename").value;
    let Movieyear = document.getElementById("Movieyear").value;
    console.log(Moviename, Movieyear);
    fetch(`http://www.omdbapi.com/?apikey=c789de64&s=${Moviename}&y=${Movieyear}`)
        .then(res => res.json())
        .then(data => {
            let row = '';
            data.Search.map(item => {
                row += `<div class="card" style="width: 18rem;">
                <img id="${item.imdbID}_Poster" src="${item.Poster}" class="card-img-top" alt="...">
                <div class="card-body">
                  <h5 id="${item.imdbID}_Title" class="card-title">${item.Title}</h5>
                  <p id="${item.imdbID}_year" class="card-text">${item.Year}</p>
                  <p id="${item.imdbID}_Type" class="card-text">${item.Type}</p>
                  <p id="${item.imdbID}_imdbID" class="card-text">${item.imdbID}</p>
                  <button id="${item.imdbID}" onclick="AddMovie('${item.imdbID}','${item.Poster}','${item.Title}','${item.Year}','${item.Type}','${item.imdbID}')">Add</button>
                </div>
              </div>`

            });
            document.getElementById('Moviecards').innerHTML = row;
        })
        .catch(err => console.log(err));
}
function AddMovie(imdbID, Poster, Title, year, Type) {
    fetch(`https://localhost:44364/api/Movie`, {
        method: 'POST',
        body: JSON.stringify({ imdbID, Poster, Title, year, Type }),
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + localStorage.getItem("JWTToken")
        }
    }).then(res => MyMovies());
}