namespace BehavioralPatterns
{
    public interface IObservable //наблюдаемый объект
    {
        void RegisterObserver(IObserver o); //Attach
        void RemoveObserver(IObserver o); //Detach
        void NotifyObservers(); //Notify
    }
}