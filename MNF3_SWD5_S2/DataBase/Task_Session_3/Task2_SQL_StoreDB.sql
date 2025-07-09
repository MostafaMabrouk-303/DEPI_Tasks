use StoreDB;
go 


--1-List all products with list price greater than 1000
select *
from production.products
where list_price >1000;


--2-Get customers from "CA" or "NY" states
select * 
from sales.customers
where state='CA' or state='NY';

--3-Retrieve all orders placed in 2023
Select * from sales.orders
where YEAR(shipped_date) = 2023;

--4-Show customers whose emails end with @gmail.com
Select * from sales.customers
where email like '%@gmail.com';

--5-Show all inactive staff
select * from sales.staffs
where active != 1;


--6-List top 5 most expensive products
select top(5) list_price
from production.products
order by list_price desc;

--7-Show latest 10 orders sorted by date
select top(10) *
from sales.orders
order by shipped_date desc

--8-Retrieve the first 3 customers alphabetically by last name
select top(3)*
from sales.customers
order by last_name;

--9-Find customers who did not provide a phone number
select *
from sales.customers
where phone is null;

--10-Show all staff who have a manager assigned
select *
from sales.staffs
where manager_id is not null;

----------------------------

--11-Count number of products in each category

select category_id,count(*) as 'number_of_products'
from production.products p 
group by category_id
order by category_id

select g.category_id,count(*) as 'number_of_products'  
from production.products p right outer join production.categories g
on p.category_id =g.category_id
group by g.category_id         -- 33 Row has value other null count = 0

select distinct category_id  --33 Row
from production.products  

select category_id          --33 Row --> id 
from production.categories  
where category_id in (select category_id from production.products)

-------------------------

--12-Count number of customers in each state
select state, count(*) [number of customers]
 from sales.customers
group by state


--13-Get average list price of products per brand
select brand_id,avg(list_price) [average list price]
from production.products
group by brand_id
order by brand_id

--14-Show number of orders per staff
select staff_id,count(*) [number of orders]
from sales.orders
group by staff_id

--15-Find customers who made more than 2 orders
select customer_id
from sales.orders
group by customer_id
having count(*) >2

--For Full Data about Customer Erorr
/*select c.*
from sales.orders o join sales.customers c
on o.customer_id = c.customer_id
group by o.customer_id
having count(*) >2 */

--16-Products priced between 500 and 1500
select * 
from production.products
where list_price between 500 and 1500;

--17-Customers in cities starting with "S"
select * 
from sales.customers
where city like 'S%';

--18-Orders with order_status either 2 or 4
select * 
from sales.orders
where order_status not in (2,4) -- <>2 & <>4


--19-Products from category_id IN (1, 2, 3)
select * 
from production.products
where category_id in (1,2,3);

--20-Staff working in store_id = 1 OR without phone number
select * 
from sales.staffs
where store_id=1 or phone is null;

