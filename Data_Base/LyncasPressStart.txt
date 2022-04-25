--Cria tabela pessoa
CREATE TABLE Pessoa
(
	idPessoa INT IDENTITY(1,1) PRIMARY KEY not null,
	nome VARCHAR (100) not null,
	sobrenome varchar (100) not null,
	email varchar (100) not null,
	telefone varchar(15) not null,
	data_de_nascimento date not null
);

--Cria tabela Autenticação
CREATE TABLE Autenticacao
(
	id int IDENTITY(1,1) PRIMARY KEY not null,
	idPessoa INT not null,
	senha VARCHAR (50) not null,
	status BIT
);

--Adiciona constraint
alter table Autenticacao
	add constraint fk_Pessoa Foreign Key (idPessoa) references Pessoa (idPessoa)
	ON DELETE CASCADE
    ON UPDATE CASCADE;

--Popula tabelas Pessoa e Autenticação, respectivamente
INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Maria', 'Antonieta', 'maria@gmail.com', '(12) 1234-5678', '01/01/1991');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'abcde1', 1);

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Fernanda', 'Maria', 'fernanda@gmail.com', '(23) 2345-6789', '02/02/2002');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'teste1', 0);

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('José', 'Hernandez', 'jose@gmail.com', '(34) 5678-9012', '03/03/1973');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'senha9', 1);

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Pedro', 'Emanuel', 'pedro@hotmail.com', '(45) 96789-0123', '13/03/1973');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'senha5', 1);

--Visualiza tabela Pessoa
SELECT * FROM Pessoa;

--Visualiza tabela autenticação
SELECT * FROM Autenticacao;

--Atualiza o cadastro da pessoa com idPessoa de nº. 4
UPDATE Pessoa
	SET sobrenome =  'Emannuel'
	WHERE idPessoa = 4;

--Insere novo registro nas tabelas Pessoa e Autenticação
INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Jorge', 'Caetano', 'jorge@hotmail.com', '(21) 9876-5432', '01/01/1960');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'se1la', 0);

--Exclui os registros com e-mail do servidor hotmail
DELETE FROM Pessoa
	WHERE email like '%@hotmail.com';

--Insere novo registro nas tabelas Pessoa e Autenticação
INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Mario', 'Silva', 'mario@yahoo.com', '(41) 99999-9999', '01/10/1960');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'issoeh1teste', 1);

--Deleta registros com a data de nascimento menor que 01/01/1970
DELETE FROM Pessoa
	where data_de_nascimento < '01-01-1970';

--Insere novos registros nas tabelas Pessoa e Autenticação
INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Joaquim', 'Eduardo', 'joaquim@gmail.com', '(51) 3578-1598', '01/12/1980'),
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'abc123', 1);

INSERT INTO Pessoa (nome, sobrenome, email, telefone, data_de_nascimento)
	VALUES
	('Renato', 'Junior', 'renato.j@gmail.com', '(47) 99341-3578', '11/05/1995');
INSERT INTO Autenticacao (idPessoa, senha, status)
	VALUES
	(SCOPE_IDENTITY(), 'asdf12', 0);

--Select fazendo o inner join das tabelas Pessoa e Autenticação exibindo os registros com status = 1
SELECT Pessoa.idPessoa, Pessoa.nome, Pessoa.sobrenome, Autenticacao.status
FROM Pessoa INNER JOIN Autenticacao ON Autenticacao.idPessoa =  Pessoa.idPessoa
WHERE status = 1;


--drop table pessoa;
--drop table autenticacao;