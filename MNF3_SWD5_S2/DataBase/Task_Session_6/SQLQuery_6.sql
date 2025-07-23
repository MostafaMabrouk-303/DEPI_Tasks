Use StoreDB;
go 


---------[1] Customer Spending Analysis ---------------

declare @CustomerId int =1;
declare @TotalSpent Decimal(18,2);

Select @TotalSpent =  Sum(oi.quantity* oi.list_price*(1-oi.discount))
From sales.customers c join sales.orders o 
on c.customer_id=o.customer_id
join sales.order_items oi
on oi.order_id=o.order_id
where c.customer_id=@CustomerId;

if(@TotalSpent>5000)
	 BEGIN
		PRINT 'VIP Customer';
	END

ELSE
	BEGIN
		PRINT 'Regular Customer';
	END

---------[2] Product Price Threshold Report ---------------

Declare @Count int ;
Declare @Price decimal(10,2) =1500 ;


Select @Count= Count(*)
From production.products
where list_price >@Price

Print 'Number of Product more than '+cast(@Price as varchar)+' is '+Cast(@Count as varchar)
	
---------[3] Staff Performance Calculator ---------------

Declare @StaffID int=1;
Declare @Year int =2017;
Declare @Total decimal(10,2);

SELECT @Total = SUM(oi.quantity * oi.list_price * (1 - oi.discount))
FROM sales.orders o
JOIN sales.order_items oi ON o.order_id = oi.order_id
WHERE o.staff_id = @StaffID
  And Year(o.order_date) = @Year;

  Print 'Total Sales of Staff ' + CAST(@StaffID as Varchar) +' in '+
  Cast(@Year as Varchar)+' is '+Cast(@Total as Varchar)


  ---------[4]  Global Variables Information ---------------
  SELECT
    @@VERSION AS SQLServerVersion,
    @@SERVERNAME AS ServerName,
    @@ROWCOUNT AS LastRowsAffected,
    @@ERROR AS LastErrorNumber;


  --------- [5] ---------------
  -- 
  Declare @ProductId int =1;
  Declare @StoreId int =1;
  Declare @Quantity int ;

 Select @Quantity = quantity
FROM production.stocks
WHERE product_id = @ProductId AND store_id = @StoreId;

if @Quantity>20
 begin 
     PRINT 'Well stocked';
 end 

Else If @Quantity between 10 and 20 
	 begin 
	 Print 'Moderate stock'
	 end 

Else If @Quantity < 10
begin 
	 Print 'Low stock - reorder neede'
 end 

 Else 
	 Print 'NotFound';

  --------- [6] ---------------
Declare @BatchSize INT = 3;
Declare @UpdateCount INT = 1;
While @UpdateCount > 0
	Begin
    WITH ToUpdate AS (
        SELECT TOP (@BatchSize) *
        FROM production.stocks
        WHERE quantity < 5
        ORDER BY quantity ASC
    )
    UPDATE ToUpdate
    SET quantity = quantity + 10;

    SET @UpdateCount = @@ROWCOUNT;

    PRINT CAST(@UpdateCount AS VARCHAR) + ' products updated in this batch';
	End

    ---------------[7]Product Price Categorization ---------------
Select product_id,product_name,list_price,
case 
	When list_price<300 then 'Budget'
	When list_price between 300 and 800  then 'Mid-Range'
	When list_price between 800 and 2000  then 'Premium'
	else 'Luxury'
end as 'Price_Categorization'
from production.products ;

    ---------------[8]Customer Order Validation ---------------
Declare @CustomerId int = 5;
Declare @OrderCount int;

if Exists (Select 1 From sales.customers Where customer_id = @CustomerId)
Begin
    SELECT @OrderCount = COUNT(*) 
    FROM sales.orders 
    WHERE customer_id = @CustomerId;

    Print 'Customer exist and Order count is : ' + Cast(@OrderCount as varchar);
end
else
Begin
    print 'Customer does not exist.';
end


    ---------------[9]Shipping Cost Calculator Function ---------------

Create Function dbo.CalculateShipping (@OrderTotal Decimal(10, 2))
Return Decimal(10, 2)
as
Begin
    DECLARE @ShippingCost DECIMAL(10, 2)

    SET @ShippingCost = 
        CASE 
            When @OrderTotal > 100 Then 0.00
            When @OrderTotal Between 50 And 99.99 Then 5.99
            else 12.99
        End

    Return @ShippingCost
End

    ---------------[10]Product Category Function---------------
Create Function dbo.GetProductsByPriceRange
(
    @MinPrice Decimal(10,2),
    @MaxPrice Decimal(10,2)
)
Return Table
as
return
(
    Select  p.product_id,  p.product_name,  p.list_price,  b.brand_name, c.category_name
    From production.products p
    join production.brands b ON p.brand_id = b.brand_id
    join production.categories c ON p.category_id = c.category_id
    WHERE p.list_price BETWEEN @MinPrice AND @MaxPrice
);


    ---------------[11]Customer Sales Summary Function---------------
Create Function dbo.GetCustomerYearlySummary (@CustomerID INT)
Return @Summary TABLE (Year INT,TotalOrders INT,TotalSpent DECIMAL(18,2), AverageOrderValue DECIMAL(18,2)  )
AS
BEGIN
    INSERT INTO @Summary
    SELECT 
        YEAR(o.order_date) AS Year,
        COUNT(DISTINCT o.order_id) AS TotalOrders,
        SUM(oi.quantity * oi.list_price * (1 - oi.discount)) AS TotalSpent,
        AVG(oi.quantity * oi.list_price * (1 - oi.discount)) AS AverageOrderValue
    FROM sales.orders o
    JOIN sales.order_items oi ON o.order_id = oi.order_id
    WHERE o.customer_id = @CustomerID
    GROUP BY YEAR(o.order_date)

    RETURN
END

    ---------------[12]Discount Calculation Function---------------
Create Function dbo.CalculateBulkDiscount (@Quantity INT)
Return Decimal(5,2)
as
Begin
    Declare @Discount Decimal(5,2)

    IF @Quantity Between 1 and 2
        SET @Discount = 0.00
    ELSE IF @Quantity BETWEEN 3 AND 5
        SET @Discount = 5.00
    ELSE IF @Quantity BETWEEN 6 AND 9
        SET @Discount = 10.00
    ELSE IF @Quantity >= 10
        SET @Discount = 15.00
    ELSE
        SET @Discount = 0.00  

    Return @Discount
end


    ---------------[13]Customer Order History Procedure---------------


