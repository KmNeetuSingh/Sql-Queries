1. **What are the different types of loops in C#?**
   - The different types of loops in C# are:
     - `for` loop
     - `while` loop
     - `do-while` loop
     - `foreach` loop

2. **Explain the syntax and working of the `for` loop in C#.**
   - Syntax:
     ```csharp
     for (initialization; condition; iterator)
     {
         // Code to execute
     }
     ```
   - Working:
     - The `initialization` step is executed once at the beginning.
     - The `condition` is evaluated before each iteration. If true, the loop executes; otherwise, it terminates.
     - The `iterator` is executed after each iteration.
     - Example:
       ```csharp
       for (int i = 0; i < 5; i++)
       {
           Console.WriteLine(i);
       }
       ```

3. **How does a `while` loop work?**
   - A `while` loop repeatedly executes a block of code as long as the specified condition is true.
   - Syntax:
     ```csharp
     while (condition)
     {
         // Code to execute
     }
     ```
   - Example:
     ```csharp
     int i = 0;
     while (i < 5)
     {
         Console.WriteLine(i);
         i++;
     }
     ```

4. **What is the difference between a `while` loop and a `do-while` loop?**
   - A `while` loop checks the condition before executing the loop body.
   - A `do-while` loop checks the condition after executing the loop body, ensuring the loop body runs at least once.
   - Example:
     ```csharp
     // while loop
     int i = 0;
     while (i < 0)
     {
         Console.WriteLine(i); // This will not execute
     }

     // do-while loop
     int j = 0;
     do
     {
         Console.WriteLine(j); // This will execute once
     } while (j < 0);
     ```

5. **What happens if the loop condition in a `while` loop is initially false?**
   - If the condition is initially false, the loop body will not execute at all.

6. **How do you use a `foreach` loop in C#?**
   - A `foreach` loop is used to iterate over collections like arrays, lists, etc.
   - Syntax:
     ```csharp
     foreach (var item in collection)
     {
         // Code to execute
     }
     ```
   - Example:
     ```csharp
     int[] numbers = { 1, 2, 3, 4, 5 };
     foreach (int num in numbers)
     {
         Console.WriteLine(num);
     }
     ```

7. **Can we modify elements inside a `foreach` loop? Why or why not?**
   - No, you cannot modify elements directly inside a `foreach` loop because `foreach` uses an enumerator, which does not allow modification of the collection during iteration.

---

### **Section 2: Intermediate Questions**

8. **What is an infinite loop? Provide examples using `for`, `while`, and `do-while`.**
   - An infinite loop is a loop that never terminates because its condition always evaluates to true.
   - Examples:
     ```csharp
     // for loop
     for (;;)
     {
         Console.WriteLine("Infinite loop");
     }

     // while loop
     while (true)
     {
         Console.WriteLine("Infinite loop");
     }

     // do-while loop
     do
     {
         Console.WriteLine("Infinite loop");
     } while (true);
     ```

9. **How does the `break` statement work inside loops?**
   - The `break` statement terminates the loop immediately and transfers control to the statement following the loop.
   - Example:
     ```csharp
     for (int i = 0; i < 10; i++)
     {
         if (i == 5)
             break;
         Console.WriteLine(i);
     }
     ```

10. **What is the role of the `continue` statement in loops?**
    - The `continue` statement skips the remaining code in the current iteration and moves to the next iteration of the loop.
    - Example:
      ```csharp
      for (int i = 0; i < 10; i++)
      {
          if (i % 2 == 0)
              continue;
          Console.WriteLine(i);
      }
      ```

11. **How can you exit multiple nested loops at once?**
    - You can use a `goto` statement or a flag variable to exit multiple nested loops.
    - Example using `goto`:
      ```csharp
      for (int i = 0; i < 10; i++)
      {
          for (int j = 0; j < 10; j++)
          {
              if (i * j > 50)
                  goto ExitLoops;
          }
      }
      ExitLoops:
      Console.WriteLine("Exited loops");
      ```

12. **What is the difference between `break` and `return` inside a loop?**
    - `break` exits the loop and continues executing the code after the loop.
    - `return` exits the entire method (or function) in which the loop is defined.

13. **How do you iterate through an array using loops?**
    - You can use a `for` loop or `foreach` loop to iterate through an array.
    - Example:
      ```csharp
      int[] numbers = { 1, 2, 3, 4, 5 };
      for (int i = 0; i < numbers.Length; i++)
      {
          Console.WriteLine(numbers[i]);
      }
      ```

