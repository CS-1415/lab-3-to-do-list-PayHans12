//Payton Hansen
//10 september 2025
//To do list lab 3

List<Task> toDoList = new List<Task>();
int id = int.MaxValue; //This is for checking the id value before marking complete or displaying the discription. 
//its sent as the ints max value to be greater than any reasonanbly possible task id

while (true)
{
    Console.Clear();
    Console.WriteLine("  id  tasks");
    Console.WriteLine("-------------------------");
    foreach (Task item in toDoList)
    {
        item.DisplayTask();
    }

    Console.WriteLine("\nPress \"+\" to add a task. Press \"x\" to toggle whether or not the task is complete. Press \"i\" to view a task's information.");
    switch (Console.ReadLine())
    {
        case "+":
            Task newTask = new Task();

            toDoList.Add(newTask);
            newTask.ID = toDoList.Count;

            Console.WriteLine("What is the title of the task?");
            newTask.Title = Console.ReadLine();

            Console.WriteLine("What is the tasks description?");
            newTask.Description = Console.ReadLine();
            break;
        case "x":
            while (true)
            {
                Console.Write("What is the ID of the task you wish to mark completed? ");
                //Got a little ahead of my self here. I went to Chapter 35 to learn how to make this not fail if they enter something I dont want.
                //I didn't want to make a huge complicated thing so I searched in the book for a solution.
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (id <= toDoList.Count)
                    {
                        break;
                    }
                }
                catch (Exception) { }
            }

            foreach (Task item in toDoList)
            {
                if (item.ID == id)
                {
                    item.IsComplete = true;
                }
            }
            break;
        case "i":
            id = int.MaxValue;
            while (true)
            {
                Console.Write("What is the ID of the task you wish to mark completed? ");
                //Same thing over here
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (id <= toDoList.Count)
                    {
                        break;
                    }
                }
                catch (Exception) { }
            }

            foreach (Task item in toDoList)
            {
                if (item.ID == id)
                {
                    item.DislayDescription();
                }
            }
            break;
        default:
            break;
    }
}


class Task
{
    private int id;
    private string title;
    private string description;
    private bool isComplete = false;
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplete { get; set; }

    public void DisplayTask()
    {
        Console.WriteLine($"{id}    {title}");
    }

    public void DislayDescription()
    {
        Console.WriteLine($"{description}");
    }

    public void MarkAsCompleted()
    {
        isComplete = true;
    }
}