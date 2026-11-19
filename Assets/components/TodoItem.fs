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
                .completed {
                    color: var(--green-6);
                    background-color: var(--green-0);
                    border: 1px solid var(--green-1);
                    text-shadow: 0 1px 0 var(--gree-2);
                    margin-right: 10px;

                    &:hover {
                        background-color: var(--green-1);
                    }
                }
                .not-completed {
                    margin-right: 10px;
                }
                .label {
                    font: var(--font-system-ui)
                }
            """

    member val label = "Example Todo" with get, set
    member val completed = false with get, set


    override this.render() =

        view {
            if this.completed then
                button {
                    class' "completed"
                    rawHtml "&#9745;"
                }
            else
                button {
                    class' "not-completed"
                    rawHtml "&#9744"
                }

            span {
                class' "label"
                $"{this.label}"
            }
        }

defineComponent<TodoItem> ()
