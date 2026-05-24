# NOUS - API de Gestão (.NET) | Sprint 4

**Integrantes:**
- Guilherme Costeira Braganholo — RM560628
- Julio Cesar Dias Vilella — RM560494
- Gabriel Nakamura Ogata — RM560671

---

## Descrição do Projeto

A API de Gestão do NOUS foi desenvolvida em ASP.NET Core para apoiar o painel administrativo da plataforma, permitindo acompanhar indicadores educacionais e emocionais dos alunos. Na Sprint 4, a aplicação foi evoluída com monitoramento, observabilidade, logging estruturado e testes automatizados seguindo o padrão AAA.

---

## Funcionalidades Implementadas

- Autenticação com JWT.
- Endpoints protegidos para acesso ao dashboard.
- Documentação automática com Swagger.
- Health Checks da API, prontidão, banco de dados e serviços externos.
- Logging estruturado com Serilog em console e arquivo.
- Correlação de requisições com header `X-Correlation-Id`.
- Observabilidade com OpenTelemetry para tracing e métricas.
- Endpoint de snapshot de métricas.
- Testes unitários com xUnit, Moq e padrão AAA.
- Testes de integração com `WebApplicationFactory`.

---

## Autenticação

Endpoint de login:

```http
POST /api/Auth/login
```

Exemplo de requisição:

```json
{
  "userName": "admin",
  "password": "Admin@123"
}
```

Use o token retornado no Swagger ou nas requisições HTTP:

```http
Authorization: Bearer SEU_TOKEN
```

---

## Endpoints Principais

### Dashboard

```http
GET /api/Dashboard/overview
GET /api/Dashboard/risk-students
```

### Health Checks

```http
GET /health
GET /health/ready
```

O endpoint `/health` retorna o status geral da API e os checks configurados:

- `api`: saúde básica da API.
- `database`: conectividade com banco de dados validada para a Sprint 4.
- `external-services`: disponibilidade de serviços externos.
- `ready`: prontidão da aplicação.

### Métricas

```http
GET /api/Metrics
```

A aplicação também coleta tracing e métricas com OpenTelemetry, incluindo instrumentação de requisições ASP.NET Core, chamadas HTTP e runtime.

---

## Logging e Observabilidade

O Serilog registra logs estruturados em:

- Console da aplicação.
- Arquivos na pasta `logs/`, com rotação diária.

Cada requisição recebe ou reutiliza um `X-Correlation-Id`, facilitando o rastreamento dos logs.

---

## Documentação Swagger

Com a aplicação rodando, acesse:

```text
http://localhost:5080/swagger
```

---

## Como Executar o Projeto

Restaurar dependências:

```bash
dotnet restore
```

Executar a aplicação:

```bash
dotnet run --project src/Nous.Management.Api
```

Acessar o Swagger:

```text
http://localhost:5080/swagger
```

---

## Como Executar os Testes

Executar todos os testes:

```bash
dotnet test
```

Os testes estão organizados no projeto `tests/Nous.Management.Tests` e cobrem:

- Testes unitários da camada de serviço.
- Testes unitários de controller com Moq.
- Testes de integração dos endpoints com `WebApplicationFactory`.
- Cenários de sucesso, autenticação e erro.




VIDEO: https://www.youtube.com/watch?v=y3Gp0zc8jjo
