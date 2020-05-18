create table Тип
(
	id_типа int not null identity(1,1),
	Название varchar(20) not null
	constraint cs_pktype primary key(id_типа)
)
go

insert Тип
	values ('Администратор'),
			('Клиент')
go

select * from Тип
go

create table Пользователь
(
	id_пользователя int not null identity(1,1),
	id_типа int not null default 2,
	Логин varchar(30) not null unique,
	Пароль varchar(30) not null
	constraint cs_pkuser primary key(id_пользователя),
	constraint cs_fktype foreign key(id_типа) references Тип(id_типа) on update cascade on delete cascade
)
go

CREATE TABLE Задание(
	id_задания int IDENTITY(1,1) NOT NULL,
	id_клиента int NOT NULL,
	Название varchar(100) NOT NULL,
	Описание varchar(max) NOT NULL,
	Дата_создания datetime NOT NULL,
	Крайний_срок datetime NOT NULL,
	id_статуса int default 1,
	constraint cs_pktask primary key(id_задания),
	constraint cs_fkclient foreign key(id_клиента) references Клиент(id_клиента) on update cascade on delete cascade,
	constraint cs_fkstatus foreign key(id_статуса) references Статус(id_статуса) on update cascade on delete cascade
	)
	go

	CREATE TABLE Заметка(
	id_заметки int IDENTITY(1,1) NOT NULL,
	id_распределения int NOT NULL,
	Содержание varchar(max) NULL,
	Дата_добавления datetime NOT NULL,
	constraint cs_pknote primary key(id_заметки),
	constraint cs_fkdistribution foreign key(id_распределения) references Распределение(id_распределения) on update cascade on delete cascade
	)
	go

	CREATE TABLE Клиент(
	id_клиента int IDENTITY(1,1) NOT NULL,
	Имя varchar(50) NOT NULL,
	Электронная_почта varchar(max) NOT NULL,
	Дата_регистрации date NOT NULL,
	Телефон varchar(20) NOT NULL,
	Город varchar(50) NOT NULL,
	constraint cs_pkclient primary key(id_клиента)
	)
	go

	CREATE TABLE Распределение(
	id_распределения int IDENTITY(1,1) NOT NULL,
	id_пользователя int NOT NULL,
	id_задания int NOT NULL,
	Дата_распределения datetime NOT NULL,
	constraint cs_pkdistribution primary key(id_распределения),
	constraint cs_fktasksecond foreign key(id_задания) references Задание(id_задания) on update cascade on delete cascade,
	constraint cs_fkuser foreign key(id_пользователя) references Пользователь(id_пользователя) on update cascade on delete cascade
	)
	go
	
CREATE TABLE Статус(
	id_статуса int IDENTITY(1,1) NOT NULL,
	Состояние varchar(100) NOT NULL,
	constraint cs_pkstatus primary key(id_статуса)
	)
	go

create table Подзадача(
	id_подзадачи int identity(1,1) not null,
	id_задания int not null,
	Описание varchar(max) not null,
	Статус bit not null default 0,
	constraint cs_pkminitask primary key(id_подзадачи),
	constraint cs_fkminitask foreign key(id_задания) references Задание(id_задания) on update cascade on delete cascade
	)
	go


	

create procedure SignUp
@login varchar(20),
@password varchar(max) as 
begin
insert into Пользователь(Логин, Пароль) values (@login, @password)
end
GO


CREATE procedure ClientUpdate
@name varchar(50),
@email varchar(100),
@date date,
@phone varchar(20),
@town varchar(50),
@id int as 
begin
	update Клиент 
	set Имя = @name, Электронная_почта = @email, Дата_регистрации = @date, Телефон = @phone, Город = @town
	where id_клиента = @id
end
GO

CREATE procedure ClientAdd
@name varchar(50),
@email varchar(100),
@date date,
@phone varchar(20),
@town varchar(50) as
begin
	insert into Клиент(Имя, Электронная_почта, Дата_регистрации, Телефон, Город) values (@name, @email, @date, @phone, @town)
end
GO

CREATE procedure TaskAdd
@client int,
@name varchar(100),
@description varchar(max),
@deadline datetime as
	begin 
		insert into Задание(Название, Описание, id_клиента, Дата_создания, Крайний_срок) values (@name, @description, @client, GETDATE(), @deadline)
	end
go


execute TaskAdd 21,'AC1', 'Создание ролика для AC1', '2020-04-04'
go

execute TaskAdd 21,'BC1', 'Создание ролика для BC1', '2020-04-04'
go


