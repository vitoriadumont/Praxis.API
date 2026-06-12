# Praxis.API

Sistema acadêmico desenvolvido em ASP.NET Core Web API para gerenciamento de alunos, professores, disciplinas e registros acadêmicos.

---

# Sobre o Projeto

O Praxis.API é uma API REST desenvolvida para a disciplina de Projeto 1 do curso de Engenharia de Software.

O sistema tem como objetivo realizar o gerenciamento acadêmico de uma instituição de ensino, permitindo:

- cadastro de alunos;
- cadastro de professores;
- gerenciamento de disciplinas;
- controle de registros acadêmicos;
- controle de notas e frequência;
- cálculo automático de aprovação/reprovação.

O projeto foi desenvolvido utilizando arquitetura em camadas, Entity Framework Core e PostgreSQL.

---

# Tecnologias Utilizadas

- ASP.NET Core Web API
- C#
- Entity Framework Core
- PostgreSQL
- Swagger/OpenAPI
- Git/GitHub

---

# Arquitetura do Projeto

O sistema foi desenvolvido utilizando arquitetura em camadas:

```text
Controllers
↓
Services
↓
Repositories
↓
Entity Framework Core
↓
PostgreSQL
```

## Estrutura de Pastas

```text
Praxis.API
│
├── Controllers
├── Data
├── DTOs
├── Migrations
├── Models
├── Repositories
├── Services
├── appsettings.json
├── Program.cs
├── README.md
```

---

# Funcionalidades

## Alunos

- cadastrar aluno
- listar alunos
- buscar aluno por ID
- atualizar aluno
- remover aluno

## Professores

- cadastrar professor
- listar professores
- buscar professor por ID
- atualizar professor
- remover professor

## Disciplinas

- cadastrar disciplina
- listar disciplinas
- buscar disciplina por ID
- atualizar disciplina
- remover disciplina

## Registro Acadêmico

- matricular aluno em disciplina
- registrar nota
- registrar frequência
- calcular status de aprovação

---

# Regras de Negócio

O sistema calcula automaticamente o status do aluno:

| Condição | Resultado |
|---|---|
| Nota >= 7 e Frequência >= 75 | Aprovado |
| Caso contrário | Reprovado |

---

# Relacionamentos do Banco

## Professor → Disciplinas

Relacionamento 1:N

Um professor pode possuir várias disciplinas.

---

## Aluno → Disciplinas

Relacionamento N:N através da entidade RegistroAcademico.

---

# Pré-requisitos

Antes de executar o projeto, é necessário possuir instalado:

- .NET 8 SDK
- PostgreSQL
- Visual Studio Code ou Visual Studio
- Git

---

# Instalação do Projeto

## 1. Clonar o repositório

```bash
git clone https://github.com/vitoriadumont/Praxis.API.git
```

---

## 2. Acessar pasta do projeto

```bash
cd Praxis.API
```

---

## 3. Restaurar dependências

```bash
dotnet restore
```

---

# Configuração do Banco de Dados

## 1. Criar banco PostgreSQL

No PostgreSQL:

```sql
CREATE DATABASE praxis;
```

---

## 2. Configurar string de conexão

Editar o arquivo:

```text
appsettings.json
```

Configurar:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=praxis;Username=postgres;Password=SUA_SENHA"
}
```

---

## 3. Executar migrations

```bash
dotnet ef database update
```

---

# Executando o Projeto

## Rodar API

```bash
dotnet run
```

---

# Swagger

Após executar o projeto:

```text
http://localhost:5027/swagger
```

---

# Endpoints da API

## Alunos

| Método | Endpoint |
|---|---|
| GET | /api/alunos |
| GET | /api/alunos/{id} |
| POST | /api/alunos |
| PUT | /api/alunos/{id} |
| DELETE | /api/alunos/{id} |

---

## Professores

| Método | Endpoint |
|---|---|
| GET | /api/professores |
| GET | /api/professores/{id} |
| POST | /api/professores |
| PUT | /api/professores/{id} |
| DELETE | /api/professores/{id} |

---

## Disciplinas

| Método | Endpoint |
|---|---|
| GET | /api/disciplinas |
| GET | /api/disciplinas/{id} |
| POST | /api/disciplinas |
| PUT | /api/disciplinas/{id} |
| DELETE | /api/disciplinas/{id} |

---

## Registro Acadêmico

| Método | Endpoint |
|---|---|
| GET | /api/registroacademico |
| GET | /api/registroacademico/{id} |
| POST | /api/registroacademico |
| DELETE | /api/registroacademico/{id} |

---

# Exemplos de Requisição

## Criar Aluno

POST `/api/alunos`

```json
{
  "nome": "João Silva",
  "matricula": "2025001",
  "curso": "Engenharia de Software"
}
```

---

## Criar Professor

POST `/api/professores`

```json
{
  "nome": "Carlos Henrique",
  "email": "carlos@praxis.com",
  "departamento": "Tecnologia"
}
```

---

## Criar Disciplina

POST `/api/disciplinas`

```json
{
  "nome": "Banco de Dados",
  "codigo": "BD101",
  "professorId": 1
}
```

---

## Criar Registro Acadêmico

POST `/api/registroacademico`

```json
{
  "alunoId": 1,
  "disciplinaId": 1,
  "nota": 8.5,
  "frequencia": 92
}
```

---

# Principais Aprendizados

Durante o desenvolvimento do projeto, foram aplicados conceitos importantes de engenharia de software e desenvolvimento backend:

- arquitetura em camadas;
- APIs REST;
- modelagem relacional;
- Entity Framework Core;
- PostgreSQL;
- injeção de dependência;
- Repository Pattern;
- Service Layer;
- DTO Pattern.

---

# Integrantes do Grupo

- Amanda Ribeiro de Oliveira
- Bruna Ferreira de Oliveira Santana
- Vitória Luisa Dumont

---

# Licença

Projeto desenvolvido exclusivamente para fins acadêmicos.