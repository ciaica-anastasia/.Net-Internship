using System;
using System.Collections.Generic;

namespace BehavioralPatterns
{
    public class Stock : IObservable //валютная биржа
    {
        StockInfo sInfo; // информация о торгах

        List<IObserver> observers;

        public Stock()
        {
            observers = new List<IObserver>();
            sInfo = new StockInfo();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(sInfo); //объект передает данные о своем состоянии
            }
        }

        public void Market() //имитирует торги и инкапсулирует всю информацию о валютных курсах в StockInfo
        {
            Random rnd = new Random();
            sInfo.USD = rnd.Next(15, 20);
            sInfo.Euro = rnd.Next(15, 25);
            NotifyObservers(); //уведомление после торгов
        }
    }
}