alter procedure UserTaskList
@userid int as
	begin
		select Задание.id_задания, Название, Описание, Дата_создания, Крайний_срок, id_распределения
		from Задание
		join Распределение on Распределение.id_задания = Задание.id_задания
		join Пользователь on Пользователь.id_пользователя = Распределение.id_пользователя
		where Пользователь.id_пользователя = @userid and id_статуса in (4,2)
	end
go

create Procedure UsersInTask 
@taskid int as
begin
	select Пользователь.id_пользователя, Логин, id_распределения
	from Пользователь
	join Распределение on Распределение.id_пользователя = Пользователь.id_пользователя
	where id_задания = @taskid

end
go

create procedure NoteAdd
@destributionid int, 
@description varchar(max) as
begin
	insert into Заметка(id_распределения, Дата_добавления, Содержание) values (@destributionid, GETDATE(), @description)
end
go

create procedure NoteList
@destribution int as
begin
	select Содержание, id_заметки, Дата_добавления
	from Заметка
	join Распределение on Распределение.id_распределения = Заметка.id_распределения
	where Заметка.id_распределения = @destribution
end
go


create procedure TaskDistribution
@taskid int, @userid int as
	begin
		insert into Распределение(id_задания, id_пользователя, Дата_распределения) values (@taskid, @userid, GETDATE())
		update Задание
		set id_статуса = 2 
		where id_задания = @taskid
	end
go

create procedure SubtaskView
@taskid int as
	begin
		select *
		from Подзадача
		where id_задания = @taskid
	end
go

create procedure SubtaskAdd
@taskid int,
@description varchar(max) as
	begin
		insert into Подзадача(id_задания, Описание, Статус) values (@taskid, @description, 0)
	end
	go

alter procedure SubtaskComplete
@subtaskid int as
	begin
		update Подзадача
		set Статус = 1
		where id_подзадачи = @subtaskid 
	end
go

create procedure SubtaskRollback
@subtaskid int as
	begin
		update Подзадача
		set Статус = 0
		where id_подзадачи = @subtaskid
	end
go

create procedure EmployeeView
as
begin
	select *
	from Пользователь
	where id_типа = 2
end
go

create procedure TasksPerformed
as
begin
	select * 
	from Задание
	where id_статуса = 1 or id_статуса = 2
end
go

create view GanttView as
select Название, Дата_создания as 'Дата начала', Крайний_срок as 'Крайний срок', Статус.Состояние as 'Статус'
from Задание
join Статус on Статус.id_статуса = Задание.id_статуса
go

create procedure TaskCompleted 
@taskid int
as
begin
	update Задание 
	set id_статуса = 3
	where id_задания = @taskid
end
go

create procedure NotInTimeTaskCompleted 
@taskid int
as
begin
	update Задание 
	set id_статуса = 5
	where id_задания = @taskid
end
go

create procedure ReadyTaskCount
@userid int
as
begin
	select  count(Задание.id_задания) 'Количество'
	from Пользователь
	join Распределение on Распределение.id_пользователя = Пользователь.id_пользователя
	join Задание on Распределение.id_задания = Задание.id_задания
	where Пользователь.id_пользователя = @userid and Задание.id_статуса = 3
end
go

create procedure InProcessTaskCount
@userid int
as
begin
	select  count(Задание.id_задания) 'Количество'
	from Пользователь
	join Распределение on Распределение.id_пользователя = Пользователь.id_пользователя
	join Задание on Распределение.id_задания = Задание.id_задания
	where Пользователь.id_пользователя = @userid and Задание.id_статуса = 2
end
go

create procedure lateReadyTaskCount
@userid int
as
begin
	select  count(Задание.id_задания) 'Количество'
	from Пользователь
	join Распределение on Распределение.id_пользователя = Пользователь.id_пользователя
	join Задание on Распределение.id_задания = Задание.id_задания
	where Пользователь.id_пользователя = @userid and Задание.id_статуса = 5
end
go



create procedure DroppedTaskCount
@userid int
as
begin
	select  count(Задание.id_задания) 'Количество'
	from Пользователь
	join Распределение on Распределение.id_пользователя = Пользователь.id_пользователя
	join Задание on Распределение.id_задания = Задание.id_задания
	where Пользователь.id_пользователя = @userid and Задание.id_статуса = 4
end
go




select Задание.Название
from Задание 
where id_статуса = dbo.ReadyTaskCount(1)
--create function IsDistribution(@taskid int, @userid int) 
--returns int
--as
--	begin 
--	declare @isNull int
--	set @isNull = (select Count(id_распределения) from Распределение where id_задания = @taskid and id_пользователя = @userid)
--	return @isNull
--	end
--go

--select dbo.IsDistribution(9, 1) as 'Count'
