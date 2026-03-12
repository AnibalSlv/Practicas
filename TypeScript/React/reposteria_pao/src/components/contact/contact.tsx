import styles from "./contact.module.css"

function Contact(){
    return(
        <div className={styles.containerContact}>
            <div className={styles.contact}>
                <p>Contactame</p>
                <hr/>
                <div className={styles.contactImg}>
                    <div className={styles.whatsApp}>
                        <img src="/others_img/whatsApp.png" alt="whatsApp"/>
                    </div>
                    <div className={styles.instagram}>
                        <img src="/others_img/instagram.png" alt="Instagram" />
                    </div>
                </div>
            </div>
            <div className={styles.map}>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3688737.8640797692!2d-102.4561867809782!3d25.46222168482309!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x86629584a2a5b05d%3A0x701df442c36cbbc6!2zTnVldm8gTGXDs24sIE3DqXhpY28!5e0!3m2!1ses-419!2sve!4v1771778031806!5m2!1ses-419!2sve" width="600" height="450" loading="lazy"/>
            </div>
        </div>
    )
}

export default Contact