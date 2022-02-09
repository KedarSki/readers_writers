
int numberOfPhilosophers = 5;
Task[] philosophers;
SemaphoreSlim[] forks = new SemaphoreSlim[numberOfPhilosophers];

philosophers = new Task[numberOfPhilosophers];
forks = new SemaphoreSlim[numberOfPhilosophers];

for (int i = 0; i < numberOfPhilosophers; i++)
{

    philosophers[i] = DiningProcess(i);
    forks[i] = new SemaphoreSlim(1);
}

int GetforkIndex(int index)
{
    return index % numberOfPhilosophers;
}

Task DiningProcess (int philosopherIndex)
{
    return Task.Run(() => { 
    
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Philosopher {philosopherIndex}: Is hungry and would like to eat");

            var fork1 = GetforkIndex(philosopherIndex);
            var fork2 = GetforkIndex(philosopherIndex + 1);

            var forkList = new List<int> { fork1, fork2 }.OrderBy(index => index).ToList();

            foreach(var forkIndex in forkList)
            {
                forks[forkIndex].Wait();
            }

            Console.WriteLine($"Philosopher {philosopherIndex} is Eating");
            Thread.Sleep(100);
            Console.WriteLine($"Philosopher {philosopherIndex} Put forks down.");
            forks[GetforkIndex(philosopherIndex)].Release();
            forks[GetforkIndex(philosopherIndex + 1)].Release();
            Console.WriteLine($"Philosopher {philosopherIndex} Thinking...");
            Thread.Sleep (200);

        }
    
    });
}



Task.WaitAll(philosophers);
Console.WriteLine("Bawl is empty... All philosophers has finished dinner");
Console.ReadLine();