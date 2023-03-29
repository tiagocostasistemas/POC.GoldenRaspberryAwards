# POC.GoldenRaspberryAwards

Este é um projeto de POC (Proof of Concept) que tem como objetivo demonstrar a construção de uma aplicação simples capaz de processar dados de um arquivo CSV contendo informações sobre os filmes premiados com o Golden Raspberry Awards (também conhecido como Framboesa de Ouro), um prêmio satírico americano que elege os piores filmes do ano.

## Executando a aplicação

Para executar a aplicação, siga os seguintes passos:

1. Certifique-se de ter o .NET SDK instalado em sua máquina (versão mínima: 6.0).
2. Faça o clone deste repositório em sua máquina.
3. Abra o terminal ou prompt de comando na pasta raiz do projeto.
4. Execute o seguinte comando: `dotnet run --project .\POC.GoldenRaspberryAwards.API\`.
5. A aplicação será iniciada.
6. Para utilizar a aplicação, acesse o endereço https://localhost:7019/swagger ou http://localhost:5019/swagger.

## Executando os testes

Para executar os testes automatizados do projeto, siga os seguintes passos:

1. Abra o terminal ou prompt de comando na pasta raiz do projeto.
2. Execute o seguinte comando: `dotnet test`.
3. Os testes serão executados e o resultado será exibido no console.

## Tecnologias utilizadas

- .NET 6
- xUnit
