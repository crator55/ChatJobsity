using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Services
{
    public interface IStockGetter
    {
        string GetResponseBot(string message);
    }
}