using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace CheckMockingGenericInterfaces
{

    public interface IWhatever
    {
        int DoSomething(int x);
    }

    public interface IWhateverGenericMethod
    {
        int DoSomethingA(int x);
        int DoSomethingB<T>(T x);
    }

    public class Sut
    {
        IWhatever blabla;

        public Sut(IWhatever b)
        {
            blabla = b;
        }

        public int ComeOn(int y)
        {
            return blabla.DoSomething(y);
        }
    }


    public class Sut2
    {
        IWhateverGenericMethod blabla;

        public Sut2(IWhateverGenericMethod b)
        {
            blabla = b;
        }

        public int ComeOn(int y)
        {
            return blabla.DoSomethingA(y);
        }
    }

    public class Class1
    {
        [Test]
        public void TestOrdinaryInterface()
        {
            var mock = new Mock<IWhateverGenericMethod>();
            mock.Setup(o => o.DoSomethingA(It.IsAny<int>())).Returns(42);

            var sut = new Sut2(mock.Object);

            var res = sut.ComeOn(2);

            Assert.That(res, Is.EqualTo(42));
        }


        [Test]
        public void TestGenericMethodInterface()
        {
            var mock = new Mock<IWhateverGenericMethod>();
            mock.Setup(o => o.DoSomethingA(It.IsAny<int>())).Returns(42);

            var sut = new Sut2(mock.Object);

            var res = sut.ComeOn(2);

            Assert.That(res, Is.EqualTo(42));
        }
    }
}
