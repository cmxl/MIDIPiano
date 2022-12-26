using Microsoft.AspNetCore.Components;

namespace dominikz.dev.Components.TabControl;

public partial class TabPage
{
    [CascadingParameter] protected TabControl? Parent { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }

    [Parameter] public int Id { get; set; }
    
    [Parameter] public string? Text { get; set; }

    protected override void OnInitialized()
    {
        if (Parent == null)
            throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");

        base.OnInitialized();
        Parent.AddPage(this);
    }
}