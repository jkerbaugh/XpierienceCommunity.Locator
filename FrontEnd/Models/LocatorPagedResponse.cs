using DocumentFormat.OpenXml.Drawing.Charts;

namespace XperienceCommunity.Locator.Models
{
    public class LocatorPagedResponse<T> : LocatorResponse<T>
    {
        public virtual int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int RecordsFiltered { get; set; }
        public int RecordsTotal { get; set; }

        public LocatorPagedResponse(T data)
        {
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }

        public LocatorPagedResponse(T data, int pageNumber, int pageSize, RecordsCount recordsCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            RecordsFiltered = recordsCount.RecordsFiltered;
            RecordsTotal = recordsCount.RecordsTotal;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}
