string folderPath = @"C:\Users\krist\source\repos\Week9Lists\data";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myShoppingList = new List<string>();

if (File.Exists(filePath))
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
}


static List<string> GetItemsFromUser()
{
    List<string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine($"\nAdd an item (add) / Exit (exit)");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine($"Enter an item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else
        {
            Console.WriteLine($"Bye");
            break;
        }
    }

    return userList;
}

ShowItemsFromList(myShoppingList);


static void ShowItemsFromList(List<string> someList)
{
    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items yo your shopping list.");

    int i = 1;
    foreach (string item in someList)
    {
        Console.WriteLine($"{i}. {item}");
        i++;
    }
}

