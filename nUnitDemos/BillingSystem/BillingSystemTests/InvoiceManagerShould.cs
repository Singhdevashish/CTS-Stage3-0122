using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using Moq;
using BillingSystem;
namespace BillingSystemTests
{
    [TestFixture]
    public class InvoiceManagerShould
    {
        private InvoiceManager SUT;
        private Mock<IEmailSender> EmailSenderMock;
        [SetUp]
        public void Init()
        {
            EmailSenderMock = new Mock<IEmailSender>();
        }

        [Test]
        public void Confirm_Invoice()
        {
            SUT = new InvoiceManager(EmailSenderMock.Object);

            var invoice = new Invoice { InvoiceId = 101 };
            var customer = new Customer { Email = "techiesyed@outlook.com" };

            var actual = SUT.ConfirmInvoice(invoice, customer);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Confirm_Invoice_Using_String_Email()
        {
            EmailSenderMock.Setup(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            SUT = new InvoiceManager(EmailSenderMock.Object);

            var invoice = new Invoice { InvoiceId = 101 };
            var customer = new Customer { Email = "techiesyed@outlook.com" };

            var actual = SUT.ConfirmInvoice(invoice, customer);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Confirm_Invoice_Calls_SendEmail_Only_Once()
        {
            EmailSenderMock.Setup(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            SUT = new InvoiceManager(EmailSenderMock.Object);

            var invoice = new Invoice { InvoiceId = 101 };
            var customer = new Customer { Email = "techiesyed@outlook.com" };

            var actual = SUT.ConfirmInvoice(invoice, customer);
            EmailSenderMock.Verify(m => m.SendEmail(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
            Assert.That(actual, Is.True);
        }
    }
}
