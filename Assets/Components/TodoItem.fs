[<AutoOpen>]
module TodoItem

open Fable.Core
open Browser.Types
open Firelight
open type Firelight.Lit
open Firelight.Html
open AutoLoader

[<AttachMembers>]
type TodoItem() =
    inherit LitElement()

    // Changing a reactive property re-renders the component.
    static member properties =
        PropertyDeclarations.create
            [ "label", PropertyDeclaration<string>()
              "completed", PropertyDeclaration<bool>() ]

    // Styles live in the component's shadow DOM, so they apply only to this component.
    static member styles =
        css
            $$"""
                
            """

    member val label = "Example Todo" with get, set
    member val completed = false with get, set


    override this.render() =

        view {
            if this.completed then
                span {
                    class' "completed"
                    rawHtml "&#9745;"
                }
            else
                span {
                    class' "not-completed"
                    rawHtml "&#9744"
                }

            span {
                class' "label"
                $"{this.label}+"
            }
        }

defineComponent<TodoItem> ()
