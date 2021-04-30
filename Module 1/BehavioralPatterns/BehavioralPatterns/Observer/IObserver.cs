using System;

namespace BehavioralPatterns
{
    public interface IObserver
    {
        void Update(Object ob); //я хочу передавать объект StockInfo с текущей информацией о торгах,
                                //чтобы принимать решение о покупке или продаже евро/долларов
    }
}