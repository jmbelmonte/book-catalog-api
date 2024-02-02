namespace Book_Catalog_API.Helpers
{
    public class BookParameters
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string Title { get; set; }
        public int? CategoryId { get; set; }
    }
}
