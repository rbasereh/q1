using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Flattering
{
    public class FlatteringTests
    {
        private void AssertFlatten(List<object> input, List<object> expect)
        {
            var actual = Flatter.MakeFlat(input);
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void AlreadyFlattenList()
        {
            AssertFlatten(new List<object> { 1, 2, 3 }, new List<object> { 1, 2, 3 });
        }

        [Fact]
        public void EmptyList()
        {
            AssertFlatten(new List<object> { }, new List<object> { });
        }

        [Fact]
        public void OneLevel()
        {
            AssertFlatten(new List<object> { 1, 2, new List<object> { 3, 4 }, 7 }, new List<object> { 1, 2, 3, 4, 7 });
        }

        [Fact]
        public void MultipleOneLevel()
        {
            AssertFlatten(new List<object>{
                1,2,3,
                new List<object>{4,5,6},
                new List<object>{7,8,9},
                10,20
            },
            new List<object>{
                1,2,3,4,5,6,7,8,9,10,20
            });
        }

        [Fact]
        public void ThreeLevel()
        {
            AssertFlatten(new List<object>{
                1,2,3,5,
                new List<object>{
                    7,8,9,
                    new List<object>{10,11,12}
                },
                new List<object>{
                    10,23,46,
                    new List<object>{12,36,98,
                    new List<object>{14,12,36}
                    }
                }
            }, new List<object>
            {
                1,2,3,5,7,8,9,10,11,12,10,23,46,12,36,98,14,12,36
            });
        }

        [Fact]
        public void MultiLevelOneElement()
        {
            AssertFlatten(new List<object>{
                new List<object>{},
                new List<object>{
                    new List<object>{
                        new List<object>{
                            new List<object>{},
                            new List<object>{1}
                        }
                    }
                }
            }, new List<object> { 1 });
        }
    }
}