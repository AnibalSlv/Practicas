"use client"
import { useState } from 'react';
import styles from './menu_carrusel.module.css'

const slides = [
    {
        id:1,
        image: "/products_img/product1.jpg",
        title: "Croissant",
        name: "pan/ croissant",
    },
    {
        id:2,
        image: "/products_img/product2.jpg",
        title: "Postre1",
        name: "postre/ con crema",
    },
    {
        id:3,
        image: "/products_img/product3.jpg",
        title: "Postre2",
        name: "postre/ dona",
    },
    {
        id:4,
        image: "/products_img/product4.jpg",
        title: "Postre3",
        name: "postre/ dona",
    },
    {
        id:5,
        image: "/products_img/product5.jpg",
        title: "Postre5",
        name: "postre/ ponque",
    },
    {
        id:6,
        image: "/products_img/product6.jpg",
        title: "Postre6",
        name: "postre/ postre6",
    }
]


interface MenuCarruselProps { // Esto es para que el componente sepa que es lo que recibe porque si pones string[] da error
    images: string[]
}

function MenuCarrusel({images}: MenuCarruselProps){
    const [currentIndex, setCurrentIndex] = useState(0);

    const nextImage = (currentIndex + 1) % slides.length;
    const followingImage = (currentIndex + 2) % slides.length;

    const handleNext = () =>{
        setCurrentIndex((prevIndex: number): number =>
            prevIndex + 1 === slides.length ? 0 : prevIndex + 1 // prevIndex + 1 es igual a todas las imagenes ? true : false
    )}

    const handlePrevious = () => {
        setCurrentIndex((prevIndex: number) =>
        prevIndex - 1 < 0 ? slides.length - 1 : prevIndex - 1
    )}

    const handleDotClick = (index: number) => {
        setCurrentIndex(index)
    }

    return(
        <div className={styles.container}>
            <div className={styles.containerCards}>
                <div className={styles.left} onClick={handlePrevious}>
                    <svg
                        height="20"
                        viewBox="0 96 960 960"
                        width="20">
                        <path d="M400 976 0 576l400-400 56 57-343 343 343 343-56 57Z" />
                    </svg>
                </div>
                <div className={styles.card} key={currentIndex}>
                    <div className={styles.cardImage}>
                        <img src={slides[currentIndex].image}/>
                    </div>
                    <div className={styles.cardText}>
                        <p className={styles.cardMeal}>{slides[currentIndex].name}</p>
                        <p className={styles.cardTitle}>{slides[currentIndex].title}</p>
                    </div>
                </div>
                <div className={`${styles.card} ${styles.otherCard}`} key={nextImage}>
                    <div className={styles.cardImage}>
                        <img src={slides[nextImage].image}/>
                    </div>
                    <div className={styles.cardText}>
                        <p className={styles.cardMeal}>{slides[nextImage].name}</p>
                        <p className={styles.cardTitle}>{slides[nextImage].title}</p>
                    </div>
                </div>
                <div className={`${styles.card} ${styles.otherCard}`} key={followingImage}>
                    <div className={styles.cardImage}>
                        <img src={slides[followingImage].image}/>
                    </div>
                    <div className={styles.cardText}>
                        <p className={styles.cardMeal}>{slides[followingImage].name}</p>
                        <p className={styles.cardTitle}>{slides[followingImage].title}</p>
                    </div>
                </div>

                <div className={styles.right} onClick={handleNext}>
                <svg
                    height="20"
                    viewBox="0 96 960 960"
                    width="20"
                >
                    <path d="m304 974-56-57 343-343-343-343 56-57 400 400-400 400Z" />
                </svg>
                </div>
            </div>  
            <div className={styles.carousel_indicator}>
                {slides.map((_: any, index: number) => (
                <div
                    key={index}
                    className={`${styles.dot} ${currentIndex === index ? styles.active : ""}`}
                    onClick={() => handleDotClick(index)}
                ></div>
                ))}
            </div>
        </div>
    )
}

export default MenuCarrusel