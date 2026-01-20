# Teste_automacao_busca_cep

Automação de Testes – Busca CEP e Rastreamento (Correios)
Este projeto é uma solução de automação de testes End-to-End (E2E) desenvolvida para validar as funcionalidades de busca de CEP e rastreamento de objetos no portal dos Correios. O projeto utiliza uma arquitetura moderna e escalável.

Tecnologias Utilizadas
Linguagem: C# (.NET)

Framework de Testes: NUnit

Automação Web: Selenium WebDriver

BDD (Behavior Driven Development): Reqnroll (Sucessor do SpecFlow)

Design Pattern: Page Object Model (POM)

Arquitetura do Projeto
O projeto foi estruturado seguindo padrões de Clean Code para facilitar a manutenção:

Features/: Arquivos .feature escritos em Gherkin (Português).

StepDefinitions/: Camada que liga o BDD ao código C#.

Pages/: Classes contendo os seletores e as interações com os elementos da página (Page Object Model).

Drivers/: Gerenciamento da instância do WebDriver.

Support/: Hooks e configurações de esperas explícitas (WebDriverWait).

Diferenciais Técnicos
Sincronismo Dinâmico: Implementação de WebDriverWait para lidar com elementos assíncronos e evitar flaky tests.

Injeção de Dependência: Uso do ScenarioContext para compartilhar o estado do Driver entre os Steps.

Tratamento de CAPTCHA: Estratégia de pausa inteligente permitindo a resolução manual do desafio visual sem quebrar o fluxo da automação.

Asserções Flexíveis: Validação de mensagens de erro robustas que aceitam variações de texto (singular/plural) do sistema.

Pré-requisitos
Visual Studio 2022 ou VS Code.

SDK do .NET 6.0 ou superior.

Extensão do Reqnroll instalada no Visual Studio.

Google Chrome atualizado.

Como Executar
Clone o repositório:

Bash
git clone https://github.com/seu-usuario/seu-repositorio.git
Abra a Solution (.sln) no Visual Studio.

Compile o projeto (Build).

Abra o Test Explorer (Explorador de Testes).

Execute o cenário contido em BuscaCep.feature.

Nota: O teste fará pausas para que você resolva o CAPTCHA manualmente no navegador com retry dinamico apos erro do captcha
