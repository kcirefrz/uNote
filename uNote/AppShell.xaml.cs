﻿namespace uNote;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		SetNavBarIsVisible(this, false);
	}
}
