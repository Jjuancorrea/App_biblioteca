create database dbs_biblioteca;
use dbs_biblioteca;

create table tbl_libros	
(
	PkCodigo varchar(10) primary key,
	Nombre varchar(80) not null,
	Autor varchar(10) not null,
	Fecha_publicacion varchar(60) not null,
	N_paginas int not null,
	Reseña varchar(1000) not null
);