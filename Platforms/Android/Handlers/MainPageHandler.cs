using AndroidX.ViewPager2.Widget;

using Microsoft.Maui.Handlers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedTabColorBug.Handlers.PlatformImplementations;

internal class MainPageHandler : TabbedViewHandler
{
	public MainPageHandler()
	{
		Mapper.AppendToMapping(nameof(TabbedPage.CurrentPage), this.BlockIfNeeded);
	}

	private void BlockIfNeeded(ITabbedViewHandler handler, ITabbedView view)
	{
		if (handler.PlatformView == null || handler.VirtualView == null)
		{
			return;
		}
		var virtualView = view as TabbedPage;
		// redirect taps on the second tab to the first tab
		if (((NavigationPage)virtualView.CurrentPage).Title == "Page 2")
		{
			// this should set the selected tab highlight on the first tab but it does not
			var platformView = (handler.PlatformView) as ViewPager2;
			virtualView.CurrentPage = virtualView.Children[0];
			virtualView.SelectedItem = virtualView.Children[0];
			platformView.CurrentItem = 0;
			platformView.SetCurrentItem(0, false);
			platformView.PerformClick();
		}
	}
}
