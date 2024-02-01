using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;
using TemplateCleanArchitecture.App.Models;

namespace TemplateCleanArchitecture.App.Pages.GenerPage
{
    public partial class Genre
    {
        [Inject]
        public HttpClient httpClient { get; set; }
        public List<GenreVm> genres { get; set; }

        [Parameter]
        public string GenreName { get; set; } = string.Empty;

        [Parameter]
        public string ShowErrorMassege { get; set; } = string.Empty;

        [Parameter]
        public string ErrorMassegeContent { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var data = await httpClient
                .GetFromJsonAsync<List<GenreVm>>("https://localhost:7139/api/Genre") ?? new List<GenreVm>();

            genres = data.ToList();
        }

        private bool _processing = false, showLeaveAlert = false;
        private void OnSeveGenre()
        {
            _processing = true;
            var result = httpClient
                .PostAsJsonAsync<GenreVm>("https://localhost:7139/api/Genre", new GenreVm { Name = GenreName });

            result.Wait();

            if (GenreName == string.Empty)
            {
                ShowErrorMassege = "isWorning";
                ErrorMassegeContent = "Please insert genre name!";
            }
            else if (result.IsCompletedSuccessfully)
            {
                if (!result.Result.IsSuccessStatusCode)
                {
                    ShowErrorMassege = "isNotSuccess";
                    ErrorMassegeContent = "Insert data has been error";
                }
                else
                {
                    var response = result.Result.Content.ReadFromJsonAsync<GenreVm>().Result;
                    //if (response != null)
                    //    genres.Add(response);

                    GenreName = string.Empty;
                    ShowErrorMassege = "isSuccess";
                    ErrorMassegeContent = "Insert data has been sucsses";
                }

            }
            _processing = false;

            showLeaveAlert = true;
        }

        private void OnDeleteGenre(int genreId)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:7139/api/Genre"),
                Content = new StringContent(JsonConvert.SerializeObject(new GenreVm { Id = genreId}), Encoding.UTF8, "application/json")
            };
            var result = httpClient.SendAsync(request);
        }

        private void CloseAlert()
        {
                showLeaveAlert = !showLeaveAlert;
        }

        
    }
}
