1. In a relational database, relational means that data is stored in tables connected by common fields. For example, a company database may have a Customers table that contains customer details and an Orders table that contains order details. These two tables are related through a CustomerID field so you can tell which customer made which order.

2. Keys uniquely identify records and establish relationships between tables. A **Primary Key** uniquely identifies each record in a table. A **Foreign Key** refers to the Primary Key of another table to establish a relationship. For instance, in an e-commerce database, the "Products" table has "ProductID" as a Primary Key; the "OrderDetails" table will have "ProductID" as a Foreign Key in order to connect orders with respective products.

3. ACID properties ensure database reliability: 
  - Atomicity ensures that either a transaction completes entirely or does not happen at all. When money is subtracted from one account but added to another, the transaction is rolled back.
- **Consistency:** The database is never invalid both before and after a transaction. For example, after booking a flight ticket, the available seats have been decreased.  
Isolation: Ensures that several transactions don't interleave. For instance, two different users can buy a ticket for a film but won't be allocated the same seat.
- **Persistence** ensures once a transaction is committed, it stays permanently, even in the event of a system crash. After placing an online order, the information is saved.

4. SQL databases are structured tables and predefined schemas, which are ideal for complex queries and relationships. Examples include MySQL and PostgreSQL, commonly used in banking and finance. NoSQL databases do not require fixed schemas, making them suitable for handling large-scale, flexible, and real-time data. Examples include MongoDB and Firebase, used in social media and big data applications.

5. MySQL Workbench is a tool for managing MySQL databases. It enables users to write SQL queries, execute the same, create and edit tables, manage database connections, and visualize the schema of databases. 6. Normalization structures the database to avoid redundancy and to improve efficiency.  - **1NF** ensures each column contains atomic values.
- **2NF** eliminates partial dependencies, that is, a non-key column should depend only on the whole primary key.  
   - **3NF** removes transitive dependencies, that is, all non-key columns depend only on the primary key.  
   - **BCNF** is an advanced form of 3NF, handling special cases.

7. NoSQL databases provide scalability, flexibility, and high performance. Examples include Instagram (MongoDB), real-time analytics like Elasticsearch for search engines, and IoT applications like Redis for fast data access.

8. A transaction is a set of database operations that execute as a single unit. For example, in an online purchase, there will be stock deducted, updating user payment history, and generation of receipt. In case any of these steps fail, the whole transaction will roll back to maintain data consistency.

9. Indexing improves query performance as it provides a data structure to speed up searches. For instance, looking for a student by StudentID in a large table will be faster if there is an index on "StudentID" than to scan the entire table.

10. Foreign Keys link tables together and maintain the integrity of related data. They prevent orphan records, for example, an order existing without a valid customer. If the Orders table contains a CustomerID that does not exist in the Customers table, the database will prevent adding such an order.

11. Data consistency ensures that database information follows rules and remains accurate. For instance, if a bank transfer updates one account but not the other, the data becomes inconsistent. The **Consistency** property in ACID ensures that all changes follow database rules, maintaining integrity.  

12. MySQL can import CSV files using the `LOAD DATA INFILE` statement:  
   ```sql
   LOAD DATA INFILE 'file.csv'
```
INTO TABLE table_name 
   FIELDS TERMINATED BY ',' 
   LINES TERMINATED BY '\
';
   ``
   Most frequent mistakes are as follows:
   - **File not found**: Check whether the file is present in the right directory.  
   - **Column mismatch**: Check your columns of your CSV should be matching with the tables structure.
Access denied: Use GRANT Permission to give the MySQL user permission to read the file.
