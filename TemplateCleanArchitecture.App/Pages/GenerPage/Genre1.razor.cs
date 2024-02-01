using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazor.Extensions;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TemplateCleanArchitecture.App.Models;
using static MudBlazor.CategoryTypes;

namespace TemplateCleanArchitecture.App.Pages.GenerPage
{
    public partial class Genre1
    {
        //defind model for validation form  ------------------------------------------

        [Inject]
        public HttpClient httpClient { get; set; }
        public List<GenreVm> genres { get; set; }

        RegisterGenreForm model = new RegisterGenreForm();

        public class RegisterGenreForm
        {
            [Required]
            [MinLength(3, ErrorMessage = "The genre name cannot be less than 3 character")]
            [MaxLength(50, ErrorMessage = "The genre name cannot be more than 50 character")]
            [RegularExpression("^[A-Za-z\\ ]+$", ErrorMessage = "Only A-Z or a-z characters and space")]
            public string Name { get; set; }
        }

        protected override async Task OnInitializedAsync()
        {
            var data = await httpClient
                .GetFromJsonAsync<List<GenreVm>>("https://localhost:7139/api/Genre") ?? new List<GenreVm>();

            genres = data.ToList();
        }

        private void OnValidSubmit(EditContext context)
        {
            var result = httpClient
                .PostAsJsonAsync<GenreVm>("https://localhost:7139/api/Genre", new GenreVm { Name = context.Model.As<RegisterGenreForm>().Name });

            result.Wait();

            if (result.IsCompletedSuccessfully)
            {
                if (result.Result.IsSuccessStatusCode)
                {
                    var response = result.Result.Content.ReadFromJsonAsync<GenreVm>().Result;
                    if (response != null)
                        genres.Add(response);

                    model.Name = string.Empty;
                }
            }
        }

        private async Task OnDeleteGenreAsync(int genreId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:7139/api/Genre"),
                Content = new StringContent(JsonConvert.SerializeObject(new GenreVm { Id = genreId }), Encoding.UTF8, "application/json")
            };
            var result = await httpClient.SendAsync(request);

            await OnInitializedAsync();
        }


        ////private HashSet<Element> selectedItems = new HashSet<Element>();
        //private void OnRowClick()
        //{
        //    Console.WriteLine("select row");

        //}
    }
}

