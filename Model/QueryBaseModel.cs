namespace ducky_api_server.Model
{
    public class QueryBaseModel
    {
        private int _pageIndex;
        private int _pageSize;
        public int PageIndex
        {
            get
            {
                if (_pageIndex <= 0)
                {
                    _pageIndex = 1;

                }
                return _pageIndex;
            }
            set { _pageIndex = value; }
        }
        public int PageSize
        {
            get
            {
                if (_pageSize <= 0)
                {
                    _pageSize = 30;

                }
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
        public long Total { get; set; }
    }
}