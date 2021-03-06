﻿create table Тип
(
	id_типа int not null identity(1,1),
	Название varchar(20) not null
	constraint cs_pktype primary key(id_типа)
)
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
	Дата_создания date not null,
	Дата_конца date,
	Статус bit not null default 0,
	constraint cs_pkminitask primary key(id_подзадачи),
	constraint cs_fkminitask foreign key(id_задания) references Задание(id_задания) on update cascade on delete cascade
	)
	go

	create table Уведомление(
	id_уведомления int identity(1,1) not null,
	id_пользователя int,
	Содержание varchar(max) not null,
	Статус int not null default 0,
	constraint cs_pknotification primary key(id_уведомления),
	constraint cs_fknotification foreign key(id_пользователя) references Пользователь(id_пользователя) on update cascade on delete cascade
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


create procedure UserTaskList
@userid int as
	begin
		select Задание.id_задания, Название, Описание, Дата_создания, Крайний_срок, id_распределения, Статус.Состояние
		from Задание
		join Распределение on Распределение.id_задания = Задание.id_задания
		join Пользователь on Пользователь.id_пользователя = Распределение.id_пользователя
		join Статус on Задание.id_статуса = Статус.id_статуса
		where Пользователь.id_пользователя = @userid and Задание.id_статуса in (4,2)
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

create procedure TaskRemoveDistribution
@taskid int, @userid int as
	begin
		delete from Распределение
		where id_задания = @taskid and id_пользователя = @userid
	end
go

create procedure SubtaskView
@taskid int as
	begin
		select id_подзадачи, Описание, Статус
		from Подзадача
		where id_задания = @taskid
	end
go

create procedure SubtaskAdd
@taskid int,
@description varchar(max) as
	begin
		insert into Подзадача(id_задания, Описание, Статус, Дата_создания) values (@taskid, @description, 0, GETDATE())
	end
	go

create procedure SubtaskComplete
@subtaskid int as
	begin
		update Подзадача
		set Статус = 1, Дата_конца = GETDATE()
		where id_подзадачи = @subtaskid 
	end
go

create procedure SubtaskRollback
@subtaskid int as
	begin
		update Подзадача
		set Статус = 0, Дата_конца = null
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

alter procedure TasksPerformed
as
begin
	select * 
	from Задание
	where id_статуса in (1,2,4)
end
go

create view GanttView as
select Название, Дата_создания as 'Дата начала', Крайний_срок as 'Крайний срок', Статус.Состояние as 'Статус'
from Задание
join Статус on Статус.id_статуса = Задание.id_статуса
go



alter procedure ReadyTaskCount
@userid int
as
begin
	select  count(Задание.id_задания) 'Количество'
	from Пользователь
	join Распределение on Распределение.id_пользователя = Пользователь.id_пользователя
	join Задание on Распределение.id_задания = Задание.id_задания
	where Пользователь.id_пользователя = @userid and Задание.id_статуса in (3,5)
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
	where Пользователь.id_пользователя = @userid and Задание.id_статуса = 4
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
	where Пользователь.id_пользователя = @userid and Задание.id_статуса = 6
end
go

create view AdminNoteList as
select Логин, Задание.Название, Заметка.Содержание, Заметка.Дата_добавления
from Заметка
join Распределение on Распределение.id_распределения = Заметка.id_распределения
join Пользователь on Распределение.id_пользователя = Пользователь.id_пользователя
join Задание on Распределение.id_задания = Задание.id_задания
go

--create procedure TaskStatusUpdater
--as
--begin
--	update Задание
--	set id_статуса = case
--	when GETDATE() > Крайний_срок and GETDATE() < DATEADD(DAY, 7, Крайний_срок) then 4 
--	when GETDATE() > Крайний_срок and GETDATE() > DATEADD(day, 7, Крайний_срок) then 6
--	else id_статуса end
--	where id_статуса = 2
--end
--go


create procedure TaskCompleted 
@taskid int
as
begin
	update Задание 
	set id_статуса = case
	when id_статуса = 2 then 3
	when id_статуса = 4 then 5
	else id_статуса end
	where id_задания = @taskid
end
go

create procedure UserTaskUpdater
@usertask int
as
begin
	select Задание.id_задания, Задание.Дата_создания,Задание.Крайний_срок,Задание.Название, Задание.Описание, Задание.id_статуса, Пользователь.id_пользователя
	from Задание
	join Распределение on Распределение.id_задания = Задание.id_задания
	join Пользователь on Пользователь.id_пользователя = Распределение.id_пользователя
	where id_статуса in (2,4) and Пользователь.id_пользователя = @usertask
end
go

create view SubtaskGanttChart
as
	select id_задания, Дата_создания, Дата_конца, Статус, Описание
	from Подзадача
	where Статус = 1
go

create trigger OnTaskDistribution
on Распределение
after insert
as
	begin
		declare @userid int
		set @userid = (select id_пользователя from inserted)
		insert into Уведомление(id_пользователя, Содержание, Статус) values (@userid, 'Вам назначено новое задание!', 0)
	end
go

create procedure OnTaskRemoveDistribution
@userid int, @taskid int
as
	begin
		declare @name varchar(max)
		set @name = (select Название from Задание
		where id_задания = @taskid)
		insert into Уведомление(id_пользователя, Содержание, Статус) values (@userid, CONCAT('Вы сняты с задания ', @name), 0)
	end
go


create procedure TakDistributionReaded
@userid int
as
begin
	update Уведомление
	set Статус = 1
	where id_пользователя = @userid
end
go

create procedure ExpiredNotificationAdd
@name varchar(max),
@taskid int
as
begin
	insert into Уведомление(id_пользователя, Содержание)
			select id_пользователя, CONCAT('Задание ', @name, ' просрочено!')
			from Распределение where id_задания = @taskid
	end
go

create procedure DroppedNotificationAdd
@name varchar(max),
@taskid int
as
begin
	insert into Уведомление(id_пользователя, Содержание)
			select id_пользователя, CONCAT('У задания ', @name, ' истек срок. Оно уже не может быть завершено!')
			from Распределение where id_задания = @taskid
	end
go

create procedure EndedTasks
as
begin
	select Название, Описание, Дата_создания, Крайний_срок, Состояние
	from Задание
	join Статус on Задание.id_статуса = Статус.id_статуса
	where Задание.id_статуса in (3,5,6)
end
go


--create trigger OnTaskUpdate
--on Задание
--after update
--as
--	begin
--		declare @taskid int
--		declare @status int
--		declare @name varchar(max)
--		set @taskid = (select id_задания from inserted)
--		set @status = (select id_статуса from inserted)
--		set @name = (select Название from inserted)
--		if (@status = 4)
--			begin
--				insert into Уведомление(id_пользователя, Содержание)
--				select id_пользователя, CONCAT('Задание ', @name, ' просрочено!')
--				from Распределение where id_задания = @taskid
--			end
--		else if (@status = 6)
--			begin
--				insert into Уведомление(id_пользователя, Содержание)
--				select id_пользователя, CONCAT('У задания ', @name, ' истек срок. Оно уже не может быть завершено!')
--				from Распределение where id_задания = @taskid
--			end
--	end
--go
