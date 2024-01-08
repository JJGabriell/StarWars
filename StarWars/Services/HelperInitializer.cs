using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StarWars.Services
{
    public static class HelperInitializer<T> 
    {
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T)), new ParameterExpression[0]).Compile();
    }

}