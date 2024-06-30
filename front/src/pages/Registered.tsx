import React from "react";
import SectionHome from "../components/SectionHome";
import gato from "../assets/img/cat.svg";
import Header from "../components/Header";
import Footer from "../components/Footer";
import { Box, Center, Flex } from "@chakra-ui/react";

export default function Registered() {
  return (
    <>
     <Box display="flex" flexDirection="column" minHeight="100vh">
    <Header />
    <Box flex="1" display="flex" justifyContent="center" alignItems="center">
      <SectionHome
            imageAlt={'imagem gato'} 
            headingText="Usuario cadastrado com sucesso"
            bodyText="Caso você tenha alguma dúvida, sobre as ONGs, como trabalham, como adotar e como pode ajudar com com os gastos das ONGs parceiras, pode entrar em contato, pelo nosso whatsapp AQUI. E também temos instagram CrazyCatGang"
            linkUrl="/login"
            linkText="Voltar para a tela de Login"
            linkColor="#FFBD59"
            linkBackground="#8C52FF" imageSrc={gato}      />
    </Box>
    <Footer />
  </Box>
    </>
  );
}
