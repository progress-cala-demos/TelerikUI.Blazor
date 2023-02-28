using Demo1Shared.DTOs;

namespace Demo1.Common
{
    public class GridConfig
    {
        public List<int?> PageSizes = new List<int?> { 10, 20, 50, 100, null };
        public int PageSize = 10;
        public int CurrentPage = 1;
        public int ButtonsCount = 10;
        public GridConfig()
        {
        }

        public GridConfig(int pageSize, List<int?> pageSizes, int currentPage, int buttonsCount)
        {
            PageSize = pageSize;
            PageSizes = pageSizes;
            CurrentPage = currentPage;
            ButtonsCount = buttonsCount;
        }
    }
}
