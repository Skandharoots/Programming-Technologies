using Presentation.ViewModel;

namespace PresentationTest
{
    [TestClass]
    public class ClientItemViewModelTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            ClientItemViewModel viewModel = new ClientItemViewModel(10, "Marek", "Kopania");

            Assert.AreEqual(10, viewModel.Id);
            Assert.AreEqual("Marek", viewModel.Name);
            Assert.AreEqual("Kopania", viewModel.Surname);
        }

        [TestMethod]
        public void CanUpdateTest()
        {
            ClientItemViewModel viewModel = new ClientItemViewModel(20, "Marek", "Kopania");

            Assert.IsTrue(viewModel.CanUpdate);
        }

        [TestMethod]
        public void CannotUpdateTest()
        {
            ClientItemViewModel viewModel = new ClientItemViewModel(20, "Marek", "Kopania");
            viewModel.Name = null;
            viewModel.Surname = null;

            Assert.IsFalse(viewModel.CanUpdate);
        }
    }
}