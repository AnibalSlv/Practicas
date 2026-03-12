"use strict";
// Recuerda usar npx tsc nombre_del_archivo.ts
// El npx es porque lo hago local lo de instalar el TS
// El tsc es el comando para TS
// Y lo que hace el comando es pasar el archivo de TS a JS para que los navegadores lo corran
Object.defineProperty(exports, "__esModule", { value: true });
// Para evitar tener que escribir el comando por cada cambio que hagas en TS para que se transforme en un JS y eso utiliza
// npx tsc nombre_del_archivo.ts -w
// El -w quiere decir watch es decir inicia el modo observador, esto transforma automaticamente el archivo de TS en uno JS
// de manera automatica
// TODO: Esto es importante y es que para inicializar un proyecto con TS es npx tsc -init
// Esto nos agrega una carpeta tsconfig.json y nos agrega funciones nuevas que podemos utilizar
// TODO: npx tsc -w Es lo mismo que el modo observador mencionado anteriormente pero de manera global
// Esto solo se puede hacer si inicilizaste el proyecto como un TS (En el primer TODO se muestra)
console.log('Buenas noches mundos');
function string() {
    const text1 = "texto nuevo";
    const text2 = '$"" o fString';
    const text3 = `Esto es lo equivalente a ${text2}`;
}
function number() {
    const number1 = 2;
    const number2 = 2.5e-2; // 2.5 * 10^-2 = 0.015
    const number3 = 0xA; // Valor hexadecimal (base 16)
    const number4 = 0o12; // Valor decimal (base 8)
    const number5 = 0b1010; // Valor binario (base 2)
}
function others() {
    const boolTrue = true;
    const boolFalse = false;
    let variable; // Valor undefined
    let variable2; // Valor null
    const arrayNumber = [1, 2, 3, 4, 5, 6, 7];
    const arrayString = ["a", "b", "c"];
    const arrayBoolean = [true, false, true];
    let DataWeek;
    (function (DataWeek) {
        DataWeek[DataWeek["Monday"] = 0] = "Monday";
        DataWeek[DataWeek["Tuesday"] = 1] = "Tuesday";
        DataWeek[DataWeek["Wednesday"] = 2] = "Wednesday";
        DataWeek[DataWeek["Thursday"] = 3] = "Thursday";
        DataWeek[DataWeek["Friday"] = 4] = "Friday";
        DataWeek[DataWeek["Saturday"] = 5] = "Saturday";
        DataWeek[DataWeek["Sunday"] = 6] = "Sunday";
    })(DataWeek || (DataWeek = {}));
    let Colors;
    (function (Colors) {
        Colors["Red"] = "Rojo";
        Colors["Green"] = "Verde";
        Colors["Blue"] = "Azul";
    })(Colors || (Colors = {}));
}
function user(name, age) {
    console.log(`Hola ${name}, ${age}`);
    return;
}
function sum(number, number2) {
    return number2 + number2;
}
const dividir = (a, b) => a + b;
//# sourceMappingURL=script.js.map