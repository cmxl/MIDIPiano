# MIDI Piano

This is a simple MIDI piano component for Blazor.<br />
It will use the [Web MIDI API](https://developer.mozilla.org/en-US/docs/Web/API/MIDIAccess) in the future.<br />
Currently it run on a custom notation format and mp3 samples.

_Initial idea and code from [@dominikz98](https://github.com/dominikz98)_

---

## Usage

* Add a project reference to `MIDIPiano` in your Blazor project.

* Add the following to your `index.html` file:

```html
<script src="_content/MIDIPiano/scripts/audio.js"></script>
```

* Add the following to your `_Imports.razor` file:

```html
@using MIDIPiano
@using MIDIPiano.Components
```

* Add the following to your razor page view:

```html
<Piano @ref="Piano" />
```

* Add the following to your razor page code:

```csharp
using MIDIPiano;
using MIDIPiano.Components;

public partial class MyRazorPage
{
	Piano Piano { get; set; }
	
	protected override void OnAfterRender(bool firstRender)
	{
		if (firstRender)
		{
			// this is just to demonstrate the usage of the component
			Piano.Song = MusicSheets.FadedByAlanWalker.MapToVm();
			Piano.Play();
		}
	}
}
```