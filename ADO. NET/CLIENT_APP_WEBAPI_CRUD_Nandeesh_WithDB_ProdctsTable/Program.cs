// Basic namespaces required for the program

using System;                      // Contains basic C# functionality like Console
using System.Collections.Generic;  // Needed for List<T>
using System.Net.Http;             // Contains HttpClient for calling APIs
using System.Threading.Tasks;      // Needed for async and await
using Newtonsoft.Json;             // Used to convert JSON into C# objects

namespace CLIENT_APP_WEBAPI_CRUD_Nandeesh_WithDB_ProdctsTable
{
    internal class Program
    {
        // async -> allows use of await keyword
        // Task -> async version of void/Main
        static async Task Main(string[] args)
        {
            // Create object of HttpClient
            // HttpClient is used to send HTTP requests to APIs
            HttpClient client = new HttpClient();


            // BaseAddress is the common/root URL of your API
            // Every API call will start from this URL
            //
            // Final URL becomes:
            // http://localhost:5182/api/products
            //
            client.BaseAddress =
                new Uri("http://localhost:5182/api/");


            // Send GET request to:
            // http://localhost:5182/api/products
            //
            // await means:
            // "wait here until API sends response"
            //
            HttpResponseMessage response =
                await client.GetAsync("products");


            // Read API response body as string
            //
            // Example JSON coming from API:
            //
            // [
            //   {
            //      "id":1,
            //      "name":"Laptop",
            //      "price":50000
            //   }
            // ]
            //
            string json =
                await response.Content.ReadAsStringAsync();


            // Convert JSON string into C# List<Product>
            //
            // Deserialize means:
            // JSON  ---> C# Objects
            //
            List<Product> products =
                JsonConvert.DeserializeObject<List<Product>>(json);


            // Loop through every product in the list
            foreach (var p in products)
            {
                // Print product details to console
                Console.WriteLine(
                    $"Id: {p.Id}, Name: {p.Name}, Price: {p.Price}");
            }


            // =========================================================
            // GET PRODUCT BY ID
            // =========================================================

            Console.WriteLine("GET PRODUCT BY ID:\n");


            // Product ID we want to fetch
            int id = 1;


            // Send GET request to:
            // http://localhost:5182/api/products/1
            //
            HttpResponseMessage singleProductResponse =
                await client.GetAsync($"products/{id}");


            // Check whether request was successful
            if (singleProductResponse.IsSuccessStatusCode)
            {
                // Read JSON response
                string singleProductJson =
                    await singleProductResponse.Content.ReadAsStringAsync();


                // Convert JSON → Product object
                Product product =
                    JsonConvert.DeserializeObject<Product>(singleProductJson);


                // Print product details
                Console.WriteLine(
                    $"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
            else
            {
                // If API returns 404 or error
                Console.WriteLine("Product not found");
            }


            // Pause console
            Console.ReadLine();
        }
    }
}