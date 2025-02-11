### **Basic Level**

**Q1: What is a primary key in a database, and why is it important? Provide an example using the students table.**  
- A **primary key** is a unique identifier for each record in a table. It ensures no two rows have the same value for this column.  
- **Importance**: It helps maintain data integrity, enables fast searching, and establishes relationships between tables.  
- **Example**: In the `students` table, the `id` column is the primary key. Each student has a unique `id` (e.g., 1 for Alice, 2 for Bob).

---

**Q2: What does the SELECT statement do in MySQL? Write a query to retrieve all records from the students table.**  
- The `SELECT` statement retrieves data from a table.  
- **Query**:  
  ```sql
  SELECT * FROM students;
  ```  
  This will return all rows and columns from the `students` table.

---

**Q3: How do you insert data into a table using MySQL? Insert a new student (id: 5, name: Emily, age: 21) into the students table.**  
- Use the `INSERT INTO` statement to add data.  
- **Query**:  
  ```sql
  INSERT INTO students (id, name, age) VALUES (5, 'Emily', 21);
  ```  
  This adds a new row with `id = 5`, `name = Emily`, and `age = 21`.

---

**Q4: What is the purpose of a foreign key? Explain with respect to the orders table.**  
- A **foreign key** links two tables by referencing the primary key of another table.  
- **Example**: In the `orders` table, the `customer_id` is a foreign key that references the `id` column in the `students` table. This ensures that every order is associated with a valid student.

---

**Q5: How can you delete a record from the students table where the id = 2?**  
- Use the `DELETE` statement.  
- **Query**:  
  ```sql
  DELETE FROM students WHERE id = 2;
  ```  
  This removes the student with `id = 2` (Bob) from the table.

---

**Q6: What is the difference between DELETE and TRUNCATE in SQL? Provide an example.**  
- **DELETE**: Removes specific rows (can use a `WHERE` clause). It logs each deletion, so it’s slower.  
  ```sql
  DELETE FROM students WHERE age < 18;
  ```  
- **TRUNCATE**: Removes all rows from a table. It’s faster but cannot use a `WHERE` clause.  
  ```sql
  TRUNCATE TABLE students;
  ```

---

**Q7: How can you update a student's age? Write a query to update Charlie’s age to 21 in the students table.**  
- Use the `UPDATE` statement.  
- **Query**:  
  ```sql
  UPDATE students SET age = 21 WHERE name = 'Charlie';
  ```  
  This changes Charlie’s age to 21.

---

### **Medium Level**

**Q1: Why do we need tabular data instead of storing everything in a single file? Explain the benefits using the students and orders tables.**  
- **Benefits**:  
  1. **Data Integrity**: Tables enforce rules (e.g., primary keys, foreign keys) to prevent duplicate or invalid data.  
  2. **Efficiency**: Tables allow faster searching and sorting using indexes.  
  3. **Scalability**: Tables can handle large datasets better than a single file.  
  4. **Relationships**: Tables can be linked (e.g., `students` and `orders`), enabling complex queries.  

---

**Q2: Understanding database relationships, how does the customer_id in the orders table relate to the id in the students table? Why is this important?**  
- The `customer_id` in the `orders` table is a foreign key that references the `id` in the `students` table.  
- **Importance**: It ensures that every order is associated with a valid student, maintaining data consistency and enabling queries like "Find all orders placed by Alice."

---

**Q3: Write an SQL query to find all orders placed after January 12, 2025.**  
- **Query**:  
  ```sql
  SELECT * FROM orders WHERE order_date > '2025-01-12';
  ```  
  This retrieves all orders with `order_date` after January 12, 2025.

---

**Q4: Write an SQL query to delete all records from the orders table where the order_status is "Cancelled".**  
- **Query**:  
  ```sql
  DELETE FROM orders WHERE order_status = 'Cancelled';
  ```  
  This removes all cancelled orders.

---

### **Hard Level**

**Q1: Write an SQL query to find the total number of orders placed by each student, showing the results in ascending order of total orders.**  
- **Query**:  
  ```sql
  SELECT s.name, COUNT(o.order_id) AS total_orders
  FROM students s
  LEFT JOIN orders o ON s.id = o.customer_id
  GROUP BY s.id
  ORDER BY total_orders ASC;
  ```  
  This shows the number of orders per student, sorted by the total number of orders.

---

**Q2: Write an SQL query to display all students who have not placed any orders.**  
- **Query**:  
  ```sql
  SELECT s.name
  FROM students s
  LEFT JOIN orders o ON s.id = o.customer_id
  WHERE o.order_id IS NULL;
  ```  
  This lists students who have not placed any orders.

---





 