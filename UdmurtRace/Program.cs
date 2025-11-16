using System;
using UdmurtRace.DAL;
using UdmurtRace.DAL.Repositories;
using UdmurtRace.Domain.Entities;

class Program
{
    //static void Main()
    //{
    //    using var context = new AppDbContext();

    //    var clientRepo = new ClientRepository(context);
    //    var raceRepo = new RaceRepository(context);
    //    var saleRepo = new SaleRepository(context);

    //    while (true)
    //    {
    //        Console.WriteLine("\nГлавное Меню");
    //        Console.WriteLine("1. Управление клиентами");
    //        Console.WriteLine("2. Управление рейсами");
    //        Console.WriteLine("3. Управление продажами");
    //        Console.WriteLine("0. Выход");
    //        Console.Write("Выберите действие: ");

    //        switch (Console.ReadLine())
    //        {
    //            case "1":
    //                ManageClients(clientRepo);
    //                break;
    //            case "2":
    //                ManageRaces(raceRepo);
    //                break;
    //            case "3":
    //                ManageSales(saleRepo, clientRepo, raceRepo);
    //                break;
    //            case "0":
    //                return;
    //            default:
    //                Console.WriteLine("Неверный ввод.");
    //                break;
    //        }
    //    }
    //}

    //static void ManageClients(ClientRepository repo)
    //{
    //    Console.WriteLine("\nУправление Клиентами");
    //    Console.WriteLine("1. Показать всех");
    //    Console.WriteLine("2. Добавить");
    //    Console.WriteLine("3. Изменить");
    //    Console.WriteLine("4. Удалить");
    //    Console.Write("Выбор: ");

    //    switch (Console.ReadLine())
    //    {
    //        case "1":
    //            foreach (var c in repo.GetAllClients())
    //                Console.WriteLine($"{c.ClientId}: {c.SurName} {c.ClientName} {c.Patronymic}, {c.Email}, {c.Phone}, {c.Address}");
    //            break;
    //        case "2":
    //            var client = new ClientEntity();
    //            Console.Write("Фамилия: "); client.SurName = Console.ReadLine();
    //            Console.Write("Имя: "); client.ClientName = Console.ReadLine();
    //            Console.Write("Отчество: "); client.Patronymic = Console.ReadLine();
    //            Console.Write("Email: "); client.Email = Console.ReadLine();
    //            Console.Write("Телефон: "); client.Phone = Console.ReadLine();
    //            Console.Write("Адрес: "); client.Address = Console.ReadLine();
    //            repo.AddClient(client);
    //            break;
    //        case "3":
    //            Console.Write("ID клиента: ");
    //            int idU = int.Parse(Console.ReadLine());
    //            var existing = repo.GetClientById(idU);
    //            if (existing != null)
    //            {
    //                Console.Write("Новый email: "); existing.Email = Console.ReadLine();
    //                Console.Write("Новый телефон: "); existing.Phone = Console.ReadLine();
    //                repo.UpdateClient(existing);
    //            }
    //            break;
    //        case "4":
    //            Console.Write("ID клиента: ");
    //            repo.DeleteClient(int.Parse(Console.ReadLine()));
    //            break;
    //    }
    //}

    //static void ManageRaces(RaceRepository repo)
    //{
    //    Console.WriteLine("\nУправление Рейсами");
    //    Console.WriteLine("1. Показать все");
    //    Console.WriteLine("2. Добавить");
    //    Console.WriteLine("3. Изменить");
    //    Console.WriteLine("4. Удалить");
    //    Console.Write("Выбор: ");

