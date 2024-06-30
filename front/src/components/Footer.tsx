import React from 'react';
import { Box, Text, Link } from '@chakra-ui/react';

const Footer = () => {
  return (
    <Box bg="#8C52FF" p={4} textAlign="center">
      <Text color="white">
        Desenvolvido por <Link href="#" target="_blank" color="#FFBD59">Francyne Leocadio, Renan Dos Santos, Pedro Dawybida e Henrique Onorato</Link>.
      </Text>
    </Box>
  );
};

export default Footer;
