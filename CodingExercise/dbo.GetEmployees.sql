CREATE FUNCTION [dbo].[GetEmployees]
(
	 @name varchar(50)	
)
RETURNS @returntable TABLE
(
	EmpName varchar(50) null
)
AS
BEGIN
	declare  @ManID varchar(50)
	set @ManID = (select LineManager.ManID
	from LineManager
	where LineManager.ManName = @name);

	with EmployeeCTE AS 
	(
		select EmpID, EmpName, ManID
		from Employee
		where ManID = @ManID

		union all 

		select Employee.EmpID, Employee.EmpName, Employee.ManID
		from Employee 
		join EmployeeCTE
		on Employee.ManID = EmployeeCTE.EmpID
	)

	INSERT @returntable
	SELECT EmpName from EmployeeCTE
	RETURN
END