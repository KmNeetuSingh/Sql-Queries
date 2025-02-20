-- Understanding JOINS (Theoretical Examples)
-- INNER JOIN: Returns matching rows from both tables
-- LEFT JOIN: Returns all rows from the left table, and matching rows from the right table
-- RIGHT JOIN: Returns all rows from the right table, and matching rows from the left table
-- FULL OUTER JOIN: Returns all rows from both tables, with NULLs where no match exists

-- Customers & Orders
-- Retrieve all customers who have placed an order
SELECT DISTINCT C.customer_id, C.name, C.email
FROM customers C
JOIN orders O ON C.customer_id = O.customer_id;

-- List orders along with customer names
SELECT O.order_id, C.name, O.total_amount, O.order_date
FROM orders O
JOIN customers C ON O.customer_id = C.customer_id;

-- Find customers who haven’t placed any orders
SELECT C.customer_id, C.name, C.email
FROM customers C
LEFT JOIN orders O ON C.customer_id = O.customer_id
WHERE O.order_id IS NULL;

-- Employees & Departments
-- Retrieve all employees and their department names
SELECT E.emp_id, E.name, D.dept_name
FROM employees E
LEFT JOIN departments D ON E.department_id = D.department_id;

-- Find departments that have no employees
SELECT D.department_id, D.dept_name
FROM departments D
LEFT JOIN employees E ON D.department_id = E.department_id
WHERE E.emp_id IS NULL;

-- Filtering with Aggregation & JOIN
-- Retrieve the average grade per course
SELECT C.title, AVG(E.grade) AS avg_grade
FROM enrollments E
JOIN courses C ON E.course_id = C.course_id
GROUP BY C.title;

-- List students who are not enrolled in any courses
SELECT S.student_id, S.name
FROM students S
LEFT JOIN enrollments E ON S.student_id = E.student_id
WHERE E.course_id IS NULL;

-- Find students who scored above the course average grade
SELECT E.student_id, S.name, C.title, E.grade
FROM enrollments E
JOIN courses C ON E.course_id = C.course_id
JOIN students S ON E.student_id = S.student_id
WHERE E.grade > (SELECT AVG(grade) FROM enrollments WHERE course_id = C.course_id);

-- Product Sales Analysis with JOINS
-- Retrieve all products that have never been sold
SELECT P.product_id, P.product_name
FROM products P
LEFT JOIN order_items OI ON P.product_id = OI.product_id
WHERE OI.product_id IS NULL;

-- Find the top 3 best-selling products based on total quantity sold
SELECT P.product_name, SUM(OI.quantity) AS total_quantity
FROM order_items OI
JOIN products P ON OI.product_id = P.product_id
GROUP BY P.product_name
ORDER BY total_quantity DESC
LIMIT 3;

-- Get the total revenue per product category
SELECT P.category, SUM(OI.quantity * OI.price) AS total_revenue
FROM order_items OI
JOIN products P ON OI.product_id = P.product_id
GROUP BY P.category;

-- Customer Order Behavior Analysis
-- Find customers who have placed more than 5 orders
SELECT C.customer_id, C.name, COUNT(O.order_id) AS order_count
FROM customers C
JOIN orders O ON C.customer_id = O.customer_id
GROUP BY C.customer_id, C.name
HAVING order_count > 5;

-- Retrieve the total amount spent per customer
SELECT C.customer_id, C.name, SUM(O.total_amount) AS total_spent
FROM customers C
JOIN orders O ON C.customer_id = O.customer_id
GROUP BY C.customer_id, C.name;

-- Get customers who haven’t placed any orders in the last 6 months
SELECT C.customer_id, C.name
FROM customers C
LEFT JOIN orders O ON C.customer_id = O.customer_id AND O.order_date >= NOW() - INTERVAL 6 MONTH
WHERE O.order_id IS NULL;

-- Mastering Aggregations with HAVING & JOINS
-- Find total revenue per region where revenue exceeds $10,000
SELECT region, SUM(quantity * price) AS total_revenue
FROM sales
GROUP BY region
HAVING total_revenue > 10000;

-- Retrieve the lowest revenue-generating product
SELECT product_name, SUM(quantity * price) AS total_revenue
FROM sales
GROUP BY product_name
ORDER BY total_revenue ASC
LIMIT 1;

-- Get the monthly revenue for the past 6 months
SELECT DATE_FORMAT(sale_date, '%Y-%m') AS month, SUM(quantity * price) AS total_revenue
FROM sales
WHERE sale_date >= NOW() - INTERVAL 6 MONTH
GROUP BY month
ORDER BY month DESC;

-- Complex Many-to-Many Relationship: Student-Course Enrollments
-- Retrieve all students along with their enrolled courses
SELECT S.name AS student_name, C.title AS course_name
FROM enrollments E
JOIN students S ON E.student_id = S.student_id
JOIN courses C ON E.course_id = C.course_id;

-- Find students enrolled in more than 3 courses
SELECT E.student_id, S.name, COUNT(E.course_id) AS course_count
FROM enrollments E
JOIN students S ON E.student_id = S.student_id
GROUP BY E.student_id, S.name
HAVING course_count > 3;

-- Get the highest and lowest grades for each course
SELECT C.title, MAX(E.grade) AS highest_grade, MIN(E.grade) AS lowest_grade
FROM enrollments E
JOIN courses C ON E.course_id = C.course_id
GROUP BY C.title;