14. **Write a C# program to find the largest and smallest number in an array using loops.**
    ```csharp
    int[] numbers = { 10, 20, 5, 30, 15 };
    int largest = numbers[0];
    int smallest = numbers[0];

    for (int i = 1; i < numbers.Length; i++)
    {
        if (numbers[i] > largest)
            largest = numbers[i];
        if (numbers[i] < smallest)
            smallest = numbers[i];
    }

    Console.WriteLine("Largest: " + largest);
    Console.WriteLine("Smallest: " + smallest);
    ```

---

### **Section 3: Advanced Questions**

15. **Can a `for` loop run indefinitely? If yes, how?**
    - Yes, a `for` loop can run indefinitely if the condition is always true.
    - Example:
      ```csharp
      for (;;)
      {
          Console.WriteLine("Infinite loop");
      }
      ```

16. **How do you implement a loop using recursion instead of traditional looping constructs?**
    - Example:
      ```csharp
      void RecursiveLoop(int n)
      {
          if (n <= 0)
              return;
          Console.WriteLine(n);
          RecursiveLoop(n - 1);
      }
      RecursiveLoop(5);
      ```

17. **What is the impact of using `goto` inside loops? Is it recommended? Explain with an example.**
    - Using `goto` can make code harder to read and maintain. It is generally not recommended.
    - Example:
      ```csharp
      for (int i = 0; i < 10; i++)
      {
          if (i == 5)
              goto ExitLoop;
      }
      ExitLoop:
      Console.WriteLine("Exited loop");
      ```

18. **How does a `foreach` loop work internally in C#?**
    - A `foreach` loop uses an enumerator to iterate over a collection. 
    It calls the `GetEnumerator` method of the collection and
     uses the `MoveNext` and `Current` properties of the enumerator.

19. **Can a `foreach` loop be replaced with a `for` loop? If yes, in what cases?**
    - Yes, a `foreach` loop can be replaced with a `for` loop when working with indexable 
    collections like arrays or lists.
    - Example:
      ```csharp
      int[] numbers = { 1, 2, 3, 4, 5 };
      for (int i = 0; i < numbers.Length; i++)
      {
          Console.WriteLine(numbers[i]);
      }
      ```

20. **How do you optimize performance in loops when working with large datasets?**
    - Use efficient algorithms and data structures.
    - Minimize operations inside loops.
    - Avoid unnecessary computations or method calls.
    - Use `Parallel.ForEach` for CPU-bound tasks.

21. **What are the best practices for writing efficient loops in C#?**
    - Use the appropriate loop construct (`for`, `while`, `foreach`).
    - Minimize the scope of loop variables.
    - Avoid unnecessary computations inside loops.
    - Use `break` and `continue` judiciously.

22. **How does the `Parallel.ForEach` loop differ from a normal `foreach` loop? Provide an example.**
    - `Parallel.ForEach` executes iterations in parallel, utilizing multiple CPU cores,
     while `foreach` executes iterations sequentially.
    - Example:
      ```csharp
      List<int> numbers = Enumerable.Range(1, 100).ToList();
      Parallel.ForEach(numbers, num =>
      {
          Console.WriteLine(num);
      });
      ```

---

### **Bonus Challenge**

23. **Write a C# program that processes a list of tasks using both normal `foreach` and `Parallel.ForEach` loops.**
    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            List<int> tasks = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Normal foreach:");
            foreach (var task in tasks)
            {
                ProcessTask(task);
            }

            Console.WriteLine("Parallel.ForEach:");
            Parallel.ForEach(tasks, task =>
            {
                ProcessTask(task);
            });
        }

        static void ProcessTask(int task)
        {
            Console.WriteLine($"Processing task {task} on thread {Task.CurrentId}");
            Task.Delay(100).Wait(); // Simulate work
        }
    }
    ```

24. **Compare and explain the output.**
    - The `foreach` loop processes tasks sequentially, while `Parallel.ForEach` processes tasks
     concurrently, leading to faster execution for CPU-bound tasks.

25. **How does parallel processing improve performance in this scenario?**
    - Parallel processing divides the workload across multiple CPU cores,
     reducing the total execution time for large datasets or CPU-intensive tasks.

