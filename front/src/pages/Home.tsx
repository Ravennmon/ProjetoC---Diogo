import Header from "../components/Header";
import SectionHome from "../components/SectionHome";
import alimentosPetImg from "../assets/img/alimentos_pet.svg";
import meninaCachorroImg from "../assets/img/meninaCachorro1.svg";
import meninaGatoImg from "../assets/img/meninaGato.svg";
import imagemDeco from "../assets/img/shape_roxo.svg"; 
import Footer from "../components/Footer";
import { Box } from "@chakra-ui/react";

export default function Home() {
  return (
    <>
      <Header />
      <Box
        flex="1"
        display="flex"
        flexDirection="column"
        justifyContent="center"
        alignItems="center"
        padding="0 80px"
      >
        <SectionHome
          imageSrc={alimentosPetImg}
          imageAlt="Alimentos para seu pet"
          headingText="Garanta uma casa ou cuidados até um lar doce chegar, para os pequeninos."
          bodyText="A AmorPet é uma plataforma criada por desenvolvedores inesperientes, mas que querem de alguma forma ajudar a causa de resgate e cuidado de animais, especializados em amar seus pets, criamos a plataforma para o registro de ongs e tutores, para que o match ocorra da melhor forma possível."
          linkUrl="/produtos"
          linkText="Agende uma visita"
          linkBackground="#8C52FF"
          linkColor="#FFBD59"
          decorationImage={imagemDeco} // Passa a imagem de decoração apenas para o primeiro SectionHome
        />
        <SectionHome
          imageSrc={meninaCachorroImg}
          imageAlt="Menina com cachorro"
          headingText="Conheça nossos cãezinhos."
          bodyText="Cachorros abandonados são um problema sério e lamentável que afeta muitas regiões do mundo. Esse tipo de situação é prejudicial tanto para os cães quanto para a sociedade como um todo. Aqui somos especializados no resgate e reabilitação dos mesmos, para a adoção, correta e assistida inicialmente."
          linkUrl="/produtos"
          linkText="Conheça alguns cachorrinhos"
          linkBackground="#8C52FF"
          linkColor="#FFBD59"
        />
        <SectionHome
          imageSrc={meninaGatoImg}
          imageAlt="Menina com gato"
          headingText="Conheça nossos gatinhos."
          bodyText="Gatos abandonados, muitas vezes referidos como gatos de rua ou gatos vadios, enfrentam desafios semelhantes aos cachorros abandonados, embora haja diferenças notáveis em sua natureza e nas formas de abordar o problema."
          linkUrl="/produtos"
          linkText="Conheça alguns gatinhos"
          linkBackground="#8C52FF"
          linkColor="#FFBD59"
        />
      </Box>
      <Footer />
    </>
  );
}
