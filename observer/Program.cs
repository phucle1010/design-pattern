using System;
using System.Collections.Generic;

// Đối tượng Subject (người ta có thể tưởng tượng nó là một loại sensor hoặc nguồn dữ liệu)
public class Publisher
{
    private List<ISubscriber> observers = new List<ISubscriber>();
    private int state;

    public int State
    {
        get { return state; }
        set
        {
            state = value;
            NotifyObservers();
        }
    }

    public void Attach(ISubscriber observer)
    {
        observers.Add(observer);
    }

    public void Detach(ISubscriber observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

// Interface cho các Observer
public interface ISubscriber
{
    void Update();
}

// Các lớp quan sát cụ thể
public class ConcreteSubscriberA : ISubscriber
{
    private string name;
    private Publisher publisher;

    public ConcreteSubscriberA(string name, Publisher publisher)
    {
        this.name = name;
        this.publisher = publisher;
        this.publisher.Attach(this);
    }

    public void Update()
    {
        Console.WriteLine(
            $"{name} nhận được thông báo: Trạng thái đã thay đổi thành {publisher.State}");
    }
}

public class ConcreteSubscriberB : ISubscriber
{
    private string name;
    private Publisher publisher;

    public ConcreteSubscriberB(string name, Publisher publisher)
    {
        this.name = name;
        this.publisher = publisher;
        this.publisher.Attach(this);
    }

    public void Update()
    {
        Console.WriteLine($"{name} nhận được thông báo: Trạng thái đã thay đổi thành {publisher.State}");
    }
}

public class Program
{
    static void Main()
    {
        Publisher publisher = new Publisher();
        ConcreteSubscriberA subscriberA = new ConcreteSubscriberA("Subscriber A", publisher);
        ConcreteSubscriberB subscriberB = new ConcreteSubscriberB("Subscriber B", publisher);

        publisher.State = 5; // Thay đổi trạng thái của Subject, tất cả các Observer sẽ nhận thông báo
        publisher.State = 10; // Thay đổi trạng thái của Subject, tất cả các Observer sẽ nhận thông báo
    }
}