IF OBJECT_ID (N'TipoEvento', N'U') IS NULL 
BEGIN
	create table TipoEvento(
	IDTipoEvento int identity constraint PK_TipoEvento primary key,
	Descripcion nvarchar(50),
	Estado int
	)
	PRINT 'Table TipoEvento WAS CREATED !'
END
go
create table TipoUsuario(
IDTipo int identity constraint PK_TipoUsurio primary key,
Descripcion nvarchar(50),
Estado int
)
go
Create table Institucion(
IDInstitucion int identity constraint PK_Institucion primary key,
Descripcion varchar(30),
Estado int)
go
Create table NivelAcademico(
IDNivel int identity constraint PK_Nivel primary key,
Descripcion varchar(20)) 
go
Create table Usuario(
	IDUsuario int identity constraint PK_Usuario primary key,
	IDTipo int,
	Nombre varchar(30),
	Apellido1 varchar(30),
	Apellido2 varchar(30),
	Usuario varchar(50),
	Clave varchar(50),
	FechaIngreso date,
	Estado int,
	IDInstitucion int,
	IDNivel int
)
go
IF OBJECT_ID(N'dbo.FK_Usuario_TipoUsuario', N'F') IS NULL 
BEGIN
	alter table Usuario add constraint FK_Usuario_TipoUsuario
	foreign key (IDTipo) references TipoUsuario (IDTipo)

	PRINT 'Foreign key FK_Usuario_TipoUsuario WAS CREATED !'
END
go
alter table Usuario add constraint FK_Usuario_Institucion
foreign key (IDInstitucion) references Institucion (IDInstitucion)
go
alter table Usuario add constraint FK_Usuario_NivelAC
foreign key (IDNivel) references NivelAcademico (IDNivel)
go
Create table Contacto (
IDContacto int identity constraint PK_Contacto primary key,
TipoContacto int,
Identificador varchar(30),
IDUsuario int
)
go
alter table Contacto add constraint FK_Contacto_Usuario
foreign key (IDUsuario) references Usuario (IDUsuario)
go
Create table Tema(
IDTema int identity constraint PK_Tema primary key,
IDTipo int,
Descripcion varchar(500)
)
go
alter table Tema add constraint FK_Tema_TipoEvento
foreign key (IDTipo) references TipoEvento (IDTipoEvento)
go
Create table Evento( 
IDEvento int identity constraint PK_Evento primary key,
IDTipoEvento int,
FechaInicio datetime,
FechaFinal datetime,
IDExpositor int,
IDTema int,
Limite int,
IDUbicacion int,
Estado int,
Calificacion int)
go
alter table Evento add constraint FK_Evento_Tema
foreign key (IDTema) references Tema (IDTema)
go
alter table Evento add constraint FK_Evento_Usuario
foreign key (IDExpositor) references Usuario (IDUsuario)
go
alter table Evento add constraint FK_Evento_TipoEvento
foreign key (IDTipoEvento) references TipoEvento (IDTipoEvento)
go
Create table Reserva(
IDReserva int identity constraint PK_Reserva primary key,
IDEvento int,
IDUsuario int,
Reserva int,
Confirma int)
go
alter table Reserva add constraint FK_Reserva_Usuario
foreign key (IDUsuario) references Usuario (IDUsuario)
go
alter table Reserva add constraint FK_Reserva_Evento
foreign key (IDEvento) references Evento (IDEvento)
go
create table Calificacion(
IDCalifiacion int identity constraint PK_Califica primary key,
IDEvento int,
IDUsuario int,
Calificacion int,
Comentario varchar(1500))
go
alter table Calificacion add constraint FK_Calificacion_Usuario
foreign key (IDUsuario) references Usuario (IDUsuario)
go
alter table Calificacion add constraint FK_Calificacion_Evento
foreign key (IDEvento) references Evento (IDEvento)

go
create table Ubicacion(
IDUbicacion int identity constraint PK_Ubicacion primary key,
IDEvento int,
IDProvincia int,
IDCanton int,
IDDistrito int,
Lugar varchar(200)) 
go
alter table Evento add constraint FK_Evento_Ubica foreign key (IDUbicacion)
references Ubicacion(IDUbicacion)
go
Create table Provincia(
IDProvincia int identity constraint PK_Provincia primary key,
Nombre varchar(10)
)
go

Create table Canton(
IDCanton int identity constraint PK_Canton primary key,
IDProvicia int,
CodCanton int,
Nombre varchar(20)
)
go

Create table Distrito(
IDdistrito int identity constraint PK_Distrito primary key,
IDProvicia int,
IDCanton int ,
CodDistrito int,
Nombre varchar(30)
)
go

alter table Ubicacion add constraint FK_Ubica_provincia
foreign key (IDProvincia)
references Provincia(IDProvincia)
go

alter table Ubicacion add constraint FK_Ubica_Canton
foreign key (IDCanton)
references Canton(IDCanton)
go

alter table Ubicacion add constraint FK_Ubica_Distrito
foreign key (IDDistrito)
references Distrito(IDDistrito)
go
