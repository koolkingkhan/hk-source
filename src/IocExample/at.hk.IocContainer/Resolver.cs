using System;
using System.Collections.Generic;
using System.Linq;

namespace at.hk.IocContainer
{
    public class Resolver
    {
        private readonly Dictionary<Type, Type> _dependencyDictionary = new Dictionary<Type, Type>();

        public T Resolve<T>()
        {
            return (T) Resolve(typeof (T));
        }

        public void Register<TFrom, TTo>()
        {
            _dependencyDictionary.Add(typeof (TFrom), typeof (TTo));
        }

        private object Resolve(Type typeToResolve)
        {
            Type resolvedType;

            if (!_dependencyDictionary.TryGetValue(typeToResolve, out resolvedType))
            {
                throw new Exception(string.Format("Could not resolve type {0}", typeToResolve.FullName));
            }

            var firstConstructor = resolvedType.GetConstructors().First();
            var constructorParams = firstConstructor.GetParameters();

            if (!constructorParams.Any())
            {
                return Activator.CreateInstance(resolvedType);
            }

            IList<object> parameters = constructorParams.Select(parameter => Resolve(parameter.ParameterType)).ToList();

            return firstConstructor.Invoke(parameters.ToArray());
        }
    }
}