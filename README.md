## A aplicação 

API com o objetivo de fornecer informações sobre o transporte público da cidade de São Paulo, similar a [API **Olho Vivo**](api.md).

## Requisitos

Esses requisitos são obrigatórios e devem ser desenvolvidos para a entrega do teste

### CRUD

Implementar as operações de **criação (POST)**, **consulta (GET)** (Por Id e GetAll), **atualização (PUT)** e **exclusão (DELETE)** de todas as entidades do seguinte diagrama:

!['D](imagens/backend_diagrama.png)

### Métodos

Após implementar o CRUD para as entidades, implemente os seguintes métodos:

* `Linhas por Parada`: Recebe o identificador de uma parada e retorna as linhas associadas a parada informada

* `Veiculos por Linha`: Recebe o identificador de uma linha e retorna os veículos associados a linha informada

## O que é permitido

* Linguagem C#

* PostgreSQL, MySQL, Oracle, etc

* Mapeamento objeto-relacional (ORM)

* Qualquer tecnologia complementar as citadas anteriormente são permitidas desde que seu uso seja justificável

## O que não é permitido

* Bancos de Dados **não relacionais**.
  
* Utilizar bibliotecas ou códigos de terceiros que implementem algum dos requisitos.

* Outras linguagens diferentes de C#

## Recomendações
* O teste é propositalmente simples para permitir que você demostre suas habilidades e conhecimentos sem escrever muito código, sendo assim é interessante utilizar design patters e padrões de arquitetura.
* **Linter**: Desenvolva o projeto utilizando algum padrão de formatação de código.
* Idealmente a nomeclatura de classes, métodos, atributos e propriedades devem estar no idioma Ingles.

## Extras

Aqui são listados algumas sugestões para você que quer ir além do desafio inicial. Lembrando que você não precisa se limitar a essas sugestões, se tiver pensado em outra funcionalidade que considera relevante ao escopo da aplicação fique à vontade para implementá-la.

* `Paradas por Posição`: Implementar um método que recebe uma posição (lat, long) como parâmetro e retorna as paradas mais proximas a posição informada.

* **Documentação**: Gerar a documentação da API de forma automatizada, utilizando o `swagger` ou equivalentes

* **Containerização**: Realizar a conteinerização da aplicação utilizando Docker

* **Front-end da aplicação**: Se seu foco é ser fullstack, você pode explorar isso desenvolvendo um front-end para a aplicação, seja em tecnologia .NET (MVC, Razor, Blazor) ou javacript (VueJS, Angular, ReactJS, etc.)

 