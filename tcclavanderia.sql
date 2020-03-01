-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 01/03/2020 às 23:24
-- Versão do servidor: 10.1.37-MariaDB
-- Versão do PHP: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `tcclavanderia`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `cidade`
--

CREATE TABLE `cidade` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `uf` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `cidade`
--

INSERT INTO `cidade` (`id`, `nome`, `uf`) VALUES
(1, 'SÃO JOSÉ DO RIO PRETO', 'SP'),
(2, 'CIA NORTE', 'PR'),
(4, 'BIRIGUI', 'RJ');

-- --------------------------------------------------------

--
-- Estrutura para tabela `empresa`
--

CREATE TABLE `empresa` (
  `id` int(11) NOT NULL,
  `nome` int(150) NOT NULL,
  `cnpj` varchar(150) NOT NULL,
  `endereco` varchar(150) NOT NULL,
  `numero` varchar(10) NOT NULL,
  `bairro` varchar(150) NOT NULL,
  `cep` varchar(150) NOT NULL,
  `cidade_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura para tabela `ficha`
--

CREATE TABLE `ficha` (
  `id` int(11) NOT NULL,
  `lavanderia_id` int(11) NOT NULL,
  `data` datetime NOT NULL,
  `roupa_id` int(11) NOT NULL,
  `quantidade` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura para tabela `lavagem`
--

CREATE TABLE `lavagem` (
  `id` int(11) NOT NULL,
  `processo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `lavagem`
--

INSERT INTO `lavagem` (`id`, `processo`) VALUES
(2, 'RESINA SILICONADA'),
(3, 'HYPER DESTROYER'),
(4, 'CLEAN OZ');

-- --------------------------------------------------------

--
-- Estrutura para tabela `lavanderia`
--

CREATE TABLE `lavanderia` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `cnpj` varchar(50) DEFAULT NULL,
  `endereco` varchar(50) DEFAULT NULL,
  `numero` varchar(50) DEFAULT NULL,
  `bairro` varchar(50) DEFAULT NULL,
  `cep` varchar(50) DEFAULT NULL,
  `cidade_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `lavanderia`
--

INSERT INTO `lavanderia` (`id`, `nome`, `cnpj`, `endereco`, `numero`, `bairro`, `cep`, `cidade_id`) VALUES
(1, 'TESTE', '123', 'MAESTRO', '112', 'ALAMEDA', '212', 0),
(4, 'qwqw', '444433', 'wwqwqw', '1212', 'wdsds', '11121', 0),
(5, 'www', '221221', 'ww', '21212', 'ww', '121', 0),
(10, 'w', '32323', 'w', '32', 'w', '1', 0),
(11, 'master', 'sasasa', 'asas', 'sasasas', 'sasas', 'sasasas', 0),
(12, 'teste', 'teteetete', 'tet', 'tetetett', 'tetet', 'tete', 0),
(13, 'www', 'wwww', 'ww', 'ww', 'ww', 'ww', 0),
(14, 'gg', 'gggg', 'gg', 'gg', 'gg', 'gg', 0),
(17, 'NEW JEANS', '1212121', 'RUA 13', '22121', 'CENTRO', '221212', 0),
(18, 'PLUMA', '11', 'QQ', '11', 'QQ', '11', 4),
(19, 'NEW JEANS', '997977', 'RUA 34', '321', 'ALORADA', '1233434343', 1),
(20, 'RIO PRETO LAVANDERIA', '221212', 'RRE', '12', 'RRER', '2212', 1);

-- --------------------------------------------------------

--
-- Estrutura para tabela `roupa`
--

CREATE TABLE `roupa` (
  `id` int(11) NOT NULL,
  `tipo_id` int(11) NOT NULL,
  `ano` varchar(5) NOT NULL,
  `modelo` varchar(50) NOT NULL,
  `tecido_id` int(11) NOT NULL,
  `estacao` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `roupa`
--

INSERT INTO `roupa` (`id`, `tipo_id`, `ano`, `modelo`, `tecido_id`, `estacao`) VALUES
(1, 2, '2000', '200U', 4, 'PRIMAVERA'),
(3, 2, '2020', '658U', 4, 'VERÃO'),
(4, 2, '2020', '500U', 1, 'PRIMAVERA/VERÃO'),
(5, 2, '2019', '300U', 4, 'PRIMAVERA'),
(6, 2, '2018', '54I', 2, 'PRIMAVERA'),
(9, 2, '2020', 'R547', 1, 'OUTONO'),
(10, 2, '98', '987', 4, 'PRIMAVERA'),
(11, 1, '98', '89Y', 2, 'PRIMAVERA/VERÃO'),
(12, 1, '98', '89Y', 2, 'PRIMAVERA/VERÃO'),
(14, 2, '32', '3232T', 2, 'PRIMAVERA'),
(16, 1, '32', '323R', 4, 'PRIMAVERA');

-- --------------------------------------------------------

--
-- Estrutura para tabela `roupa_lavagem`
--

CREATE TABLE `roupa_lavagem` (
  `id` int(11) NOT NULL,
  `roupa_id` int(11) NOT NULL,
  `lavagem_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `roupa_lavagem`
--

INSERT INTO `roupa_lavagem` (`id`, `roupa_id`, `lavagem_id`) VALUES
(1, 1, 4),
(4, 4, 1),
(5, 4, 1),
(6, 4, 1),
(32, 8, 4),
(33, 8, 3),
(34, 8, 2),
(35, 8, 2),
(36, 8, 3),
(41, 10, 4),
(42, 10, 3),
(43, 10, 2),
(47, 12, 3),
(48, 12, 3),
(49, 12, 3),
(50, 13, 3),
(51, 13, 2),
(52, 13, 4),
(53, 14, 4),
(54, 14, 3),
(55, 14, 2),
(84, 5, 4),
(85, 5, 4),
(86, 5, 4),
(93, 6, 2),
(94, 6, 2),
(95, 6, 2),
(102, 9, 4),
(103, 9, 3),
(104, 9, 2),
(108, 16, 4),
(109, 16, 3);

-- --------------------------------------------------------

--
-- Estrutura para tabela `tecido`
--

CREATE TABLE `tecido` (
  `id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `composicao` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tecido`
--

INSERT INTO `tecido` (`id`, `nome`, `composicao`) VALUES
(1, 'OREGON BLACK', '80% ALGODÃO - 10% ELASTANO - 10% POLIÉSTER'),
(2, 'OREGON AZUL ', '80% ALGODÃO - 10% ELASTANO - 10% POLIESTER '),
(4, 'GARCEZ', '98% ALGODÃO - 2% ELASTANO');

-- --------------------------------------------------------

--
-- Estrutura para tabela `tipo`
--

CREATE TABLE `tipo` (
  `id` int(11) NOT NULL,
  `nome` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Despejando dados para a tabela `tipo`
--

INSERT INTO `tipo` (`id`, `nome`) VALUES
(1, 'CALÇA'),
(2, 'BERMUDA'),
(3, 'SHORT'),
(4, 'JAQUETA'),
(5, 'SAIA');

-- --------------------------------------------------------

--
-- Estrutura para tabela `valor_lavagem`
--

CREATE TABLE `valor_lavagem` (
  `id` int(11) NOT NULL,
  `lavagem_id` int(11) NOT NULL,
  `lavanderia_id` int(11) NOT NULL,
  `valor` float NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Índices de tabelas apagadas
--

--
-- Índices de tabela `cidade`
--
ALTER TABLE `cidade`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `empresa`
--
ALTER TABLE `empresa`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `ficha`
--
ALTER TABLE `ficha`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `lavagem`
--
ALTER TABLE `lavagem`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `lavanderia`
--
ALTER TABLE `lavanderia`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `roupa`
--
ALTER TABLE `roupa`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Índices de tabela `roupa_lavagem`
--
ALTER TABLE `roupa_lavagem`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `tecido`
--
ALTER TABLE `tecido`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `tipo`
--
ALTER TABLE `tipo`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `valor_lavagem`
--
ALTER TABLE `valor_lavagem`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT de tabelas apagadas
--

--
-- AUTO_INCREMENT de tabela `cidade`
--
ALTER TABLE `cidade`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `empresa`
--
ALTER TABLE `empresa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `ficha`
--
ALTER TABLE `ficha`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `lavagem`
--
ALTER TABLE `lavagem`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `lavanderia`
--
ALTER TABLE `lavanderia`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT de tabela `roupa`
--
ALTER TABLE `roupa`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de tabela `roupa_lavagem`
--
ALTER TABLE `roupa_lavagem`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=110;

--
-- AUTO_INCREMENT de tabela `tecido`
--
ALTER TABLE `tecido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `tipo`
--
ALTER TABLE `tipo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de tabela `valor_lavagem`
--
ALTER TABLE `valor_lavagem`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
