import {
    Box,
    Button,
    FormControl,
    FormLabel,
    Input,
    Select,
    VStack,
    Heading,
} from "@chakra-ui/react";

interface Sex {
    key: string;
    value: string;
}

interface Size {
    key: string;
    value: string;
}

interface Ong {
    id: number;
    name: string;
}
  

const CadastroAnimal = () => {
    const sexes: Sex[] = [
        { key: "Macho", value: "M" },
        { key: "Fêmea", value: "F" },
    ];
    const sizes: Size[] = [
        { key: "P", value: "Pequeno" },
        { key: "M", value: "Médio" },
        { key: "G", value: "Grande" },
    ];
    const ongs: Ong[] = [
        { id: 1, name: "Ong 1" },
        { id: 2, name: "Ong 2" },
        { id: 3, name: "Ong 3" },
    ]

    function createAnimal(): void {
        throw new Error("Function not implemented.");
    }

    return (
        <Box width="100%" maxWidth="600px" margin="auto" padding="16px">
            <Heading as="h2" size="lg" marginBottom="24px" textAlign="center">
                Cadastro de Animais
            </Heading>
            <VStack spacing="24px" as="form" id="animal-form">
                <FormControl id="name">
                    <FormLabel>Nome</FormLabel>
                    <Input type="text" name="name" placeholder="Nome" />
                </FormControl>

                <FormControl id="specie">
                    <FormLabel>Espécie</FormLabel>
                    <Select name="specie" placeholder="Selecione a espécie">
                        <option value="C">Cachorro</option>
                        <option value="G">Gato</option>
                        <option value="O">Outros</option>
                    </Select>
                </FormControl>

                <FormControl id="breed">
                    <FormLabel>Raça</FormLabel>
                    <Input type="text" name="breed" placeholder="Raça" />
                </FormControl>

                <FormControl id="birth_date">
                    <FormLabel>Data de Nascimento</FormLabel>
                    <Input type="date" name="birth_date" />
                </FormControl>

                <FormControl id="size">
                    <FormLabel>Porte</FormLabel>
                    <Select name="size" placeholder="Selecione o porte">
                        {sizes.map((size) => (
                            <option key={size.key} value={size.key}>
                                {size.value}
                            </option>
                        ))}
                    </Select>
                </FormControl>

                <FormControl id="sex">
                    <FormLabel>Sexo</FormLabel>
                    <Select name="sex" placeholder="Selecione o sexo">
                        {sexes.map((sex) => (
                            <option key={sex.key} value={sex.key}>
                                {sex.value}
                            </option>
                        ))}
                    </Select>
                </FormControl>

                <FormControl id="ong_id">
                    <FormLabel>Ong</FormLabel>
                    <Select name="ong_id" placeholder="Selecione a Ong">
                        {ongs.map((ong) => (
                            <option key={ong.id} value={ong.id}>
                                {ong.name}
                            </option>
                        ))}
                    </Select>
                </FormControl>

                <Button colorScheme="purple" onClick={() => createAnimal()}>
                    Criar
                </Button>
            </VStack>
        </Box>
    );
};

export default CadastroAnimal;
