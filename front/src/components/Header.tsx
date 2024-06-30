import { Box, Flex, Image, Spacer} from '@chakra-ui/react'
import logo from '../assets/img/logo3.svg';
import NavBar from './NavBar';



export default function Header() {
  return (
    <Flex bg='#FFBD59' alignItems='center' width='100%'>
        <Box padding='24px 80px'>
            <Image src={logo} alt='Logo Amor Pet'/>
        </Box>
        <Spacer/>
        <Box pr='80px'>
            <NavBar/>
        </Box>
    </Flex>
  )
}
