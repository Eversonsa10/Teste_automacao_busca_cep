
#language: pt-br
Funcionalidade: Avaliação – Busca CEP

Cenário: Validar buscas de CEP e Rastreamento no site dos Correios
    # Passos 1 a 4
    Dado que eu navego para o site dos Correios
    Quando eu busco pelo CEP "80700000"
    Então o sistema deve informar que o CEP não existe
    E eu volto para a tela inicial

    # Passos 5 a 7
    Quando eu busco pelo CEP "01013-001"
    Então o resultado deve ser "Rua Quinze de Novembro, São Paulo/SP"
    E eu volto para a tela inicial

    # Passos 8 a 10
    Quando eu procuro pelo rastreamento "SS987654321BR"
    Então o sistema informa que o código não está correto
    E eu fecho o navegador