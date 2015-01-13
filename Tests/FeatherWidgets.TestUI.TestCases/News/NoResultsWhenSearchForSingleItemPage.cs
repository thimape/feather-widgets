﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feather.Widgets.TestUI.Framework;
using FeatherWidgets.TestUI.TestCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatherWidgets.TestUI
{
    /// <summary>
    /// This is test class for NoResultsWhenSearchForSingleItemPage.
    /// </summary>
    [TestClass]
    public class NoResultsWhenSearchForSingleItemPage_ : FeatherTestCase
    {
        /// <summary>
        /// UI test NoResultsWhenSearchForSingleItemPage
        /// </summary>
        [TestMethod,
        Owner("Sitefinity Team 7"),
        TestCategory(FeatherTestCategories.PagesAndContent),
        TestCategory(FeatherTestCategories.NewsSelectors)]
        public void NoResultsWhenSearchForSingleItemPage()
        {
            BAT.Macros().NavigateTo().Pages();
            BAT.Wrappers().Backend().Pages().PagesWrapper().OpenPageZoneEditor(PageName);
            BATFeather.Wrappers().Backend().Pages().PageZoneEditorWrapper().EditWidget(WidgetName);
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerContentScreenWrapper().SingleItemSettingsTab();
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerContentScreenWrapper().SelectExistingPage();
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerContentScreenWrapper().ClickSelectButton();
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerContentScreenWrapper().SearchItemByTitle(SearchText);
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerContentScreenWrapper().WaitForItemsToAppear(SearchResultsCount);
            BATFeather.Wrappers().Backend().Widgets().WidgetDesignerContentScreenWrapper().NoItemsFound();
        }

        /// <summary>
        /// Performs Server Setup and prepare the system with needed data.
        /// </summary>
        protected override void ServerSetup()
        {
            BAT.Macros().User().EnsureAdminLoggedIn();
            BAT.Arrange(this.TestName).ExecuteSetUp();
        }

        /// <summary>
        /// Performs clean up and clears all data created by the test.
        /// </summary>
        protected override void ServerCleanup()
        {
            BAT.Arrange(this.TestName).ExecuteTearDown();
        }

        private const string PageName = "News";
        private const string WidgetName = "News";
        private const string SearchText = "FeatherPage";
        private const int SearchResultsCount = 0;
    }
}