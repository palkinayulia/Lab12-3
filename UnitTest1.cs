using ClassLibrary10Lab;
using Лабораторная_работа_12_3;
namespace Test12_3Lab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestConstructorTree()
        {
            MyTree<Watch> tree = new MyTree<Watch>(5);
            Assert.AreEqual(5, tree.Count);
        }

        [TestMethod]
        public void TestConstructorFindTree()
        {
            MyTree<Watch> tree = new MyTree<Watch>(3);
            tree.TransformToFindTree();
            Assert.AreEqual(3, tree.Count);
        }

        [TestMethod]
        public void TestCloneTree()
        {
            MyTree<Watch> tree = new MyTree<Watch>(5);
            MyTree<Watch> tree2 = tree.Clone();
            Assert.AreEqual(tree2.Count, tree.Count);
        }
    }
}