CREATE TABLE tblCliente (
 cpf INT,
 nome VARCHAR(40) ,
 datanascimento datetime,
 CONSTRAINT pk_cpf PRIMARY KEY (cpf),
 );

  INSERT INTO tblCliente (cpf, nome, datanascimento )
VALUES
(111111, 'Daniel',  '1983-05-08 12:35:29.123 '),
(222222, 'Jarbas',  '1983-05-08 12:35:29.123 ');

CREATE TABLE tblModelo (
 codmod INT,
 Desc_2 VARCHAR(40),
 CONSTRAINT pk_codmod PRIMARY KEY (codmod),

 );

  INSERT INTO tblModelo (codmod, Desc_2)
VALUES
(1, 'Passat'),
(2, 'Ferrari');

CREATE TABLE tblPatio (
 num int,
 endereco VARCHAR(40),
 capacidade integer
 CONSTRAINT pk_num PRIMARY KEY (num),
 );

  INSERT INTO tblPatio (num, endereco, capacidade)
VALUES
(1, 'av paulista', 5),
(2, 'av faria lima', 15);

CREATE TABLE tblveiculos (
 Placa VARCHAR(8) NOT NULL,
 CONSTRAINT pk_Placa PRIMARY KEY (Placa),
 cor VARCHAR(40) NOT NULL,
 modelo_codmod INT NOT NULL,
 CONSTRAINT fk_modelo_codmod FOREIGN KEY(modelo_codmod) REFERENCES tblModelo (codmod) ON DELETE CASCADE,
 cliente_cpf INT NOT NULL,
 CONSTRAINT fk_cliente_cpf FOREIGN KEY(cliente_cpf) REFERENCES tblCliente (cpf) ON DELETE CASCADE
 );

 INSERT INTO tblveiculos (Placa, cor, modelo_codmod, cliente_cpf)
VALUES
('666', 'amarelo', 1, 111111),
('BTG-2022', 'azul', 2, 222222);

CREATE TABLE tblestaciona (
 cod INT,
 CONSTRAINT pk_cod PRIMARY KEY (cod),
 dtentrada VARCHAR(10) NOT NULL,
 dtsaida VARCHAR(10) NOT NULL,
 hsentrada VARCHAR(10) NOT NULL,
 hssaida VARCHAR(10) NOT NULL,
 patio_num INT NOT NULL,
 CONSTRAINT fk_patio_num FOREIGN KEY(patio_num) REFERENCES tblPatio (num) ON DELETE CASCADE,
 veiculo_placa VARCHAR(8) NOT NULL,
 CONSTRAINT fk_veiculo_placa FOREIGN KEY(veiculo_placa) REFERENCES tblveiculos (Placa) ON DELETE CASCADE
 );

 INSERT INTO tblestaciona (cod,dtentrada, dtsaida, hsentrada, hssaida, patio_num, veiculo_placa)
VALUES
(1, '01',  '01', '02', '03', 1, '666'),
(2, '01',  '01', '02', '03', 2, 'BTG-2022');

select * from tblveiculos
select * from tblestaciona
select * from tblCliente
-- resposta1
SELECT
    P.Placa,
    
    C.nome as nome
FROM
    tblveiculos P
INNER JOIN
  tblCliente C
ON P.cliente_cpf = C.cpf


--resposta 2

SELECT
    P.endereco,
    
    C.veiculo_placa as placa,
	C.dtentrada,
	C.dtsaida
FROM
    tblPatio P
INNER JOIN
  tblestaciona C
ON P.num = C.patio_num where c.veiculo_placa = 'BTG-2022'