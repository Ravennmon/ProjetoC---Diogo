import { useState } from 'react';
import {
  Box,
  Button,
  Checkbox,
  Flex,
  Heading,
  Input,
  Link,
  Text,
} from "@chakra-ui/react";

export default function LoginForm() {
  const [email, setEmail] = useState("");
  const [remember, setRemember] = useState(false);
  const [errors, setErrors] = useState<{ email?: string; password?: string }>({});

  const login = () => {
    const password = ""; 
    fetch('/login', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        email,
        password,
        remember
      }),
    })
      .then(response => response.json())
      .then(data => {
        if(data === true){
          window.location.href = '/admin/tutors';
        } else {
          setErrors(data);
        }
      })
      .catch(error => {
        console.error('Error:', error);
      });
  }

  const renderErrors = (field: keyof typeof errors) => {
    if(errors[field]) {
      return (
        <Text color="red.500" mt={2}>{errors[field]}</Text>
      );
    }
    return null;
  }

    function setPassword(value: string): void {
        throw new Error('Function not implemented.');
    }

  return (
    <Flex
      height="100vh"
      align="center"
      justify="center"
      bg="#f5f5f5"
      
    >
      <Box
        bg="white"
        p={8}
        borderRadius="10px"
        boxShadow="0 0 10px rgba(0, 0, 0, 0.1)"
        width="500px"
        maxW="90%"
      >
        <Heading as="h2" mb={6} textAlign="center" color="#333" fontSize="24px">
          Login
        </Heading>
        <Input
          type="email"
          placeholder="Email"
          mb={4}
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          isInvalid={!!errors.email}
          variant="flushed"
          borderColor="#ddd"
          borderRadius="5px"
        />
        {renderErrors('email')}
        

        <Input
            type="password"
            placeholder="Senha"
            mb={4}
            onChange={(e) => setPassword(e.target.value)}
            isInvalid={!!errors.password}
            variant="flushed"
            borderColor="#ddd"
            borderRadius="5px"
        />
        {renderErrors('password')}
        <Flex align="center" mb={4}>
          <Checkbox
            isChecked={remember}
            onChange={(e) => setRemember(e.target.checked)}
            borderColor="#ddd"
            borderRadius="5px"
          >
            Lembrar-me
          </Checkbox>
        </Flex>
        <Button
          colorScheme="purple"
          width="100%"
          mb={4}
          onClick={login}
          bg="#8C52FF"
          color="#FFBD59"
          fontSize="16px"
          borderRadius="5px"
          _hover={{ opacity: 0.9 }}
        >
          Login
        </Button>
        <Link href="/register" color="#8C52FF" textAlign="center" display="block" _hover={{ textDecoration: 'underline' }}>
          Cadastrar-se
        </Link>
      </Box>
    </Flex>
  );
}
