# TaskManager

A simple task manager application to create tasks for personal use,to check off tasks as completed


Feature: Current Date should be display in the application

The current date is always shown at the top right of the application.


Feature: Create a new task

1. A task must always have a task ID
2. If you do not enter the task ID, the Create and Update buttons will remain disabled.
3. Enter the task ID and click on Tab or go to any other field. The Create and Update buttons are immediately enabled.
4. Enter the details of the task like TaskName, DueDate, Status etc. Click on Create. Task will be created and displayed in the table.
5. If the task is Pending (Status) and Current Date is beyond Due Date, the task will be marked as Overdue and the row shall display in RED.
6. The task is marked Completed, it will display in Green.

Feature: Name and rename tasks

1. Enter the task ID of an existing Task.
2. Now enter the TaskName that you want to give.
3. Click on Update.

You can update as many times as you want.

Feature: Assign a date a task is due.

1. You can assign a due date when creating the task.
2. You can also update the due date.

Feature: Mark a task as completed.

1. You can create a task and mark the Status as Completed.
2.You can also update the status of an existing task as Completed.
3. Status field is a drop down in the UI where you can select Pending and Completed.

Feature: Delete task that is no longer needed.

1. In the table, click on the Delete button against a task you want to delete.
2. Task is deleted.

Feature: Highlight tasks that are completed in green

1. If the task is marked Completed, it will display in Green.

Feature: Highlight tasks that are overdue in red

1.If the task is Pending (Status) and Current Date is beyond Due Date, the task will be marked as Overdue and the row shall display in RED.


Technology Stack Used:
.NET Framework 4.7.2
WPF with MVVM 
