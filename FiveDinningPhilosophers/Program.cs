

int numberOfPhilosophers = 5;
Task[] philosophers;
SemaphoreSlim[] chopsticks = new SemaphoreSlim[numberOfPhilosophers];

philosophers = new Task[numberOfPhilosophers];
chopsticks = new SemaphoreSlim[numberOfPhilosophers];

for (int i = 0; i < numberOfPhilosophers; i++)
{

    philosophers[i] = DiningProcess(i);
    chopsticks[i] = new SemaphoreSlim(1);
}



 Task DiningProcess (int philosopherIndex)
{
    return Task.Run(() => { 
    
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Philosopher {philosopherIndex}: Is hungry and would like to eat");

            var chopstick1 = GetChopstickIndex(philosopherIndex);
            var chopstick2 = GetChopstickIndex(philosopherIndex + 1);

            var chopstickList = new List<int> { chopstick1, chopstick2 }.OrderBy(index => index).ToList();

            foreach(var chopstickIndex in chopstickList)
            {
                chopsticks[chopstickIndex].Wait();
            }

            Console.WriteLine($"Philosopher {philosopherIndex} is Eating");
            Thread.Sleep(200);
            Console.WriteLine($"Philosopher {philosopherIndex} Put chopsticks down.");
            chopsticks[GetChopstickIndex(philosopherIndex)].Release();
            chopsticks[GetChopstickIndex(philosopherIndex + 1)].Release();
            Console.WriteLine($"Philosopher {philosopherIndex} Thinking...");
            Thread.Sleep (200);

        }
    
    });
}

 int  GetChopstickIndex(int index)
{
    return index % numberOfPhilosophers;
}

Task.WaitAll(philosophers);
Console.WriteLine("Bawl is empty... All philosophers has finished dinner");
Console.ReadLine();