/*
SemaphoreSlim fork1 = new SemaphoreSlim(1);
SemaphoreSlim fork2 = new SemaphoreSlim(1);
SemaphoreSlim fork3 = new SemaphoreSlim(1);
SemaphoreSlim fork4 = new SemaphoreSlim(1);
SemaphoreSlim fork5 = new SemaphoreSlim(1);




void DinninPhilosophers(object leftChopstick, object rightChopstick, int philosopherNumber)
{
    while (true)
    {
        lock (leftChopstick)                // Grab utencil on the left 
        {
            lock (rightChopstick)           // Grab utencil on the right 
            {
                // Eat here 
                Console.WriteLine("Philosopher {0} eats.", philosopherNumber);
            }
        }

        const int numPhilosophers = 5;

        // 5 utencils on the left and right of each philosopher. Use them to acquire locks. 
        var chopsticks = new Dictionary<int, object>(numPhilosophers);

        for (int i = 0; i < numPhilosophers; ++i)
        {
            chopsticks.Add(i, new object());
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
*/