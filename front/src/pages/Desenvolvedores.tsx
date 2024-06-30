import React from "react";
import Header from "../components/Header";
import SectionDev from "../components/ProfileSection";
import francyne from "../assets/img/Francyne.png";
import renan from "../assets/img/Renan.png";
import henrique from "../assets/img/Henrique.png";
import pedro from "../assets/img/Pedro.png";
import ProfileSection from "../components/ProfileSection";
export default function Desenvolvedores() {
  return (
    <>
     <Header />
      <ProfileSection
        imgSrc={francyne}
        imgAlt="Francyne Leocadio"
        name="Francyne Leocadio"
        description="Francyne tem 27 anos, cursa o 3º semestre de ADS (Analise e desenvolvimento de Sistemas), já tem uma formação em designer gráfico e fez 3 anos de Física na UFPR."
        githubLink="https://github.com/Ravennmon"
      />
      <ProfileSection
        imgSrc={henrique}
        imgAlt="Henrique Onorato"
        name="Henrique Onorato"
        description="Henrique tem ** anos, cursa o 3º semestre de ADS (Analise e desenvolvimento de Sistemas) e já está no mercado de tecnologia, como desenvolvedor fullstack em JAVA (junior)."
        githubLink="https://github.com/Henryk212"
      />
      <ProfileSection
        imgSrc={pedro}
        imgAlt="Pedro Dawybida"
        name="Pedro Dawybida"
        description="Pedro tem 23 anos, cursa o 3º semestre de ADS (Analise e desenvolvimento de Sistemas) e está se aprimorando para o mercado de dados."
        githubLink="https://github.com/pedrodawybida"
      />
      <ProfileSection
        imgSrc={renan}
        imgAlt="Renan dos Santos"
        name="Renan dos Santos"
        description="Renan tem 27 anos, cursa o 3º semestre de ADS (Analise e desenvolvimento de Sistemas), e já está no mercado de tecnologia há 4 anos, 3 deles como Back-End com PHP, e hoje é fullstack."
        githubLink="https://github.com/rnnrls97"
      />
    </>
    
  );
}
