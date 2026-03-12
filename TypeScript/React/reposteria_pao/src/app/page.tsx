import SectionHero from '@/components/section_hero/section_hero'
import MenuCarrusel from '@/components/menu_carrusel/menu_carrusel'
import Informative from '@/components/informative/informative';
import Contact from '@/components/contact/contact';

const images: string[] = [];

function Page(){
  return(
    <>      
      <SectionHero/>
      <br/>
      <br/>
      <br/>
      <MenuCarrusel images={images}/>
      <br/>
      <br/>
      <br/>
      <Informative/>
      <br/>
      <br/>
      <br/>
      {/* <Contact/> */}
    </>
  )
}

export default Page