    //    switch (Console.ReadLine())
    //    {
    //        case "1":
    //            foreach (var r in repo.GetAllRaces())
    //                Console.WriteLine($"{r.RaceId}: {r.Number}, {r.DepartureDate} {r.DepartureTime}, {r.Destination}, {r.PriceTicket} руб, мест: {r.Seats}");
    //            break;
    //        case "2":
    //            var race = new RaceEntity();
    //            Console.Write("Номер рейса: "); race.Number = Console.ReadLine();
    //            Console.Write("Дата: "); race.DepartureDate = Console.ReadLine();
    //            Console.Write("Время: "); race.DepartureTime = Console.ReadLine();
    //            Console.Write("Пункт назначения: "); race.Destination = Console.ReadLine();
    //            Console.Write("Цена билета: "); race.PriceTicket = float.Parse(Console.ReadLine());
    //            Console.Write("Количество мест: "); race.Seats = int.Parse(Console.ReadLine());
    //            Console.Write("Описание: "); race.Description = Console.ReadLine();
    //            repo.AddRace(race);
    //            break;
    //        case "3":
    //            Console.Write("ID рейса: ");
    //            int idU = int.Parse(Console.ReadLine());
    //            var existing = repo.GetRaceById(idU);
    //            if (existing != null)
    //            {
    //                Console.Write("Новая цена: "); existing.PriceTicket = float.Parse(Console.ReadLine());
    //                Console.Write("Новое кол-во мест: "); existing.Seats = int.Parse(Console.ReadLine());
    //                repo.UpdateRace(existing);
    //            }
    //            break;
    //        case "4":
    //            Console.Write("ID рейса: ");
    //            repo.DeleteRace(int.Parse(Console.ReadLine()));
    //            break;
    //    }
    //}

    //static void ManageSales(SaleRepository repo, ClientRepository clientRepo, RaceRepository raceRepo)
    //{
    //    Console.WriteLine("\nУправление Продаами");
    //    Console.WriteLine("1. Показать все");
    //    Console.WriteLine("2. Добавить");
    //    Console.WriteLine("3. Изменить статус/примечания");
    //    Console.WriteLine("4. Удалить");
    //    Console.Write("Выбор: ");

    //    switch (Console.ReadLine())
    //    {
    //        case "1":
    //            foreach (var s in repo.GetAllSales())
    //                Console.WriteLine($"{s.SaleId}: Рейс {s.RaceId}, Клиент {s.ClientId}, Статус {s.Status}, Примечания: {s.Notes}");
    //            break;
    //        case "2":
    //            Console.WriteLine("Выберите клиента:");
    //            foreach (var c in clientRepo.GetAllClients())
    //                Console.WriteLine($"{c.ClientId}: {c.SurName} {c.ClientName}");
    //            int clientId = int.Parse(Console.ReadLine());

    //            Console.WriteLine("Выберите рейс:");
    //            foreach (var r in raceRepo.GetAllRaces())
    //                Console.WriteLine($"{r.RaceId}: {r.Number}, {r.Destination}");
    //            int raceId = int.Parse(Console.ReadLine());

    //            var sale = new SaleEntity();
    //            sale.ClientId = clientId;
    //            sale.RaceId = raceId;

    //            bool Status = false;
    //            while (!Status)
    //            {
    //            Console.Write("Новый статус(Продан/Возврат):  ");
    //            sale.Status = Console.ReadLine();
    //                if (sale.Status == "Продан" || sale.Status == "Возврат")
    //                {
    //                    Status = true;
    //                }
    //                else
    //                {
    //                    Console.WriteLine("Ошибка!Статусы: Продан/Возврат");
    //                }

    //            }
    //            Console.Write("Примечания (услуги): ");
    //            sale.Notes = Console.ReadLine();

    //            //var client = clientRepo.GetClientById(clientId);
    //            //var race = raceRepo.GetRaceById(raceId);
    //            //sale.ClientName = $"{client.SurName} {client.ClientName}";
    //            //sale.Address = client.Address;
    //            //sale.Phone = client.Phone;
    //            //sale.Number = race.Number;
    //            //sale.DepartureDate = race.DepartureDate;
    //            //sale.DepartureTime = race.DepartureTime;
    //            //sale.PriceTicket = race.PriceTicket;

    //            repo.AddSale(sale);
    //            break;
    //        case "3":
    //            Console.Write("ID продажи: ");
    //            int idU = int.Parse(Console.ReadLine());
    //            var existing = repo.GetSaleById(idU);
    //            if (existing != null)
    //            {
    //                Console.Write("Новый статус(Продан/Возврат): "); existing.Status = Console.ReadLine();
    //                Console.Write("Примечания: "); existing.Notes = Console.ReadLine();
    //                repo.UpdateSale(existing);
    //            }
    //            break;
    //        case "4":
    //            Console.Write("ID продажи: ");
    //            repo.DeleteSale(int.Parse(Console.ReadLine()));
    //            break;
    //    }
    //}
}
