
SemaphoreSlim leftFork = new SemaphoreSlim(1);
SemaphoreSlim rightFork= new SemaphoreSlim(1);


void DinninPhilosophers()
{
    while (true)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Philosopher is thinking..");
        Thread.Sleep(200);
        leftFork.Wait();
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Philosopher taking left fork");

        rightFork.Wait();
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Philosopher taking right fork");

        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Philosopher is eating");
        Thread.Sleep(150);
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Philosopher finished eating");
        leftFork.Release();
        rightFork.Release();
        Thread.Sleep(100);
    }


}


Thread phil1 = new Thread(() =>
{
    DinninPhilosophers();
});

Thread phil2 = new Thread(() =>
{
    DinninPhilosophers();
});

Thread phil3 = new Thread(() =>
{
    DinninPhilosophers();
});

Thread phil4 = new Thread(() =>
{
    DinninPhilosophers();
});

Thread phil5 = new Thread(() =>
{
    DinninPhilosophers();
});

phil1.Start();
phil2.Start();
phil3.Start();
phil4.Start();
phil5.Start();

/* int philisopherNumber = 5;
 Task[] philosiphers;
 SemaphoreSlim[] chopsticks;


    philosiphers = new Task[philisopherNumber];
    chopsticks = new SemaphoreSlim[philisopherNumber];

    for (int i = 0; i < philisopherNumber; ++i)
    {
        philosiphers[i] = GenerateNewPhilosopher(i);
        chopsticks[i] = new SemaphoreSlim(1);
    }

    Task.WaitAll(philosiphers);
    Console.WriteLine("Finished eating. HUZZAH!");
    Console.ReadLine();


  Task GenerateNewPhilosopher(int philosipherIndex)
{
    return Task.Run(() =>
    {

        for (int i = 0; i < 100; ++i)
        {
            Console.WriteLine($"Phil {philosipherIndex}: Attempting to get food");

            var chopstick1 = GetChopstickIndex(philosipherIndex);
            var chopstick2 = GetChopstickIndex(philosipherIndex + 1);
            var chopsticksList = new List<int>() { chopstick1, chopstick2 }.OrderBy(index => index).ToList();
            foreach (var chopstickIndex in chopsticksList)
            {
                chopsticks[chopstickIndex].Wait();
            }

            Console.WriteLine($"Phil {philosipherIndex}: Eating");
            Task.Delay(100); // NOM NOM NOM

            chopsticks[GetChopstickIndex(philosipherIndex)].Release();
            chopsticks[GetChopstickIndex(philosipherIndex + 1)].Release();
        }
    });
}

  int GetChopstickIndex(int index)
{
    return index % philisopherNumber;
}
*/