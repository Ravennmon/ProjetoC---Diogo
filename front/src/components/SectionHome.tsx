import { Box, Flex, Heading, Text, Link, Image } from "@chakra-ui/react";

type SectionHomeProps = {
  imageSrc: string;
  imageAlt: string;
  headingText: string;
  bodyText: string;
  linkUrl: string;
  linkText: string;
  linkColor: string;
  linkBackground: string;
  decorationImage?: string; 
};

export default function SectionHome({
  imageSrc,
  imageAlt,
  headingText,
  bodyText,
  linkUrl,
  linkText,
  linkColor,
  linkBackground,
  decorationImage,
}: SectionHomeProps) {
  return (
    <Box position="relative" width="100%" marginBottom="128px">
      <Flex align="center" gap="32px" padding="24px 80px">
        <Box flexShrink={0}>
          <Image src={imageSrc} alt={imageAlt} boxSize="400px" objectFit="cover" />
        </Box>
        <Box flex="1">
          <Heading marginBottom="32px" fontSize="36px">
            {headingText}
          </Heading>
          <Text lineHeight="150%" marginBottom="32px" fontSize="18px">
            {bodyText}
          </Text>
          <Link
            href={linkUrl}
            color={linkColor}
            background={linkBackground}
            borderRadius="10px"
            padding="16px 32px"
            textDecoration="none"
            fontSize="18px"
            _hover={{}}
            isExternal
          >
            {linkText}
          </Link>
        </Box>
      </Flex>
      {decorationImage && (
        <Box
          position="absolute"
          bottom="-50px" 
          left="0"
          width="100vw" 
          zIndex="-10"
        >
          <img src={decorationImage} alt="Decoration" style={{ width: '100%' }} />
        </Box>
      )}
    </Box>
  );
}
