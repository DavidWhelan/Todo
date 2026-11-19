module AutoLoader

open Fable.Core
open Fable.Core.JsInterop
open Browser
open Browser.Types
open Firelight
open type Firelight.Lit
open MutationObserver
open Interop

let inline defineComponent<'T when 'T :> LitElement> () =
    let tagName = createTagName<'T> ()
    Lit.defineElement<'T> tagName

let capitalize (s: string) =
    if s.Length = 0 then s
    else if s.Length = 1 then s.ToUpper()
    else s[0].ToString().ToUpper() + s.Substring(1)

let register tagName : JS.Promise<unit> =
    let element = window.customElements.get tagName

    match element with
    | Some s -> JS.Constructors.Promise.resolve ()
    | None ->
        let compName = tagName.Split('-')[1..] |> Array.map capitalize |> String.concat ""

        JsInterop.importDynamic $"{window.location.origin}/components/{compName}.fs?import"
        |> Promise.catch (fun e -> console.error ($"Failed to load component {compName}: {e}"))

let discover (root: Element) =
    let tagList = root.querySelectorAll (":not(:defined)")

    let promise =
        seq { for i in 0 .. tagList.length - 1 -> tagList.Item(i).tagName.ToLower() }
        |> Seq.distinct
        |> Seq.filter (fun tag -> tag.StartsWith("al-"))
        |> Seq.map register
        |> Promise.allSettled

    promise
    |> Promise.catchEnd (fun e -> console.error ($"Failed to discover components: {e}"))

let options = MutationObserverOptions(subtree = true, childList = true)

let callback (mutations: MutationRecord array) (observer: MutationObserver) =
    mutations
    |> Array.iter (fun mutation ->
        match mutation.target with
        | :? Element as element -> discover element |> ignore
        | _ -> ())

let observer = MutationObserver(callback)

let startLoader () =
    discover (document.documentElement) |> ignore
    observer.observe (document, options)

let stopLoader () = observer.disconnect ()

startLoader ()
