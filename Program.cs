using System;

namespace SalesApp
{
    // Создание собственного класса исключения
    public class SaleProhibitedException : Exception
    {
        // Конструктор, который вызывает конструктор базового класса
        public SaleProhibitedException(string message) : base(message)
        {
        }
    }

    // Класс "Покупатель"
    public class Buyer
    {
        public int Age { get; set; }    // Свойство "Возраст"

        // Конструктор, который задает возраст покупателя
        public Buyer(int age)
        {
            Age = age;
        }
    }

    // Класс "Продавец"
    public class Seller
    {
        // Метод для продажи товара
        public void Sell(string product, Buyer buyer)
        {
            // Проверка, если товар равен "алкоголь" и возраст покупателя меньше 18
            if (product == "алкоголь" && buyer.Age < 18)
            {
                // Порождение исключения
                throw new SaleProhibitedException("Продажа запрещена!");
            }

            // Если условия продажи выполнены
            Console.WriteLine("Товар продан");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание экземпляров класса "Покупатель"
            Buyer buyer1 = new Buyer(17);  // Покупатель с возрастом 17
            Buyer buyer2 = new Buyer(20);  // Покупатель с возрастом 20

            // Создание экземпляра класса "Продавец"
            Seller seller = new Seller();

            try
            {
                // Попытка продать алкоголь покупателю 1 (должно выдать исключение)
                seller.Sell("алкоголь", buyer1);
            }
            catch (SaleProhibitedException ex)
            {
                // Обработка собственного исключения и вывод сообщения
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Обработка всех остальных возможных исключений
                Console.WriteLine($"Общая ошибка: {ex.Message}");
            }

            try
            {
                // Попытка продать алкоголь покупателю 2 (должно пройти успешно)
                seller.Sell("алкоголь", buyer2);
            }
            catch (SaleProhibitedException ex)
            {
                // Обработка собственного исключения и вывод сообщения
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Обработка всех остальных возможных исключений
                Console.WriteLine($"Общая ошибка: {ex.Message}");
            }
        }
    }
}