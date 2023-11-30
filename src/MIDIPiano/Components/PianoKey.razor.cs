using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using MIDIPiano.Models;

namespace MIDIPiano.Components;

public partial class PianoKey
{
	private string _cssClasses = string.Empty;

	[Parameter]
	public Tone? Tone { get; set; }

	[Parameter]
	public EventCallback<Tone> Clicked { get; set; }

	public bool Selected { get; private set; }

	protected override void OnInitialized()
		=> OverrideStyle();

	public void Select()
	{
		Selected = true;
		OverrideStyle();
	}

	public void DeSelect()
	{
		Selected = false;
		OverrideStyle();
	}

	private void OverrideStyle()
	{
		var classes = new List<string>();

		if (Tone?.IsGroupTone ?? false)
			classes.Add("piano-key-black");
		else
			classes.Add("piano-key");

		if (Selected)
			classes.Add("piano-key-selected");

		_cssClasses = string.Join(" ", classes);
		StateHasChanged();
	}
}