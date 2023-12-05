﻿using TalabatG02.APIs.Dtos;

namespace TalabatG02.APIs.Helpers
{
    public class Pagenation<T>
    {
      

        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }

        public Pagenation(int pageIndex, int pageSize,int count,IReadOnlyList<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;
            Count = count;
        }
    }
}
