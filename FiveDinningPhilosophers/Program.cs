
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
