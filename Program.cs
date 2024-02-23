using HTTPUtils;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

Console.Clear();
Console.WriteLine("Starting Assignment 2");

// SETUP 
const string myPersonalID = "971ca776bbb3f682147c0b19b5997a3caa82ddc97abd45c0fc5cfd8a573cd34e"; // GET YOUR PERSONAL ID FROM THE ASSIGNMENT PAGE https://mm-203-module-2-server.onrender.com/
const string baseURL = "https://mm-203-module-2-server.onrender.com/";
const string startEndpoint = "start/"; // baseURl + startEndpoint + myPersonalID
const string taskEndpoint = "task/";   // baseURl + taskEndpoint + myPersonalID + "/" + taskID

// Creating a variable for the HttpUtils so that we dont have to type HttpUtils.instance every time we want to use it
HttpUtils httpUtils = HttpUtils.instance;

//#### REGISTRATION
// We start by registering and getting the first task
Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); // Print the response from the server to the console
string taskID = "aLp96"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

//#### FIRST TASK 
// Fetch the details of the task from the server.
Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Task task1 = JsonSerializer.Deserialize<Task>(task1Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task1?.title}{ANSICodes.Reset}\n{task1?.description}\nParameters: {Colors.Yellow}{task1?.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
static string CheckOddOrEven(string result, int number)
{
    return number % 2 == 0 ? "even" : "odd";
}
var answer = task1?.parameters.Split(",").Select(p => int.Parse(p.Trim())).Aggregate("mixed", CheckOddOrEven);

// Send the answer to the server
Response task1AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer.ToString());
Console.WriteLine($"Answer: {Colors.Green}{answer}\n{task1AnswerResponse}{ANSICodes.Reset}");

taskID = "kuTw53L"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

Console.WriteLine("\n-----------------------------------\n");
Console.WriteLine(task1Response);

//#### SECOND TASK
// Fetch the details of the task from the server.
Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Console.WriteLine(task2Response);
Task task2 = JsonSerializer.Deserialize<Task>(task2Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task2?.title}{ANSICodes.Reset}\n{task2?.description}\nParameters: {Colors.Yellow}{task2?.parameters}{ANSICodes.Reset}");

// Calculate the answer to the task
static bool IsPrime(int number)
{
    if (number < 2)
    {
        return false;
    }
    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            return false;
        }
    }
    return true;
}

var answer2 = task2.parameters.Split(",").Select(p => int.Parse(p.Trim())).Where(n => IsPrime(n)).OrderBy(n => n).ToList();

// Convert prime numbers list to string for sending back as a response
string primeNumbersString = string.Join(",", answer2);

// Output the prime numbers
Console.WriteLine($"Prime Numbers: {primeNumbersString}");

// Send the answer to the server
Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, primeNumbersString);
Console.WriteLine($"Answer: {Colors.Green}{string.Join(", ", answer2)}\n{task2AnswerResponse}{ANSICodes.Reset}");

taskID = "otYK2"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

Console.WriteLine("\n-----------------------------------\n");
Console.WriteLine(task2Response);

//#### THIRD TASK
// Fetch the details of the task from the server.
Response task3Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); // Get the task from the server
Console.WriteLine(task3Response);
Task task3 = JsonSerializer.Deserialize<Task>(task3Response.content);
Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{task3?.title}{ANSICodes.Reset}\n{task3?.description}\nParameters: {Colors.Yellow}{task3?.parameters}{ANSICodes.Reset}");


// Calculate the answer to the task

// Convert prime numbers list to string for sending back as a response
static string GetUniqueWordsInAlphabeticalOrder(string input)
{
    // Split the input string into words
    string[] words = input.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

    // Get unique words in alphabetical order
    var answer3 = words.Select(w => w.Trim()).Distinct().OrderBy(w => w);

    // Join the unique words back to a single string separated by spaces
    string result = string.Join(" ", answer3);

    return result;
}

var answer3 = task3?.parameters.Split(",").Select(p => p.Trim()).Distinct().OrderBy(p => p);
// Output the prime numbers


// Send the answer to the server
Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID,string.Join(",", answer3));
Console.WriteLine($"Answer: {Colors.Green}{string.Join(",", answer3)}\n{task3AnswerResponse}{ANSICodes.Reset}");

taskID = "psu31_4"; // We get the taskID from the previous response and use it to get the task (look at the console output to find the taskID)

Console.WriteLine("\n-----------------------------------\n");
Console.WriteLine(task2Response);






class Task
{
    public string? title { get; set; }
    public string? description { get; set; }
    public string? taskID { get; set; }
    public string? usierID { get; set; }
    public string? parameters { get; set; }
}