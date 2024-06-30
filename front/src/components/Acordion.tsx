import {
  Accordion,
  AccordionItem,
  AccordionButton,
  AccordionPanel,
  AccordionIcon,
  Box,
} from "@chakra-ui/react";

export default function Acordion({
  sections,
  allowMultiple = true,
}: {
  sections: Array<{ title: string; content: string }>;
  allowMultiple?: boolean;
}) {
  return (
    <Accordion allowMultiple={allowMultiple}>
      {sections.map((section, index) => (
        <AccordionItem key={index} mb="16px"> {/* Adiciona espaço entre os itens */}
          <h2>
            <AccordionButton
              border="2px solid #8C52FF"
              borderRadius="8px"
              cursor="pointer"
              padding="24px"
              margin="0"
            >
              <Box
                flex="1"
                textAlign="left"
                fontSize="32px"
                fontWeight="600"
              >
                {section.title}
              </Box>
              <AccordionIcon />
            </AccordionButton>
          </h2>
          <AccordionPanel
            fontSize="16px"
            pb={4}
            borderRight="1px solid #8C52FF"
            borderBottom="1px solid #8C52FF"
            borderLeft="1px solid #8C52FF"
            borderRadius="0 0 8px 8px"
            mt="-1px"
            ml="5px"
            mr="5px"
          >
            {section.content}
          </AccordionPanel>
        </AccordionItem>
      ))}
    </Accordion>
  );
}
