"use client"
import { ComponentPropsWithoutRef, Dispatch, SetStateAction, useState } from "react";

 // Esto es importante para que se ejecuten las funciones pq es codigo cliente

let textButton: string = "Click"
let variableFontSize: string = "16px"


type ButtonPropsStyle = {
  style: React.CSSProperties;
};

function Button(){
  return(
    <button>{textButton}</button>
  )
}

// el props puede llamarse de cualquier manera, 
function Button2(props: {text: string}){
  return(
    <button>{props.text}</button>
  )
}

type Color = "red" | "blue" | "yellow" | "black" 

type ButtonProps = {
  text: string,
  subtitle?: string, // Si no pones ? al utilizarlo en para que se muestre tirara un error o bueno advertencia
  color: Color, // Esto es por si tenemos por ejemplo dos propiedades y utilizan los mismos colores, asi si se actualiza 
  // en 1 se actualiza en el otro
  // color:  "red" | "blue" | "yellow" | "black"  <-- Tambien se puede escribir asi
  number: number,
  onClick?: (text: string) => void,
}

function Button3(props: ButtonProps){
  return(
    <button>{props.text} {props.color} {props.number}</button>
  )
}

// TODO: Es importante el ? si en el type pusiste ? (el . en ?. es que dice: Si existe ponle ese valor)
function Button4({text, color, number, onClick}: ButtonProps){
  return(
    <button onClick={() => onClick?.("Buenas noches mundo")}>{text} {color} {number}</button>
  )
}

function Button5({style}: ButtonPropsStyle){
  return (
    <button style= {style}>Esto tiene estilos</button>
  )
}

//-------------------------------------------- Separacion para limpiar un poco ------------------------------

type ButtonPropsChildren = {
  children : React.ReactNode, // Nos permite hacer que un componente tenga hijos tanto JSX (html) como string
  // children : string | JSX.Element | JSX.Element[] Asi tambien pudes Hacer algo parecido y el [] es para que acepte
  // Mas de un tipo de elemento JSX como hijo porque si pones mas de uno sin [] directamente da error
}

function ButtonChildren({children}: ButtonPropsChildren){
  return <button>Tengo hijos</button>
}

type ButtonStateHope = {
  setCount: Dispatch<SetStateAction<number>> , // TODO: Dale ctrl + espacio para que te ayude a auto-completar 
  // Dispatch: Esta es una funcion que envia una orden
  // SetStateAction: La orden cambia el estado
  // <Tipo de datos>: Solo se aceptan estos tipos de datos

  // TODO: tambien puedes colocar simplemente: setCount: (n:number) => void
}

function ButtonState({setCount}: ButtonStateHope){
  return <button onClick={() => setCount(10)}>Dame click y hago algo</button>
}

type LinkProps = ComponentPropsWithoutRef<"a"> // Con esto decimos que queremos poder utilizar las propiedades de 
// Lo que este dentro de <> en este caso de la etiqueta "a" (obvio de html)

function Link({href}: LinkProps){ // lo que este dentro de {} son las propiedades en este caso es hreft
  return <a href={href}>Soy un link</a> // Aun que no salta error sin href si no lo colocas no se puede usar 
}

function Page(){

  const [count, setCount] = useState(0) // Esto dice: count = 0 y si setCount lo cambias tu re dibujas la pagina 
  // (por el useState)
  
  return(
    <div>
      <Button/>
      <br/>
      <Button2 text="esto se llama props"/>
      <br/>
      <Button3 text="Esto lo hice desde  un type" color="black" number={3}/>
      <br/>
      <Button4 text="Esto es destructurar el objeto" color="red" number={2} onClick={() => alert('Funciona :p')}/>
      <br/>
      <Button5 style={{
        backgroundColor: "red",
        color: "white",
        fontSize: variableFontSize,
        padding: "20px"
      }}/>
      <br/>
      <ButtonChildren>
        <div>Soy su hijo</div>
        <span>Yo tambien</span>
      </ButtonChildren>
      <br/>
      <h1>{count}</h1>
      <ButtonState setCount = {setCount}/>
      <br/>
      <Link href="/a"/>
    </div>
  )
}

// Importante no colocar ()
export default Page