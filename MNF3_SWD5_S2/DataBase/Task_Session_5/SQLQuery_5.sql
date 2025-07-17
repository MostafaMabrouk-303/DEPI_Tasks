Use StoreDB;
go 

--1.Write a query that classifies all products into price categories:
Select product_name,list_price ,
Case  
when  list_price<300 then 'Economy'
when  list_price>=3000and list_price<=999 then 'Standard' --$300-$999
when  list_price between 999 and 2500  then 'Premium'  --$1000-$2499
else  'Luxury' 
end as  'Price Category'
from production.products


--2.Create a query that shows order processing information with user-friendly status descriptions:
 Select order_status,
 case order_status
	 when 1 then 'Order Received'     
	 when 2 then 'In Preparation'     
	 when 3 then 'Order Cancelled'     
	 when 4 then 'Order Delivered'     
 end as 'order processing',
 case
   when order_status=1 and DATEDIFF(Day,order_date,getdate())>5 then 'URGENT'
   when order_status=2 and DATEDIFF(Day,order_date,getdate())>5 then 'HIGH'
   else 'Normal'
  end as ' priority level'
from sales.orders


--3.Write a query that categorizes staff based on the number of orders they've handled:
select * from sales.staffs;
select * from sales.orders;

Select f.staff_id,count(*) as 'count_of_Ordrers',
	case 
		when count(*)=0 then 'New Staff'
		when count(*) between 0 and 11 then 'Junior Staff'
		when  count(*) between 10 and 26 then 'Senior Staff'
		else 'Expert Staff'
		end as 'StateOfStaff'
from sales.staffs f join sales.orders o on f.staff_id=o.staff_id 
group by f.staff_id

--4.Create a query that handles missing customer contact information:
Select first_name+' '+last_name [Full NAme],
isnull(phone,'No Phone Available') as 'Contact Phone',
 coalesce(phone,email,'No Phone Available') as 'preferred_contact'
from sales.customers


--5.Write a query that safely calculates price per unit in stock:
Select p.product_id,p.product_name,s.store_id, s.quantity, p.list_price,
isnull(p.list_price / nullif(s.quantity, 0), 0) AS price_per_unit,
case
      When s.quantity = 0 THEN 'Out of Stock'
      When s.quantity <= 5 THEN 'Low Stock'
        else 'In Stock'
 end as [Price Per Unit]
from production.stocks s join production.products p 
on p.product_id=s.product_id
where store_id=1


--6.Create a query that formats complete addresses safely:
Select customer_id,first_name+' '+ last_name [Full Name],
  COALESCE(street, '') AS street_address,
  COALESCE(city, '') AS city,
  COALESCE(state, '') AS state,
  isnull(zip_code, 'Zip Not Available') AS zip_code,
  Concat (street,city,state ,zip_code)

from sales.customers


--7.Use a CTE to find customers who have spent more than $1,500 total:
WITH CustomerSpending as (
Select customer_id, sum(oi.quantity*list_price) as [Total]
from sales.orders o join sales.order_items oi
on oi.order_id=o.order_id
group by customer_id
)
SELECT   c.customer_id,c.first_name, c.last_name,cs.Total
FROM CustomerSpending cs
JOIN sales.customers c 
    ON cs.customer_id = c.customer_id
WHERE cs.Total > 1500
ORDER BY cs.Total DESC;



--8.Create a multi-CTE query for category analysis:
WITH CategoryRevenue AS (
    SELECT p.category_id,SUM(oi.quantity * oi.list_price) AS total_revenue
    FROM production.products p
    JOIN sales.order_items oi 
        ON p.product_id = oi.product_id
    GROUP BY p.category_id
),
CategoryAvgOrderValue AS (
    SELECT   p.category_id,
        AVG(oi.quantity * oi.list_price) AS avg_order_value
    FROM production.products p
    JOIN sales.order_items oi 
        ON p.product_id = oi.product_id
    GROUP BY p.category_id
)

SELECT c.category_id, c.category_name,cr.total_revenue, ca.avg_order_value,
    CASE 
        WHEN cr.total_revenue > 50000 THEN 'Excellent'
        WHEN cr.total_revenue > 20000 THEN 'Good'
        ELSE 'Needs Improvement'
    END AS performance_rating
FROM CategoryRevenue cr
JOIN CategoryAvgOrderValue ca 
    ON cr.category_id = ca.category_id
JOIN production.categories c
    ON c.category_id = cr.category_id
ORDER BY cr.total_revenue DESC;


--9.Use CTEs to analyze monthly sales trends:
WITH MonthlySales AS (
    SELECT 
        FORMAT(o.order_date, 'yyyy-MM') AS sales_month,
        SUM(oi.quantity * oi.list_price ) AS total_sales
    FROM sales.orders o
    JOIN sales.order_items oi  ON o.order_id = oi.order_id    
    GROUP BY FORMAT(o.order_date, 'yyyy-MM')
)

SELECT  current.sales_month, current.total_sales,   prev.total_sales AS previous_month_sales,

    CASE 
        WHEN prev.total_sales IS NULL THEN NULL
        WHEN prev.total_sales = 0 THEN NULL
        ELSE ROUND(((current.total_sales - prev.total_sales) * 100.0) / prev.total_sales, 2)
    END AS growth_percentage
FROM MonthlySales current
LEFT JOIN MonthlySales prev 
    ON FORMAT(DATEADD(MONTH, 1, CAST(prev.sales_month + '-01' AS DATE)), 'yyyy-MM') = current.sales_month
ORDER BY current.sales_month;


--10.Create a query that ranks products within each category:
WITH ProductRanks AS (
    SELECT   p.category_id,  c.category_name,   p.product_id,
   p.product_name,  p.list_price,     
     
        ROW_NUMBER() OVER (PARTITION BY p.category_id ORDER BY p.list_price DESC) AS row_num,
        RANK() OVER (PARTITION BY p.category_id ORDER BY p.list_price DESC) AS rank_num,
        DENSE_RANK() OVER (PARTITION BY p.category_id ORDER BY p.list_price DESC) AS dense_rank_num
    FROM production.products p
    JOIN production.categories c
        ON p.category_id = c.category_id
)

SELECT  category_id, category_name,    product_id,product_name,
list_price, row_num,  rank_num, dense_rank_num  
FROM ProductRanks
WHERE row_num <= 3
ORDER BY category_id, row_num;

--11.Rank customers by their total spending:

--12.Create a comprehensive store performance ranking:

--13.Create a PIVOT table showing product counts by category and brand:

--14.Create a PIVOT showing monthly sales revenue by store:

--15.PIVOT order statuses across stores:

--16.Create a PIVOT comparing sales across years:

--17.Use UNION to combine different product availability statuses:

--18.Use INTERSECT to find loyal customers:

--19.Use multiple set operators to analyze product distribution:

--20.Complex set operations for customer retention:













































