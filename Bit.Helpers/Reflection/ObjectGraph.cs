using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace Bit.Helpers.Reflection
{
	public class ObjectGraph : Collection<GraphedObject>
	{
		public GraphedObject Root { get; set; }

		private IEnumerable<GraphedObject> InheritedObjects { get; set; } 

		private List<Type> _simpleTypes = new List<Type>()
		{
			typeof(string),
			typeof(int),
			typeof(bool),
			typeof(decimal),
			typeof(byte),
			typeof(char),
			typeof(uint),
			typeof(long),
			typeof(double),
			typeof(short),
			typeof(float),
			typeof(ulong),
			typeof(ushort),
			typeof(DateTime)
		}; 

		public ObjectGraph(object rootObject)
		{
			InheritedObjects = new List<GraphedObject>();
			Root = new GraphedObject() { Raw = rootObject, Type = rootObject.GetType(), OriginatingObject = null, PropertyName = null, IsRoot = true };
			Items.Add(Root);
			BuildGraph();
		}

		protected ObjectGraph(object rootObject, IEnumerable<GraphedObject> existingObjects)
		{
			InheritedObjects = existingObjects;
			Root = new GraphedObject() { Raw = rootObject, Type = rootObject.GetType() };
			BuildGraph();
		}

		public void BuildGraph()
		{
			foreach (var propertyInfo in Root.Raw.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				//var value = propertyInfo.GetGetMethod().Invoke(Root.Raw, new object[] {});

				object value;

				try
				{
					value = propertyInfo.GetValue(Root.Raw);
				}
				catch (Exception)
				{
					continue;
				}

				var originating = Root;
				var propertyName = propertyInfo.Name;

				if (value == null || IsSimpleType(value) || AlreadyExistsInGraph(value))
				{
					continue;
				}

				IEnumerable resultEnumerable;

				if (IsCollection(value))
				{
					resultEnumerable = (IEnumerable) value;
				}
				else
				{
					resultEnumerable = new List<object> {value};
				}

				foreach (var obj in resultEnumerable)
				{
					if (!IsSimpleType(obj))
					{
						Items.Add(new GraphedObject() { Raw = obj, Type = obj.GetType(), OriginatingObject = originating.Raw, PropertyName = propertyName, IsRoot = false });
						var recursionGraph = new ObjectGraph(obj, InheritedAndCurrent());

						foreach (var graphedObject in recursionGraph)
						{
							Items.Add(graphedObject);
						}
					}
				}
			}
		}

		public bool AlreadyExistsInGraph(object o)
		{
			return InheritedObjects.Any(x => x.Raw == o);
		}

		public IEnumerable<GraphedObject> InheritedAndCurrent()
		{
			var result = InheritedObjects.ToList();

			result.AddRange(Items.ToList());

			return result;
		} 

		public IEnumerable<GraphedObject> GetObjects()
		{
			return Items;
		}

		public IEnumerable<object> GetRawObjects()
		{
			return Items.Select(x => x.Raw);
		} 

		protected bool IsSimpleType(object o)
		{
			return o.GetType().IsValueType || _simpleTypes.Contains(o.GetType()) || o.GetType().IsEnum;
		}

		protected bool IsCollection(object o)
		{
			return (o is IEnumerable);
		}
	}

	public class GraphedObject
	{
		public bool IsRoot { get; set; }
		public object OriginatingObject { get; set; }
		public string PropertyName { get; set; }
		public object Raw { get; set; }
		public Type Type { get; set; }
	}
}
