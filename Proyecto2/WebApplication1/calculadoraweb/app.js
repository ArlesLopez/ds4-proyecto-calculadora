//----------------------------------------
// CONFIGURACIÓN DE LA API
//----------------------------------------
const API = "https://localhost:44343";

//----------------------------------------
// VARIABLES DE CALCULADORA
//----------------------------------------
let pantalla = document.getElementById("pantalla");
let numero1 = null;
let operador = "";

//----------------------------------------
// FUNCIONES DE LA CALCULADORA
//----------------------------------------

function agregar(num) {
    pantalla.value += num;
}

function limpiar() {
    pantalla.value = "";
    numero1 = null;
    operador = "";
}

function borrar() {
    pantalla.value = pantalla.value.slice(0, -1);
}

function operar(op) {
    if (pantalla.value === "") return;

    numero1 = parseFloat(pantalla.value);
    operador = op;
    pantalla.value = "";
}

function calcular() {
    if (pantalla.value === "" || numero1 === null) return;

    let numero2 = parseFloat(pantalla.value);
    let resultado = 0;

    switch (operador) {
        case "+": resultado = numero1 + numero2; break;
        case "-": resultado = numero1 - numero2; break;
        case "*": resultado = numero1 * numero2; break;
        case "/": resultado = numero1 / numero2; break;
    }

    pantalla.value = resultado;

    let operacionTexto =
        operador === "+" ? "Suma" :
            operador === "-" ? "Resta" :
                operador === "*" ? "Multiplicacion" :
                    "Division";

    //----------------------------------------
    // GUARDAR EN API
    //----------------------------------------
    fetch(`${API}/api/operaciones/guardar`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            Numero1: numero1,
            Numero2: numero2,
            OperacionTipo: operacionTexto,
            Resultado: resultado
        })
    })
        .then(r => r.text())
        .then(t => console.log("Guardado en BD:", t))
        .catch(err => console.error("Error guardando:", err));
}

//----------------------------------------
// HISTORIAL
//----------------------------------------
function cargarHistorial() {
    fetch(`${API}/api/operaciones/historial`)
        .then(r => r.json())
        .then(data => {
            let tabla = `
                <tr>
                    <th>ID</th>
                    <th>Operación</th>
                    <th>Número 1</th>
                    <th>Número 2</th>
                    <th>Resultado</th>
                    <th>Fecha</th>
                </tr>
            `;

            data.forEach(x => {
                tabla += `
                <tr>
                    <td>${x.Id}</td>
                    <td>${x.OperacionTipo}</td>
                    <td>${x.Numero1}</td>
                    <td>${x.Numero2}</td>
                    <td>${x.Resultado}</td>
                    <td>${x.Fecha}</td>
                </tr>
                `;
            });

            document.getElementById("historial").innerHTML = tabla;
        })
        .catch(err => console.error("Error cargando historial:", err));
}
