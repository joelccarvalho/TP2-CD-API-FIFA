using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballApi.Errors;
using FootballApi.Models;
using FootballApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using FootballApi.General;

namespace FootballApi.General
{
    /*
     * This class checks all properties of an object are non-null
     */
    public static class General
    {
        public static bool ArePropertiesNotNull<T>(this T obj)
        {
            return typeof(T).GetProperties().All(propertyInfo => propertyInfo.GetValue(obj) != null);    
        }

    }
}