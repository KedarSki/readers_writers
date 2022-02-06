
int value1 = 100;
int value2 = 100;
ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
object _lock = new object();

void Writer()
{

    while (true)
    {

        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Writer: TRIES TO ENTER");

            _rw.EnterWriteLock();
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Writer: Enters");
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Writer:  Writing..");
            value1++;
            value2--;
            Thread.Sleep(100);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Writer:  Job Done! Left");
            _rw.ExitWriteLock();
            Thread.Sleep(100);
    }
}



void Reader()
{

    while (true)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Reader: TRIES TO ENTER");
        _rw.EnterReadLock();
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Reader: Enters");
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Reader: Reading {value1} and {value2}");
        Thread.Sleep(100);
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Reader: Job Done!.. Left");
        _rw.ExitReadLock();
        Thread.Sleep(200);

    }
}

Thread w1 = new Thread(() =>
{

    Writer();

});

Thread w2 = new Thread(() =>
{

    Writer();

});

Thread r1 = new Thread(() =>
{
    Reader();
});

Thread r2 = new Thread(() =>
{
    Reader();
});

Thread r3 = new Thread(() =>
{
    Reader();
});

Thread r4 = new Thread(() =>
{
    Reader();

});

Thread r5 = new Thread(() =>
{
    Reader();
});

w1.Start();
w2.Start();

r1.Start();
r2.Start();
r3.Start();
r4.Start();
r5.Start();




