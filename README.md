# Blazor.Teleport
Makes it easy to render a RenderFragment (part of a Component) outside of the current render tree. 
Use the `<Beam To="My.target">` component to "beam" its content to `<Materializer Name="My.target">`, 
no matter where in the render tree the Materializer is placed.

## Getting started
Add the reference to your project:
```powershell
Install-Package Blazor.Teleport
```

In `Startup.cs` in `ConfigureServices(...)` add a call to 
```csharp
services.AddTeleporter();
```

## Beaming content
Add
```html
<Materializer Name="Header" />
```
where you want other content to appear, for example somewhere in `MainLayout.razor`

In the pages
add 
```html
<Beam To="Header">
  <span>This is <b>my</b> headline.</span>
</Beam>
```
with differing content. When you run your project you will see the content of the `<Beam>` tags appear in the place of the `<Materializer>` tag.

## Multiple targets
You can have multiple `<Materializer>`s with different name, and each `<Beam>` tag with the same name will teleport it's content there.

### Multiple targets with same name
This seems to work, beamed content appears in every `<Materializer>` with the same name. I don't see a problem with this, but can't promise it will be supported forever.

## Omitting `<Beam>`
When you omit a `<Beam>` tag, nothing will be rendered to the corresponding `<Materializer>`. Even more, when a `<Beam>` is removed from the UI, it will clear the content of the `<Materializer>`, so old content won't stay on page.

## Duplicate `<Beam>` tags
When there are multiple `<Beam>` tags with the same target, the last one that gets rendered wins, the other content is overwritten.
