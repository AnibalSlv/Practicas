// Recuerda usar npx tsc nombre_del_archivo.ts
// El npx es porque lo hago local lo de instalar el TS
// El tsc es el comando para TS
// Y lo que hace el comando es pasar el archivo de TS a JS para que los navegadores lo corran

// Para evitar tener que escribir el comando por cada cambio que hagas en TS para que se transforme en un JS y eso utiliza
// npx tsc nombre_del_archivo.ts -w
// El -w quiere decir watch es decir inicia el modo observador, esto transforma automaticamente el archivo de TS en uno JS
// de manera automatica

// TODO: Esto es importante y es que para inicializar un proyecto con TS es npx tsc -init
// Esto nos agrega una carpeta tsconfig.json y nos agrega funciones nuevas que podemos utilizar

// TODO: npx tsc -w Es lo mismo que el modo observador mencionado anteriormente pero de manera global
// Esto solo se puede hacer si inicilizaste el proyecto como un TS (En el primer TODO se muestra)

console.log('Buenas noches mundos')

function string(){
    const text1: string = "texto nuevo"
    const text2: string = '$"" o fString'
    const text3: string = `Esto es lo equivalente a ${text2}`
}

function  number(){
    const number1: number = 2;
    const number2: number = 2.5e-2; // 2.5 * 10^-2 = 0.015
    const number3: number = 0xA; // Valor hexadecimal (base 16)
    const number4: number = 0o12; // Valor decimal (base 8)
    const number5: number = 0b1010; // Valor binario (base 2)
}

function others(){

    const boolTrue: boolean = true;
    const boolFalse: boolean = false;

    // let es para decir que el dato es una variable
    let variable: undefined; // Valor undefined
    let variable2: null; // Valor null

    const arrayNumber: number[] = [1, 2, 3, 4, 5, 6, 7];
    const arrayString: string[] = ["a", "b", "c"];
    const arrayBoolean: boolean[] = [true, false, true];

    enum DataWeek {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }

    enum Colors{
        Red = 'Rojo',
        Green = 'Verde',
        Blue = 'Azul',
    }
}

// El = 30 es como C# con ?? si no le das un valor el valor por defecto sera 30, igual si pones age? le dices que puedes no
// darle un valor aun que no puedes combiar ? con el valor por defecto (el equivalente a ??)
function user(name: string, age: number = 30){
    console.log(`Hola ${name}, ${age}`);
    return;
}

function sum(number: number, number2: number): number{
    return number2 + number2;
}

const dividir = (a: number, b: number) => a + b; // Aquí "adivina" el tipo de retorno

interface usuarios{
    Name: string;
    Age: number;
    Id?: number;
}

class usuario implements usuarios{
    Name: string;
    Age: number;
    Id?: number; // Esta propiedad es opcional colocarla directamente, la intefaz no te obliga 

    constructor(name: string, age:number){
        this.Name = name;
        this.Age = age;
    }

    greet(){
        console.log(`Hola, mi nombre es ${this.Name}.`)
    }
}

// Interfaz para funciones 
interface sums{
    (a: number, b: number): boolean;
}

// Nota: tambien existe esto:

interface Usuario {
    id: number;
    nombre: string;
    email: string;
    admin?: boolean; // El '?' significa que es opcional
}

const nuevoUsuario: Usuario = {
    id: 1,
    nombre: "Alex",
    email: "alex@correo.com"
};

// Con esto un tipo de dato puede ser diferente tipo de datos por ejemplo: Id puede ser string o number
function dataType(){
    type Id = string | number;
}

function objects(){
        let object = {
            name: "un Nombre original",
        age: 19,
        existing: true,
        tecnology: ["C#"]
    }

    // Dos formas de cambiar los valores de un objeto:

    object.name = "algo mas";

    object = {
        name: "me cambie el nombre",
        age: 30,
        existing: false,
        tecnology: ["TS"]
    }
}

function TypePersonality(){
    type Programmer = {
        name: string,
        age: number | string,
        tecnology?: string[]
    }
    let Programmer1: Programmer = {
        name: "pedro",
        age: 40,
    }

    let Programmer2: Programmer = {
        name: "Juan",
        age: "veinte y uno",
        tecnology: ["C#"]
    }
}