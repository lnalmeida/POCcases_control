# API de Controle de Casos - Prova de Conceito

Esta é uma API construída em C# e MongoDB que tem como objetivo fornecer uma prova de conceito para um sistema de controle de casos para um serviço de implementação e manutenção de tags do Google Ads e Analytics. A API oferece três endpoints principais:

## Endpoints

### 1. `GET /api/casos/all`

Este endpoint retorna todos os casos armazenados no MongoDB.

#### Exemplo de uso:

```
GET /api/casos/all
```

### 2. `GET /api/casos/search`

Este endpoint permite buscar um caso específico com base em parâmetros de consulta. Os parâmetros de consulta são `field` (nome do campo) e `value` (valor registrado no respectivo campo). A API retornará todos os casos que correspondem aos critérios de consulta.

#### Exemplo de uso:
```
GET /api/casos/search?field=nome&value=exemplo
```

### 3. `POST /api/casos/add`

Este endpoint permite a inserção de um novo documento contendo os dados de um caso no MongoDB. Os dados do caso devem ser fornecidos no corpo da solicitação em formato JSON.

#### Exemplo de uso:

```
POST /api/casos/add

Corpo da solicitação:
{
  "ldap": "string",
  "dataAtendimento": "string",
  "numeroCaso": "string",
  "statusAtendimento": "string",
  "novoStatus": "string",
  "tarefas": "string",
  "print": "string",
  "hora": "string",
  "time": "string"
}
```

## Pré-requisitos

Antes de utilizar esta API, certifique-se de ter os seguintes pré-requisitos:

- Instalação do MongoDB
- Ambiente de desenvolvimento C# configurado

## Configuração

1. Clone este repositório em sua máquina local:

```
git clone https://github.com/seu-usuario/api-controle-casos.git
```

2. Acesse o diretório do projeto:

```
cd api-controle-casos
```

3. Execute a aplicação:

```
dotnet run
```

A API estará disponível em `http://localhost:5000`.

## Uso

Você pode utilizar qualquer cliente HTTP (por exemplo, Postman, cURL) para interagir com a API.

Certifique-se de definir as variáveis de ambiente apropriadas para a conexão com o MongoDB, como a URL do servidor e as credenciais de acesso.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para enviar pull requests para melhorias ou correções.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

Este é um projeto de prova de conceito da API de Controle de Casos. Se você tiver alguma dúvida ou precisar de assistência, entre em contato conosco em [l.n.almeida.ti@gmail.com](mailto:l.n.almeida.ti@gmail.com).
