CREATE TABLE Talento
( 
	IdTalento             integer IDENTITY ( 1,1 ) ,
	Email                 nvarchar(100)  NOT NULL ,
	Nome                  nvarchar(200)  NOT NULL ,
	Skype                 nvarchar(100)  NOT NULL ,
	Whatsapp              nvarchar(50)  NOT NULL ,
	Linkedin              nvarchar(100)   NULL ,
	Cidade                nvarchar(50)  NOT NULL ,
	Estado                nvarchar(50)  NOT NULL ,
	Portfolio             nvarchar(100)   NULL ,
	Pretensao             decimal NOT NULL ,
	LinkCRUD			  nvarchar(100)   NULL ,
	primary key (IdTalento)
);

CREATE TABLE InfoBancaria
( 
	IdInfoBancaria             integer IDENTITY ( 1,1 ) ,
	Nome                  nvarchar(200)   NULL ,
	CPF                 nvarchar(50)   NULL ,
	Banco              nvarchar(50)   NULL ,
	Agencia              nvarchar(100)   NULL ,
	TipoConta                nvarchar(50)   NULL ,
	NumeroConta                nvarchar(50)   NULL ,
	IdTalento             integer
	primary key (IdInfoBancaria, IdTalento),
	constraint fk_InfoBancaria_Talento foreign key (IdTalento) references Talento (IdTalento) on delete cascade
);

CREATE TABLE Disponibilidade
( 
	IdDisponibilidade             integer IDENTITY ( 1,1 ) ,
	Descricao                     nvarchar(200)  NOT NULL ,
	primary key (IdDisponibilidade)
);

CREATE TABLE TalentoDisponibilidade
( 
	IdTalentoDisponibilidade            integer IDENTITY ( 1,1 ) ,
    IdTalento             integer,
	IdDisponibilidade     integer ,
	primary key (IdTalentoDisponibilidade,IdTalento),
	constraint fk_TalentoDisp_Talento foreign key (IdTalento) references Talento (IdTalento) on delete cascade,
	constraint fk_TalentoDisp_Disponi foreign key (IdDisponibilidade) references Disponibilidade (IdDisponibilidade) on delete cascade
);

CREATE TABLE MelhorHorario
( 
	IdMelhorHorario             integer IDENTITY ( 1,1 ) ,
	Descricao                     nvarchar(200)  NOT NULL ,
	primary key (IdMelhorHorario)
);

CREATE TABLE TalentoMelhorHorario
( 
	IdTalentoMelhorHorario             integer IDENTITY ( 1,1 ) ,
    IdTalento             integer,
	IdMelhorHorario     integer ,
	primary key (IdTalentoMelhorHorario, IdTalento),
	constraint fk_TalentoMH_Talento foreign key (IdTalento) references Talento (IdTalento) on delete cascade,
	constraint fk_TalentoMH_MelhorH foreign key (IdMelhorHorario) references MelhorHorario (IdMelhorHorario) on delete cascade
);

CREATE TABLE ConhecimentoEspecifico
( 
	IdConhecimentoEspecifico             integer IDENTITY ( 1,1 ) ,
	Descricao                     nvarchar(100)  NOT NULL ,
	primary key (IdConhecimentoEspecifico)
);

CREATE TABLE TalentoConhecimentos
( 
	IdTalentoConhecimentos             integer IDENTITY ( 1,1 ) ,
    IdTalento             integer,
	IdConhecimentoEspecifico integer not   NULL ,
	Avaliacao             integer   NULL ,
	primary key (IdTalentoConhecimentos, IdTalento, IdConhecimentoEspecifico),
	constraint fk_TalentoConh_Talento foreign key (IdTalento) references Talento (IdTalento) on delete cascade,
	constraint fk_TalentoConh_Conhe foreign key (IdConhecimentoEspecifico) references ConhecimentoEspecifico (IdConhecimentoEspecifico) on delete cascade
);

insert into Disponibilidade (Descricao) values ('Up to 4 hours per day / Até 4 horas por dia');
insert into Disponibilidade (Descricao) values ('4 to 6 hours per day / De 4 á 6 horas por dia');
insert into Disponibilidade (Descricao) values ('6 to 8 hours per day /De 6 á 8 horas por dia');
insert into Disponibilidade (Descricao) values ('Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)');
insert into Disponibilidade (Descricao) values ('Only weekends / Apenas finais de semana');

insert into MelhorHorario (Descricao) values ('Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)');
insert into MelhorHorario (Descricao) values ('Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)');
insert into MelhorHorario (Descricao) values ('Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)');
insert into MelhorHorario (Descricao) values ('Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)');
insert into MelhorHorario (Descricao) values ('Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)');

insert into ConhecimentoEspecifico (Descricao) values ('Ionic');
insert into ConhecimentoEspecifico (Descricao) values ('Android');
insert into ConhecimentoEspecifico (Descricao) values ('IOS');
insert into ConhecimentoEspecifico (Descricao) values ('HTML');
insert into ConhecimentoEspecifico (Descricao) values ('CSS');
insert into ConhecimentoEspecifico (Descricao) values ('Bootstrap');
insert into ConhecimentoEspecifico (Descricao) values ('Jquery');
insert into ConhecimentoEspecifico (Descricao) values ('AngularJs');
insert into ConhecimentoEspecifico (Descricao) values ('Java');
insert into ConhecimentoEspecifico (Descricao) values ('Asp.Net MVC');
insert into ConhecimentoEspecifico (Descricao) values ('C');
insert into ConhecimentoEspecifico (Descricao) values ('C++');
insert into ConhecimentoEspecifico (Descricao) values ('Cake');
insert into ConhecimentoEspecifico (Descricao) values ('Django');
insert into ConhecimentoEspecifico (Descricao) values ('Majento');
insert into ConhecimentoEspecifico (Descricao) values ('PHP');
insert into ConhecimentoEspecifico (Descricao) values ('Wordpress');
insert into ConhecimentoEspecifico (Descricao) values ('Phyton');
insert into ConhecimentoEspecifico (Descricao) values ('Ruby');
insert into ConhecimentoEspecifico (Descricao) values ('My SQL Server');
insert into ConhecimentoEspecifico (Descricao) values ('My SQL');
insert into ConhecimentoEspecifico (Descricao) values ('Salesforce');
insert into ConhecimentoEspecifico (Descricao) values ('Photoshop');
insert into ConhecimentoEspecifico (Descricao) values ('Illustrator');
insert into ConhecimentoEspecifico (Descricao) values ('SEO');
