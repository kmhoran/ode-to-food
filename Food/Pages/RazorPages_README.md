
﻿# Razor Pages

Razor pages are a slimed down feature .net core provides for rendering HTML. It does not require the overhead of the MVC.

By convention, Razor Pages exist in the *Pages/* directory.

### Naming

Razor page names are signigicant as they will form part of the resulting URL. When a request comes in for a Razor Page, the MVC will look for the specified name in the *Pages/* directory
(eg. *~/myPage* => myPage.cshtml)

### The Page
**@page** is the Razor syntax that makes a CSHTML file into a razor page


### _ViewImports
Just like normal views, Razor Pages can include a _ViewImports.cshtml for shared imports and view tools
