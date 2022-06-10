const btn1 = document.querySelector("#btn1");
const btn2 = document.querySelector("#btn2");

async function getUsersLastLoan() {
  const options = {
    method: "GET",
  };

  const res = await fetch(
    "http://localhost:5150/api/usuario/lastPrestamo",
    options
  );

  const json = await res.json();

  var col = [];
  for (var i = 0; i < json.length; i++) {
    for (var key in json[i]) {
      if (col.indexOf(key) === -1) {
        col.push(key);
      }
    }
  }
  //   const json = str === "" ? {} : JSON.parse(str);
  let table = document.createElement("table");
  for (let i = 0; i < json.length; i++) {
    let tr = table.insertRow(-1);
    for (var j = 0; j < col.length; j++) {
      var tabCell = tr.insertCell(-1);
      tabCell.innerHTML = json[i][col[j]];
    }
  }

  var divContainer = document.getElementById("showData");
  divContainer.innerHTML = "";
  divContainer.appendChild(table);
}

async function getUsersMoney() {
  const options = {
    method: "GET",
  };

  const res = await fetch(
    "http://localhost:5150/api/usuario/notEnoughMoney",
    options
  );

  const json = await res.json();

  var col = [];
  for (var i = 0; i < json.length; i++) {
    for (var key in json[i]) {
      if (col.indexOf(key) === -1) {
        col.push(key);
      }
    }
  }
  //   const json = str === "" ? {} : JSON.parse(str);
  let table = document.createElement("table");
  for (let i = 0; i < json.length; i++) {
    let tr = table.insertRow(-1);
    for (var j = 0; j < col.length; j++) {
      var tabCell = tr.insertCell(-1);
      tabCell.innerHTML = json[i][col[j]];
    }
  }

  var divContainer = document.getElementById("showData2");
  divContainer.innerHTML = "";
  divContainer.appendChild(table);
}

btn1.addEventListener("click", getUsersLastLoan);
btn2.addEventListener("click", getUsersMoney);
