<h1 align="center">📚 Mensagery Library</h1>

---

## 📖 Sobre o Projeto

Mensagery Lib + Docker + Unit Testing

Este projeto demonstra o uso de uma biblioteca de mensageria baseada em **RabbitMQ**. Ele inclui:

- Uma API com endpoints que executam as principais ações do RabbitMQ.
- Uma biblioteca de testes unitários.
- Empacotamento via **NuGet**.

---

## 🚀 Funcionalidades

- Envio e recebimento de mensagens via RabbitMQ
- Integração com API REST
- Testes automatizados
- Containerização com Docker
- Distribuição via NuGet

---

## 📦 Instalação via NuGet

A biblioteca está disponível via NuGet:

https://www.nuget.org/packages/Mensagery.Lib.Rabbit.DCF/1.0.0
---

## 🐳 Docker

Para subir o Docker desta aplicação,dentro da pasta MensageryLib utilize:
docker-compose up
isso subirá um container do RabbitMq
A implementação do projeto ApiMensagery ainda esta em andamento.
È necessario rodar o programa via IIS Express ou algum outro compilador.
Caso tenha o RabbitMq instalado, é possivel subir o container da imagem da ApiMensagery, mudando os endereços necessarios.