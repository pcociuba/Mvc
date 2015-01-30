using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using XmlFormattersWebSite.Models;

namespace XmlFormattersWebSite.Controllers
{
    public class WrapperController : Controller
    {
        public IEnumerable<int> IEnumerableOfValueTypes()
        {
            return new[] { 10, 20 };
        }

        public IEnumerable<string> IEnumerableOfNonWrappedTypes()
        {
            return new[] { "value1", "value2" };
        }

        public IEnumerable<string> IEnumerableOfNonWrappedTypes_Empty()
        {
            return new string[] { };
        }

        public IEnumerable<Person> IEnumerableOfWrappedTypes()
        {
            return new[] {
                new Person() { Id = 10, Name = "Mike" },
                new Person() { Id = 11, Name = "Jimmy" }
            };
        }
        
        public IEnumerable<Person> IEnumerableOfWrappedTypes_Empty()
        {
            return new Person[] { };
        }

        public IEnumerable<string> IEnumerableOfNonWrappedTypes_NullInstance()
        {
            return null;
        }

        public IEnumerable<Person> IEnumerableOfWrappedTypes_NullInstance()
        {
            return null;
        }

        public IQueryable<int> IQueryableOfValueTypes()
        {
            return Enumerable.Range(1, 2).Select(i => i * 10).AsQueryable();
        }

        public IQueryable<string> IQueryableOfNonWrappedTypes()
        {
            return Enumerable.Range(1, 2).Select(i => "value" + i).AsQueryable();
        }

        public IQueryable<Person> IQueryableOfWrappedTypes()
        {
            return new[] {
                new Person() { Id = 10, Name = "Mike" },
                new Person() { Id = 11, Name = "Jimmy" }
            }.AsQueryable();
        }

        public IQueryable<Person> IQueryableOfWrappedTypes_Empty()
        {
            return (new Person[] { }).AsQueryable();
        }

        public IQueryable<string> IQueryableOfNonWrappedTypes_Empty()
        {
            return (new string[] { }).AsQueryable();
        }

        public IQueryable<string> IQueryableOfNonWrappedTypes_NullInstance()
        {
            return null;
        }

        public IQueryable<Person> IQueryableOfWrappedTypes_NullInstance()
        {
            return null;
        }

        public SerializableError SerializableError()
        {
            var error1 = new SerializableError();
            error1.Add("key1", "key1-error");
            error1.Add("key2", "key2-error");

            return error1;
        }

        public IEnumerable<SerializableError> IEnumerableOfSerializableErrors()
        {
            List<SerializableError> errors = new List<SerializableError>();
            var error1 = new SerializableError();
            error1.Add("key1", "key1-error");
            error1.Add("key2", "key2-error");

            var error2 = new SerializableError();
            error2.Add("key3", "key1-error");
            error2.Add("key4", "key2-error");
            errors.Add(error1);
            errors.Add(error2);
            return errors;
        }

        public IActionResult LogSerializableError([FromBody] SerializableError error)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            return new ObjectResult(error);
        }
    }
}