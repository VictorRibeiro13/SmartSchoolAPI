
namespace SmartSchool.API.Helpers
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        private int PageSizeValue = 10;
        /// <summary>
        /// PageNumber (Start at 1)
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// PageSize (Maximum Page Size is 50)
        /// </summary>
        public int PageSize { 
            get { return PageSizeValue; } 
            set { PageSizeValue = (value > MaxPageSize) ? MaxPageSize : value; } 
        }

        public int? Registration { get; set; } = null;
        public string? Name { get; set; } = string.Empty;
        public bool? Active { get; set; }
    }
}
