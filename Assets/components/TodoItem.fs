[<AutoOpen>]
module TodoItem

open Fable.Core
open Browser
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
                :host {
                    display: block;
                    margin-bottom: var(--size-2);
                }
                button {
                    margin-right: var(--size-fluid-2);
                    font: var(--font-system-ui)
                }
                .completed {
                    color: var(--green-6);
                    background-color: var(--green-0);
                    border: 1px solid var(--green-1);
                    text-shadow: 0 1px 0 var(--green-2);
                    
                    &:hover {
                        background-color: var(--green-1);
                    }
                    &:active {
                        background-color: var(--green-2);
                    }
                }
                .not-completed {
                    color: var(--red-6);
                    background-color: var(--red-0);
                    border: 1px solid var(--red-1);
                    text-shadow: 0 1px 0 var(--red-2);

                    &:hover {
                        background-color: var(--red-1);
                    }
                    &:active {
                        background-color: var(--red-2);
                    }
                }
                .label {
                    font: var(--font-system-ui)
                }
            """

    member val label = "Example Todo" with get, set
    member val completed = false with get, set


    override this.render() =

        view {
            div {
                if this.completed then
                    button {
                        class' "completed"
                        rawHtml "&#9745;"
                        onClick (fun _ -> console.log ($"{this.label} was clicked"))
                    }
                else
                    button {
                        class' "not-completed"
                        rawHtml "&#9744"
                        onClick (fun _ -> console.log ($"{this.label} was clicked"))
                    }

                span {
                    class' "label"
                    $"{this.label}"
                }
            }
        }

defineComponent<TodoItem> ()
