using Microsoft.AspNetCore.Components;
using System.Data;
using TemplateCleanArchitecture.App.Models;

namespace TemplateCleanArchitecture.App.Pages.MapPage
{
    public partial class Map
    {
        //    private readonly double _latitude = 34.027;
        //    private readonly double _longitude = -118.805;
        [Parameter]
        public string Attributes { get; set; } = string.Empty;
        [Parameter]
        public double Latitude { get; set; } = 34.027;
        [Parameter]
        public double Longitude { get; set; } = -118.805;

        private readonly double _latitude = 34.027;
        private readonly double _longitude = -118.805;
        //private List<DataSet> myPoints = DataSet.GenerateSomePoints(34.027, -118.805);

        Points myPoints = new Points();

    }
}
