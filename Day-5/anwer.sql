-- Rename table for ease of access
RENAME TABLE `supermart grocery sales - retail analytics dataset` TO `sales`;

-- Fix column name encoding issue
ALTER TABLE `sales`
CHANGE COLUMN `ï»¿Order ID` `Order_id` VARCHAR(50);

-- 1. Total Sales Per Category
SELECT Category, SUM(Sales) AS total_sales
FROM sales
GROUP BY Category;

-- 2. Retrieve all sales ordered by sales amount (descending)
SELECT * FROM sales
ORDER BY Sales DESC;

-- List all sales in the 'Food Grains' category, sorted in ascending order by Order_id
SELECT * FROM sales
WHERE Category = 'Food Grains'
ORDER BY Order_id ASC;

-- 3. Retrieve the top 5 most expensive sales
SELECT * FROM sales
ORDER BY Sales DESC
LIMIT 5;

-- Fetch any 10 random sales transactions
SELECT * FROM sales
ORDER BY RAND()
LIMIT 10;

-- 4. Top 3 highest revenue-generating customers
SELECT `Customer Name`, SUM(Sales) AS total_sales
FROM sales
GROUP BY `Customer Name`
ORDER BY total_sales DESC
LIMIT 3;

-- 5. Sales above $3000, grouped by category, ordered by total sales
SELECT Category, SUM(Sales) AS total_sales
FROM sales
WHERE Sales > 3000
GROUP BY Category
ORDER BY total_sales DESC;

-- 6. Total sales per region, filtering regions exceeding $10,000
SELECT Region, SUM(Sales) AS total_sales
FROM sales
GROUP BY Region
HAVING total_sales > 10000;

-- 7. Highest, lowest, and average sales per category
SELECT Category,
       MAX(Sales) AS highest_sale,
       MIN(Sales) AS lowest_sale,
       AVG(Sales) AS avg_sale
FROM sales
GROUP BY Category;

-- 8. Retrieve the 5 most recent sales (fixing the incorrect column name)
SELECT * FROM sales
ORDER BY `Order Date` DESC
LIMIT 5;

-- Top 3 largest transactions per region
SELECT Region, Sales
FROM sales
ORDER BY Region, Sales DESC
LIMIT 3;

-- 9. Retrieve the top 10 regions contributing to total sales
SELECT Region, SUM(Sales) AS total_sales
FROM sales
GROUP BY Region
ORDER BY total_sales DESC
LIMIT 10;

-- 10. Categories with total sales exceeding $20,000
SELECT Category, SUM(Sales) AS total_sales
FROM sales
GROUP BY Category
HAVING total_sales > 20000
ORDER BY total_sales DESC
LIMIT 3;

-- 11. Top 3 regions where total sales exceeded $2000
SELECT Region, SUM(Sales) AS total_sales
FROM sales
GROUP BY Region
HAVING total_sales > 2000
ORDER BY total_sales DESC
LIMIT 3;

-- Retrieve categories with the highest sales per region
SELECT Region, Category, MAX(Sales) AS highest_sales
FROM sales
GROUP BY Region, Category
ORDER BY Region, highest_sales DESC;

-- 12. Optimize query to get the top 3 transactions
SELECT * FROM sales
ORDER BY Sales DESC
LIMIT 3;
