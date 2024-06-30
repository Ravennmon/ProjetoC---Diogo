import React from "react";
import Header from "../components/Header";
import Acordion from "../components/Acordion";
import { Box, Flex, Heading, Text } from "@chakra-ui/react";
import dog from "../assets/img/dog2.svg";
import Footer from "../components/Footer";

export default function Faq() {
  const sections = [
    {
      title: "Podemos Visitar a ONG para ver os pequeninos?",
      content:
        "Sim! Você pode nos visitar, contanto que marque uma visita prévia, em caso de escolha de gatinhos ou cãezinhos que estejam em lar temporário, precisamos marcar com antecedência, para poder agendar com os tutores temporários a visita, já que os animais se encontram nas casas dos mesmos.",
    },
    {
      title: "Qualquer um pode adotar?",
      content:
        "Sim! Seguindo algumas regras. Precisa ser maior de 18 anos, possuir telas nas janelas de seu apartamento/casa, responsabilidade e dar muito amor e carinho. E claro, antes de uma adoção tenha consciência de que o animal não é um objeto que pode ser devolvido a qualquer momento, apenas porque sim, tenha muita certeza antes de fazer sua adoção.",
    },
    {
      title: "Como posso ser um Tutor temporário?",
      content:
        "Para ser um tutor temporário, precisa seguir as mesmas diretrizes para ser um tutor, lembrando que a ONG lhe ajudará nos gastos com os pequeninos, sua maior função, é cuidar e proteger os pequenos, até ganharem um lar definitivo.",
    },
  ];

  return (
    <div>
      <Header />
      <Flex 
        alignItems='flex-start'
        gap='64px'
        padding='64px 80px'
      >
        <Box flexShrink={0}>
          <img
            src={dog}
            alt="Desenho de um cachorro"
            width="400px"
            height="400px"
            style={{ objectFit: 'cover' }}
          />
        </Box>
        <Box flex="1">
          <Heading 
            fontWeight='600'
            fontSize='32px'
            mb='32px'
          >
            Dúvidas mais frequentes, antes de entrar em contato.
          </Heading>

          <Text mb="24px">
            Muitas pessoas possuem dúvidas, de como funciona uma adoção, através de uma ONG ou de um protetor individual. Segue abaixo as principais, caso possua alguma que não se encontre por aqui, pode nos contatar.
          </Text>
          <Acordion sections={sections} />
        </Box>
      </Flex>
      <Footer/>
    </div>
  );
}
