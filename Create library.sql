/*V2*/
drop database Library;
create database Library;
use Library;
Create Table Library.Publisher (Id Int Not Null Auto_Increment, Name Varchar(100) Not Null, Address Json Default Null, Primary Key(Id)) Engine=InnoDB Default Charset Latin1;
Create Table Library.Book (
Id Int Not Null Auto_Increment, 
Isbn Varchar(30) Not Null, 
Author Varchar(100) Not Null, Language Varchar(30) Not Null, 
Idpublisher Int Not Null, 
Primary Key(Id), 
FOREIGN KEY (Idpublisher) REFERENCES Publisher(Id)) 
Engine=InnoDB Default Charset Latin1;
Create Table Library.Volume (
Id Int Not Null Auto_Increment, 
Title Varchar(100) Not Null, 
Number Int Not Null, 
Pages Int Not Null, 
Idbook Int Not Null, 
Primary Key(Id), 
FOREIGN KEY (Idbook) REFERENCES Book(Id) 
ON DELETE CASCADE) 
Engine=InnoDB Default Charset Latin1;

