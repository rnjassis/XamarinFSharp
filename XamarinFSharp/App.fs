namespace XamarinFSharp

open Xamarin
open Xamarin.Forms
open Xamarin.Forms.Xaml

type RootPage()=
    inherit MasterDetailPage()

type App() =
    inherit Application()
    let menuPage = new MPage()
    let homePage = new HomePage()
    let rootPage = new RootPage()
    do
        let navigationPage = new NavigationPage(homePage)
        rootPage.Master <- menuPage
        rootPage.Detail <- navigationPage
        base.MainPage <- rootPage