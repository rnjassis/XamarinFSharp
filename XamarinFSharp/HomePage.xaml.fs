namespace XamarinFSharp

open Xamarin.Forms.Xaml
open Xamarin.Forms

type HomePage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<MPage>)