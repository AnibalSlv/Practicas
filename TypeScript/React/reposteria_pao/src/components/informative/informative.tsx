import styles from "./informative.module.css"

function Informative(){
    return(
        <section className={styles.sectionInformation}>
            <div className={styles.imgContainer}>
                <img src="/others_img/croissant.jpg"/>
            </div>
            <div className={styles.textContainer}>
                <p>Lorem ipsum dolor sit, amet consectetur adipisicing elit. Officiis mollitia itaque, illo reprehenderit quis corrupti. Voluptas maiores odit eligendi similique, ut, nihil vitae vel aperiam repudiandae delectus, sint sed quia! Lorem ipsum dolor sit amet consectetur, adipisicing elit. Laudantium exercitationem, magnam veritatis expedita vel eos adipisci! Similique architecto labore veniam? Quod eius neque sit ipsa? Sint quas nulla exercitationem illum. Lorem ipsum dolor sit amet consectetur adipisicing elit. Temporibus ullam nihil quos voluptatum corporis, quae porro, vitae cumque amet recusandae numquam mollitia? Tenetur quidem obcaecati sequi deserunt, impedit cupiditate porro.</p>
                <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Corrupti, quia aspernatur pariatur, aperiam nisi, rem amet quis nam quisquam non maxime? Veritatis cum, fuga aliquid voluptatum illum animi pariatur magni.</p>
                <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Enim autem hic minus? Quaerat ducimus officiis accusamus dolorem hic. Tenetur repudiandae, repellat dolor autem praesentium ad sapiente nam! Ullam, suscipit quae?</p>
            </div>
        </section>
    )
}

export default Informative