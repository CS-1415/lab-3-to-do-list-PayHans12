//Payton Hansen
//10 september 2025
//To do list lab 3

List<Task> toDoList = new List<Task>();
int id = -1; //This is for checking the id value before marking complete or displaying the discription. 
//its sent as -1 because it checks for values > 0 and <= the List count

while (true)
{
    Console.Clear();
    Console.WriteLine("    id   tasks");
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
                    if (id <= toDoList.Count && id > 0)
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
                    item.IsComplete = !item.IsComplete;
                }
            }
            break;
        case "i":
            id = -1;
            while (true)
            {
                Console.Write("What is the ID of the task you wish to mark completed? ");
                //Same thing over here
                try
                {
                    id = int.Parse(Console.ReadLine());
                    if (id <= toDoList.Count && id > 0)
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
                    Console.WriteLine("Press enter to Continue");
                    Console.ReadLine();
                }
            }
            break;
        default:
            break;
    }
}


class Task
{
    private int iD;
    private string title;
    private string description;
    private bool isComplete = false;

    public int ID { get => iD; set => iD = value; }
    public string Title { get => title; set => title = value; }
    public string Description { get => description; set => description = value; }
    public bool IsComplete { get => isComplete; set => isComplete = value; }

    public void DisplayTask()
    {
        if (isComplete)
        {
            Console.WriteLine($"[x] {iD}    {title}");
        }
        else
        {
            Console.WriteLine($"[ ] {iD}    {title}");
        }
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