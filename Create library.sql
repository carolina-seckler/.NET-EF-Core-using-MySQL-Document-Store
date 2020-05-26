create database library;
use library;
create table library.publisher (id int not null auto_increment, name varchar(100) not null, primary key(id));
create table library.book (id int not null auto_increment, info json default null, publisherid int not null, primary key(id), FOREIGN KEY (publisherid) REFERENCES publisher(id)) engine=InnoDB default charset latin1;