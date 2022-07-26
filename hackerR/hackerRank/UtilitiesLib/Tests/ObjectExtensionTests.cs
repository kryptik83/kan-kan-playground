using FluentAssertions.Execution;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace UtilitiesLib.Tests
{
    public class ObjectExtensionTests
    {
        [Fact]
        public void GetPropertyValue_ReturnsTrue_WhenPropertyIsBool()
        {
            var obj = new
            {
                BooleanProperty = false
            };

            var val = obj.GetPropertyValue(nameof(obj.BooleanProperty));

            using var scope = new AssertionScope();
            {
                Assert.True(val != null);
                Assert.True(val?.GetType() == typeof(bool));
                Assert.False((bool) val);
            }
        }

        [Fact]
        public void Compare()
        {
            var obj1 = new RandomClass(1, null, "vijit", new RandomSubClass("newstr2", 100));
            var obj2 = new RandomClass(1, true, "Vijit", new RandomSubClass("newstr1", 100));

            var props = obj1.GetModifiedProperties(obj2);

            props.ForEach(Console.WriteLine);
        }

        
        
        [Fact]
        public void CompareJsons()
        {
            var obj1 = JsonConvert.SerializeObject(new RandomClass(1, null, "vijit", new RandomSubClass("newstr2", 100))) ?? string.Empty;
            var obj2 = JsonConvert.SerializeObject(new RandomClass(1, true, "Vijit", new RandomSubClass("newstr1", 100))) ?? string.Empty;

            var props = obj1.GetModifiedJsonProperties(obj2);

            props.ForEach(Console.WriteLine);
        }
        public class RandomClass
        {
            public RandomClass() { }

            public RandomClass(int i, bool? b, string s, RandomSubClass subClass = null)
            {
                intval = i;
                boolval = b;
                stringval = s;
                SubClass = subClass;
            }

            public RandomSubClass SubClass { get; set; }
            public int intval { get; set; }
            public bool? boolval { get; set; }
            public string stringval { get; set; }
        }

        public class RandomSubClass
        {
            public RandomSubClass() { }

            public RandomSubClass(string s, int i)
            {
                newstr = s;
                newint = i;
            }

            public string newstr { get; set; }
            public int newint { get; set; }
        }
    }
}