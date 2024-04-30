// Espera o DOM carregar completamento.
document.addEventListener("DOMContentLoaded", () => {
    // Elementos que inicializarão com animação ativa
    const initFades = document.querySelectorAll('.init')

    // Armazena todos os elementos com classe 'duvida'.
    const duvidasEl = document.querySelectorAll('.duvida')

    // Adiciona um evento de click para adicionar/remover a classe 'ativa' em cada elemento através do forEach.
    duvidasEl.forEach(duvida => duvida.addEventListener('click', () => duvida.classList.toggle('ativa')))

    // Adiciona um evento para monitorar o scroll e chamar a função show().
    window.addEventListener("scroll", show)

    // Adiciona a classe 'active' nos dois primeiros elementos.
    initFades.forEach(el => el.classList.add('active'))
})

// Função para mostrar os sections conforme o scroll.
const show = () => {

    // Armazena todos os elementos com classe  .fade.
    const elements = document.querySelectorAll('.fade')

    // Adiciona classe 'active' quando o elemento estiver visível na tela.
    elements.forEach(element => {
        const windowHeight = window.innerHeight
        const elementTop = element.getBoundingClientRect().top
        const elementVisible = 150;

        if (elementTop < windowHeight - elementVisible) {
            element.classList.add('active');
        }
    })
  }
  