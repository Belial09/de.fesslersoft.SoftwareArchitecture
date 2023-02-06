using System;
using System.Linq;
using NUnit.Framework;
using Moq;
using _01_strategy_pattern;
using _01_strategy_pattern.interfaces;
using _01_strategy_pattern.entities.PaymentMethods;
using _01_strategy_pattern.entities;

namespace _01_strategy_pattern_tests
{
    [TestFixture]
    public class ShoppingCartTests
    {
        private ShoppingCart _shoppingCart;
        private Mock<IItem> _mockItem;
        private Mock<IPaymentMethod> _mockPaymentMethod;

        [SetUp]
        public void SetUp()
        {
            _shoppingCart = new ShoppingCart();
            _mockItem = new Mock<IItem>();
            _mockPaymentMethod = new Mock<IPaymentMethod>();

            _mockItem.Setup(x => x.Identifier).Returns(Guid.NewGuid());
            _mockItem.Setup(x => x.Name).Returns("Item 1");

            _mockPaymentMethod.Setup(x => x.getPaymentMethodName()).Returns("Paypal");
        }

        [Test]
        public void AddItem_ItemAndPaymentMethod_ItemAddedSuccessfully()
        {
            // Act
            _shoppingCart.AddItem(_mockItem.Object, _mockPaymentMethod.Object);

            // Assert
            Assert.IsTrue(_shoppingCart._items.Count == 1);
        }

        [Test]
        public void GetItem_ValidItemIdentifier_ReturnsMatchingItem()
        {
            // Arrange
            var expectedIdentifier = _mockItem.Object.Identifier;
            _shoppingCart.AddItem(_mockItem.Object, _mockPaymentMethod.Object);

            // Act
            var actualItem = _shoppingCart.getItem(expectedIdentifier);

            // Assert
            Assert.IsNotNull(actualItem);
            Assert.AreEqual(expectedIdentifier, actualItem.Item1.Identifier);
        }

        [Test]
        public void GetItem_InvalidItemIdentifier_ReturnsNull()
        {
            // Act
            var actualItem = _shoppingCart.getItem(Guid.NewGuid());

            // Assert
            Assert.IsNull(actualItem);
        }

        [Test]
        public void RemoveItem_ValidItem_ItemRemovedSuccessfully()
        {
            // Arrange
            var expectedItem = new Tuple<IItem, IPaymentMethod>(_mockItem.Object, _mockPaymentMethod.Object);
            _shoppingCart.AddItem(_mockItem.Object, _mockPaymentMethod.Object);

            // Act
            _shoppingCart.removeItem(expectedItem);

            // Assert
            Assert.IsTrue(_shoppingCart._items.Count == 0);
        }

        [Test]
        public void RemoveItem_InvalidItem_NoItemRemoved()
        {
            //Arrange
            var cart = new ShoppingCart();
            var item = new Item("apple");
            var paymentMethod = new PayPal();
            var itemTuple = new Tuple<IItem, IPaymentMethod>(item, paymentMethod);

            //Act
            cart.removeItem(itemTuple);

            //Assert
            Assert.That(cart._items.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestRemoveItem()
        {
            //Arrange
            var item = new Mock<IItem>();
            item.SetupGet(i => i.Identifier).Returns(Guid.NewGuid());
            item.SetupGet(i => i.Name).Returns("item1");
            var paymentMethod = new Mock<IPaymentMethod>();
            paymentMethod.Setup(pm => pm.getPaymentMethodName()).Returns("PayPal");
            var cart = new ShoppingCart();
            cart.AddItem(item.Object, paymentMethod.Object);
            cart.removeItem(new Tuple<IItem, IPaymentMethod>(item.Object, paymentMethod.Object));
            //Assert
            Assert.IsFalse(cart._items.Any(i => i.Item1.Identifier == item.Object.Identifier));
        }

        [Test]
        public void TestCheckout()
        {
            //Arrange
            var item1 = new Mock<IItem>();
            item1.SetupGet(i => i.Identifier).Returns(Guid.NewGuid());
            item1.SetupGet(i => i.Name).Returns("item1");
            var paymentMethod1 = new Mock<IPaymentMethod>();
            paymentMethod1.Setup(pm => pm.getPaymentMethodName()).Returns("PayPal");

            var item2 = new Mock<IItem>();
            item2.SetupGet(i => i.Identifier).Returns(Guid.NewGuid());
            item2.SetupGet(i => i.Name).Returns("item2");
            var paymentMethod2 = new Mock<IPaymentMethod>();
            paymentMethod2.Setup(pm => pm.getPaymentMethodName()).Returns("Klarna");

            var cart = new ShoppingCart();
            cart.AddItem(item1.Object, paymentMethod1.Object);
            cart.AddItem(item2.Object, paymentMethod2.Object);

            //Act
            cart.Checkout();

            //Assert
            Assert.IsTrue(cart._items.Count == 2);
        }
    }
}