# SKOR.UI
UI Controls for Xamarin.Forms
# Usage
## Xamarin.Forms
Install Skor.UI nuget
[Skor.Controls](https://www.nuget.org/packages/Skor.Controls/)
## Android
Add new line before LoadApplication in MainActivity
```csharp
Skor.Controls.Droid.Controls.Init();
```
## iOS
Add new line before LoadApplication in AppDelegate
```csharp
Skor.Controls.Droid.Controls.Init();
```
## Example
```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage ...
             xmlns:controls="clr-namespace:Skor.Controls;assembly=Skor.Controls"...>

    <StackLayout Padding="32">
        <controls:GradientButton Text="JShine"
                                 HorizontalOptions="FillAndExpand"
                                 HeightRequest="48"
                                 WidthRequest="100"
                                 TextColor="White"
                                 CornerRadius="12"
                                 Image="test.jpg"
                                 StartColor="#12c2e9"
                                 CenterColor="#c471ed"
                                 EndColor="#f64f59" />
        <controls:GradientButton Text="Memarian"
                                 Image="test.jpg"
                                 CornerRadius="12"
                                 HorizontalOptions="FillAndExpand"
                                 HeightRequest="48"
                                 WidthRequest="100"
                                 TextColor="White"
                                 StartColor="#aa4b6b"
                                 CenterColor="#6b6b83"
                                 EndColor="#3b8d99" />
        <controls:GradientButton Text="Cool sky"
                                 Image="test.jpg"
                                 CornerRadius="24"
                                 HorizontalOptions="FillAndExpand"
                                 HeightRequest="48"
                                 WidthRequest="100"
                                 TextColor="White"
                                 StartColor="#2980B9"
                                 CenterColor="#6DD5FA"
                                 EndColor="#FFFFFF" />
        <controls:GradientButton Text="Green and blue"
                                 Image="test.jpg"
                                 CornerRadius="24"
                                 HorizontalOptions="FillAndExpand"
                                 HeightRequest="48"
                                 WidthRequest="100"
                                 TextColor="White"
                                 StartColor="#c2e59c"
                                 EndColor="#64b3f4" />
    </StackLayout>

</ContentPage>

```
