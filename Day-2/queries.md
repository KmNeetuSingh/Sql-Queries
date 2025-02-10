<!-- -- -- Calculate the total score for each student by adding the MathScore and ScienceScore. -->
create  database School;
use School;
create table Student_records(Student_Id INT Primary Key,
MAth_Score INT,
Scinece_Score INT,
Total_Classes INT,
Days_absent INT
);
-- Calculate the number of classes each student actually attended.
Insert into Student_records(Student_Id,
MAth_Score
,Scinece_Score
,Total_Classes
,Days_absent) 
Values 
(1,85,90,30,5),
(2,75,80,25,3),
(3,95,85,28,6),
(4,60,70,32,7),
(5,80,80,30,2);

<!-- -- Find the total study hours for each student, assuming each class equals 2 study hours. -->

SELECT Student_Id, MAth_Score, Scinece_Score, 
       (MAth_Score + Scinece_Score) AS TotalScore
FROM Student_records;
Select * from  Student_records;
SELECT Student_Id,Total_Classes,Days_absent, 
       (Total_Classes - Days_absent) AS Attentive_Students
FROM Student_records;
<!-- -- Calculate the average score for each student (MathScore + ScienceScore) / 2.
 -->
SELECT Student_Id,Total_Classes, 
       (Total_Classes * 2) AS Study_Students
FROM Student_records;SELECT Student_Id, MAth_Score, Scinece_Score, 
       ((MAth_Score+Scinece_Score)/2) AS Average_Students
FROM Student_records; 

<!-- -- Retrieve the total score of each student where the combined score is greater than 160. -->

select Student_Id, MAth_Score,Scinece_Score,
       (MAth_Score + Scinece_Score) As TotalScore
from Student_records
WHERE (MAth_Score + Scinece_Score) >160;

<!---- Find students who attended more than 25 classes.
  -->
select Student_Id, Total_Classes, Days_absent,
       (Total_Classes - Days_absent) As Totalday
from Student_records
WHERE (Total_Classes - Days_absent) >25;
 <!-- Hard_level_quesitons -->
Select * from Student_records;
select Student_Id, Total_Classes, Days_absent , MAth_Score , Scinece_Score,
   (Total_Classes - Days_absent) As Class_Attentive,
   (MAth_Score +Scinece_Score ) As Total_Score
from Student_records
Where  (Total_Classes - Days_absent) = (select max(Total_Classes - Days_absent) from Student_records);
<!-- -- Medium level Questions--      -->
create database Products;
use Products;
create table products (ProductID int Primary key, 
ProductName varchar(255), 
Price Int,
Quantity Int,
Discount Int
);
Insert into products(ProductId,ProductName,Price,Quantity,Discount) 
values (1,'Pen', 10,50 , 10),(2,'Notebook', 20,30 ,5),(3,'Eraser',5,100 ,0),(4,'Marker', 15,40,20);
select * from products;
SELECT 
    ProductID, 
    ProductName, 
    Price, 
    Discount, 
    (Price - (Price * Discount / 100)) AS DiscountedPrice
FROM products
WHERE(Price - (Price * Discount / 100)) > 15;
<!-- -- --Find products with total inventory value (Price × Quantity) greater than 600. -->
select * from products ;
SELECT 
    ProductID, 
    ProductName, 
    Price, 
    Discount, 
    (Price * Quantity) AS InventoryValue
FROM products
WHERE(Price * Quantity) > 600;

<!-- --  Retrieve products where the price after discount is less than 10. -->
SELECT 
    ProductID, 
    ProductName, 
    Price, 
    Discount, 
    (Price - (Price * Discount / 100)) AS DiscountedPrice
FROM products
WHERE(Price - (Price * Discount / 100)) < 10;
<!-- -- --Find products where the price after discount is between 5 and 15. -->
 
SELECT 
    ProductID, 
    ProductName, 
    Price, 
    Discount, 
    (Price - (Price * Discount / 100.0)) AS DiscountedPrice
FROM products
WHERE (Price - (Price * Discount / 100.0)) BETWEEN 5 AND 15;
<!-- -- Hard LevelQ2: Find products where the price after discount is greater than 10 but less than 20, and the total inventory value (Price × Quantity) exceeds 600. -->
SELECT 
    ProductID, 
    ProductName, 
    Price, 
    Discount, 
    Quantity, 
    (Price - (Price * Discount / 100.0)) AS DiscountedPrice, 
    (Price * Quantity) AS InventoryValue
FROM products
WHERE 
    (Price - (Price * Discount / 100.0)) BETWEEN 10 AND 20
    AND (Price * Quantity) > 600;
