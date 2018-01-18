using System;

namespace MongoDbConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            DbConnector dbConnector = new DbConnector();
            while (true)
            {
                string collectionStr = GetCollectionNumber();

                if (collectionStr.Equals("0"))
                    Environment.Exit(0);

                string operationStr = GetOperationNumber();
                switch (collectionStr)
                {
                    // provider
                    case "1":
                        switch (operationStr)
                        {
                            // create
                            case "1":
                                Console.WriteLine("Введите имя :");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите контакты :");
                                string cont = Console.ReadLine();
                                Console.WriteLine("Введите адрес :");
                                string add = Console.ReadLine();
                                string res = dbConnector.CreateProvider(name, cont, add);
                                if (res.Equals("error"))
                                    Console.WriteLine("Произошла ошибка! Возможно, данный объект уже существует!");
                                else
                                    Console.WriteLine("Операция успешно выполнена!");
                                break;

                            // get all 
                            case "2":
                                Console.WriteLine(dbConnector.GetAllProviders());
                                break;

                            // get by id
                            case "3":
                                Console.WriteLine("Введите id :");
                                string id = Console.ReadLine();
                                Console.WriteLine(dbConnector.GetProviderById(id));
                                break;

                            // update
                            case "4":
                                Console.WriteLine("Введите id :");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Введите новое имя :");
                                string newName = Console.ReadLine();
                                Console.WriteLine(dbConnector.UpdateProviderName(ID, newName));
                                break;

                            // delete by id
                            case "5":
                                Console.WriteLine("Введите id :");
                                string iD = Console.ReadLine();
                                Console.WriteLine(dbConnector.DeleteProviderById(iD));
                                break;
                        }
                        break;

                    // StoragePoint
                    case "2":
                        switch (operationStr)
                        {
                            // create
                            case "1":
                                Console.WriteLine("Введите адрес :");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите контакты :");
                                string cont = Console.ReadLine();
                                Console.WriteLine("Введите ренту :");
                                string add = Console.ReadLine();
                                string res = dbConnector.CreateStoragePoint(name, cont, add);
                                if (res.Equals("error"))
                                    Console.WriteLine("Произошла ошибка! Возможно, данный объект уже существует!");
                                else
                                    Console.WriteLine("Операция успешно выполнена!");
                                break;

                            // get all 
                            case "2":
                                Console.WriteLine(dbConnector.GetAllStoragePoints());
                                break;

                            // get by id
                            case "3":
                                Console.WriteLine("Введите id :");
                                string id = Console.ReadLine();
                                Console.WriteLine(dbConnector.GetStoragePointById(id));
                                break;

                            // update
                            case "4":
                                Console.WriteLine("Введите id :");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Введите новый адрес :");
                                string newName = Console.ReadLine();
                                Console.WriteLine(dbConnector.UpdateStoragePointAddress(ID, newName));
                                break;

                            // delete by id
                            case "5":
                                Console.WriteLine("Введите id :");
                                string iD = Console.ReadLine();
                                Console.WriteLine(dbConnector.DeleteStoragePointById(iD));
                                break;
                        }
                        break;

                    // Product
                    case "3":
                        switch (operationStr)
                        {
                            // create
                            case "1":
                                Console.WriteLine("Введите имя :");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите цену :");
                                string price = Console.ReadLine();
                                Console.WriteLine("Введите доступен ли товар :");
                                string isav = Console.ReadLine();
                                Console.WriteLine("Введите id хранилища (storage) :");
                                string storage = Console.ReadLine();
                                Console.WriteLine("Введите id поставщика (provider) :");
                                string provider = Console.ReadLine();

                                string res = dbConnector.CreateProduct(name, price, isav, storage, provider);
                                if (res.Equals("error"))
                                    Console.WriteLine("Произошла ошибка! Возможно, данный объект уже существует!");
                                else
                                    Console.WriteLine("Операция успешно выполнена!");
                                break;

                            // get all 
                            case "2":
                                Console.WriteLine(dbConnector.GetAllProducts());
                                break;

                            // get by id
                            case "3":
                                Console.WriteLine("Введите id :");
                                string id = Console.ReadLine();
                                Console.WriteLine(dbConnector.GetProductById(id));
                                break;

                            // update
                            case "4":
                                Console.WriteLine("Введите id :");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Введите новое имя :");
                                string newName = Console.ReadLine();
                                Console.WriteLine(dbConnector.UpdateProductName(ID, newName));
                                break;

                            // delete by id
                            case "5":
                                Console.WriteLine("Введите id :");
                                string iD = Console.ReadLine();
                                Console.WriteLine(dbConnector.DeleteProductById(iD));
                                break;
                        }
                        break;

                    // Media
                    case "4":
                        switch (operationStr)
                        {
                            // create
                            case "1":
                                Console.WriteLine("Введите название медиа :");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите содержимое медиа :");
                                string cont = Console.ReadLine();
                                Console.WriteLine("Введите ID продукта :");
                                string add = Console.ReadLine();
                                string res = dbConnector.CreateMedia(name, cont, add);
                                if (res.Equals("error"))
                                    Console.WriteLine("Произошла ошибка! Возможно, данный объект уже существует!");
                                else
                                    Console.WriteLine("Операция успешно выполнена!");
                                break;

                            // get all 
                            case "2":
                                Console.WriteLine(dbConnector.GetAllMedia());
                                break;

                            // get by id
                            case "3":
                                Console.WriteLine("Введите id :");
                                string id = Console.ReadLine();
                                Console.WriteLine(dbConnector.GetMediaById(id));
                                break;

                            // update
                            case "4":
                                Console.WriteLine("Введите id :");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Введите новое имя :");
                                string newName = Console.ReadLine();
                                Console.WriteLine(dbConnector.UpdateMediaName(ID, newName));
                                break;

                            // delete by id
                            case "5":
                                Console.WriteLine("Введите id :");
                                string iD = Console.ReadLine();
                                Console.WriteLine(dbConnector.DeleteMediaById(iD));
                                break;
                        }
                        break;

                    // BuyerInfo
                    case "5":
                        switch (operationStr)
                        {
                            // create
                            case "1":
                                Console.WriteLine("Введите имя :");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите фамилию :");
                                string lname = Console.ReadLine();
                                Console.WriteLine("Введите номер телефона :");
                                string ph = Console.ReadLine();
                                Console.WriteLine("Введите адрес :");
                                string add = Console.ReadLine();

                                string res = dbConnector.CreateBuyerInfo(name, lname, ph, add);
                                if (res.Equals("error"))
                                    Console.WriteLine("Произошла ошибка! Возможно, данный объект уже существует!");
                                else
                                    Console.WriteLine("Операция успешно выполнена!");
                                break;

                            // get all 
                            case "2":
                                Console.WriteLine(dbConnector.GetAlLBuyerInfos());
                                break;

                            // get by id
                            case "3":
                                Console.WriteLine("Введите id :");
                                string id = Console.ReadLine();
                                Console.WriteLine(dbConnector.GetBuyerInfoById(id));
                                break;

                            // update
                            case "4":
                                Console.WriteLine("Введите id :");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Введите новое имя :");
                                string newName = Console.ReadLine();
                                Console.WriteLine(dbConnector.UpdateBuyerInfoName(ID, newName));
                                break;

                            // delete by id
                            case "5":
                                Console.WriteLine("Введите id :");
                                string iD = Console.ReadLine();
                                Console.WriteLine(dbConnector.DeleteBuyerInfoById(iD));
                                break;
                        }
                        break;

                    // BookingProduct
                    case "6":
                        switch (operationStr)
                        {
                            // create
                            case "1":
                                Console.WriteLine("Введите ID продукта (productid) :");
                                string productid = Console.ReadLine();
                                Console.WriteLine("Введите ID покупателя (buyerid) :");
                                string buyerid = Console.ReadLine();
                                Console.WriteLine("Введите количество :");
                                string quantity = Console.ReadLine();

                                string res = dbConnector.CreateBookingProduct(productid, buyerid, quantity);
                                if (res.Equals("error"))
                                    Console.WriteLine("Произошла ошибка! Возможно, данный объект уже существует!");
                                else
                                    Console.WriteLine("Операция успешно выполнена!");
                                break;

                            // get all 
                            case "2":
                                Console.WriteLine(dbConnector.GetAlLBookingProducts());
                                break;

                            // get by id
                            case "3":
                                Console.WriteLine("Введите id :");
                                string id = Console.ReadLine();
                                Console.WriteLine(dbConnector.GetBookingProductById(id));
                                break;

                            // update
                            case "4":
                                Console.WriteLine("Введите id :");
                                string ID = Console.ReadLine();
                                Console.WriteLine("Введите новое количество :");
                                string newName = Console.ReadLine();
                                Console.WriteLine(dbConnector.UpdateBookingProductQuantity(ID, newName));
                                break;

                            // delete by id
                            case "5":
                                Console.WriteLine("Введите id :");
                                string iD = Console.ReadLine();
                                Console.WriteLine(dbConnector.DeleteBookingProductById(iD));
                                break;
                        }
                        break;

                    // quit from the program
                    case "0":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static string GetOperationNumber()
        {
            Console.WriteLine("Выберите операцию (введите ее номер):");
            Console.WriteLine("1. СОЗДАТЬ");
            Console.WriteLine("2. ПОЛУЧИТЬ ВСЕ");
            Console.WriteLine("3. ПОЛУЧИТЬ ОБЪЕКТ (по id)");
            Console.WriteLine("4. ОБНОВИТЬ");
            Console.WriteLine("5. УДАЛИТЬ (по id)");
            var op = Console.ReadLine().Trim();
            if (!(op.Equals("1") || op.Equals("2") || op.Equals("3") || op.Equals("4") || op.Equals("5")))
            {
                Console.WriteLine("Вы ввели неверное значение, повторите ввод.");
                return GetOperationNumber();
            }
            else
            {
                return op;
            }
        }

        public static string GetCollectionNumber()
        {
            Console.WriteLine("Выберите коллекцию (введите ее номер):");
            Console.WriteLine("1. Provider");
            Console.WriteLine("2. StoragePoint");
            Console.WriteLine("3. Product");
            Console.WriteLine("4. Media");
            Console.WriteLine("5. BuyerInfo");
            Console.WriteLine("6. BookingProduct");
            Console.WriteLine("0. ЗАВЕРШИТЬ ПРОГРАММУ");
            var op = Console.ReadLine().Trim();
            if (!(op.Equals("0") || op.Equals("1") || op.Equals("2") || op.Equals("3") || op.Equals("4") || op.Equals("5") || op.Equals("6")))
            {
                Console.WriteLine("Вы ввели неверное значение, повторите ввод.");
                return GetCollectionNumber();
            }
            else
            {
                return op;
            }
        }
    }
}