namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMoviesPagination
{
    public class MoviesPaginationDto
    {
        private const int maxPageSize = 100;
        private int _minValue = 1;
        private int _pageSize = 10;

        public int PageNumber { 
            get => _minValue;
            set => _minValue = (value < _minValue) ? _minValue : value; }

        public int PageSize {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize || value < 1) ? maxPageSize :value;
        }
    }
}
