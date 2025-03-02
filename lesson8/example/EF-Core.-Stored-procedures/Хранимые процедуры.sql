 USE Database_Books
 
Create function BooksList(
       @Author nvarchar(50)
   )
     returns @returntable table
     (
       Id int,
       Name nvarchar(100),
       Author nvarchar (50),
       Themes nvarchar (50),
       Press nvarchar (50),
       Pages int,
       YearPress int,
       Comment nvarchar (50),
       Quantity int
   )
     as
     BEGIN
       INSERT @returntable
       SELECT Id, Name, Author, Themes, Press, Pages, YearPress, Comment, Quantity
       FROM Books WHERE Author = @Author
       RETURN
     END
     go

select * from BooksList(N'Архангельский')
create procedure ShowBooksByThemes
   @themes nvarchar (255) as
   select * from books
   where themes like @themes
   order by Name desc
   go

execute ShowBooksByThemes 'Программирование' 

create procedure how_many_books @quantity int output  
as
SELECT @quantity = COUNT(*) FROM books 
go

declare @quantity int
execute how_many_books @quantity output
select 'Количество записей в таблице Books:',@quantity
go


 create procedure Delete_Book
 @name nvarchar (255) as
 delete from books where name like @name 
 go
 
  declare @name nvarchar(255)
  set @name = '%Visual%Basic%'
  execute Delete_Book @name 
  go

   create view sum_of_pages (Pages, Press) as
 SELECT sum(Pages), Press from books
 group by Press
 go

create procedure MaxPages @press nvarchar(255) output, @sum int output
as
SELECT @press=Press, @sum=sum(Pages)
FROM books
GROUP BY Press
HAVING sum(Pages)= (select max(Pages)from sum_of_pages)
go

 declare @izdat nvarchar(255), @sum int
 execute MaxPages @izdat output, @sum output
 select 'Издательство:',@izdat,'Сумма:',@sum

create procedure Add_Book @name nvarchar(100), @pages int, @yearpress int,
				 @themes nvarchar(50), @author nvarchar(50), @press nvarchar(50), 
				 @comment nvarchar(50), @quantity int
 as
 INSERT INTO books (name, pages, yearpress, themes, author, press, comment, quantity)
 VALUES (@name, @pages, @yearpress, @themes, @author, @press, @comment, @quantity)