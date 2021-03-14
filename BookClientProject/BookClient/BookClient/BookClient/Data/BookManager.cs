using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookClient.Data
{
    public class BookManager
    {
        //Variables
        static readonly string BaseAddress = "https://localhost:44318/";
        static readonly string Url = $"{BaseAddress}/api/books/";
        private string authorizationKey;


        public async Task<IEnumerable<Book>> GetAll()
        {
            // TODO: use GET to retrieve books
            HttpClient client = await GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Book>>(result);
        }//End GetAll Method

        public async Task<Book> Add(string title, string author, string genre)
        {
            Book book = new Book()
            {
                Title = title,
                Authors = new List<string>(new[] { author }),
                ISBN = string.Empty,
                Genre = genre,
                PublishDate = DateTime.Now.Date,
            };

            HttpClient client = await GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(book),
                    Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Book>(
                await response.Content.ReadAsStringAsync());
        }//End Add Book Method

        public async Task Update(Book book)
        {
            HttpClient client = await GetClient();
            await client.PutAsync(Url + book.ISBN,
                new StringContent(
                    JsonConvert.SerializeObject(book),
                    Encoding.UTF8, "application/json"));
        }//End Update Book Method

        public async Task Delete(string isbn)
        {
            HttpClient client = await GetClient();
            await client.DeleteAsync(Url + isbn);
        }//End Delete Book Method

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            if (string.IsNullOrEmpty(authorizationKey))
            {
                authorizationKey = await client.GetStringAsync(Url + "login");
                authorizationKey = JsonConvert.DeserializeObject<string>(authorizationKey);
            }

            client.DefaultRequestHeaders.Add("Authorization", authorizationKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }//End GetClient



    }//End Class
}//End Namespace

