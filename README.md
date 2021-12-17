## NOTES

- I have only excluded code from test coverage where I see there is no significant functionality to test.

## Original Requirements
Develop a console application in .Net: 

The aim of the coffee solution is to create a drink based on user input. You are required to provide the machine with the following capabilities: 
- Create a cappuccino drink. In order to make a cappuccino the user must provide the amount of sugar required. A cappuccino requires 5 beans to make, coffee requires 2 and a Latte requires 3. 
- Coffee should require the selection of whether a user would like Milk or not. We may assume other drinks always require milk. 
- Change the console app(user interface) so that a user has the ability to select more drinks whenever a drink is ready. The machine should only turn off when the user sends the command "off". 
- Implement tracking of the number of beans and remaining milk capacity in the machine. An appropriate message should be displayed should there be insufficient beans or milk remaining in the machine for the selection. Milk Requirements per drink: Coffee - 1 Milk unit, Latte - 2 Milk units, Cappuccino - 3 Milk units. 
- The machines maximum bean capacity is 25. The maximum milk capacity is 20. 

Pay special attention to the following: 
- SOLID. 
- Unit tests should be written where applicable and should run successfully 
- Code readability. Imagine you are working in a team of developers that will need to maintain your code 

**Bonus:** Display a message to user when the bean capacity has reached 5 or lower, informing them of a low bean capacity. 

_________________________________ 

We do strongly penalise the following: 
- Violations of single responsibility. The program.cs file should be clean and services shouldn’t have multiple responsibilities.  
- Failing unit tests. All tests should pass and be written where required  

You may share your submission with either via a file share or a repository.   
Unfortunately our mail security will block your code should you try and email it to me.  
