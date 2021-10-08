using System;
using System.Collections.Generic;

namespace LR_7.Entities
{
    public delegate void BuyTicket();
    public delegate void TicketBaseChanging(Ticket ticket, bool operation); 
    public delegate void PassengerBaseChanging(Passenger passenger, bool operation); 
    public delegate void TaxeBaseChanging(Taxe taxe, bool operation); 
    
    public class Airport
    {
        public event BuyTicket OnBuy;
        public event PassengerBaseChanging OnPChanging;
        public event TicketBaseChanging OnTChanging;
        public event TaxeBaseChanging OnTaxeChanging;

        private Dictionary<string,Taxe> _taxeBase = new Dictionary<string,Taxe>();
        private List<string> _direction = new List<string>();
        private List<Passenger> _passengerBase = new List<Passenger>();
        private List<Ticket> _ticketBase = new List<Ticket>();
        
        private float _totalSum;
        private int _suitable;

        public Airport()
        {
            this._suitable = 0;
            this._totalSum = 0;
        }
        
        public Passenger AirRegistration()
        {
            Passenger passenger = new Passenger();
                        
            Console.Write("\nЖелаете пройти регистрацию?\n1. Да, желаю\n2. Нет, " +
                          "я уже проходил регистрацию\nВаш выбор: ");
            int reg = Convert.ToInt32(Console.ReadLine());
            
            if (reg == 1)
            {
                passenger.Registration();
                for (int i = 0; i < _passengerBase.Count; i++) 
                    if (_passengerBase[i].PassportNum == passenger.PassportNum) 
                    {
                        Console.WriteLine("Такой пассажир уже зарегестрирован. Если вы этого не дел" +
                                          "али, обратитесь в техподдержку.");
                        return null;
                    }
                
                _passengerBase.Add(passenger);
                OnPChanging?.Invoke(passenger, true);
                Console.Write("Ваши данные сохранены!\n");
                return passenger;
            }
            
            if (reg == 2) 
            {
                Console.Write("\nВведите номер вашего пасспорта: ");
                string passport = Console.ReadLine(); 
                for (int i = 0; i < _passengerBase.Count; i++) 
                    if (_passengerBase[i].PassportNum == passport) 
                    {
                        passenger = _passengerBase[i]; 
                        Console.Write("\nЗдравствуйте, " + passenger.FName + " " + passenger.SName + "!");
                        return passenger;
                    }
                Console.Write("Совпадений в базе не найдено.\n");
                return null;
            }

            Console.Write("Неверный ввод.\n");
            return null;
        }

        public void BuyTicket(Passenger passenger)
        {
            String finishPoint;
            
            Console.Write("Введите пункт назначения: ");
            finishPoint = Console.ReadLine();
                        
            Console.Write("\nВам подойдут следующие рейсы: ");
            for (int i = 0; i < _ticketBase.Count; i++)
                if (_ticketBase[i].FindSuitable(finishPoint))
                { 
                    Console.Write("\nНомер билета: " + i);
                    Console.WriteLine(_ticketBase[i].Info()); 
                    _suitable++;
                }

            if (_suitable == 0)
            {
                Console.WriteLine("\nСожалеем, но подходящих рейсов не найдено.");
                return;
            }

            Console.Write("\nВаш выбор: ");
            int indexTic = Convert.ToInt32(Console.ReadLine());
            if (indexTic < _ticketBase.Count)
            {
                Ticket temp = _ticketBase[indexTic]; 
                _totalSum += temp.Price;
                passenger.TotalSum += temp.Price;
                passenger._inPropertyTicket.Add(temp);
                OnBuy?.Invoke();
                return;
            }
                
            Console.Write("\nТакого билета нет в базе.");
        }

        private void AddTicket()
        {
            Ticket ticket = new Ticket();
            ticket.AddNewTicket();
            if (_taxeBase[ticket.FinishPoint] != null)
            {
                Taxe taxe = _taxeBase[ticket.FinishPoint];
                ticket.Price = taxe.Price;
                _ticketBase.Add(ticket);
                OnTChanging?.Invoke(ticket, true);
                Console.Write("\nБилет добавлен.");
            }
            else
                Console.Write("\nОшибка.");
        }

