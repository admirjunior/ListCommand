# Command Reference Tool

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=flat&logo=dotnet&logoColor=white)
![GitHub](https://img.shields.io/github/license/seu-usuario/seu-repositorio?style=flat)

Uma ferramenta simples em C# para consultar comandos e funções de tecnologias amplamente usadas em desenvolvimento e testes, como Git, Linux, Docker, Node.js, Puppeteer e JavaScript.

## Sobre o Projeto

Este projeto foi criado como uma iniciativa pessoal para organizar e documentar comandos que utilizo no meu dia a dia como QA (Quality Assurance). Ele reflete minha experiência com pipelines de CI/CD, automação de testes e configuração de ambientes, áreas essenciais para garantir a qualidade em projetos de software. A ferramenta armazena os dados em um arquivo JSON e oferece uma interface de console para consulta rápida.

### Tecnologias Utilizadas
- **C#**: Linguagem principal do projeto.
- **.NET**: Framework para execução e manipulação de JSON.
- **JSON**: Formato leve para persistência de dados.

### Motivação
Como QA, frequentemente trabalho com ferramentas como Docker para configurar ambientes de teste, Git para controle de versão em pipelines, e Puppeteer para automação de testes web. Este software me ajuda a manter uma referência rápida desses comandos, economizando tempo e melhorando minha produtividade.

## Funcionalidades
- Lista comandos de:
  - **Git**: Controle de versão.
  - **Linux**: Comandos de terminal.
  - **Docker**: Gerenciamento de containers.
  - **Node.js**: Funções comuns.
  - **Puppeteer**: Automação de navegadores.
  - **JavaScript**: Funções nativas.
- Exibe descrição, opções e exemplos para cada comando.
- Salva os dados em um arquivo `commands.json` para fácil edição.

## Como Usar

### Pré-requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) instalado (versão 6.0 ou superior).

### Instalação
1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
