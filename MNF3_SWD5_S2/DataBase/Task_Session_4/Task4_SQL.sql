use StoreDB ;
go 

--1.Count the total number of products in the database.
Select count (*) [Number of Products]
from production.products;

--2. Find the average, minimum, and maximum price of all products
Select avg(list_price) [Average Price],
min (list_price) [Minimum Price],
max (list_price) [Maximum Price]
from production.products;

--3.Count how many products are in each category.
Select C.category_name,count (*) [Number of Products]
from production.products P join production.categories C
on P.category_id=C.category_id
group by c.category_name ;

--4.Find the total number of orders for each store.
select s.store_id,s.store_name,count(*)  [number of orders]
from sales.orders o join sales.stores s
on s.store_id =o.store_id
group by s.store_id,s.store_name ;


--5.Show customer first names in UPPERCASE and last names in lowercase for the first 10 customers.
select top(10) UPPER(first_name) [First Name],
LOWER(last_name) [Last NAme]
from sales.customers ; 


--6.Get the length of each product name. Show product name and its length for the first 10 products.
select top(10) product_name , len(product_name) [Length of Name ]
from production.products ; 


--7.Format customer phone numbers to show only the area code (first 3 digits) for customers 1-15.
select phone,SUBSTRING(phone,1,3) [Area code]
from sales.customers
where customer_id between 1 and 15;


--8.Show the current date and extract the year and month from order dates for orders 1-10.
select GETDATE() [Current Date],
	YEAR(order_date) [Year of Order],
	MONTH(order_date) [Month of Order] ,
	DAY(order_date) [Day of Order]
from sales.orders
where store_id between 1 and 10;


--9.Join products with their categories. Show product name and category name for first 10 products.
select top(10) P.product_name,C.category_name
from production.products P join production.categories C
on P.category_id =C.category_id


--10.Join customers with their orders. Show customer name and order date for first 10 orders.
Select top(10) C.first_name+' '+C.last_name [Full Customer Name] ,O.order_date
from sales.customers C join sales.orders O 
on C.customer_id =O.customer_id


--11. Show all products with their brand names, even if some products don't have brands. Include product name, brand name (show 'No Brand' if null).
Select P.product_name ,isnull(B.brand_name,'No Brand Name')
from production.products P left outer join production.brands B
on P.brand_id = B.brand_id


--12.Find products that cost more than the average product price. Show product name and price.
Select *
from production.products
where list_price>(Select avg(list_price) from production.products);


--13.Find customers who have placed at least one order. Use a subquery with IN. Show customer_id and customer_name.
Select customer_id,first_name+' '+last_name [Full Name]
from sales.customers
where customer_id in (Select customer_id from sales.orders);


--14.For each customer, show their name and total number of orders using a subquery in the SELECT clause.
Select first_name+' '+last_name [Full Name],
(
select count(*) from 
sales.orders o where c.customer_id = o.customer_id
)
from sales.customers c


--15.Create a simple view called easy_product_list that shows product name, category name, and price. Then write a query to select all products from this view where price > 100.
create view easy_product_list  as
Select
p.product_name,c.category_name,list_price
from production.products p join production.categories c
on p.category_id = c.category_id

Select product_name from easy_product_list
where list_price>1000


--16.Create a view called customer_info that shows customer ID, full name (first + last), email, and city and state combined. Then use this view to find all customers from California (CA).
create view customer_info  as
Select customer_id,first_name+' '+last_name [Full Name ],email,city,state
from sales.customers

Select * from customer_info
where state='CA';


--17.Find all products that cost between $50 and $200. Show product name and price, ordered by price from lowest to highest.
Select product_name,list_price
from production.products 
where list_price between 50 and 200
order by list_price 


--18.Count how many customers live in each state. Show state and customer count, ordered by count from highest to lowest.
Select state,COUNT(*)
from sales.customers 
group by state
order by Count(*) desc

--19.Find the most expensive product in each category. Show category name, product name, and price.
Select c.category_name,p.product_name,p.list_price
from production.products p join production.categories c
on p.category_id = c.category_id
Where p.list_price = (
    Select MAX(p2.list_price)
    from production.products p2
    where p2.category_id = p.category_id
	)

--20.Show all stores and their cities, including the total number of orders from each store. Show store name, city, and order count.
Select s.store_name,s.city,count(o.order_id) [Order Count]
from sales.stores s left outer join sales.orders o 
on s.store_id=o.store_id
group by s.store_name,s.city





