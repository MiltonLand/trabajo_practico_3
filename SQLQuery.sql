ALTER TABLE WorkingDay ADD WorkedHours decimal ;

ALTER TABLE Employees ADD HourPrice decimal;

insert into Country( CountryName) values ('Argentina');

insert into Country( CountryName) values ('Brazil');

insert into Employees(FirstName, LastName, CountryID, [Shift], HireDate, HourPrice) VALUES ('Daniel','Riba', '1', 'ma�ana', '2016-01-01', '200');

insert into Employees(FirstName, LastName, CountryID, [Shift], HireDate, HourPrice) VALUES ('Juan','Perez', '2', 'tarde', '2015-01-01', '100');

insert into Employees(FirstName, LastName, CountryID, [Shift], HireDate, HourPrice) VALUES ('Tomas','Rodriguez', '1', 'noche', '2013-01-01', '200');

insert into WorkingDay (EmployeeID, TimeIn, [TimeOut], WorkedHours) values ('1', '2017-04-12T08:00:00.000', '2017-04-12T12:00:00.000', '4' );

insert into WorkingDay (EmployeeID, TimeIn, [TimeOut], WorkedHours) values ('2', '2017-04-12T14:00:00.000', '2017-04-12T18:00:00.000', '4' );

insert into WorkingDay (EmployeeID, TimeIn, [TimeOut], WorkedHours) values ('3', '2017-04-12T19:00:00.000', '2017-04-12T21:00:00.000', '2' );
