﻿using DevIn.Common.RazorLib.TreeViews.Models;
using Microsoft.AspNetCore.Components;

namespace DevIn.Common.RazorLib.TreeViews.Displays.Utils;

public partial class TreeViewAdhocDisplay : ComponentBase
{
    [Parameter, EditorRequired]
    public TreeViewNoType TreeViewNoTypeAdhoc { get; set; } = null!;
}