namespace XamarinFSharp

open Xamarin.Forms
open Xamarin.Forms.Xaml

type MPage() =
    inherit ContentPage()
    let _ = base.LoadFromXaml(typeof<MPage>)

module MPage = 
    let Page = MPage()