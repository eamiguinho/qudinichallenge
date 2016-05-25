using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Core;

namespace QudiniChallenge.Global
{
    public static class Ioc
    {
        private static readonly Lazy<ContainerBuilder> _instance = new Lazy<ContainerBuilder>(() => new ContainerBuilder());
        private static Container _container;

        public static ContainerBuilder Instance
        {
            get { return _instance.Value; }
        }

        public static Container Container
        {
            get { return _container ?? (_container = Instance.Build() as Container); }
        }

    }

    public enum Result
    {
        Ok,
        Error,
        InvalidCredentials
    }

    public class DataResult<T>
    {
        public DataResult(T data)
        {
            Data = data;
            Result = Result.Ok;
        }
        public DataResult(Result res)
        {
            Result = res;
        }

        public DataResult(Result res, string errorMessage)
        {
            Result = res;
        }

        public Result Result { get; set; }
        public bool IsOk { get { return Result == Result.Ok; } }

        public T Data { get; set; }
    }
}
