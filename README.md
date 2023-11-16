# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
O método AdicionarVeiculo foi modificado e incluído algumas verificações:
1. Verifica se é uma placa válida no padrão XXX-1234. Para isso foi desenvolvido um médoto de ValidarPlaca através de um Regex;
![image](https://github.com/iagovcavalcanti/trilha-net-fundamentos-desafio/assets/149210815/1f7a3f73-f231-41c4-bec4-f6a5d86c1f4b)

2. Verifica se o usuário não inseriu nenhuma informação e imprime uma mensagem de erro vermelha;
![image](https://github.com/iagovcavalcanti/trilha-net-fundamentos-desafio/assets/149210815/9b054f72-1ef2-443a-bc02-ad09e4ea7a2c)

3. Verifica se a placa inserida já foi cadastrada e imprime uma mensagem de erro vermelha;
![image](https://github.com/iagovcavalcanti/trilha-net-fundamentos-desafio/assets/149210815/f4b1734e-61d7-45db-b145-a42f3fd7b820)

4. Caso nenhuma dessas condições sejam verdadeiras, adiciona a placa na lista.
![image](https://github.com/iagovcavalcanti/trilha-net-fundamentos-desafio/assets/149210815/acf7ce57-5ef5-4678-92f5-88167d7b64a8)

Listar veículos:
![image](https://github.com/iagovcavalcanti/trilha-net-fundamentos-desafio/assets/149210815/6c144361-a3d3-4352-b48a-b37b7f5d4adc)

Remover veículos:
![image](https://github.com/iagovcavalcanti/trilha-net-fundamentos-desafio/assets/149210815/fffb13a5-f488-408a-9f1f-3b904db67c97)





