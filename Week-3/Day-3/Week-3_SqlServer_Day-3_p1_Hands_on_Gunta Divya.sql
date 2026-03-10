--create database Sample
go
Use Sample
go

drop table if exists tbl_order;
drop table if exists tbl_customer;
go

create table tbl_customer(customerid int primary key,
firstname varchar(30),
lastname varchar(30)
);
go

create table tbl_order(order_id int primary key,order_date date,
order_status int check(order_status in(1,2,3,4)),
customerid int,foreign key(customerid)references tbl_customer(customerid)
);
go

insert into tbl_customer values(1,'gunta','divya')
insert into tbl_customer values(3,'angeru','sandnya')
insert into tbl_customer values(2,'abc','def')
insert into tbl_customer values(4,'ghi','jkl')
go

insert into tbl_order values(100,'2026-03-04',4,1)
insert into tbl_order values(101,'2025-01-14',1,2)
insert into tbl_order values(102,'2024-02-24',2,3)
insert into tbl_order values(103,'2023-03-04',4,4)
go

SELECT c.*,o.*
FROM tbl_customer c INNER JOIN tbl_order o
ON c.customerid = o.customerid
WHERE o.order_status =1  OR o.order_status =4
ORDER BY o.order_date DESC;

create view vw_cutomer_order as
SELECT c.customerid,c.firstname,o.order_id,o.order_status
FROM tbl_customer c INNER JOIN tbl_order o
ON c.customerid = o.customerid
WHERE o.order_status =1  OR o.order_status =4;






