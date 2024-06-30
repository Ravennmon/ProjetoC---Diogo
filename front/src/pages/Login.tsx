import React from 'react'
import Header from '../components/Header'
import LoginForm from '../components/LoginForm'
import { Box,} from '@chakra-ui/react'
import Footer from '../components/Footer'

export default function Login() {
  return (
    <div>
      <Header />
      <LoginForm/>
      <Footer/>

    </div>
  )
}
