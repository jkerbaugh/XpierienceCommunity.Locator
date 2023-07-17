﻿using System.Collections.Generic;

namespace XperienceCommunity.Locator.Models
{
    public class LocatorResponse<T>
    {
        public LocatorResponse()
        {
        }

        public LocatorResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public LocatorResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
