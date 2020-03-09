## Wiz Movies

Este projeto foi feito em uma única camada dividida em três seções básicas:
Controller: onde foi feito o endpoint de buscar filmes.
Domain: onde estão as classes de domínio referente a filme, interface e enum (gênero do filme).
Service: onde é feita a requisição para a API The Movie DB, conforme pedido no desafio.

  -A configuração desta requisição é feita em appsettings.json, no qual o service invoca para a chamada da API.
  
  -Pelo fato de cada requisição retornar apenas 20 registros, na url requisição é permitido adicionar número de página para que mais dados diferentes sejam trazidos. Dessa forma, o service foi implementado para fazer 5 requisições e trazer dados de 5 páginas diferentes.
  
  -O resultado dessas requisições são mapeados para uma lista da classe Movie e consequentemente filtrados para apenas filmes que ainda serão lançados.
  
  -O json das requisições em The Movie DB retornam uma lista de categorias para cada filme, estas por sua vez, estão inconsistentes. Alguns filmes não possuem nenhuma categoria na lista, outros por sua vez, existem ids na casa dos milhares, porém existem cerca de 29 tipos de categorias de filmes hoje. Dessa forma, foi descartada as categorias trazidas na requisição e no mapeamento da categoria foi sorteado um número de 1 a 29.
  
### Padrões 
Além do padrão Controller/Domain/Service costumeiramente utilizado no mercado de trabalho em TI que separa as classes por definições e papeis dentro do projeto, foi utilizado o padrão de injeção de dependência no construtor que diminui o acoplamento e torna o código mais limpo.

### Bibliotecas
Duas bibliotecas externas foram usadas:

Swashbuckles.AspNetCore (Swagger): para auxiliar no teste e visualização da API criada.

Newtonsoft.Json: para tratamento dos dados retornados da API The Movie DB, de json para objetos manipuláveis no .NET.
