﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNet.Mvc.Xml
{
    /// <summary>
    /// Serializes <see cref="IEnumerable{T}"/> types by delegating them through a concrete implementation.
    /// </summary>
    /// <typeparam name="TWrapped">The wrapping or original type of the <see cref="IEnumerable{T}"/> 
    /// to proxy.</typeparam>
    /// <typeparam name="TDeclared">The type parameter of the original <see cref="IEnumerable{T}"/> 
    /// to proxy.</typeparam>
    public class DelegatingEnumerable<TWrapped, TDeclared> : IEnumerable<TWrapped>
    {
        private readonly IEnumerable<TDeclared> _source;
        private readonly IWrapperProvider _wrapperProvider;

        /// <summary>
        /// Initializes a <see cref="DelegatingEnumerable{TWrapped, TDeclared}"/>. 
        /// This constructor is necessary for <see cref="System.Runtime.Serialization.DataContractSerializer"/> 
        /// to serialize.
        /// </summary>
        public DelegatingEnumerable()
        {
            _source = Enumerable.Empty<TDeclared>();
        }

        /// <summary>
        /// Initializes a <see cref="DelegatingEnumerable{TWrapped, TDeclared}"/> with the original
        ///  <see cref="IEnumerable{T}"/> and the wrapper provider for wrapping individual elements.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}"/> instance to get the enumerator from.</param>
        /// <param name="wrapperProvider">The wrapper provider for wrapping individual elements.</param>
        public DelegatingEnumerable([NotNull] IEnumerable<TDeclared> source, IWrapperProvider wrapperProvider)
        {
            _source = source;
            _wrapperProvider = wrapperProvider;
        }

        /// <summary>
        /// Gets a delegating enumerator of the original <see cref="IEnumerable{T}"/> source which is being
        /// wrapped.
        /// </summary>
        /// <returns>The delegating enumerator of the original <see cref="IEnumerable{T}"/> source.</returns>
        public IEnumerator<TWrapped> GetEnumerator()
        {
            return new DelegatingEnumerator<TWrapped, TDeclared>(_source.GetEnumerator(), _wrapperProvider);
        }

        /// <summary>
        /// This method is not implemented but is required method for serialization to work. Do not use.
        /// </summary>
        /// <param name="item">The item to add. Unused.</param>
        public void Add(object item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a delegating enumerator of the original <see cref="IEnumerable{T}"/> source which is being
        /// wrapped.
        /// </summary>
        /// <returns>The delegating enumerator of the original <see cref="IEnumerable{T}"/> source.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}