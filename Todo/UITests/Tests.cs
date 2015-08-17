using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Todo.UITests
{
    [TestFixture (Platform.Android)]
    [TestFixture (Platform.iOS)]
    public class Tests
    {
        private IApp app;
        private readonly Platform platform;

        public Tests (Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest ()
        {
            this.app = AppInitializer.StartApp (platform);
        }

        [Test]
        public void AddItemWithoutName()
        {
            // Arrange

            // Act
            app.Tap (c => c.Marked ("Add"));
            app.Tap (c => c.Marked ("Save"));
            var results = app.WaitForElement (c => c.Marked ("Validation Error"));
            app.Screenshot ("Validation Error - Please enter a name");

            // Assert
            Assert.IsTrue(results.Any());
        }

        [Test]
        public void AddItem()
        {
            // Arrange

            // Act
            app.Tap (c => c.Marked ("Add"));
            app.EnterText (c => c.Class (GetClassName ("EntryEditText", "UITextField")), "Buy car");
            app.Screenshot ("Add Todo - Buy car entered");
            app.Tap (c => c.Marked ("Save"));
            var results = app.WaitForElement (c => c.Marked ("Buy car"));
            app.Screenshot ("Todo List - Buy car added");

            // Assert
            Assert.IsTrue(results.Any());
        }
    
        private string GetClassName(string android, string iOS)
        {
            switch (this.platform) {
                case Platform.Android:
                    return android;
            default:
                    return iOS;
            }
        }
    }
}