        private void AddTaxe()
        {
            Taxe taxe = new Taxe();
            taxe.AddTaxe(); 
            _direction.Add(taxe.EndPoint);
            _taxeBase.Add(taxe.EndPoint ,taxe);
            OnTaxeChanging?.Invoke(taxe, true);
            Console.Write("\nТариф добавлен.");
        }
        
        public void ReturnPrice()
        {
            Console.Write("\nВыберите вариант:\n1. Для одного пассажира\n2. " +
                          "Сумма всех реализованных билетов\nВаш выбор: ");
            int secondChoose = Convert.ToInt32(Console.ReadLine());
            if (secondChoose == 1)
            {
                Console.Write("\nИндекс пассажира в списке: ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index < _passengerBase.Count)
                {
                    Passenger temp = _passengerBase[index];
                    Console.Write("Данный пассажир купил билетов на сумму: " + temp.TotalSum + " рублей.");
                }
                else
                    Console.Write("Такого пассажира нет в базе.");
            }
            else if (secondChoose == 2)
                Console.Write("\nСумма всех проданных билетов: " + _totalSum + " рублей.");
        }

        public void ChangeBase()
        {
            Console.Write("\nКакую базу необходимо изменить:\n1. Базу пассажиров\n2. Базу" +
                              " билетов\n3. Базу тарифов\nВаш выбор: ");
            int firstChoose = Convert.ToInt32(Console.ReadLine());
            switch (firstChoose)
            {
                case 1:
                    Console.Write("\nБаза пассажиров:\n");
                
                    for (int i = 0; i < _passengerBase.Count; i++)
                        if (_passengerBase[i] != null)
                            Console.Write("\nНомер пассажира: " + i + _passengerBase[i].Info() + "\n");
                
                    Console.Write("\n");
                    this.DeletePassanger();
                    break;
                
                case 2:
                    Console.Write("\nБаза билетов:\n");
                
                    for (int i = 0; i < _ticketBase.Count; i++)
                        Console.Write("\nНомер билета: " + i + _ticketBase[i].Info() + "\n");

                    Console.Write("\nЧто вы хотите сделать:\n1. Добавить билет\n2. Удалить" +
                                  " билет\nВаш выбор: ");
                    int secondChoose = Convert.ToInt32(Console.ReadLine());
                    if (secondChoose == 1)
                        this.AddTicket();
                    if (secondChoose == 2)
                        this.DeleteTicket();
                    break;
                    
                case 3:
                    Console.Write("\nБаза тарифов:\n");
                    
                    for (int i = 0; i < _taxeBase.Count; i++)
                        Console.Write("\nНомер тарифа: " + i + _taxeBase[_direction[i]].Info() + "\n");
                    
                    Console.Write("\nЧто вы хотите сделать:\n1. Добавить тариф\n2. Удалить" +
                                  " тариф\nВаш выбор: ");
                    int thirdChoose = Convert.ToInt32(Console.ReadLine());
                    if (thirdChoose == 1)
                        this.AddTaxe();
                    if (thirdChoose == 2)
                        this.DeleteTaxe();
                    break;

                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }

        private void DeletePassanger()
        {
            Console.Write("Введите номер пассажира, которого нужно удалить: ");
            int pass = Convert.ToInt32(Console.ReadLine());
            Passenger passenger = _passengerBase[pass];
            OnPChanging(passenger, false);
            
            if ( _passengerBase.Remove(_passengerBase[pass]))
                Console.WriteLine("Удаление завершено.");
            else
                Console.WriteLine("Ошибка.");
        }
        
        private void DeleteTicket()
        {
            Console.Write("Введите номер билета, который нужно удалить: ");
            int tick = Convert.ToInt32(Console.ReadLine());
            Ticket ticket = _ticketBase[tick];
            OnTChanging?.Invoke(ticket, false);
            
            if (_ticketBase.Remove(_ticketBase[tick]))
                Console.WriteLine("Удаление завершено.");
            else
                Console.WriteLine("Ошибка.");
        }
        
        private void DeleteTaxe()
        {
            Console.Write("Введите направление, которое нужно удалить: ");
            string direct = Console.ReadLine();
            Taxe taxe = _taxeBase[direct];
            OnTaxeChanging?.Invoke(taxe, false);
            
            if (_taxeBase.Remove(direct) && _direction.Remove(direct))
                Console.WriteLine("Удаление завершено.");
            else
                Console.WriteLine("Ошибка.");
        }
    }
}