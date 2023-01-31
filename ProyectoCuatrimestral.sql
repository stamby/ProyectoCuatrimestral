create database tp;

use tp;

create table especialidades (
    id int identity(1,1) primary key not null,
    nombre varchar(40) not null
);

create table medicos (
    id int identity(1,1) primary key not null,
    nombre varchar(40) not null,
    apellido varchar(40) not null,
    email varchar(40) not null,
    clave varchar(10) not null default '',
    especialidad_id int foreign key references especialidades(id)
);

create table pacientes (
    id int identity(1,1) primary key not null,
    nombre varchar(40) not null,
    apellido varchar(40) not null,
    email varchar(40) not null,
    clave varchar(10) not null default '',
    obra_social varchar(40) not null
);

create table turnos (
    id int identity(1,1) primary key not null,
    hora_desde datetime not null,
    hora_hasta datetime not null,
    medico_id int foreign key references medicos(id),
    paciente_id int foreign key references pacientes(id)
);

create index indice_turnos on turnos (
    hora_desde,
    hora_hasta,
    medico_id
);