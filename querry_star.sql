CREATE TABLE clientes(
	id SMALLINT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(40) NOT NULL,
	cpf SMALLINT(11) UNIQUE NOT NULL,
	telefone SMALLINT(11),
	endereco VARCHAR(50),
	uf VARCHAR(02),
	cep SMALLINT(08),
	data_nascimento DATE,
	nome_resp VARCHAR(40) NULL
);

CREATE TABLE produtos(
	idProduto SMALLINT PRIMARY KEY,
	nome_pr VARCHAR(30),
	val_uni DECIMAL(9,2),
	tipo VARHCAR(20)
);

CREATE TABLE estoque(
	cd_prod SMALLINT REFERENCES produtos(idProduto),
	val_uni DECIMAL(9,2),
	qnt_prod SMALLINT
);

CREATE TABLE pedido(
	num_ped SMALLINT PRIMARY KEY,
	prazo_entr SMALLINT NOT NULL,
	cd_cli SMALLINT NOT NULL REFERENCES cliente(id),
	cd_prod SMALLINT NOT NULL REFERENCES produtos(idProduto)
);