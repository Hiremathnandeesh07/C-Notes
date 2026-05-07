use ADO_Stored_Procedure_CRUD_operations

exec sp_helptext 'sp_AddStudent';


-- procedure to add student 

create procedure sp_AddStudent   
@name varchar(100), @course varchar(100)  
as  
begin  
    begin transaction;  
    insert into student (name,course) values (@name,@course);  
  
    commit;  
end



- you can get the id of the newly inserted data like this  (add this inplace of insert query in procedure)
    
    ```sql
      insert into Student(name,course) output inserted.id values (@name,@course);
    ```