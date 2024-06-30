import { useState } from "react";
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
import { useFormik } from "formik";
import * as yup from "yup";

const validationSchema = yup.object({
  name: yup.string().required("Nome é obrigatório"),
  email: yup.string().email("Email inválido").required("Email é obrigatório"),
  password: yup.string().required("Senha é obrigatória"),
});

export default function RegisterForm() {
  const [remember, setRemember] = useState(false);

  const formik = useFormik({
    initialValues: {
      name: "",
      email: "",
      password: "",
    },
    validationSchema: validationSchema,
    onSubmit: (values) => {
      fetch("/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          ...values,
          remember,
        }),
      })
        .then((response) => response.json())
        .then((data) => {
          if (data === true) {
            window.location.href = "/admin/tutors";
          } else {
            formik.setErrors(data);
          }
        })
        .catch((error) => {
          console.error("Error:", error);
        });
    },
  });

  return (
    <Flex height="100vh" align="center" justify="center" bg="#f5f5f5" mt={0}>
      <Box
        bg="white"
        p={8}
        borderRadius="10px"
        boxShadow="0 0 10px rgba(0, 0, 0, 0.1)"
        width="500px"
        maxW="90%"
      >
        <Heading as="h2" mb={6} textAlign="center" color="#333" fontSize="24px">
          Cadastro
        </Heading>
        <form onSubmit={formik.handleSubmit}>
          <Box mb={4}>
            <Input
              type="text"
              name="name"
              placeholder="Nome"
              value={formik.values.name}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              isInvalid={!!(formik.touched.name && formik.errors.name)}
              variant="flushed"
              borderColor="#ddd"
              borderRadius="5px"
            />
            {formik.touched.name && formik.errors.name ? (
              <Text color="red.500" mt={2}>
                {formik.errors.name}
              </Text>
            ) : null}
          </Box>
          <Box mb={4}>
            <Input
              type="email"
              name="email"
              placeholder="Email"
              value={formik.values.email}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              isInvalid={!!(formik.touched.email && formik.errors.email)}
              variant="flushed"
              borderColor="#ddd"
              borderRadius="5px"
            />
            {formik.touched.email && formik.errors.email ? (
              <Text color="red.500" mt={2}>
                {formik.errors.email}
              </Text>
            ) : null}
          </Box>
          <Box mb={4}>
            <Input
              type="password"
              name="password"
              placeholder="Senha"
              value={formik.values.password}
              onChange={formik.handleChange}
              onBlur={formik.handleBlur}
              isInvalid={!!(formik.touched.password && formik.errors.password)}
              variant="flushed"
              borderColor="#ddd"
              borderRadius="5px"
            />
            {formik.touched.password && formik.errors.password ? (
              <Text color="red.500" mt={2}>
                {formik.errors.password}
              </Text>
            ) : null}
          </Box>
          <Button
            type="submit"
            colorScheme="purple"
            width="100%"
            mb={4}
            bg="#8C52FF"
            color="#FFBD59"
            fontSize="16px"
            borderRadius="5px"
            _hover={{ opacity: 0.9 }}
          >
            Cadastre-se
          </Button>
        </form>
      </Box>
    </Flex>
  );
}
