using NUnit.Framework;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.service;

namespace NUnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<Data> arrayOut = new List<Data>()
            {
                  new Data(){Name="Folder17",Index="9.3"},
                new Data(){Name="Folder17",Index="9.3.2"},
                new Data(){Name="Folder17",Index="9.3.2.3"},

                new Data(){Name="Folder17",Index="2.2"},
                //new Data(){Name="Folder1722",Index="2.2.37"},
                new Data(){Name="Folder1722",Index="2.2.37.9"}
            };
            List<Data> data = new List<Data>()
            {
                new Data(){Name="ParentFolder",Index="1"},
                new Data(){Name="Files",Index="1.33"},
                new Data(){Name="Folder17",Index="1.2"}
            };
            data.AddRange(arrayOut);

            PathResolver p = new PathResolver();
            var result = p.GetHangUpData(data);
            foreach (var item in result) 
            {
                foreach (var o in arrayOut)
                {
                    var eq = item.Equals(o);
                    Assert.IsTrue(eq);
                }
            }
        }
    }
}