create database DBFinal;

go

use DBFinal;

create table Clase(
Id int primary key identity(1,1),
Nombre nvarchar(20) not null unique,
Descripcion nvarchar(100)
);

create table CaracteristicaVariable(
Id int primary key identity(1,1),
Nombre nvarchar(20) not null unique,
Descripcion nvarchar(100)
);

create table Raza(
Id int primary key identity(1,1),
Nombre nvarchar(20) not null unique,
Descripcion nvarchar(100),
CaraVaId int foreign key references CaracteristicaVariable(Id)
);

create table Personaje(
Id int primary key identity(1,1),
Nombre nvarchar(30) not null,
Nivel int not null,
Fuerza int not null,
Destreza int not null,
Constitucion int not null,
Inteligencia int not null,
Sabiduria int not null,
Carisma int not null,
ImagenPers image NULL,
ClaseId int not null foreign key references Clase(Id),
RazaId int not null foreign key references Raza(Id)
);

create table HabilidadEspecial(
Id int primary key identity(1,1),
Nombre nvarchar(20) not null unique,
Descripcion nvarchar(100)
);

create table PersonajeCaracteristica(
IdPer int not null,
IdCar int not null,
Primary Key(IdPer, IdCar),
foreign key(IdPer) references Personaje(Id),
foreign key(IdCar) references CaracteristicaVariable(Id),
Valor int not null,
);

create table PersonajeHabilidadEspecial(
IdPer int not null,
IdHe int not null,
Primary Key(IdPer, IdHe),
foreign key(IdPer) references Personaje(Id),
foreign key(IdHe) references HabilidadEspecial(Id),
);

create table ClaseHabilidadEspecial(
IdClas int not null,
IdHe int not null,
Primary Key(IdClas, IdHe),
foreign key(IdClas) references Clase(Id),
foreign key(IdHe) references HabilidadEspecial(Id),
);

use DBFinal;

-- CARGA DE DATOS A LA DB.

use DBFinal;

-- Clases
insert into Clase values ('Guerrero', 'Descripcion clase Guerrero');
insert into Clase values ('Mago', 'Descripcion clase Mago');
insert into Clase values ('Sacerdote', 'Descripcion clase Sacerdote');
insert into Clase values ('Ladron', 'Descripcion clase Ladrón');

-- Característica Variable
insert into CaracteristicaVariable values ('CaractVariable1', 'Descripcion característica variable CaractVariable1');
insert into CaracteristicaVariable values ('CaractVariable2', 'Descripcion característica variable CaractVariable2');
insert into CaracteristicaVariable values ('CaractVariable3', 'Descripcion característica variable CaractVariable3');
insert into CaracteristicaVariable values ('CaractVariable4', 'Descripcion característica variable CaractVariable4');
insert into CaracteristicaVariable values ('CaractVariable5', 'Descripcion característica variable CaractVariable5');

-- Razas
insert into Raza values ('Elfo', 'Descripcion raza Elfo', 3);
insert into Raza values ('Enano', 'Descripcion raza Enano', 4);
insert into Raza values ('Hobbit', 'Descripcion raza Hobbit', 1);
insert into Raza values ('Humano', 'Descripcion raza Humano', 5);
insert into Raza values ('Orco', 'Descripcion raza Orco', 2);

-- Habilidad Especial
insert into HabilidadEspecial values ('Elasticidad', 'Descripcion Habilidad Especial Elasticidad');
insert into HabilidadEspecial values ('Astucia', 'Descripcion Habilidad Especial Astucia');
insert into HabilidadEspecial values ('Bondad', 'Descripcion Habilidad Especial Bondad');
insert into HabilidadEspecial values ('Maldad', 'Descripcion Habilidad Especial Maldad');
insert into HabilidadEspecial values ('Paciencia', 'Descripcion Habilidad Especial Paciencia');

use DBFinal;

-- Personajes
insert into Personaje values ('Gerardo', 2, 4, 5, 7, 8, 4, 4, null, 1, 1);
insert into Personaje values ('Facundo', 3, 5, 6, 8, 9, 5, 5, null, 2, 1);
insert into Personaje values ('Florencia', 1, 3, 4, 6, 7, 3, 3, null, 3, 2);
insert into Personaje values ('Emiliano', 8, 7, 9, 8, 3, 6, 3, null, 4, 3);
insert into Personaje values ('Octavio', 2, 1, 2, 3, 6, 5, 9, null, 2, 3);

-- Características de personajes.

-- Personaje 1
insert into PersonajeCaracteristica values (1, 1, 4);
insert into PersonajeCaracteristica values (1, 2, 2);
insert into PersonajeCaracteristica values (1, 3, 5);
insert into PersonajeCaracteristica values (1, 4, 3);
insert into PersonajeCaracteristica values (1, 5, 1);

-- Personaje 2
insert into PersonajeCaracteristica values (2, 1, 2);
insert into PersonajeCaracteristica values (2, 2, 4);
insert into PersonajeCaracteristica values (2, 3, 3);
insert into PersonajeCaracteristica values (2, 4, 1);
insert into PersonajeCaracteristica values (2, 5, 2);

-- Personaje 3
insert into PersonajeCaracteristica values (3, 1, 3);
insert into PersonajeCaracteristica values (3, 2, 4);
insert into PersonajeCaracteristica values (3, 3, 3);
insert into PersonajeCaracteristica values (3, 4, 5);
insert into PersonajeCaracteristica values (3, 5, 5);

-- Personaje 4
insert into PersonajeCaracteristica values (4, 1, 1);
insert into PersonajeCaracteristica values (4, 2, 5);
insert into PersonajeCaracteristica values (4, 3, 3);
insert into PersonajeCaracteristica values (4, 4, 1);
insert into PersonajeCaracteristica values (4, 5, 2);

-- Personaje 5
insert into PersonajeCaracteristica values (5, 1, 3);
insert into PersonajeCaracteristica values (5, 2, 5);
insert into PersonajeCaracteristica values (5, 3, 4);
insert into PersonajeCaracteristica values (5, 4, 1);
insert into PersonajeCaracteristica values (5, 5, 2);

