using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LABTEST.Models;  

namespace LABTEST
{
    public partial class question3 : ContentPage
    {
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/posts";

        public question3()
        {
            InitializeComponent();
            BindingContext = new Question3ViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(ApiUrl);
                    List<Post> posts = System.Text.Json.JsonSerializer.Deserialize<List<Post>>(json);

                    var viewModel = (Question3ViewModel)BindingContext;
                    viewModel.Posts = posts;

                    foreach (var post in posts)
                    {
                        
                        Console.WriteLine($"Title: {post.Title}, Body: {post.Body}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class Question3ViewModel
    {
        public List<Post> Posts { get; set; }
    }
}
