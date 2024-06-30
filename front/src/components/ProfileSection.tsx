import React from 'react';
import { Box, Flex, Heading, Text, Link, Image } from '@chakra-ui/react';

type ProfileSectionProps = {
  imgSrc: string;
  imgAlt: string;
  name: string;
  description: string;
  githubLink: string;
};

const ProfileSection: React.FC<ProfileSectionProps> = ({
  imgSrc,
  imgAlt,
  name,
  description,
  githubLink,
}) => {
  return (
    <Box width="100%" marginBottom="128px">
      <Flex alignItems="center" padding="24px">
        <Image src={imgSrc} alt={imgAlt} boxSize="250px" objectFit="cover" />
        <Box marginLeft="32px">
          <Heading as="h2" fontSize="xl" marginBottom="4px">{name}</Heading>
          <Text fontSize="md" lineHeight="1.5">{description}</Text>
          <Link
            href={githubLink}
            color="#FFBD59"
            bg="#8C52FF"
            borderRadius="md"
            padding="8px 16px"
            fontWeight="600"
            fontSize="md"
            textDecoration="none"
            display="inline-block"
            marginTop="8px"
            _hover={{ bg: '#7A45E0' }}
            isExternal
          >
            GitHub
          </Link>
        </Box>
      </Flex>
    </Box>
  );
}

export default ProfileSection;
