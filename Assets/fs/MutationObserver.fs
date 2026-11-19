module MutationObserver

open Fable.Core
open Browser.Types

[<AllowNullLiteral>]
type MutationRecord =
    abstract addedNodes: NodeList with get
    abstract attributName: string option with get
    abstract attributeNamespace: string option with get
    abstract nextSibling: Node option with get
    abstract oldValue: string option with get
    abstract previousSibling: Node option with get
    abstract removedNodes: NodeList with get
    abstract target: Node with get

    [<Emit("$0.type")>]
    abstract recordType: string with get

[<AllowNullLiteral>]
type MutationObserverOptions
    [<ParamObject; Emit("$0")>]
    (
        ?subtree: bool,
        ?childList: bool,
        ?attributes: bool,
        ?attributesFilter: string[],
        ?attributesOldValue: bool,
        ?characterData: bool,
        ?characterDataOldValue: bool
    ) =
    member val subtree: bool option = jsNative with get, set
    member val childList: bool option = jsNative with get, set
    member val attributes: bool option = jsNative with get, set
    member val attributeFilter: string[] option = jsNative with get, set
    member val attributeOldValue: bool option = jsNative with get, set
    member val characterData: bool option = jsNative with get, set
    member val characterDataOldValue: bool option = jsNative with get, set


[<AllowNullLiteral>]
[<Global>]
type MutationObserver(callback: MutationRecord[] -> MutationObserver -> unit) =

    member _.disconnect() : unit = jsNative

    member _.observe(target: Node, options: MutationObserverOptions) : unit = jsNative

    member _.takeRecords() : MutationRecord[] = jsNative
