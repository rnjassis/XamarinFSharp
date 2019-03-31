namespace XamarinFSharp

open Xamarin
open Xamarin.Forms
open Xamarin.Forms.Xaml

type AppContent() =
    inherit ContentPage()

    let _ = base.LoadFromXaml(typeof<AppContent>)

type App() =
    inherit Application(MainPage = AppContent())