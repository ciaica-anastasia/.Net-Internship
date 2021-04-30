using System;

namespace BehavioralPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //есть биржа, где проходят торги, и есть брокеры и банки, которые следят за поступающей информацией
            //и в зависимости от нее делают соответствующие действия
            Stock stock = new Stock();
            Bank bank = new Bank("VictoriaBank", stock);
            Broker broker = new Broker("Иван Иваныч", stock);
            
            // имитация торгов
            stock.Market();
            
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            
            // имитация торгов
            stock.Market();
        }
    }
}