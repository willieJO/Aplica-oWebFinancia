# 💰 Sistema de Gestão Financeira

Este projeto tem como objetivo desenvolver uma aplicação para controle financeiro pessoal, permitindo que os usuários registrem e acompanhem seus gastos. A solução será baseada em uma API robusta utilizando C# e ASP.NET Core, integrada a um front-end em React.

## 🚀 Tecnologias Utilizadas

O projeto será estruturado seguindo boas práticas de arquitetura e desenvolvimento, adotando tecnologias e padrões modernos:

- **React** – Front-end dinâmico e interativo.
- **C# & ASP.NET Core** – Back-end robusto e escalável.
- **MediatR** – Implementação do padrão CQRS para melhor organização da aplicação.
- **FluentAPI** – Mapeamento de entidades no banco de dados.
- **Domain-Driven Design (DDD)** – Arquitetura baseada em domínio para melhor modelagem do sistema.
- **ASP.NET Core Pipelines** – Middleware para otimizar requisições e segurança.
- **FluentValidator** – Validações elegantes e eficientes.

## 📌 Funcionalidades Principais

- 📊 **Registro e categorização de despesas**
- 📅 **Controle de receitas e despesas por período**
- 📈 **Geração de relatórios financeiros**
- 🛡️ **Autenticação e segurança de dados**
- 🔍 **Filtros inteligentes para análise de gastos**
- 🔗 **Integração com APIs externas para dados financeiros**

## 🏗️ Arquitetura do Projeto

O projeto segue uma estrutura baseada em **DDD (Domain-Driven Design)**, garantindo um código limpo, organizado e escalável:

📂 **Camadas:**
- `Domain` – Regras de negócio e entidades.
- `Application` – Casos de uso e handlers.
- `Infrastructure` – Persistência de dados e repositórios.
- `Presentation` – APIs e controllers.
- `Client` – Interface do usuário em React.
