# Hexagonal Architecture

## **Descrição**
Este projeto segue os princípios da **Arquitetura Hexagonal**, isolando o núcleo de lógica de negócios do restante do sistema e permitindo adaptações para diferentes tecnologias.

---

## **Motivos para usar Hexagonal**
1. **Independência de tecnologia**:
   - Fácil troca de frameworks ou tecnologias.
2. **Testabilidade**:
   - Núcleo de negócios pode ser testado isoladamente.
3. **Manutenção**:
   - Define responsabilidades claras entre o núcleo e infraestrutura.
4. **Flexibilidade**:
   - Adaptações específicas podem ser implementadas para diferentes necessidades.

---

## **Comando Docker para Banco de Dados**
Utilizamos o SQL Server como banco de dados. Execute o seguinte comando para configurá-lo:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Educa123!Senha" \
-p 1433:1433 --name sqlserver \
-d mcr.microsoft.com/mssql/server:2019-latest
```
Script para criar a tabela

Após configurar o banco de dados, execute o script SQL abaixo para criar a tabela Livros:
```
CREATE TABLE Livros (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Titulo NVARCHAR(255) NOT NULL,
    Autor NVARCHAR(255) NOT NULL,
    Categoria NVARCHAR(100) NOT NULL,
    Disponivel BIT NOT NULL
);
```

Camadas do Projeto

1. Core

	•	Contém a lógica de negócios e casos de uso.
	•	Domain: Entidades e interfaces (e.g., Livro.cs, IRepositoryPort.cs).
	•	Application: Casos de uso (e.g., CadastrarLivroUseCase.cs).

2. Adapters

	•	Implementa as portas e conecta o núcleo ao mundo externo.
	•	Persistence: Banco de dados (e.g., LivroRepositoryAdapter.cs).
	•	API: Controladores HTTP (e.g., LivroController.cs).

Como rodar

	1.	Configure o banco de dados usando o comando Docker acima.
	2.	Execute o projeto no terminal:

dotnet run


	3.	Acesse os endpoints da API (e.g., via Swagger em http://localhost:5000/swagger).

Se precisar de mais ajustes ou informações adicionais, é só avisar! 😊