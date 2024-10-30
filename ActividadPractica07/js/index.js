/*
    Funciones del menú
*/

const $btnInicio = document.getElementById('btnInicio')

const $btnNuevo = document.getElementById('btnNuevo')

const $btnConsultar = document.getElementById('btnConsultar')

const $btnClientes = document.getElementById('btnCantidadTurnos')

const $contenido = document.getElementById('content')

$btnInicio.addEventListener("click", function() {

    $contenido.innerHTML = `<h1 class="mb-4">Bienvenido a la Actividad Práctica Número 7</h1>
                                <div class="row">
                                    <div class="col">
                                         <p>TUP -PROG II - UTN FRC </p>
                                         <img id="fondo" src="images/utn.png" alt="¡Error al cargar la imagen!">
                                    </div>
                                </div>`
})

$btnConsultar.addEventListener("click", function() {

    $contenido.innerHTML = `<h1>Consultar turnos</h1>
                            <div class="consultar">
                                <span>Aquí se mostrará el listado de turnos</span>
                                <button onclick="consultarTurnos()" class="btn btn-primary" id="btnConsultar">Consultar</button>
                            </div>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Fecha</th>
                                        <th scope="col">Hora</th>
                                        <th scope="col">Cliente</th>
                                    </tr>
                                </thead>
                                <tbody id="tbody">
                                </tbody>
                            </table>`

})

$btnNuevo.addEventListener("click", function() {

    $contenido.innerHTML = `<h1>Agregar nuevo turno</h1>
                            <form class="form" onsubmit="crearTurno(event)">
                                

                                <label class="form-label" for="fecha">Fecha</label>
                                <input class="form-control" id="fecha" type="date" required></input>

                                <label class="form-label" for="hora">Hora (Solo se admiten horas en punto o media)</label>
                                <select class="form-control" id="hora" name="hora">
                                
                                </select>

                                <label class="form-label" for="cliente">Cliente</label>
                                <input class="form-control" id="cliente" type="text" required></input>

                                <button class="btn btn-primary" type="submit">Enviar</button>
                            </form>`

    const $selectHora = document.getElementById('hora')

    for (let h = 0; h < 24; h++) {
        for (let m = 0; m < 60; m += 30) {
            const horaFormateada = `${String(h).padStart(2, '0')}:${String(m).padStart(2, '0')}`
            const option = document.createElement('option')
            option.value = horaFormateada
            option.textContent = horaFormateada
            $selectHora.appendChild(option)
        }
    }

})

$btnClientes.addEventListener("click", function(){
    $contenido.innerHTML = `<h1>Consultar cantidad de turnos por cliente</h1>
                            <div class="consultar">
                                <span>Aquí se mostrará el listado de clientes con la cantidad de turnos que tienen</span>
                                <button onclick="consultarClientes()" class="btn btn-primary" id="btnTurnos">Consultar</button>
                            </div>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">#</th>
                                        <th scope="col">Cliente</th>
                                        <th scope="col">Cantidad de turnos</th>
                                    </tr>
                                </thead>
                                <tbody id="tbodyClientes">
                                </tbody>
                            </table>`
})

/*
    Funciones de cada menú
*/






// Generar opciones de 30 minutos desde 00:00 hasta 23:30


//Consultar

let idTurno = 0

const turnos = [{id: ++idTurno, fecha: '2024-10-20', hora: '10:00', cliente: 'Gabriel'},
              {id: ++idTurno, fecha: '2024-10-21', hora: '10:00', cliente: 'Juan'},
              {id: ++idTurno, fecha: '2024-10-22', hora: '10:00', cliente: 'Pepe'}]


function consultarTurnos(){

    const $bodyTabla = document.getElementById('tbody')
    $bodyTabla.innerHTML = ``
    turnos.forEach(turno => { 
        const fila = document.createElement('tr')


        fila.innerHTML=`<tr>
                        <th scope="row">${turno.id}</th>
                        <td>${String(turno.fecha)}</td>
                        <td>${String(turno.hora)}
                        <td>${turno.cliente}</td>
                    </tr>
                    `
        $bodyTabla.appendChild(fila)
                  })     
}

//Agregar

function crearTurno(event){

    event.preventDefault()

    const $fecha = document.getElementById('fecha')
    const $hora = document.getElementById('hora')
    const $cliente = document.getElementById('cliente')

    idTurno++

    const turno = {id: idTurno, fecha: String($fecha.value), hora: String($hora.value),cliente: $cliente.value}

    const existe = turnos.some(turnoArray => 
                        turnoArray.fecha === turno.fecha &&
                        turnoArray.hora === turno.hora)

    if(!existe){
        turnos.push(turno)
        $fecha.value = ""
        hora.value = ""
        $cliente.value = ""
    }
    else{
        alert('Esa fecha y hora ya están reservadas')
    }
    

    
}

function consultarClientes(){

    const turnosPorCliente = turnos.reduce((acc, turno) => {

    if (!acc[turno.cliente]) {
        acc[turno.cliente] = 0
    }
    acc[turno.cliente]++
    return acc
    }, {})


    const resultado = Object.keys(turnosPorCliente).map(cliente => ({
    nombre: cliente,
    cantidadTurnos: turnosPorCliente[cliente]
    }))

    const $bodyClientes = document.getElementById('tbodyClientes')

    $bodyClientes.innerHTML = ``
    let idCliente = 0

    resultado.forEach(cliente => { 
        const fila = document.createElement('tr')
        idCliente++

        fila.innerHTML=`<tr>
                        <th scope="row">${idCliente}</th>
                        <td>${cliente.nombre}</td>
                        <td>${cliente.cantidadTurnos}</td>
                    </tr>
                    `
        $bodyClientes.appendChild(fila)
                  })     
}

