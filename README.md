# MottuFlow – API REST

Esta API REST foi criada como parte do projeto **MottuFlow**, desenvolvido nas disciplinas de **Advanced Business Development with .NET**. Seu objetivo é oferecer funcionalidades completas de **CRUD** para o gerenciamento de:

* Funcionários
* Pátios
* Motos
* Câmeras
* ArUco Tags
* Status das motos
* Localidades

No contexto da disciplina de **IoT**, estamos desenvolvendo uma solução de **visão computacional** que será utilizada em câmeras para identificar motocicletas por meio de **ArUco Tags**.
👉 [Link para uma imagem de exemplo no Google](https://docs.opencv.org/4.x/singlemarkersdetection.jpg)

A API será responsável pela comunicação com o banco de dados criado na disciplina de **Database**, facilitando o envio e recebimento de informações da infraestrutura do projeto.

Além disso, a API será integrada futuramente com o aplicativo mobile em desenvolvimento na disciplina de **Desenvolvimento Mobile**.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core Minimal API
- Entity Framework Core
- Oracle Database
- Swagger (OpenAPI) para documentação

---

## 🔌 Conexão com o Banco de Dados

A conexão com o banco Oracle deve ser configurada no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "OracleDb": "User Id=usuario;Password=senha;Data Source=oracle.fiap.com.br:1521/orcl"
}
````

---

## 🚀 Como Executar o Projeto

1. **Clone o repositório:**

```bash
git clone https://github.com/thejaobiell/MottuFlowDotNet.git
cd mottuflow-api
```

2. **Restaure os pacotes:**

```bash
dotnet restore
```

3. **Execute a aplicação:**

```bash
dotnet run
```

4. Acesse a documentação interativa Swagger em:

```
http://localhost:5175/swagger
```
---

## 📂 Endpoints Disponíveis

Os principais endpoints estão organizados por entidade:

---

### 🧑 Funcionários

- `GET /funcionarios` — Lista todos os funcionários
- `GET /funcionarios/{id}` — Busca um funcionário pelo ID
- `GET /funcionarios/buscar?cpf={cpf}` — Busca funcionário pelo CPF
- `POST /funcionarios` — Cadastra um novo funcionário
- `PUT /funcionarios/{id}` — Atualiza um funcionário existente
- `DELETE /funcionarios/{id}` — Remove um funcionário

---

### 🏢 Pátios

- `GET /patios` — Lista todos os pátios
- `GET /patios/{id}` — Busca um pátio pelo ID
- `POST /patios` — Cadastra um novo pátio
- `PUT /patios/{id}` — Atualiza um pátio existente
- `DELETE /patios/{id}` — Remove um pátio

---

### 🛵 Motos

- `GET /motos` — Lista todas as motos
- `GET /motos/{id}` — Busca uma moto pelo ID
- `POST /motos` — Cadastra uma nova moto
- `PUT /motos/{id}` — Atualiza uma moto existente
- `DELETE /motos/{id}` — Remove uma moto

---

### 📷 Câmeras

- `GET /cameras` — Lista todas as câmeras
- `GET /cameras/{id}` — Busca uma câmera pelo ID
- `POST /cameras` — Cadastra uma nova câmera
- `PUT /cameras/{id}` — Atualiza uma câmera existente
- `DELETE /cameras/{id}` — Remove uma câmera

---

### 🧩 ArucoTags

- `GET /arucotags` — Lista todas as ArucoTags
- `GET /arucotags/{id}` — Busca uma ArucoTag pelo ID
- `POST /arucotags` — Cadastra uma nova ArucoTag
- `PUT /arucotags/{id}` — Atualiza uma ArucoTag existente
- `DELETE /arucotags/{id}` — Remove uma ArucoTag

---

### ⚙️ Status das Motos

- `GET /statusmotos` — Lista todos os status
- `GET /statusmotos/{id}` — Busca um status pelo ID
- `POST /statusmotos` — Cadastra um novo status
- `PUT /statusmotos/{id}` — Atualiza um status existente
- `DELETE /statusmotos/{id}` — Remove um status

---

### 🌍 Localidades

- `GET /localidades` — Lista todas as localidades
- `GET /localidades/{id}` — Busca uma localidade pelo ID
- `POST /localidades` — Cadastra uma nova localidade
- `PUT /localidades/{id}` — Atualiza uma localidade existente
- `DELETE /localidades/{id}` — Remove uma localidade

---

## 📌 Observações

* Existe um arquivo **POST.txt** com templates para testar a api;
* O projeto utiliza o padrão **DTO** para encapsulamento e segurança dos dados;
* Os dados trafegam via JSON;
* Ideal para uso interno de sistemas de monitoramento e controle de frotas de motos;

---


## 👥 Equipe de Desenvolvimento

- **João Gabriel Boaventura Marques e Silva** - RM554874 - 2TDSB2025
- **Léo Mota Lima** - RM557851 - 2TDSB2025
- **Lucas Leal das Chagas** - RM551124 - 2TDSB2025
