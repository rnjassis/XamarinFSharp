# XamarinFSharp blank application
Blank Xamarin.Forms project created from scratch to use 100% F# resources.

I created this project because Visual Studio is still unable to create Xamarin.Forms project in F#, only in C#

If you try to convert a C# project to F#, it'll leave many dependencies on that language.

So you can either download this project to start yours or follow the instructions below:

## How to create a Xamarin.Forms project in F#
1. Create a solution with the name of your choice
2. Right click on the solution and select Add -> New project
3. In Visual F#, select .Net Standard and give the same name as the Project. Make sure that the location of the project it's inside the solution
4. On this project, right-click on Dependencies and select Manage NuGet Packages and install Xamarin.Forms(by Microsoft)
Right-click on the project and select Add -> New Item
Since this is a F# project, it won't let you create a .xaml directly. So, in the name field, replace .fs to .xaml, in my case, App.xaml
5. Add the following in the xaml file
```
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="XamarinFSharp.AppContent">

    <StackLayout>
        <Label Text="Working"/>
    </StackLayout>
</ContentPage>
```

  Pay attencion to x:Class field

6. Rename Library.fs to App.xaml.fs (in my case) and replace the code for the following:

```
namespace XamarinFSharp

open Xamarin
open Xamarin.Forms
open Xamarin.Forms.Xaml

//is the same on x:Class on the .xaml file
type AppContent() = 
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<AppContent>)

type App() =
    inherit Application(MainPage = AppContent())
```
7. Right click on the solution and select Add -> New project. Under Visual F#, select Blank App (Android) and call it <name of the project>.Droid and make sure it's being created inside your solution.
8. Right click on the project and select Properties. On tab Application make sure it's using an installed Android compiler
9. Right click on the project and select Manage NuGet Packages and install Xamarin.Forms(by Microsoft). It'll install more additional libraries
10. Right click on the project and select Add -> Reference and add the F# project
11. Replace the code in MainActivity.fs to

```
namespace XamarinFSharp.Droid

open System

open Android.App
open Android.Content
open Android.Content.PM
open Android.Runtime
open Android.Views
open Android.Widget
open Android.OS
open Xamarin.Forms.Platform.Android

type Resources = XamarinFSharp.Droid.Resource

[<Activity (Label = "XamarinFSharp.Droid", Icon = "@mipmap/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = (ConfigChanges.ScreenSize ||| ConfigChanges.Orientation))>]
type MainActivity () =
    inherit FormsAppCompatActivity()

    override this.OnCreate (bundle) =
        FormsAppCompatActivity.TabLayoutResource <- Resources.Layout.Tabbar
        FormsAppCompatActivity.ToolbarResource <- Resources.Layout.Toolbar

        base.OnCreate (bundle)

        Xamarin.Forms.Forms.Init (this, bundle)

        this.LoadApplication (new XamarinFSharp.App())
```
12. Now you need to create three more files used for styling. Create a file in the Resources->values folder and call it "Styles.axml" and then add the following:

```
<?xml version="1.0" encoding="UTF-8"?>
<resources>
    <style name="MyTheme" parent="MyTheme.Base">
    </style>
    <!-- Base theme applied no matter what API -->
    <style name="MyTheme.Base" parent="Theme.AppCompat.Light.DarkActionBar">
        <!--If you are using revision 22.1 please use just windowNoTitle. Without android:-->
        <item name="windowNoTitle">true</item>
        <!--We will be using the toolbar so no need to show ActionBar-->
        <item name="windowActionBar">false</item>
        <!-- Set theme colors from http://www.google.com/design/spec/style/color.html#color-color-palette-->
        <!-- colorPrimary is used for the default action bar background -->
        <item name="colorPrimary">#2196F3</item>
        <!-- colorPrimaryDark is used for the status bar -->
        <item name="colorPrimaryDark">#1976D2</item>
        <!-- colorAccent is used as the default value for colorControlActivated
         which is used to tint widgets -->
        <item name="colorAccent">#FF4081</item>
        <!-- You can also set colorControlNormal, colorControlActivated
         colorControlHighlight and colorSwitchThumbNormal. -->
        <item name="windowActionModeOverlay">true</item>
        <item name="android:datePickerDialogTheme">@style/AppCompatDialogStyle</item>
    </style>
    <style name="AppCompatDialogStyle" parent="Theme.AppCompat.Light.Dialog">
        <item name="colorAccent">#FF4081</item>
    </style>
</resources>
```
13. Now on the folder Resources->layout, you will now create two files, one named "Tabbar.axml" having the code

```
<?xml version="1.0" encoding="utf-8"?>
<android.support.design.widget.TabLayout xmlns:android="http://schemas.android.com/apk/res/android" xmlns:app="http://schemas.android.com/apk/res-auto" android:id="@+id/sliding_tabs" android:layout_width="match_parent" android:layout_height="wrap_content" android:background="?attr/colorPrimary" android:theme="@style/ThemeOverlay.AppCompat.Dark.ActionBar" app:tabIndicatorColor="@android:color/white" app:tabGravity="fill" app:tabMode="fixed" />
```
and other file called "Toolbar.axml" with
```
<?xml version="1.0" encoding="UTF-8"?>
<android.support.v7.widget.Toolbar xmlns:android="http://schemas.android.com/apk/res/android" android:id="@+id/toolbar" android:layout_width="match_parent" android:layout_height="wrap_content" android:background="?attr/colorPrimary" android:theme="@style/ThemeOverlay.AppCompat.Dark.ActionBar" android:popupTheme="@style/ThemeOverlay.AppCompat.Light" />
```

14. Run your app as you normally would.
