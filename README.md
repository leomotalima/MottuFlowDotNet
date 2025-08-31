# MottuFlow – API REST(teste)
Linha de teste para workflow GitHub Actions
Linha de teste para disparar workflow Build and Test


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

Além disso, a API será integrada futuramente com o aplicativo mobile em desenvolvimento na disciplina de **Mobile Application Development**.

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core Minimal API
- Entity Framework Core
- Oracle Database
- Swagger (OpenAPI) para documentação

---

# 🚀 Como Executar o Projeto

# 1. Clone o repositório
```bash
git clone https://github.com/thejaobiell/MottuFlowDotNet.git
cd MottuFlowDotNet/MottuFlowDotNet
```

# 2. Instalar o 'dotnet-ef'
```bash
dotnet tool install --global dotnet-ef
```

# 3. Restaure os pacotes
```bash
dotnet restore
```

# 🔧 **4. Verifique ou configure a conexão com o banco**

* Edite o arquivo `appsettings.json` com a string de conexão certa.

```json
"ConnectionStrings": {
  "OracleDb": "User Id=<usuario>;Password=<senha>;Data Source=oracle.fiap.com.br:1521/orcl"
}
````

## 5. Criar as Migrations e Atualizar o Banco de Dados

Execute os comandos abaixo para gerar a migration inicial e aplicar as alterações no banco de dados:

```bash
dotnet ef migrations add Inicial
dotnet ef database update
```

### Possíveis erros e soluções:

* **Erro: Já existe uma migration criada**

  > Solução: Exclua a pasta `Migrations` completamente antes de gerar uma nova migration.

* **Erro ao aplicar `update` no banco de dados**

  > Solução: Execute o script SQL abaixo para remover todas as tabelas existentes e reiniciar o processo:

```sql
DROP TABLE "Funcionarios" CASCADE CONSTRAINT;
DROP TABLE "Status" CASCADE CONSTRAINT;
DROP TABLE "Patios" CASCADE CONSTRAINT;
DROP TABLE "Motos" CASCADE CONSTRAINT;
DROP TABLE "Cameras" CASCADE CONSTRAINT;
DROP TABLE "ArucoTags" CASCADE CONSTRAINT;
DROP TABLE "Localidades" CASCADE CONSTRAINT;
DROP TABLE "_EFMigrationsHistory" CASCADE CONSTRAINT;
```

Após isso, repita os comandos:

```bash
dotnet ef migrations add Inicial
dotnet ef database update
```

# 6. Execute a aplicação
```bash
dotnet run
```

# 7. Acesse a documentação Swagger
```txt
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

---


## 👥 Equipe de Desenvolvimento

- **João Gabriel Boaventura Marques e Silva** - RM554874 - 2TDSB2025
- **Léo Mota Lima** - RM557851 - 2TDSB2025
- **Lucas Leal das Chagas** - RM551124 - 2TDSB2025

Teste de análise inicial no SonarCloud

