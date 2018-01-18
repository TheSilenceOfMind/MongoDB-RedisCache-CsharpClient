using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbConnection
{
    public class DbConnector
    {
        #region Providers CRUD operations

        public string CreateProvider(string name, string contact, string address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            string url = "provider?name=" + name + "&contact=" + contact + "&address=" + address;
            HttpResponseMessage response = client.PostAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "error"; 
            }
        }
        public string GetAllProviders()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("providers").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                } catch (Exception e)
                {
                    return result;
                }
                
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string GetProviderById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("provider/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                } catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string UpdateProviderName(string id, string newName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.PutAsync("provider/" + id + "?name=" + newName, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string DeleteProviderById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.DeleteAsync("provider/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }

        #endregion providers 

        #region Storage Point CRUD operations

        public string CreateStoragePoint (string address, string contact, string rentprice)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            string url = "storagepoint?address=" + address + "&contact=" + contact + "&rentprice=" + rentprice;
            HttpResponseMessage response = client.PostAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "error";
            }
        }
        public string GetAllStoragePoints()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("storagepoints").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string GetStoragePointById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("storagepoint/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string UpdateStoragePointAddress(string id, string newAddress)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.PutAsync("storagepoint/" + id + "?address=" + newAddress, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string DeleteStoragePointById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.DeleteAsync("storagepoint/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        #endregion

        #region Media CRUD operations
        public string CreateMedia (string medianame, string mediacontent, string productid)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            string url = "media?medianame=" + medianame + "&mediacontent=" + mediacontent + "&productid=" + productid;
            HttpResponseMessage response = client.PostAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "error";
            }
        }
        public string GetAllMedia()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("media").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string GetMediaById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("media/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string UpdateMediaName(string id, string newMediaName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.PutAsync("media/" + id + "?medianame=" + newMediaName, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string DeleteMediaById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.DeleteAsync("media/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        #endregion

        #region Products CRUD operations
        public string CreateProduct(string name, string price, string isavail, string storage, string provider)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            string url = "product?name=" + name + "&price=" + price + "&isavail=" + isavail + "&storage=" + storage + "&provider=" + provider;
            HttpResponseMessage response = client.PostAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "error";
            }
        }
        public string GetAllProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("products").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string GetProductById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("product/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string UpdateProductName(string id, string newProductName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.PutAsync("product/" + id + "?name=" + newProductName, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string DeleteProductById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.DeleteAsync("product/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        #endregion

        #region Buyer Info CRUD operations
        public string CreateBuyerInfo(string name, string lastname, string phone, string address)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            string url = "buyerinfo?name=" + name + "&lastname=" + lastname + "&phone=" + phone + "&address=" + address;
            HttpResponseMessage response = client.PostAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "error";
            }
        }
        public string GetAlLBuyerInfos()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("buyerinfos").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string GetBuyerInfoById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("buyerinfo/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string UpdateBuyerInfoName(string id, string newName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.PutAsync("buyerinfo/" + id + "?name=" + newName, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string DeleteBuyerInfoById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.DeleteAsync("buyerinfo/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        #endregion

        #region Booking Product CRUD operations
        public string CreateBookingProduct(string productid, string buyerid, string quantity)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            string url = "bookingproduct?productid=" + productid + "&buyerid=" + buyerid + "&quantity=" + quantity;
            HttpResponseMessage response = client.PostAsync(url, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return "error";
            }
        }
        public string GetAlLBookingProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("bookingproducts").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string GetBookingProductById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("bookingproduct/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                try
                {
                    var t = JsonConvert.DeserializeObject<object>(result);
                    return (JsonConvert.SerializeObject(t, Formatting.Indented));
                }
                catch (Exception e)
                {
                    return result;
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string UpdateBookingProductQuantity(string id, string quantity)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.PutAsync("bookingproduct/" + id + "?quantity=" + quantity, null).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        public string DeleteBookingProductById(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.DeleteAsync("bookingproduct/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
        #endregion
    }
}
